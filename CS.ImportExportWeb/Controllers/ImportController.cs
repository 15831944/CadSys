﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CS.Excel;
using CS.EF;
using CS.Data.Entities;
using CS.Data.Mappers;
using CS.Data.DTO.Excel;
using CS.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Caly.Common;
using CS.Services;
using System.Diagnostics;

namespace CS.ImportExportAPI.Controllers
{
    public class ImportController : Controller
    {
        CadSysContext context;
        IExcelConfigurationRepo excelConfiguration;
        IRepo repo;
        IFileRepo dXFRepo;
        ServiceBuilder serviceBuilder;

        public ImportController(CadSysContext _context, IRepo _repo, IExcelConfigurationRepo _excelConfiguration, ServiceBuilder _serviceBuilder)
        {
            context = _context;
            repo = _repo;
            excelConfiguration = _excelConfiguration;
            serviceBuilder = _serviceBuilder;
            dXFRepo = (IFileRepo)serviceBuilder.GetService("DXFRepo");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IEnumerable<IFormFile> files)
        {

            files = Request.Form.Files.Where(x => x != null);

            IEnumerable<IFormFile> excelFiles = OrderUploadedExcelFiles(files.Where(x => x.FileName.Contains(".xls", StringComparison.InvariantCultureIgnoreCase)));

            IEnumerable<IFormFile> dxfFiles = files.Where(x => x.FileName.Contains(".dxf", StringComparison.InvariantCultureIgnoreCase));

            Prepare(!excelFiles.Any() && dxfFiles.Any());

            await CycleExcels(excelFiles);

            if (excelFiles.Count()>0)
                CyclePostExcel(context);


            await CycleDXFs(dxfFiles);


            if (files.Any())
            {
                return new RedirectToActionResult("download", "home", null);//"~/home/download");
            }

            return Ok("Mai baga 0 fisa");
        }



