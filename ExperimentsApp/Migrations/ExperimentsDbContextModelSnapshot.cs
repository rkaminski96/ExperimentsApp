﻿// <auto-generated />
using System;
using ExperimentsApp.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExperimentsApp.API.Migrations
{
    [DbContext(typeof(ExperimentsDbContext))]
    partial class ExperimentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExperimentsApp.Data.Model.Experiment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<string>("Description");

                    b.Property<int>("ExperimentTypeId");

                    b.Property<int>("MachineId");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentTypeId");

                    b.HasIndex("MachineId");

                    b.HasIndex("UserId");

                    b.ToTable("Experiments");
                });

            modelBuilder.Entity("ExperimentsApp.Data.Model.ExperimentSensor", b =>
                {
                    b.Property<int>("ExperimentId");

                    b.Property<int>("SensorId");

                    b.HasKey("ExperimentId", "SensorId");

                    b.HasIndex("SensorId");

                    b.ToTable("ExperimentSensors");
                });

            modelBuilder.Entity("ExperimentsApp.Data.Model.ExperimentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ExperimentTypes");
                });

            modelBuilder.Entity("ExperimentsApp.Data.Model.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("ExperimentsApp.Data.Model.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.Property<string>("SensorProperties");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("ExperimentsApp.Data.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExperimentsApp.Data.Model.Experiment", b =>
                {
                    b.HasOne("ExperimentsApp.Data.Model.ExperimentType", "ExperimentType")
                        .WithMany("Experiments")
                        .HasForeignKey("ExperimentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExperimentsApp.Data.Model.Machine", "Machine")
                        .WithMany("Experiments")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExperimentsApp.Data.Model.User")
                        .WithMany("Experiments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ExperimentsApp.Data.Model.ExperimentSensor", b =>
                {
                    b.HasOne("ExperimentsApp.Data.Model.Experiment", "Experiment")
                        .WithMany("ExperimentSensors")
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExperimentsApp.Data.Model.Sensor", "Sensor")
                        .WithMany("ExperimentSensors")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
