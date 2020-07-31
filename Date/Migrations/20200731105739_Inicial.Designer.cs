﻿// <auto-generated />
using System;
using Date.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Date.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20200731105739_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Business.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Senha")
                        .HasColumnType("Passord");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Business.Models.Recurso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DescricaoRecurso")
                        .HasColumnType("varchar(999)");

                    b.Property<int>("NumeroVotacao")
                        .HasColumnType("integer");

                    b.Property<string>("TituloRecurso")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Recursos");
                });

            modelBuilder.Entity("Business.Models.RegistroVotacao", b =>
                {
                    b.Property<Guid>("FuncionarioId")
                        .HasColumnName("FuncionarioId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RecursoId")
                        .HasColumnName("RecursoId")
                        .HasColumnType("uuid");

                    b.Property<string>("ComentarioRecurso")
                        .IsRequired()
                        .HasColumnType("varchar(999)");

                    b.Property<DateTime>("DataVotacaoRecurso")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("FuncionarioId", "RecursoId");

                    b.HasIndex("RecursoId");

                    b.ToTable("RegistroVotacoes");
                });

            modelBuilder.Entity("Business.Models.RegistroVotacao", b =>
                {
                    b.HasOne("Business.Models.Funcionario", "Funcionario")
                        .WithMany("RegistroVotacoes")
                        .HasForeignKey("FuncionarioId")
                        .IsRequired();

                    b.HasOne("Business.Models.Recurso", "Recurso")
                        .WithMany("RegistroVotacoes")
                        .HasForeignKey("RecursoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}