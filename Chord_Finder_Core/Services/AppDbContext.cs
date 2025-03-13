using Chord_Finder_Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Chord_Finder_Core.Services
{
    public class AppDbContext : DbContext
    {
        private const string DatabaseFilename = "chord-finder.db";
        private readonly string DatabasePath;

        public DbSet<Chord> Chords { get; set; }
        public DbSet<ChordType> ChordTypes { get; set; }
        public DbSet<Note> Notes { get; set; }

        public AppDbContext()
        {
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseLazyLoadingProxies()
                .UseSqlite($"Filename={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Note
            modelBuilder.Entity<Note>()
                .Property(n => n.ID)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ChordType>()
                .Property(ct => ct.ID)
                .HasDefaultValueSql("NEWID()");

            List<Note> notes = DatabaseSeeder.SeedNotes();
            List<ChordType> chordTypes = DatabaseSeeder.SeedChordTypes();
            List<Chord> chords = DatabaseSeeder.SeedChords(chordTypes);

            modelBuilder.Entity<Note>().HasData(notes);
            modelBuilder.Entity<ChordType>().HasData(chordTypes);
            modelBuilder.Entity<Chord>().HasData(chords);

            modelBuilder.Entity<Chord>()
                .HasOne(c => c.ChordType)
                .WithMany(ct => ct.Chords)
                .HasForeignKey(c => c.ChordTypeID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
