﻿// <auto-generated />
using System;
using CS.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS.EF.Migrations
{
    [DbContext(typeof(CadSysContext))]
    partial class CadSysContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CS.Data.Entities.ActProprietate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Carnet");

                    b.Property<DateTime?>("Data");

                    b.Property<string>("Emitent");

                    b.Property<int>("ExcelRow");

                    b.Property<int?>("IdTipActProprietate");

                    b.Property<int>("Index");

                    b.Property<string>("Numar");

                    b.Property<decimal>("Suprafata");

                    b.HasKey("Id");

                    b.HasIndex("IdTipActProprietate");

                    b.ToTable("ActeProprietate");
                });

            modelBuilder.Entity("CS.Data.Entities.Dictionaries.UAT", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Denumire")
                        .IsRequired();

                    b.Property<int>("JudetId");

                    b.HasKey("Id");

                    b.HasIndex("JudetId");

                    b.ToTable("UAT");

                    b.HasData(
                        new { Id = 1, Denumire = "Sarateni", JudetId = 1 }
                    );
                });

            modelBuilder.Entity("CS.Data.Entities.Imobil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ImobilNou");

                    b.Property<bool>("Intravilan");

                    b.Property<string>("NumarCadGeneral")
                        .HasMaxLength(200);

                    b.Property<string>("NumarCadastral")
                        .HasMaxLength(200);

                    b.Property<string>("NumarCarteFunciara")
                        .HasMaxLength(200);

                    b.Property<string>("NumarTopografic")
                        .HasMaxLength(200);

                    b.Property<string>("Observatii")
                        .HasMaxLength(2000);

                    b.Property<string>("SectorCadastral")
                        .HasMaxLength(200);

                    b.Property<decimal>("SuprafataDinActe");

                    b.Property<decimal>("SuprafataDinActeConstructii");

                    b.Property<decimal>("SuprafataMasurata");

                    b.Property<decimal>("ValoareImpozitare");

                    b.HasKey("Id");

                    b.ToTable("Imobil");
                });

            modelBuilder.Entity("CS.Data.Entities.Inscriere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("ExcelRow");

                    b.Property<int>("IdInscriereDetaliu");

                    b.Property<int>("Index");

                    b.HasKey("Id");

                    b.ToTable("Inscrieri");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Inscriere");
                });

            modelBuilder.Entity("CS.Data.Entities.InscriereDetaliu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CotaActuala")
                        .HasMaxLength(50);

                    b.Property<string>("CotaInitiala")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataCererii");

                    b.Property<int>("ExcelRow");

                    b.Property<int?>("IdImobilReferinta");

                    b.Property<int>("IdTipDrept");

                    b.Property<int>("Index");

                    b.Property<string>("ModDobandire")
                        .HasMaxLength(50);

                    b.Property<string>("Moneda")
                        .HasMaxLength(50);

                    b.Property<string>("Nota")
                        .HasMaxLength(4000);

                    b.Property<int>("NumarulCererii");

                    b.Property<string>("Observatii")
                        .HasMaxLength(2000);

                    b.Property<string>("ObservatiiDrept")
                        .HasMaxLength(2000);

                    b.Property<int>("ParteaCartiiFunciare");

                    b.Property<int>("Pozitia");

                    b.Property<string>("TipCota")
                        .HasMaxLength(50);

                    b.Property<string>("TipInscriere");

                    b.Property<string>("Valoarea")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("IdImobilReferinta");

                    b.ToTable("InscrieriDetaliu");
                });

            modelBuilder.Entity("CS.Data.Entities.Judet", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Denumire")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Judet");

                    b.HasData(
                        new { Id = 1, Denumire = "Ialomita" }
                    );
                });

            modelBuilder.Entity("CS.Data.Entities.Localitate", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Denumire")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Localitate");

                    b.HasData(
                        new { Id = 1, Denumire = "Sarateni" }
                    );
                });

            modelBuilder.Entity("CS.Data.Entities.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CatFol");

                    b.Property<string>("Denumire")
                        .IsRequired();

                    b.Property<int>("ExcelRow");

                    b.Property<int?>("IdImobil");

                    b.Property<int?>("IdTarla");

                    b.Property<int>("Index");

                    b.Property<int>("Suprafata");

                    b.HasKey("Id");

                    b.HasIndex("IdImobil");

                    b.HasIndex("IdTarla");

                    b.ToTable("Parcele");
                });

            modelBuilder.Entity("CS.Data.Entities.Proprietar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime?>("DataEmiterii");

                    b.Property<string>("Emitent");

                    b.Property<int>("ExcelRow");

                    b.Property<long>("Identificator");

                    b.Property<int>("Index");

                    b.Property<string>("Initiala");

                    b.Property<string>("Judet");

                    b.Property<string>("Localitate");

                    b.Property<string>("Numar");

                    b.Property<string>("Nume");

                    b.Property<string>("Prenume");

                    b.Property<string>("Serie");

                    b.Property<int?>("Sex");

                    b.Property<string>("Tara");

                    b.Property<int?>("TipActIdentitate");

                    b.Property<int>("TipPersoana");

                    b.HasKey("Id");

                    b.ToTable("Proprietari");
                });

            modelBuilder.Entity("CS.Data.Entities.Tarla", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Denumire")
                        .IsRequired();

                    b.Property<int>("UATId");

                    b.HasKey("Id");

                    b.HasIndex("UATId");

                    b.ToTable("Tarlale");

                    b.HasData(
                        new { Id = 1, Denumire = "119,3", UATId = 1 },
                        new { Id = 2, Denumire = "339,1", UATId = 1 },
                        new { Id = 3, Denumire = "94,1", UATId = 1 },
                        new { Id = 4, Denumire = "79", UATId = 1 },
                        new { Id = 5, Denumire = "105,6", UATId = 1 },
                        new { Id = 6, Denumire = "393,3", UATId = 1 },
                        new { Id = 7, Denumire = "420,1", UATId = 1 },
                        new { Id = 8, Denumire = "160,1", UATId = 1 },
                        new { Id = 9, Denumire = "117", UATId = 1 },
                        new { Id = 10, Denumire = "480,1", UATId = 1 },
                        new { Id = 11, Denumire = "110", UATId = 1 },
                        new { Id = 12, Denumire = "161,1", UATId = 1 },
                        new { Id = 13, Denumire = "267,6", UATId = 1 },
                        new { Id = 14, Denumire = "72,1", UATId = 1 },
                        new { Id = 15, Denumire = "133,1", UATId = 1 },
                        new { Id = 16, Denumire = "267,4", UATId = 1 },
                        new { Id = 17, Denumire = "480,4", UATId = 1 },
                        new { Id = 18, Denumire = "161,3", UATId = 1 },
                        new { Id = 19, Denumire = "499,1", UATId = 1 },
                        new { Id = 20, Denumire = "75,1", UATId = 1 },
                        new { Id = 21, Denumire = "104,2", UATId = 1 },
                        new { Id = 22, Denumire = "341", UATId = 1 },
                        new { Id = 23, Denumire = "474,2", UATId = 1 },
                        new { Id = 24, Denumire = "162,2", UATId = 1 },
                        new { Id = 25, Denumire = "162,4", UATId = 1 },
                        new { Id = 26, Denumire = "169,1", UATId = 1 },
                        new { Id = 27, Denumire = "297.1.5", UATId = 1 },
                        new { Id = 28, Denumire = "479,1", UATId = 1 },
                        new { Id = 29, Denumire = "177,1", UATId = 1 },
                        new { Id = 30, Denumire = "134,1", UATId = 1 },
                        new { Id = 31, Denumire = "483,4", UATId = 1 },
                        new { Id = 32, Denumire = "383,1", UATId = 1 },
                        new { Id = 33, Denumire = "64", UATId = 1 },
                        new { Id = 34, Denumire = "140", UATId = 1 },
                        new { Id = 35, Denumire = "345,1", UATId = 1 },
                        new { Id = 36, Denumire = "445,1", UATId = 1 },
                        new { Id = 37, Denumire = "112,2", UATId = 1 },
                        new { Id = 38, Denumire = "114,1", UATId = 1 },
                        new { Id = 39, Denumire = "297.1.2", UATId = 1 },
                        new { Id = 40, Denumire = "474,1", UATId = 1 },
                        new { Id = 41, Denumire = "112,3", UATId = 1 },
                        new { Id = 42, Denumire = "105,3", UATId = 1 },
                        new { Id = 43, Denumire = "82,2", UATId = 1 },
                        new { Id = 44, Denumire = "479,2", UATId = 1 },
                        new { Id = 45, Denumire = "100", UATId = 1 },
                        new { Id = 46, Denumire = "76,1", UATId = 1 },
                        new { Id = 47, Denumire = "483,6", UATId = 1 },
                        new { Id = 48, Denumire = "51,5", UATId = 1 },
                        new { Id = 49, Denumire = "383,2", UATId = 1 },
                        new { Id = 50, Denumire = "297.1.6", UATId = 1 },
                        new { Id = 51, Denumire = "422,6", UATId = 1 },
                        new { Id = 52, Denumire = "134,2", UATId = 1 },
                        new { Id = 53, Denumire = "445,2", UATId = 1 },
                        new { Id = 54, Denumire = "483,5", UATId = 1 },
                        new { Id = 55, Denumire = "72,3", UATId = 1 },
                        new { Id = 56, Denumire = "304,2", UATId = 1 },
                        new { Id = 57, Denumire = "479,5", UATId = 1 },
                        new { Id = 58, Denumire = "133,2", UATId = 1 },
                        new { Id = 59, Denumire = "72,4", UATId = 1 },
                        new { Id = 60, Denumire = "303,2", UATId = 1 },
                        new { Id = 61, Denumire = "102,1", UATId = 1 },
                        new { Id = 62, Denumire = "114,2", UATId = 1 },
                        new { Id = 63, Denumire = "51,7", UATId = 1 },
                        new { Id = 64, Denumire = "119,5", UATId = 1 },
                        new { Id = 65, Denumire = "2420", UATId = 1 },
                        new { Id = 66, Denumire = "104,1", UATId = 1 },
                        new { Id = 67, Denumire = "112,1", UATId = 1 },
                        new { Id = 68, Denumire = "129", UATId = 1 },
                        new { Id = 69, Denumire = "161,6", UATId = 1 },
                        new { Id = 70, Denumire = "102,2", UATId = 1 },
                        new { Id = 71, Denumire = "393,2", UATId = 1 },
                        new { Id = 72, Denumire = "179,2", UATId = 1 },
                        new { Id = 73, Denumire = "140,4", UATId = 1 },
                        new { Id = 74, Denumire = "267.1.6", UATId = 1 },
                        new { Id = 75, Denumire = "422,4", UATId = 1 },
                        new { Id = 76, Denumire = "367,6", UATId = 1 },
                        new { Id = 77, Denumire = "136,2", UATId = 1 },
                        new { Id = 78, Denumire = "520,1", UATId = 1 },
                        new { Id = 79, Denumire = "119,1", UATId = 1 },
                        new { Id = 80, Denumire = "119,4", UATId = 1 },
                        new { Id = 81, Denumire = "134,3", UATId = 1 },
                        new { Id = 82, Denumire = "297,1,2", UATId = 1 },
                        new { Id = 83, Denumire = "329", UATId = 1 },
                        new { Id = 84, Denumire = "303,6", UATId = 1 },
                        new { Id = 85, Denumire = "51,6", UATId = 1 },
                        new { Id = 86, Denumire = "291.1.2", UATId = 1 },
                        new { Id = 87, Denumire = "422,1", UATId = 1 },
                        new { Id = 88, Denumire = "420,2", UATId = 1 },
                        new { Id = 89, Denumire = "520,4", UATId = 1 },
                        new { Id = 90, Denumire = "263,2", UATId = 1 },
                        new { Id = 91, Denumire = "483,8", UATId = 1 },
                        new { Id = 92, Denumire = "420,4", UATId = 1 },
                        new { Id = 93, Denumire = "119,2", UATId = 1 },
                        new { Id = 94, Denumire = "72,2", UATId = 1 },
                        new { Id = 95, Denumire = "105,2", UATId = 1 },
                        new { Id = 96, Denumire = "276,6", UATId = 1 },
                        new { Id = 97, Denumire = "445", UATId = 1 },
                        new { Id = 98, Denumire = "104", UATId = 1 },
                        new { Id = 99, Denumire = "383,3", UATId = 1 },
                        new { Id = 100, Denumire = "297,1,6", UATId = 1 },
                        new { Id = 101, Denumire = "383,5", UATId = 1 },
                        new { Id = 102, Denumire = "161,4", UATId = 1 },
                        new { Id = 103, Denumire = "179,1", UATId = 1 },
                        new { Id = 104, Denumire = "471,2", UATId = 1 },
                        new { Id = 105, Denumire = "161,5", UATId = 1 },
                        new { Id = 106, Denumire = "56,7", UATId = 1 },
                        new { Id = 107, Denumire = "267.3.4", UATId = 1 },
                        new { Id = 108, Denumire = "341,2", UATId = 1 },
                        new { Id = 109, Denumire = "76,2", UATId = 1 },
                        new { Id = 110, Denumire = "393,1", UATId = 1 },
                        new { Id = 111, Denumire = "479,3", UATId = 1 }
                    );
                });

            modelBuilder.Entity("CS.Data.Entities.TipActProprietate", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Denumire")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TipuriActProprietate");

                    b.HasData(
                        new { Id = 1, Denumire = "Titlu Proprietate" },
                        new { Id = 2, Denumire = "Contract de Vanzare Cumparare" },
                        new { Id = 3, Denumire = "Contract de Vanzare Cumparare cu Clauza de Intretinere" },
                        new { Id = 4, Denumire = "Sentinta Civila" },
                        new { Id = 5, Denumire = "Certificat de Mostenitor" },
                        new { Id = 6, Denumire = "Certificat de Mostenitor Succesiv" },
                        new { Id = 7, Denumire = "Certificat de Mostenitor Suplimentar" },
                        new { Id = 8, Denumire = "Act de Donatie" },
                        new { Id = 9, Denumire = "Contract de Donatie" },
                        new { Id = 10, Denumire = "Contract de Donatie Imobiliara" },
                        new { Id = 11, Denumire = "Contract de Partaj" },
                        new { Id = 12, Denumire = "Contract de Partaj Voluntar" },
                        new { Id = 13, Denumire = "Act de Partaj Voluntar" },
                        new { Id = 14, Denumire = "Contract de Partaj Imobiliar" },
                        new { Id = 15, Denumire = "Testament" },
                        new { Id = 16, Denumire = "Declaratie Notariala" },
                        new { Id = 17, Denumire = "Certificat de Legatar Suplimentar" }
                    );
                });

            modelBuilder.Entity("CS.Data.Entities.InscriereAct", b =>
                {
                    b.HasBaseType("CS.Data.Entities.Inscriere");

                    b.Property<int?>("IdActProprietate");

                    b.HasIndex("IdActProprietate");

                    b.HasIndex("IdInscriereDetaliu");

                    b.ToTable("InscriereAct");

                    b.HasDiscriminator().HasValue("InscriereAct");
                });

            modelBuilder.Entity("CS.Data.Entities.InscriereImobil", b =>
                {
                    b.HasBaseType("CS.Data.Entities.Inscriere");

                    b.Property<int?>("IdImobil");

                    b.HasIndex("IdImobil");

                    b.HasIndex("IdInscriereDetaliu")
                        .HasName("IX_Inscrieri_IdInscriereDetaliu1");

                    b.ToTable("InscriereImobil");

                    b.HasDiscriminator().HasValue("InscriereImobil");
                });

            modelBuilder.Entity("CS.Data.Entities.InscriereProprietar", b =>
                {
                    b.HasBaseType("CS.Data.Entities.Inscriere");

                    b.Property<int?>("IdProprietar");

                    b.HasIndex("IdInscriereDetaliu")
                        .HasName("IX_Inscrieri_IdInscriereDetaliu2");

                    b.HasIndex("IdProprietar");

                    b.ToTable("InscriereProprietar");

                    b.HasDiscriminator().HasValue("InscriereProprietar");
                });

            modelBuilder.Entity("CS.Data.Entities.ActProprietate", b =>
                {
                    b.HasOne("CS.Data.Entities.TipActProprietate", "TipAct")
                        .WithMany("ActeProprietate")
                        .HasForeignKey("IdTipActProprietate");
                });

            modelBuilder.Entity("CS.Data.Entities.Dictionaries.UAT", b =>
                {
                    b.HasOne("CS.Data.Entities.Judet", "Judet")
                        .WithMany()
                        .HasForeignKey("JudetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Data.Entities.InscriereDetaliu", b =>
                {
                    b.HasOne("CS.Data.Entities.Imobil", "ImobilReferinta")
                        .WithMany()
                        .HasForeignKey("IdImobilReferinta");
                });

            modelBuilder.Entity("CS.Data.Entities.Parcela", b =>
                {
                    b.HasOne("CS.Data.Entities.Imobil", "Imobil")
                        .WithMany("Parcele")
                        .HasForeignKey("IdImobil");

                    b.HasOne("CS.Data.Entities.Tarla", "Tarla")
                        .WithMany("Parcele")
                        .HasForeignKey("IdTarla");
                });

            modelBuilder.Entity("CS.Data.Entities.Tarla", b =>
                {
                    b.HasOne("CS.Data.Entities.Dictionaries.UAT", "UAT")
                        .WithMany()
                        .HasForeignKey("UATId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Data.Entities.InscriereAct", b =>
                {
                    b.HasOne("CS.Data.Entities.ActProprietate", "ActProprietate")
                        .WithMany("Inscrieri")
                        .HasForeignKey("IdActProprietate");

                    b.HasOne("CS.Data.Entities.InscriereDetaliu", "InscriereDetaliu")
                        .WithMany("InscrieriActe")
                        .HasForeignKey("IdInscriereDetaliu")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Data.Entities.InscriereImobil", b =>
                {
                    b.HasOne("CS.Data.Entities.Imobil", "Imobil")
                        .WithMany("Inscrieri")
                        .HasForeignKey("IdImobil");

                    b.HasOne("CS.Data.Entities.InscriereDetaliu", "InscriereDetaliu")
                        .WithMany("InscrieriImobile")
                        .HasForeignKey("IdInscriereDetaliu")
                        .HasConstraintName("FK_Inscrieri_InscrieriDetaliu_IdInscriereDetaliu1")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Data.Entities.InscriereProprietar", b =>
                {
                    b.HasOne("CS.Data.Entities.InscriereDetaliu", "InscriereDetaliu")
                        .WithMany("InscrieriProprietari")
                        .HasForeignKey("IdInscriereDetaliu")
                        .HasConstraintName("FK_Inscrieri_InscrieriDetaliu_IdInscriereDetaliu2")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS.Data.Entities.Proprietar", "Proprietar")
                        .WithMany("Inscrieri")
                        .HasForeignKey("IdProprietar");
                });
#pragma warning restore 612, 618
        }
    }
}
