﻿// <auto-generated />
using System;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kolokwium2.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20220609090641_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kolokwium2.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Heeeeyaaah",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2022, 6, 9, 11, 6, 41, 323, DateTimeKind.Local).AddTicks(7360)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "Stairway to heaven",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 6, 9, 11, 6, 41, 329, DateTimeKind.Local).AddTicks(320)
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("Labels");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "Def Jam"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "Prosto"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musicians");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            Nickname = "Borys"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Donald",
                            LastName = "Tusk",
                            Nickname = "Donek"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Musician_Track", b =>
                {
                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusician", "IdTrack");

                    b.HasIndex("IdTrack");

                    b.ToTable("Musician_Tracks");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            IdTrack = 1
                        },
                        new
                        {
                            IdMusician = 2,
                            IdTrack = 2
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 2.56f,
                            IdMusicAlbum = 2,
                            TrackName = "I know"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 3.12f,
                            IdMusicAlbum = 1,
                            TrackName = "Hello"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Album", b =>
                {
                    b.HasOne("Kolokwium2.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("Kolokwium2.Models.Musician_Track", b =>
                {
                    b.HasOne("Kolokwium2.Models.Musician", "Musician")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Track", "Track")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Kolokwium2.Models.Track", b =>
                {
                    b.HasOne("Kolokwium2.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Kolokwium2.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Kolokwium2.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("Kolokwium2.Models.Musician", b =>
                {
                    b.Navigation("Musician_Tracks");
                });

            modelBuilder.Entity("Kolokwium2.Models.Track", b =>
                {
                    b.Navigation("Musician_Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
