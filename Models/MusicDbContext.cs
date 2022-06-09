using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kol2_ko_s22106.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianTrack> MusicianTracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>(builder =>
            {
                builder.ToTable("Musician");

                builder.HasKey(e => e.IdMusician);
                builder.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                builder.Property(e => e.Nickname).HasMaxLength(30);

                builder.HasData(new Musician
                {
                    IdMusician = 1,
                    FirstName = "Thom",
                    LastName = "Yorke",
                    Nickname = "Radiohead"
                });
            });

            modelBuilder.Entity<MusicianTrack>(builder =>
            {
                builder.ToTable("Musician_Track");

                builder.HasKey(e => new { e.IdMusician, e.IdTrack });

                builder.HasOne(e => e.Musician).WithMany(e => e.MusicianTrack).HasForeignKey(e => e.IdMusician);
                builder.HasOne(e => e.Track).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdTrack);

                builder.HasData(new MusicianTrack
                {
                    IdTrack = 1,
                    IdMusician = 1
                });
            });
            modelBuilder.Entity<Track>(builder =>
            {
                builder.ToTable("Track");

                builder.HasKey(e => e.IdTrack);
                builder.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                builder.Property(e => e.Duration).IsRequired();

                builder.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                builder.HasData(new Track
                {
                    IdTrack = 1,
                    TrackName = "Idioteque",
                    Duration = 2.78F,
                    IdMusicAlbum = 1
                });
            });

            modelBuilder.Entity<Album>(builder =>
            {
                builder.ToTable("Album");

                builder.HasKey(e => e.IdAlbum);
                builder.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                builder.Property(e => e.PublishDate).IsRequired();

                builder.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                builder.HasData(new Album
                {
                    IdAlbum = 1,
                    AlbumName = "Kid A Mnesia",
                    PublishDate = DateTime.Now,
                    IdMusicLabel = 1
                });
            });
            modelBuilder.Entity<MusicLabel>(builder =>
            {
                builder.ToTable("MusicLabael");

                builder.HasKey(e => e.IdMusicLabel);
                builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

                builder.HasData(new MusicLabel
                {
                    IdMusicLabel = 1,
                    Name = "Sony"
                });
            });
        }
    }
}