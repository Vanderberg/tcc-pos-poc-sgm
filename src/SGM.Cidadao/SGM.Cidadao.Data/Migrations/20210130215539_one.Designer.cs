﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGM.Cidadao.Data.Context;

namespace SGM.Cidadao.Data.Migrations
{
    [DbContext(typeof(SgmContextCidadao))]
    [Migration("20210130215539_one")]
    partial class one
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SGM.Cidadao.Domain.Entities.CampanhaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Campanha");
                });

            modelBuilder.Entity("SGM.Cidadao.Domain.Entities.PoliticaPublicaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataPrevista")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataRealizada")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000) CHARACTER SET utf8mb4")
                        .HasMaxLength(1000);

                    b.Property<int>("DescricaoArea")
                        .HasColumnType("int");

                    b.Property<string>("NomeResponsavel")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<double>("OrcamentoPrevisto")
                        .HasColumnType("double");

                    b.Property<double>("OrcamentoRealizado")
                        .HasColumnType("double");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("PoliticaPublica");
                });

            modelBuilder.Entity("SGM.Cidadao.Domain.Entities.VotacaoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CampanhaDescricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("CampanhaID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PoliticaPublicaID")
                        .HasColumnType("char(36)");

                    b.Property<string>("PoliticaTitulo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Votos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Votacao");
                });
#pragma warning restore 612, 618
        }
    }
}