        async Task CycleExcels(IEnumerable<IFormFile> fileCollection)
        {
            foreach (var file in fileCollection)
            {
                if (file != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);

                        if (file.FileName.Contains("Proprietar", StringComparison.InvariantCultureIgnoreCase))
                        {
                            await CycleProprietari(file.FileName, stream);
                        }

                        if (file.FileName.Contains("Acte", StringComparison.InvariantCultureIgnoreCase))
                        {
                            await CycleActe(file.FileName, stream);
                        }

                        if (file.FileName.Contains("Parcel", StringComparison.InvariantCultureIgnoreCase))
                        {
                            await CycleParcele(file.FileName, stream);
                        }

                        if (file.FileName.Contains("Centraliz", StringComparison.InvariantCultureIgnoreCase))
                        {
                            await CycleCentralizator(file.FileName, stream);
                        }

                        context.SaveChanges();
                    }
                }
            }
        }

        async Task CycleDXFs(IEnumerable<IFormFile> fileCollection)
        {
            foreach (var file in fileCollection)
            {
                if (file != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        await dXFRepo.Store(stream, file.FileName);
                    }
                }
            }
        }


        //aici facem niste post procesari: Titlu in Parcela, Pozitia pe InscriereDetaliu
        public static void CyclePostExcel(CadSysContext context)
        {
            object locker = new object();
            //pozitia CF
            context.Imobile.Include(x => x.InscrieriDetaliu).ToList().ForEach(i =>
            {

                int idxPt2 = 1;
                int idxPt3 = 1;
                try
                {
                    foreach (var idPt2 in i.InscrieriDetaliu.Where(x => x.ParteaCF == 2))
                    {
                        idPt2.Pozitia = idxPt2;
                        idxPt2++;
                        context.InscrieriDetaliu.Update(idPt2);
                    }

                    foreach (var idPt3 in i.InscrieriDetaliu.Where(x => x.ParteaCF == 3))
                    {
                        idPt3.Pozitia = idxPt3;
                        idxPt3++;
                        context.InscrieriDetaliu.Update(idPt3);
                    }
                }
                catch(Exception ex)
                {
                    var q = ex.Message;

                }
                
            });

            

            /*var x = context.ActeProprietate.ToList().Where(x => x.TipActProprietateId == 1).ToList();

            var y = context.InscrieriActe.ToList().Join(x, x1 => (int)x1.ActProprietateId, x2 => x2.Id, (x1, x2) => new { IdInscriere = x1.InscriereDetaliuId, NrTitlu = x2.Numar }).ToList();

            var z = context.InscrieriDetaliu.ToList().Join(y, x1 => x1.Id, x2 => x2.IdInscriere, (x1, x2) => new { IdImobil = x1.ImobilReferintaId, NrTitlu = x2.NrTitlu }).ToList();

            foreach(var i in z)
            {
                var parcela = context.Parcele.FirstOrDefault(p => p.ImobilId == i.IdImobil);
                if (parcela!=null)
                {
                    parcela.NumarTitlu = i.NrTitlu;
                    lock (locker)
                    {
                        context.Parcele.Update(parcela);
                    }
                } 
            }*/

           

            //nrtitlu in parcela
           context.Imobile.Include(x => x.InscrieriDetaliu)
                                                .ThenInclude(y => y.InscrieriActe)
                                                    .ThenInclude(z => z.ActProprietate)
                                                    .Include(x=>x.Parcele)
                   .ToList().ForEach(i =>
            {
                try
                {
                    var titlu = i.InscrieriDetaliu.SelectMany(x => x.InscrieriActe.Where(q => q.ActProprietate != null)).Select(w => w.ActProprietate).FirstOrDefault(y => y.TipActProprietateId ==1);
                    if (titlu != null)
                    {
                        foreach (var p in i.Parcele)
                        {
                            p.NumarTitlu = titlu.Numar;
                            lock (locker)
                            {
                                context.Parcele.Update(p);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var q = ex.Message;
                }
            });

            //sterg inscrierile fara propr care nu sunt notari (gen cele care au doar titluri)
            context.InscrieriDetaliu.RemoveRange(context.InscrieriDetaliu.Include(y => y.InscrieriProprietari).ToList().Where(x => x.InscrieriProprietari.Count == 0 && x.TipInscriereId!=317));
            context.SaveChanges();
        }



        async Task CycleCentralizator(string fileName, MemoryStream stream)
        {
            var x = await Importer.GetGroupedDTOs<OutputInscriereDetaliu>(stream, fileName, new ImportConfig(), excelConfiguration);

            context.SaveChanges();

            var moduriDobandire = new ConcurrentBag<ModDobandire>(context.ModuriDobandire);
            var tipuriDrept = new ConcurrentBag<TipDrept>(context.TipuriDrept);
            var tipuriInscriere = new ConcurrentBag<TipInscriere>(context.TipuriInscriere);

            x.ForEach(y =>
            {
                try
                {
                    foreach (var iD in InscriereDetaliuMapperExtensions.FromDTO(y, context.Proprietari.Select(m => m), context.ActeProprietate.Include(w => w.TipActProprietate).ThenInclude(w => w.TipDrept), context.Parcele.Include(w => w.Imobil), moduriDobandire, tipuriDrept, tipuriInscriere))
                    {
                        if (iD.TipInscriereId == tipuriInscriere.FirstOrDefault(z => z.Denumire.Equals("NOTATION", StringComparison.InvariantCultureIgnoreCase)).Id)
                        {
                            iD.TipDreptId = null;
                            iD.ModDobandireId = null;
                            iD.Cota = string.Empty;
                            iD.Moneda = string.Empty;
                            iD.Valoarea = string.Empty;
                            iD.DetaliiDrept = string.Empty;
                        }

                        context.InscrieriDetaliu.AddAsync(iD);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            });
        }

        async Task CycleParcele(string fileName, MemoryStream stream)
        {
            var x = await Importer.GetDTOs<OutputParcela>(stream, fileName, new ImportConfig(), excelConfiguration);

            object locker = new object();
            var tarlale = new ConcurrentBag<Tarla>(context.Tarlale);


            Parallel.ForEach(x, y =>
            {
                var z = new Parcela();
                var i = new Imobil();
                var a = new Adresa()
                {
                    SIRSUP = 180019,
                    SIRUTA = 180019,
                    Intravilan = false
                };

                i.Parcele.Add(z);
                i.Adresa = a;

                lock (locker)
                {
                    context.Imobile.Add(i);
                    //context.Imobile.Add(i);
                }

                z.FromDTO(y, tarlale);
                //z.Imobil = new Imobil();
                //i.Parcele.Add(z);
            });
        }

        async Task CycleActe(string fileName, MemoryStream stream)
        {
            var x = await Importer.GetDTOs<OutputActProprietate>(stream, fileName, new ImportConfig(), excelConfiguration);

            object locker = new object();
            var tipuriActe = new ConcurrentBag<TipActProprietate>(context.TipuriActProprietate);


            Parallel.ForEach(x, y =>
            {
                var z = new ActProprietate();

                lock (locker)
                {
                    context.ActeProprietate.Add(z);
                }

                z.FromDTO(y, tipuriActe);
            });
        }

        async Task CycleProprietari(string fileName, MemoryStream stream)
        {
            var judeteAllInclussive = new ConcurrentBag<Judet>(context.Judete.Include(z => z.UATs).ThenInclude(w => w.Localitati));

            var x = await Importer.GetDTOs<OutputProprietarAdresa>(stream, fileName, new ImportConfig(), excelConfiguration);

            IAddressParser addressParser = (IAddressParser)serviceBuilder.GetService("AddressParser");
            var addressMatcher = (IMatcher)serviceBuilder.GetService("AddressMatcher");
            var matchProcessor = (IMatchProcessor)serviceBuilder.GetService("AddressMatchProcessor");

            object locker = new object();

            Parallel.ForEach(x, y =>
             {
                 var z = new Proprietar();

                 lock (locker)
                 {
                     context.Proprietari.Add(z);
                 }

                 z.FromDTO(y);
                 z.Adresa.FromDTO(y, judeteAllInclussive, addressParser, addressMatcher, matchProcessor);
                 z.Adresa.Intravilan = true;
             });
        }


        /// <summary>
        /// Daca s-au uploadat numai dxf-uri nu curatam baza
        /// </summary>
        /// <param name="dxfOnly">If set to <c>true</c> dxf only.</param>
        private void Prepare(bool dxfOnly = false)
        {
            if (!dxfOnly)
            {
                excelConfiguration.ClearAll();
                repo.ClearDatabase();
            }

            dXFRepo.ClearAll();
        }

        /// <summary>
        /// Centralizator vine ultimul
        /// </summary>
        /// <returns>The uploaded files.</returns>
        private IEnumerable<IFormFile> OrderUploadedExcelFiles(IEnumerable<IFormFile> files)
        {
            var fileCollection = new List<IFormFile>();

            fileCollection.AddRange(files.Where(x => !x.FileName.Contains("centraliz", StringComparison.InvariantCultureIgnoreCase)));
            fileCollection.AddRange(files.Where(x => x.FileName.Contains("centraliz", StringComparison.InvariantCultureIgnoreCase)));

            return fileCollection;
        }
    }
}
