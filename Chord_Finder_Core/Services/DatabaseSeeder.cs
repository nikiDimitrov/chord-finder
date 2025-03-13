using Chord_Finder_Core.Helpers;
using Chord_Finder_Core.Model;

namespace Chord_Finder_Core.Services
{
    using static Globals;
    public static class DatabaseSeeder
    {
        public static List<Note> SeedNotes()
        {
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
                notes.Add(new Note(noteNames[i], frequencies[i], UuidGenerator.GenerateUuid(notePrefix, i + 1)));
            }

            return notes;
        }

        public static List<ChordType> SeedChordTypes()
        {
            List<ChordType> chordTypes = new List<ChordType>()
            {                 
                new ChordType("Major", "A chord with a root, major third, and perfect fifth.", UuidGenerator.GenerateUuid(chordTypePrefix, 1)),
                new ChordType("Minor", "A chord with a root, minor third, and perfect fifth.", UuidGenerator.GenerateUuid(chordTypePrefix, 2)),
                new ChordType("Diminished", "A chord with a root, minor third, and diminished fifth.", UuidGenerator.GenerateUuid(chordTypePrefix, 3)),
                new ChordType("Augmented", "A chord with a root, major third, and augmented fifth.", UuidGenerator.GenerateUuid(chordTypePrefix, 4)),
                new ChordType("Dominant Seventh", "A chord with a root, major third, perfect fifth, and minor seventh.", UuidGenerator.GenerateUuid(chordTypePrefix, 5)),
                new ChordType("Major Seventh", "A chord with a root, major third, perfect fifth, and major seventh.", UuidGenerator.GenerateUuid(chordTypePrefix, 6)),
                new ChordType("Minor Seventh", "A chord with a root, minor third, perfect fifth, and minor seventh.", UuidGenerator.GenerateUuid(chordTypePrefix, 7)),
                new ChordType("Half-Diminished", "A chord with a root, minor third, diminished fifth, and minor seventh.", UuidGenerator.GenerateUuid(chordTypePrefix, 8)),
                new ChordType("Diminished Seventh", "A chord with a root, minor third, diminished fifth, and diminished seventh.", UuidGenerator.GenerateUuid(chordTypePrefix, 9)),
                new ChordType("Suspended Second", "A chord with a root, major second, and perfect fifth.", UuidGenerator.GenerateUuid(chordTypePrefix, 10)),
                new ChordType("Suspended Fourth", "A chord with a root, perfect fourth, and perfect fifth.", UuidGenerator.GenerateUuid(chordTypePrefix, 11))
            };

            return chordTypes;
        }
        public static List<Chord> SeedChords(List<ChordType> chordTypes)
        {
            List<Chord> chords = new List<Chord>();

            Dictionary<string, Guid> chordTypesDict = chordTypes.ToDictionary(ct => ct.Name, ct => ct.ID);

            Chord[] cChords =
            {
                new Chord("C", chordTypesDict["Major"], "C-E-G", UuidGenerator.GenerateUuid(chordPrefix, 1)),
                new Chord("Cm", chordTypesDict["Minor"], "C-D#/Eb-G", UuidGenerator.GenerateUuid(chordPrefix, 2)),
                new Chord("Cdim", chordTypesDict["Diminished"], "C-D#/Eb-F#/Gb", UuidGenerator.GenerateUuid(chordPrefix, 3)),
                new Chord("Caug", chordTypesDict["Augmented"], "C-E-G#/Ab", UuidGenerator.GenerateUuid(chordPrefix, 4)),
                new Chord("C7", chordTypesDict["Dominant Seventh"], "C-E-G-A#/Bb", UuidGenerator.GenerateUuid(chordPrefix, 5)),
                new Chord("Cmaj7", chordTypesDict["Major Seventh"], "C-E-G-B", UuidGenerator.GenerateUuid(chordPrefix, 6)),
                new Chord("Cmin7", chordTypesDict["Minor Seventh"], "C-D#/Eb-G-A#/Bb", UuidGenerator.GenerateUuid(chordPrefix, 7)),
                new Chord("Cø7", chordTypesDict["Half-Diminished"], "C-D#/Eb-F#/Gb-A#/Bb", UuidGenerator.GenerateUuid(chordPrefix, 8)),
                new Chord("Cdim7", chordTypesDict["Diminished Seventh"], "C-D#/Eb-F#/Gb-A", UuidGenerator.GenerateUuid(chordPrefix, 9)),
                new Chord("Csus2", chordTypesDict["Suspended Second"], "C-D-G", UuidGenerator.GenerateUuid(chordPrefix, 10)),
                new Chord("Csus4", chordTypesDict["Suspended Fourth"], "C-F-G", UuidGenerator.GenerateUuid(chordPrefix, 11)),
            };

            chords.AddRange(cChords);

            //add chords dynamically for all remaining notes from chromatic scale
            for (int i = 1, j = 12; i < 8; i++, j++)
            {
                foreach (Chord chord in cChords)
                {
                    Chord newChord = NoteTransposer.TransposeChord(chord, i);
                    newChord.ID = UuidGenerator.GenerateUuid(chordPrefix, j);
                    j++;
                    chords.Add(newChord);
                }
            }

            return chords;
        }
    }
}
