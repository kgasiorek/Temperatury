﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SettingsContext))]
    [Migration("20230322194727_AddedSomeTablesToSettings")]
    partial class AddedSomeTablesToSettings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Domain.SettingsEntities.ApplicationSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Test")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ApplicationSettings");
                });

            modelBuilder.Entity("Domain.SettingsEntities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlToScreenshot")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Domain.SettingsEntities.SensorSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("MaxAlarmEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MaxTemp")
                        .HasColumnType("REAL");

                    b.Property<bool>("MinAlarmEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MinTemp")
                        .HasColumnType("REAL");

                    b.Property<string>("OriginalName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeOfSensorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("TypeOfSensorId");

                    b.ToTable("SensorSettings");
                });

            modelBuilder.Entity("Domain.SettingsEntities.TypeOfSensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TypesOfSensor");
                });

            modelBuilder.Entity("Domain.SettingsEntities.SensorSettings", b =>
                {
                    b.HasOne("Domain.SettingsEntities.Room", "Room")
                        .WithMany("Sensors")
                        .HasForeignKey("RoomId");

                    b.HasOne("Domain.SettingsEntities.TypeOfSensor", "TypeOfSensor")
                        .WithMany("Sensors")
                        .HasForeignKey("TypeOfSensorId");

                    b.Navigation("Room");

                    b.Navigation("TypeOfSensor");
                });

            modelBuilder.Entity("Domain.SettingsEntities.Room", b =>
                {
                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("Domain.SettingsEntities.TypeOfSensor", b =>
                {
                    b.Navigation("Sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
