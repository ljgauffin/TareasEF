﻿// <auto-generated />
using System;
using EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity_Framework.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("b3a3096e-4274-4799-a843-380868d4831c"),
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("b3a3096e-4274-4799-a843-380868d4832c"),
                            Nombre = "Actividades personales",
                            Peso = 50
                        },
                        new
                        {
                            CategoriaId = new Guid("b3a3096e-4274-4799-a843-380868d4833c"),
                            Nombre = "Actividades del Hogar",
                            Peso = 20
                        });
                });

            modelBuilder.Entity("EF.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("b3a3096e-4274-4799-a843-380868d4834c"),
                            CategoriaId = new Guid("b3a3096e-4274-4799-a843-380868d4831c"),
                            FechaCreacion = new DateTime(2023, 9, 15, 20, 52, 9, 438, DateTimeKind.Local).AddTicks(6498),
                            PrioridadTarea = 1,
                            Titulo = "Hacer tarea"
                        },
                        new
                        {
                            TareaId = new Guid("b3a3096e-4274-4799-a843-380868d4835c"),
                            CategoriaId = new Guid("b3a3096e-4274-4799-a843-380868d4832c"),
                            FechaCreacion = new DateTime(2023, 9, 15, 20, 52, 9, 438, DateTimeKind.Local).AddTicks(6516),
                            PrioridadTarea = 0,
                            Titulo = "Ir al gym"
                        },
                        new
                        {
                            TareaId = new Guid("b3a3096e-4274-4799-a843-380868d4836c"),
                            CategoriaId = new Guid("b3a3096e-4274-4799-a843-380868d4833c"),
                            FechaCreacion = new DateTime(2023, 9, 15, 20, 52, 9, 438, DateTimeKind.Local).AddTicks(6519),
                            PrioridadTarea = 2,
                            Titulo = "Limpiar"
                        });
                });

            modelBuilder.Entity("EF.Models.Tarea", b =>
                {
                    b.HasOne("EF.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("EF.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
