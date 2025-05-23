﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Progreso1_EstefaniHuertas.Migrations
{
    [DbContext(typeof(DbHuertas_Hotel))]
    [Migration("20250429135904_Migracion_Inicial")]
    partial class Migracion_Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Progreso1_EstefaniHuertas.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Gold")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<bool>("Silver")
                        .HasColumnType("bit");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Progreso1_EstefaniHuertas.Models.PlanRecompensa", b =>
                {
                    b.Property<int>("PlanRecompensaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanRecompensaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PlanRecompensaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("PlanRecompensa");
                });

            modelBuilder.Entity("Progreso1_EstefaniHuertas.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorAPagar")
                        .HasColumnType("float");

                    b.HasKey("ReservaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Progreso1_EstefaniHuertas.Models.PlanRecompensa", b =>
                {
                    b.HasOne("Progreso1_EstefaniHuertas.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Progreso1_EstefaniHuertas.Models.Reserva", b =>
                {
                    b.HasOne("Progreso1_EstefaniHuertas.Models.Cliente", "Cliente")
                        .WithMany("Reserva")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Progreso1_EstefaniHuertas.Models.Cliente", b =>
                {
                    b.Navigation("Reserva");
                });
#pragma warning restore 612, 618
        }
    }
}
