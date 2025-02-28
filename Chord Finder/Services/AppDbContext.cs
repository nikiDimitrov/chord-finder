﻿using Chord_Finder.Model;
using Microsoft.EntityFrameworkCore;

namespace Chord_Finder.Services
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
            DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>().HasData(
                // C Notes
                new Note("C0", 16.35), new Note("C1", 32.70), new Note("C2", 65.41), new Note("C3", 130.81),
                new Note("C4", 261.63), new Note("C5", 523.25), new Note("C6", 1046.50), new Note("C7", 2093.00),
                new Note("C8", 4186.01),

                // C#/Db Notes
                new Note("C#0/Db0", 17.32), new Note("C#1/Db1", 34.65), new Note("C#2/Db2", 69.30), new Note("C#3/Db3", 138.59),
                new Note("C#4/Db4", 277.18), new Note("C#5/Db5", 554.37), new Note("C#6/Db6", 1108.73), new Note("C#7/Db7", 2217.46),
                new Note("C#8/Db8", 4434.92),

                // D Notes
                new Note("D0", 18.35), new Note("D1", 36.71), new Note("D2", 73.42), new Note("D3", 146.83),
                new Note("D4", 293.66), new Note("D5", 587.33), new Note("D6", 1174.66), new Note("D7", 2349.32),
                new Note("D8", 4698.63),

                // D#/Eb Notes
                new Note("D#0/Eb0", 19.45), new Note("D#1/Eb1", 38.89), new Note("D#2/Eb2", 77.78), new Note("D#3/Eb3", 155.56),
                new Note("D#4/Eb4", 311.13), new Note("D#5/Eb5", 622.25), new Note("D#6/Eb6", 1244.51), new Note("D#7/Eb7", 2489.02),
                new Note("D#8/Eb8", 4978.03),

                // E Notes
                new Note("E0", 20.60), new Note("E1", 41.20), new Note("E2", 82.41), new Note("E3", 164.81),
                new Note("E4", 329.63), new Note("E5", 659.25), new Note("E6", 1318.51), new Note("E7", 2637.02),
                new Note("E8", 5274.04),

                // F Notes
                new Note("F0", 21.83), new Note("F1", 43.65), new Note("F2", 87.31), new Note("F3", 174.61),
                new Note("F4", 349.23), new Note("F5", 698.46), new Note("F6", 1396.91), new Note("F7", 2793.83),
                new Note("F8", 5587.65),

                // F#/Gb Notes
                new Note("F#0/Gb0", 23.12), new Note("F#1/Gb1", 46.25), new Note("F#2/Gb2", 92.50), new Note("F#3/Gb3", 185.00),
                new Note("F#4/Gb4", 369.99), new Note("F#5/Gb5", 739.99), new Note("F#6/Gb6", 1479.98), new Note("F#7/Gb7", 2959.96),
                new Note("F#8/Gb8", 5919.91),

                // G Notes
                new Note("G0", 24.50), new Note("G1", 49.00), new Note("G2", 98.00), new Note("G3", 196.00),
                new Note("G4", 392.00), new Note("G5", 783.99), new Note("G6", 1567.98), new Note("G7", 3135.96),
                new Note("G8", 6271.93),

                // G#/Ab Notes
                new Note("G#0/Ab0", 25.96), new Note("G#1/Ab1", 51.91), new Note("G#2/Ab2", 103.83), new Note("G#3/Ab3", 207.65),
                new Note("G#4/Ab4", 415.30), new Note("G#5/Ab5", 830.61), new Note("G#6/Ab6", 1661.22), new Note("G#7/Ab7", 3322.44),
                new Note("G#8/Ab8", 6644.88),

                // A Notes
                new Note("A0", 27.50), new Note("A1", 55.00), new Note("A2", 110.00), new Note("A3", 220.00),
                new Note("A4", 440.00), new Note("A5", 880.00), new Note("A6", 1760.00), new Note("A7", 3520.00),
                new Note("A8", 7040.00),

                // A#/Bb Notes
                new Note("A#0/Bb0", 29.14), new Note("A#1/Bb1", 58.27), new Note("A#2/Bb2", 116.54), new Note("A#3/Bb3", 233.08),
                new Note("A#4/Bb4", 466.16), new Note("A#5/Bb5", 932.33), new Note("A#6/Bb6", 1864.66), new Note("A#7/Bb7", 3729.31),
                new Note("A#8/Bb8", 7458.62),

                // B Notes
                new Note("B0", 30.87), new Note("B1", 61.74), new Note("B2", 123.47), new Note("B3", 246.94),
                new Note("B4", 493.88), new Note("B5", 987.77), new Note("B6", 1975.53), new Note("B7", 3951.07),
                new Note("B8", 7902.13)
            );
        }
    }
}
