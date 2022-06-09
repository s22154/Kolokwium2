using System;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models
{
    public class MasterContext : DbContext
    {
        protected MasterContext()
        {
        }

        public MasterContext(DbContextOptions options) : base(options)
        {
        }
        
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<MusicLabel> Labels { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<Musician_Track> Musician_Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MusicLabel>(ml =>
            {
                ml.HasKey(e => e.IdMusicLabel);
                ml.Property(e => e.Name).IsRequired().HasMaxLength(50);

                ml.HasData(new MusicLabel
                    {
                        IdMusicLabel = 1, Name = "Def Jam"
                    },
                    new MusicLabel
                    {
                        IdMusicLabel = 2, Name = "Prosto"
                    });
            });
            
            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(e => e.PublishDate).IsRequired();
                a.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                a.HasData(
                    new Album
                    {
                        IdAlbum = 1, AlbumName = "Heeeeyaaah", PublishDate = DateTime.Now, IdMusicLabel = 2
                    },
                    new Album
                    {
                        IdAlbum = 2, AlbumName = "Stairway to heaven", PublishDate = DateTime.Now, IdMusicLabel = 1
                    }
                );
            });

            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();

                t.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                t.HasData(
                    new Track
                    {
                        IdTrack = 1, TrackName = "I know", Duration = 2.56f, IdMusicAlbum = 2
                    },
                    new Track
                    {
                        IdTrack = 2, TrackName = "Hello", Duration = 3.12f, IdMusicAlbum = 1
                    });
            });

            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.Nickname).HasMaxLength(20);

                m.HasData(
                    new Musician
                    {
                        IdMusician = 1, FirstName = "Jan", LastName = "Kowalski", Nickname = "Borys"
                    },
                    new Musician
                    {
                        IdMusician = 2, FirstName = "Donald", LastName = "Tusk", Nickname = "Donek"
                    });
            });

            modelBuilder.Entity<Musician_Track>(mt =>
            {
                mt.HasKey(e => new
                {
                    e.IdMusician,
                    e.IdTrack
                });
                mt.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician);
                mt.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);

                mt.HasData(new Musician_Track
                    {
                        IdMusician = 1, IdTrack = 1
                    },
                    new Musician_Track
                    {
                        IdMusician = 2, IdTrack = 2
                    });
            });
        }
    }
        
}