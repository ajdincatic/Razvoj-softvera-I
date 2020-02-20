﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RS1_Ispit_asp.net_core.EF;
using System;

namespace RS1_Ispit_asp.net_core.Migrations
{
    [DbContext(typeof(MojContext))]
    partial class MojContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.DodjeljenPredmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OdjeljenjeStavkaId");

                    b.Property<int>("PredmetId");

                    b.Property<int>("ZakljucnoKrajGodine");

                    b.HasKey("Id");

                    b.HasIndex("OdjeljenjeStavkaId");

                    b.HasIndex("PredmetId");

                    b.ToTable("DodjeljenPredmet");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<int>("SkolaID");

                    b.HasKey("Id");

                    b.HasIndex("SkolaID");

                    b.ToTable("Nastavnik");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Odjeljenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsPrebacenuViseOdjeljenje");

                    b.Property<string>("Oznaka");

                    b.Property<int>("Razred");

                    b.Property<int>("RazrednikID");

                    b.Property<int>("SkolaID");

                    b.Property<int>("SkolskaGodinaID");

                    b.HasKey("Id");

                    b.HasIndex("RazrednikID");

                    b.HasIndex("SkolaID");

                    b.HasIndex("SkolskaGodinaID");

                    b.ToTable("Odjeljenje");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.OdjeljenjeStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojUDnevniku");

                    b.Property<int>("OdjeljenjeId");

                    b.Property<int>("UcenikId");

                    b.HasKey("Id");

                    b.HasIndex("OdjeljenjeId");

                    b.HasIndex("UcenikId");

                    b.ToTable("OdjeljenjeStavka");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PopravniIspit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClanKomisije1Id");

                    b.Property<int>("ClanKomisije2Id");

                    b.Property<int>("ClanKomisije3Id");

                    b.Property<DateTime>("Datum");

                    b.Property<int>("PopravniIspitOpstiPodaciId");

                    b.HasKey("Id");

                    b.HasIndex("ClanKomisije1Id");

                    b.HasIndex("ClanKomisije2Id");

                    b.HasIndex("ClanKomisije3Id");

                    b.HasIndex("PopravniIspitOpstiPodaciId");

                    b.ToTable("PopravniIspit");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PopravniIspitOpstiPodaci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PredmetId");

                    b.Property<int>("SkolaId");

                    b.Property<int>("SkolskaGodinaId");

                    b.HasKey("Id");

                    b.HasIndex("PredmetId");

                    b.HasIndex("SkolaId");

                    b.HasIndex("SkolskaGodinaId");

                    b.ToTable("PopravniIspitOpstiPodaci");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PopravniIspitStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float?>("BrojBodova");

                    b.Property<bool>("ImaPravo");

                    b.Property<bool>("IsPrisutan");

                    b.Property<int>("OdjeljenjeStavkaId");

                    b.Property<int>("PopravniIspitId");

                    b.HasKey("Id");

                    b.HasIndex("OdjeljenjeStavkaId");

                    b.HasIndex("PopravniIspitId");

                    b.ToTable("PopravniIspitStavka");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PredajePredmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NastavnikID");

                    b.Property<int>("OdjeljenjeID");

                    b.Property<int>("PredmetID");

                    b.HasKey("Id");

                    b.HasIndex("NastavnikID");

                    b.HasIndex("OdjeljenjeID");

                    b.HasIndex("PredmetID");

                    b.ToTable("PredajePredmet");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<int>("Razred");

                    b.HasKey("Id");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Skola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Skola");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.SkolskaGodina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Aktuelna");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("SkolskaGodina");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Ucenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImePrezime");

                    b.HasKey("Id");

                    b.ToTable("Ucenik");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.DodjeljenPredmet", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.OdjeljenjeStavka", "OdjeljenjeStavka")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeStavkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Skola", "Skola")
                        .WithMany()
                        .HasForeignKey("SkolaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Odjeljenje", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", "Razrednik")
                        .WithMany()
                        .HasForeignKey("RazrednikID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Skola", "Skola")
                        .WithMany()
                        .HasForeignKey("SkolaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.SkolskaGodina", "SkolskaGodina")
                        .WithMany()
                        .HasForeignKey("SkolskaGodinaID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.OdjeljenjeStavka", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Odjeljenje", "Odjeljenje")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Ucenik", "Ucenik")
                        .WithMany()
                        .HasForeignKey("UcenikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PopravniIspit", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", "ClanKomisije1")
                        .WithMany()
                        .HasForeignKey("ClanKomisije1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", "ClanKomisije2")
                        .WithMany()
                        .HasForeignKey("ClanKomisije2Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", "ClanKomisije3")
                        .WithMany()
                        .HasForeignKey("ClanKomisije3Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.PopravniIspitOpstiPodaci", "PopravniIspitOpstiPodaci")
                        .WithMany()
                        .HasForeignKey("PopravniIspitOpstiPodaciId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PopravniIspitOpstiPodaci", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Skola", "Skola")
                        .WithMany()
                        .HasForeignKey("SkolaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.SkolskaGodina", "SkolskaGodina")
                        .WithMany()
                        .HasForeignKey("SkolskaGodinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PopravniIspitStavka", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.OdjeljenjeStavka", "OdjeljenjeStavka")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeStavkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.PopravniIspit", "PopravniIspit")
                        .WithMany()
                        .HasForeignKey("PopravniIspitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PredajePredmet", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Odjeljenje", "Odjeljenje")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
