﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web2.Data;

#nullable disable

namespace Web2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web2.Models.Artikal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProdavacId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProdavacId");

                    b.ToTable("Artikli");
                });

            modelBuilder.Entity("Web2.Models.Narudzbina", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ArtikalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DatumDolaskaArtikla")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumNarucivanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<long>("KupacId")
                        .HasColumnType("bigint");

                    b.Property<int>("StatusArtikla")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtikalId");

                    b.HasIndex("KupacId");

                    b.ToTable("Narudzbine");
                });

            modelBuilder.Entity("Web2.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipKorisnika")
                        .HasColumnType("int");

                    b.Property<bool>("Verifikovan")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("Web2.Models.Artikal", b =>
                {
                    b.HasOne("Web2.Models.User", "Prodavac")
                        .WithMany("Artikli")
                        .HasForeignKey("ProdavacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prodavac");
                });

            modelBuilder.Entity("Web2.Models.Narudzbina", b =>
                {
                    b.HasOne("Web2.Models.Artikal", null)
                        .WithMany("Narudzine")
                        .HasForeignKey("ArtikalId");

                    b.HasOne("Web2.Models.User", "Kupac")
                        .WithMany("Narudzine")
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("Web2.Models.Artikal", b =>
                {
                    b.Navigation("Narudzine");
                });

            modelBuilder.Entity("Web2.Models.User", b =>
                {
                    b.Navigation("Artikli");

                    b.Navigation("Narudzine");
                });
#pragma warning restore 612, 618
        }
    }
}
