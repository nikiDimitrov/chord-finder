using Chord_Finder_Core.Helpers;
using Chord_Finder_Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            //Debugger.Launch();
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
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

            string[] noteNames =
            {
                "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8",
                "C#0/Db0", "C#1/Db1", "C#2/Db2", "C#3/Db3", "C#4/Db4", "C#5/Db5", "C#6/Db6", "C#7/Db7", "C#8/Db8",
                "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8",
                "D#0/Eb0", "D#1/Eb1", "D#2/Eb2", "D#3/Eb3", "D#4/Eb4", "D#5/Eb5", "D#6/Eb6", "D#7/Eb7", "D#8/Eb8",
                "E0", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8",
                "F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8",
                "F#0/Gb0", "F#1/Gb1", "F#2/Gb2", "F#3/Gb3", "F#4/Gb4", "F#5/Gb5", "F#6/Gb6", "F#7/Gb7", "F#8/Gb8",
                "G0", "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8",
                "G#0/Ab0", "G#1/Ab1", "G#2/Ab2", "G#3/Ab3", "G#4/Ab4", "G#5/Ab5", "G#6/Ab6", "G#7/Ab7", "G#8/Ab8",
                "A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8",
                "A#0/Bb0", "A#1/Bb1", "A#2/Bb2", "A#3/Bb3", "A#4/Bb4", "A#5/Bb5", "A#6/Bb6", "A#7/Bb7", "A#8/Bb8",
                "B0", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8"
            };

            double[] frequencies =
            {
                16.35, 32.70, 65.41, 130.81, 261.63, 523.25, 1046.50, 2093.00, 4186.01,
                17.32, 34.65, 69.30, 138.59, 277.18, 554.37, 1108.73, 2217.46, 4434.92,
                18.35, 36.71, 73.42, 146.83, 293.66, 587.33, 1174.66, 2349.32, 4698.63,
                19.45, 38.89, 77.78, 155.56, 311.13, 622.25, 1244.51, 2489.02, 4978.03,
                20.60, 41.20, 82.41, 164.81, 329.63, 659.25, 1318.51, 2637.02, 5274.04,
                21.83, 43.65, 87.31, 174.61, 349.23, 698.46, 1396.91, 2793.83, 5587.65,
                23.12, 46.25, 92.50, 185.00, 369.99, 739.99, 1479.98, 2959.96, 5919.91,
                24.50, 49.00, 98.00, 196.00, 392.00, 783.99, 1567.98, 3135.96, 6271.93,
                25.96, 51.91, 103.83, 207.65, 415.30, 830.61, 1661.22, 3322.44, 6644.88,
                27.50, 55.00, 110.00, 220.00, 440.00, 880.00, 1760.00, 3520.00, 7040.00,
                29.14, 58.27, 116.54, 233.08, 466.16, 932.33, 1864.66, 3729.31, 7458.62,
                30.87, 61.74, 123.47, 246.94, 493.88, 987.77, 1975.53, 3951.07, 7902.13
            };

            List<Note> notes = new List<Note>();
            for (int i = 0; i < noteNames.Length; i++)
            {
                int category = (i / 9) + 1; //group notes by octave
                int index = (i % 9) + 1;    //assign index within group

                notes.Add(new Note(noteNames[i], frequencies[i], UuidGenerator.GenerateUuid(category, index)));
            }

            modelBuilder.Entity<Note>().HasData(notes);

            modelBuilder.Entity<ChordType>().HasData(
                new ChordType("Major", "A chord with a root, major third, and perfect fifth.", Guid.Parse("6c9ea46b-9625-4bef-bc6e-ee72da9ae732")),
                new ChordType("Minor", "A chord with a root, minor third, and perfect fifth.", Guid.Parse("fcc4ea0f-1545-4fa8-a759-a26d9cf24486")),
                new ChordType("Diminished", "A chord with a root, minor third, and diminished fifth.", Guid.Parse("aabd075a-b201-473b-ad0f-d0d875ef1584")),
                new ChordType("Augmented", "A chord with a root, major third, and augmented fifth.", Guid.Parse("b289393b-d8e7-4db7-bf1d-d83caaf71704")),
                new ChordType("Dominant Seventh", "A chord with a root, major third, perfect fifth, and minor seventh.", Guid.Parse("be08b4ae-f8f1-4518-bfec-f71b009a6006")),
                new ChordType("Major Seventh", "A chord with a root, major third, perfect fifth, and major seventh.", Guid.Parse("53fb45c9-8bb9-492e-9dac-258a460621cc")),
                new ChordType("Minor Seventh", "A chord with a root, minor third, perfect fifth, and minor seventh.", Guid.Parse("ddd178b1-1421-4d3c-a21d-ce1bd63ee8c7")),
                new ChordType("Half-Diminished", "A chord with a root, minor third, diminished fifth, and minor seventh.", Guid.Parse("b449187c-cd70-4ca3-bd1d-3a5152d8b13c")),
                new ChordType("Diminished Seventh", "A chord with a root, minor third, diminished fifth, and diminished seventh.", Guid.Parse("c7e1c758-87a8-4c00-9445-be26e069ec14")),
                new ChordType("Suspended Second", "A chord with a root, major second, and perfect fifth.", Guid.Parse("46c55a1e-f908-421a-8079-8abba03f5869")),
                new ChordType("Suspended Fourth", "A chord with a root, perfect fourth, and perfect fifth.", Guid.Parse("8d5f188c-d027-46d4-b4e8-5ed944bab598"))
            );

            modelBuilder.Entity<Chord>()
                .HasOne(c => c.ChordType)
                .WithMany(ct => ct.Chords)
                .HasForeignKey(c => c.ChordTypeID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
