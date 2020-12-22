﻿// <auto-generated />
using System;
using EmreWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmreWebApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201222173401_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmreWebApi.Models.Bok", b =>
                {
                    b.Property<int>("Bok_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Betyg")
                        .HasColumnType("int");

                    b.Property<int>("BokFörfattaresId")
                        .HasColumnType("int");

                    b.Property<string>("BokTitel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BoklånId")
                        .HasColumnType("int");

                    b.Property<int>("Isbn")
                        .HasColumnType("int");

                    b.Property<int?>("UtgivningsÅr")
                        .HasColumnType("int");

                    b.HasKey("Bok_Id");

                    b.ToTable("Böcker");
                });

            modelBuilder.Entity("EmreWebApi.Models.BokFörfattare", b =>
                {
                    b.Property<int>("BokId")
                        .HasColumnType("int");

                    b.Property<int>("FörfattareId")
                        .HasColumnType("int");

                    b.HasKey("BokId", "FörfattareId");

                    b.HasIndex("FörfattareId");

                    b.ToTable("BokFörfattare");
                });

            modelBuilder.Entity("EmreWebApi.Models.Boklån", b =>
                {
                    b.Property<int>("BoklånId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BokId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LåneDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("LånekortId")
                        .HasColumnType("int");

                    b.Property<int?>("LåntagareLånekortId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("SaldoId")
                        .HasColumnType("int");

                    b.Property<bool>("Utlånad")
                        .HasColumnType("bit");

                    b.HasKey("BoklånId");

                    b.HasIndex("BokId");

                    b.HasIndex("LåntagareLånekortId");

                    b.HasIndex("SaldoId");

                    b.ToTable("Boklåns");
                });

            modelBuilder.Entity("EmreWebApi.Models.Författare", b =>
                {
                    b.Property<int>("FörfattareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Författarenamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FörfattareId");

                    b.ToTable("Författares");
                });

            modelBuilder.Entity("EmreWebApi.Models.Låntagare", b =>
                {
                    b.Property<int>("LånekortId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Efternamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Förnamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("LånekortId");

                    b.ToTable("Låntagares");
                });

            modelBuilder.Entity("EmreWebApi.Models.Saldo", b =>
                {
                    b.Property<int>("SaldoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BokId")
                        .HasColumnType("int");

                    b.HasKey("SaldoId");

                    b.HasIndex("BokId");

                    b.ToTable("Saldo");
                });

            modelBuilder.Entity("EmreWebApi.Models.BokFörfattare", b =>
                {
                    b.HasOne("EmreWebApi.Models.Författare", "Författare")
                        .WithMany("BokFörfattares")
                        .HasForeignKey("BokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmreWebApi.Models.Bok", "Bok")
                        .WithMany("BokFörfattares")
                        .HasForeignKey("FörfattareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmreWebApi.Models.Boklån", b =>
                {
                    b.HasOne("EmreWebApi.Models.Bok", null)
                        .WithMany("Boklåns")
                        .HasForeignKey("BokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmreWebApi.Models.Låntagare", "Låntagare")
                        .WithMany("Boklåns")
                        .HasForeignKey("LåntagareLånekortId");

                    b.HasOne("EmreWebApi.Models.Saldo", "Saldo")
                        .WithMany("Boklåns")
                        .HasForeignKey("SaldoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmreWebApi.Models.Saldo", b =>
                {
                    b.HasOne("EmreWebApi.Models.Bok", "Bok")
                        .WithMany()
                        .HasForeignKey("BokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
