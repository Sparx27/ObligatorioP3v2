﻿// <auto-generated />
using System;
using System.Collections.Generic;
using LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(JuegosOlimpicosDBContext))]
    partial class JuegosOlimpicosDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AtletaDisciplina", b =>
                {
                    b.Property<int>("LiAtletasId")
                        .HasColumnType("int");

                    b.Property<int>("LiDisciplinasId")
                        .HasColumnType("int");

                    b.HasKey("LiAtletasId", "LiDisciplinasId");

                    b.HasIndex("LiDisciplinasId");

                    b.ToTable("AtletaDisciplina");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Atleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Atletas");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnioIntegracion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FchFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FchInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombrePrueba")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Habitantes")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreDelegado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelDelegado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.PuntajeEventoAtleta", b =>
                {
                    b.Property<int>("AtletaId")
                        .HasColumnType("int");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Puntaje")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AtletaId", "EventoId");

                    b.HasIndex("EventoId");

                    b.ToTable("PuntajeEventoAtleta");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAdminRegistro")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RolUsuario")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("Contrasena", "LogicaNegocio.Entidades.Usuario.Contrasena#RUsuarioContrasena", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AtletaDisciplina", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Atleta", null)
                        .WithMany()
                        .HasForeignKey("LiAtletasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Entidades.Disciplina", null)
                        .WithMany()
                        .HasForeignKey("LiDisciplinasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Atleta", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Disciplina", b =>
                {
                    b.OwnsOne("LogicaNegocio.ValueObjects.Disciplina.RDisciplinaNombre", "Nombre", b1 =>
                        {
                            b1.Property<int>("DisciplinaId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("DisciplinaId");

                            b1.HasIndex("Valor")
                                .IsUnique();

                            b1.ToTable("Disciplinas");

                            b1.WithOwner()
                                .HasForeignKey("DisciplinaId");
                        });

                    b.Navigation("Nombre")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Evento", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.PuntajeEventoAtleta", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Atleta", "Atleta")
                        .WithMany()
                        .HasForeignKey("AtletaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Entidades.Evento", null)
                        .WithMany("LiPuntajes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atleta");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Usuario", b =>
                {
                    b.OwnsOne("LogicaNegocio.ValueObjects.Usuario.RUsuarioEmail", "Email", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.HasKey("UsuarioId");

                            b1.HasIndex("Valor")
                                .IsUnique();

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Evento", b =>
                {
                    b.Navigation("LiPuntajes");
                });
#pragma warning restore 612, 618
        }
    }
}
