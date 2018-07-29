﻿using CS.Data.Entities;
using CS.Data.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CS.EF
{
    public class CadSysContext : DbContext
    {
        public CadSysContext(DbContextOptions<CadSysContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Proprietar> Proprietari { get; set; }
        public DbSet<ActProprietate> ActeProprietate { get; set; }
        public DbSet<Parcela> Parcele { get; set; }
        public DbSet<Tarla> Tarlale { get; set; }
        public DbSet<TipActProprietate> TipuriActProprietate { get; set; }
        public DbSet<Inscriere> Inscrieri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipActProprietate>().HasData(
                new TipActProprietate { Id = 1, Denumire = "Titlu Proptietate" },
                new TipActProprietate { Id = 2, Denumire = "Contract de Vanzare Cumparare" },
                new TipActProprietate { Id = 3, Denumire = "Sentinta Civila" },
                new TipActProprietate { Id = 4, Denumire = "Certificat de Mostenitor" },
                new TipActProprietate { Id = 5, Denumire = "Contract de Donatie" },
                new TipActProprietate { Id = 6, Denumire = "Contract de Vanzare Cumparare cu Clauza de Intretinere" },
                new TipActProprietate { Id = 7, Denumire = "Contract de Partaj Voluntar" },
                new TipActProprietate { Id = 8, Denumire = "Act de Partaj Voluntar" },
                new TipActProprietate { Id = 9, Denumire = "Contract de Partaj Imobiliar" },
                new TipActProprietate { Id = 10, Denumire = "Act de Donatie" }
                );

            modelBuilder.Entity<Judet>().HasData(
                new Judet { Id = 1, Denumire = "Ialomita" }
            );

            modelBuilder.Entity<UAT>().HasData(
                new UAT { Id = 1, JudetId=1, Denumire = "Sarateni" }
            );

            modelBuilder.Entity<Localitate>().HasData(
                new Localitate { Id = 1, Denumire = "Sarateni" }
            );

            modelBuilder.Entity<Tarla>().HasData(
                new Tarla { Id = 1, UATId = 1, Denumire = "100" },
                new Tarla { Id = 2, UATId = 1, Denumire = "102,1" },
                new Tarla { Id = 3, UATId = 1, Denumire = "102,2" },
                new Tarla { Id = 4, UATId = 1, Denumire = "104" },
                new Tarla { Id = 5, UATId = 1, Denumire = "104,1" },
                new Tarla { Id = 6, UATId = 1, Denumire = "104,2" },
                new Tarla { Id = 7, UATId = 1, Denumire = "105,2" },
                new Tarla { Id = 8, UATId = 1, Denumire = "105,3" },
                new Tarla { Id = 9, UATId = 1, Denumire = "105,6" },
                new Tarla { Id = 10, UATId = 1, Denumire = "110" },
                new Tarla { Id = 11, UATId = 1, Denumire = "112,1" },
                new Tarla { Id = 12, UATId = 1, Denumire = "112,2" },
                new Tarla { Id = 13, UATId = 1, Denumire = "112,3" },
                new Tarla { Id = 14, UATId = 1, Denumire = "114,1" },
                new Tarla { Id = 15, UATId = 1, Denumire = "114,2" },
                new Tarla { Id = 16, UATId = 1, Denumire = "117" },
                new Tarla { Id = 17, UATId = 1, Denumire = "119,1" },
                new Tarla { Id = 18, UATId = 1, Denumire = "119,2" },
                new Tarla { Id = 19, UATId = 1, Denumire = "119,3" },
                new Tarla { Id = 20, UATId = 1, Denumire = "119,4" },
                new Tarla { Id = 21, UATId = 1, Denumire = "119,5" },
                new Tarla { Id = 22, UATId = 1, Denumire = "129" },
                new Tarla { Id = 23, UATId = 1, Denumire = "133,1" },
                new Tarla { Id = 24, UATId = 1, Denumire = "133,2" },
                new Tarla { Id = 25, UATId = 1, Denumire = "134,1" },
                new Tarla { Id = 26, UATId = 1, Denumire = "134,2" },
                new Tarla { Id = 27, UATId = 1, Denumire = "134,3" },
                new Tarla { Id = 28, UATId = 1, Denumire = "136,2" },
                new Tarla { Id = 29, UATId = 1, Denumire = "140" },
                new Tarla { Id = 30, UATId = 1, Denumire = "140,4" },
                new Tarla { Id = 31, UATId = 1, Denumire = "160,1" },
                new Tarla { Id = 32, UATId = 1, Denumire = "161,1" },
                new Tarla { Id = 33, UATId = 1, Denumire = "161,3" },
                new Tarla { Id = 34, UATId = 1, Denumire = "161,4" },
                new Tarla { Id = 35, UATId = 1, Denumire = "161,5" },
                new Tarla { Id = 36, UATId = 1, Denumire = "161,6" },
                new Tarla { Id = 37, UATId = 1, Denumire = "162,2" },
                new Tarla { Id = 38, UATId = 1, Denumire = "162,4" },
                new Tarla { Id = 39, UATId = 1, Denumire = "169,1" },
                new Tarla { Id = 40, UATId = 1, Denumire = "177,1" },
                new Tarla { Id = 41, UATId = 1, Denumire = "179,1" },
                new Tarla { Id = 42, UATId = 1, Denumire = "179,2" },
                new Tarla { Id = 43, UATId = 1, Denumire = "2420" },
                new Tarla { Id = 44, UATId = 1, Denumire = "263,2" },
                new Tarla { Id = 45, UATId = 1, Denumire = "267,4" },
                new Tarla { Id = 46, UATId = 1, Denumire = "267,6" },
                new Tarla { Id = 47, UATId = 1, Denumire = "267.1.6" },
                new Tarla { Id = 48, UATId = 1, Denumire = "267.3.4" },
                new Tarla { Id = 49, UATId = 1, Denumire = "276,6" },
                new Tarla { Id = 50, UATId = 1, Denumire = "291.1.2" },
                new Tarla { Id = 51, UATId = 1, Denumire = "297,1,2" },
                new Tarla { Id = 52, UATId = 1, Denumire = "297,1,6" },
                new Tarla { Id = 53, UATId = 1, Denumire = "297.1.2" },
                new Tarla { Id = 54, UATId = 1, Denumire = "297.1.5" },
                new Tarla { Id = 55, UATId = 1, Denumire = "297.1.6" },
                new Tarla { Id = 56, UATId = 1, Denumire = "303,2" },
                new Tarla { Id = 57, UATId = 1, Denumire = "303,6" },
                new Tarla { Id = 58, UATId = 1, Denumire = "304,2" },
                new Tarla { Id = 59, UATId = 1, Denumire = "329" },
                new Tarla { Id = 60, UATId = 1, Denumire = "339,1" },
                new Tarla { Id = 61, UATId = 1, Denumire = "341" },
                new Tarla { Id = 62, UATId = 1, Denumire = "341,2" },
                new Tarla { Id = 63, UATId = 1, Denumire = "345,1" },
                new Tarla { Id = 64, UATId = 1, Denumire = "367,6" },
                new Tarla { Id = 65, UATId = 1, Denumire = "383,1" },
                new Tarla { Id = 66, UATId = 1, Denumire = "383,2" },
                new Tarla { Id = 67, UATId = 1, Denumire = "383,3" },
                new Tarla { Id = 68, UATId = 1, Denumire = "383,5" },
                new Tarla { Id = 69, UATId = 1, Denumire = "393,1" },
                new Tarla { Id = 70, UATId = 1, Denumire = "393,2" },
                new Tarla { Id = 71, UATId = 1, Denumire = "393,3" },
                new Tarla { Id = 72, UATId = 1, Denumire = "420,1" },
                new Tarla { Id = 73, UATId = 1, Denumire = "420,2" },
                new Tarla { Id = 74, UATId = 1, Denumire = "420,4" },
                new Tarla { Id = 75, UATId = 1, Denumire = "422,1" },
                new Tarla { Id = 76, UATId = 1, Denumire = "422,4" },
                new Tarla { Id = 77, UATId = 1, Denumire = "422,6" },
                new Tarla { Id = 78, UATId = 1, Denumire = "445" },
                new Tarla { Id = 79, UATId = 1, Denumire = "445,1" },
                new Tarla { Id = 80, UATId = 1, Denumire = "445,2" },
                new Tarla { Id = 81, UATId = 1, Denumire = "471,2" },
                new Tarla { Id = 82, UATId = 1, Denumire = "474,1" },
                new Tarla { Id = 83, UATId = 1, Denumire = "474,2" },
                new Tarla { Id = 84, UATId = 1, Denumire = "479,1" },
                new Tarla { Id = 85, UATId = 1, Denumire = "479,2" },
                new Tarla { Id = 86, UATId = 1, Denumire = "479,3" },
                new Tarla { Id = 87, UATId = 1, Denumire = "479,5" },
                new Tarla { Id = 88, UATId = 1, Denumire = "480,1" },
                new Tarla { Id = 89, UATId = 1, Denumire = "480,4" },
                new Tarla { Id = 90, UATId = 1, Denumire = "483,4" },
                new Tarla { Id = 91, UATId = 1, Denumire = "483,5" },
                new Tarla { Id = 92, UATId = 1, Denumire = "483,6" },
                new Tarla { Id = 93, UATId = 1, Denumire = "483,8" },
                new Tarla { Id = 94, UATId = 1, Denumire = "499,1" },
                new Tarla { Id = 95, UATId = 1, Denumire = "51,5" },
                new Tarla { Id = 96, UATId = 1, Denumire = "51,6" },
                new Tarla { Id = 97, UATId = 1, Denumire = "51,7" },
                new Tarla { Id = 98, UATId = 1, Denumire = "520,1" },
                new Tarla { Id = 99, UATId = 1, Denumire = "520,4" },
                new Tarla { Id = 100, UATId = 1, Denumire = "56,7" },
                new Tarla { Id = 101, UATId = 1, Denumire = "64" },
                new Tarla { Id = 102, UATId = 1, Denumire = "72,1" },
                new Tarla { Id = 103, UATId = 1, Denumire = "72,2" },
                new Tarla { Id = 104, UATId = 1, Denumire = "72,3" },
                new Tarla { Id = 105, UATId = 1, Denumire = "72,4" },
                new Tarla { Id = 106, UATId = 1, Denumire = "75,1" },
                new Tarla { Id = 107, UATId = 1, Denumire = "76,1" },
                new Tarla { Id = 108, UATId = 1, Denumire = "76,2" },
                new Tarla { Id = 109, UATId = 1, Denumire = "79" },
                new Tarla { Id = 110, UATId = 1, Denumire = "82,2" },
                new Tarla { Id = 111, UATId = 1, Denumire = "94,1" }
            );

        }

    }

}