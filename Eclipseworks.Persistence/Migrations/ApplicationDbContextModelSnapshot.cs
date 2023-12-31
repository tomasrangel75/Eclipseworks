﻿// <auto-generated />
using System;
using Eclipseworks.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eclipseworks.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Eclipseworks.Domain.Entities.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<int>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projetos", (string)null);
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<int>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CriadoPor = 0,
                            DataCriacao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Descricao = "Usuario com permissões administrativas",
                            Nome = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CriadoPor = 0,
                            DataCriacao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Descricao = "Usuario com permissões básicas",
                            Nome = "Basico"
                        },
                        new
                        {
                            Id = 3,
                            CriadoPor = 0,
                            DataCriacao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Descricao = "Usuario com permissões nível gerencial",
                            Nome = "Gerente"
                        });
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<int>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataVencimento")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prioridade")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Tarefas", (string)null);
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.TarefaHistorico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<string>("ColunaModificada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TarefaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoModificacao")
                        .HasColumnType("int");

                    b.Property<string>("ValorAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorAtual")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId");

                    b.ToTable("TarefaHistoricos", (string)null);
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<int>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CriadoPor = 1,
                            DataCriacao = new DateTimeOffset(new DateTime(2023, 12, 3, 22, 27, 14, 489, DateTimeKind.Unspecified).AddTicks(26), new TimeSpan(0, -3, 0, 0, 0)),
                            Nome = "Admin",
                            Sobrenome = ""
                        },
                        new
                        {
                            Id = 2,
                            CriadoPor = 1,
                            DataCriacao = new DateTimeOffset(new DateTime(2023, 12, 3, 22, 27, 14, 489, DateTimeKind.Unspecified).AddTicks(69), new TimeSpan(0, -3, 0, 0, 0)),
                            Nome = "User1",
                            Sobrenome = ""
                        },
                        new
                        {
                            Id = 3,
                            CriadoPor = 1,
                            DataCriacao = new DateTimeOffset(new DateTime(2023, 12, 3, 22, 27, 14, 489, DateTimeKind.Unspecified).AddTicks(75), new TimeSpan(0, -3, 0, 0, 0)),
                            Nome = "User2",
                            Sobrenome = ""
                        });
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtualizadoPor")
                        .HasColumnType("int");

                    b.Property<int>("CriadoPor")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CriadoPor = 0,
                            DataCriacao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            RoleId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CriadoPor = 0,
                            DataCriacao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            RoleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            CriadoPor = 0,
                            DataCriacao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            RoleId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            CriadoPor = 0,
                            DataCriacao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            RoleId = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            CriadoPor = 0,
                            DataCriacao = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            RoleId = 2,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.Tarefa", b =>
                {
                    b.HasOne("Eclipseworks.Domain.Entities.Projeto", "Projeto")
                        .WithMany("Tarefas")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.TarefaHistorico", b =>
                {
                    b.HasOne("Eclipseworks.Domain.Entities.Tarefa", "Tarefa")
                        .WithMany("TarefaHistoricos")
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Eclipseworks.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eclipseworks.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.Projeto", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.Tarefa", b =>
                {
                    b.Navigation("TarefaHistoricos");
                });

            modelBuilder.Entity("Eclipseworks.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
