using Chord_Finder.Helpers;
using Chord_Finder.Model;

namespace Chord_Finder.Services
{
    public static class DatabaseSeeder
    {
        private static AppDbContext _dbContext = new AppDbContext();

        private static ChordType major             = new ChordType(new Guid("990fab01-5ffc-4f3f-b0bf-842ff6545584"), "Major", "A chord with a root, major third, and perfect fifth.");
        private static ChordType minor             = new ChordType(new Guid("9e5c9249-4d35-4d29-8d23-e54403e09096"), "Minor", "A chord with a root, minor third, and perfect fifth.");
        private static ChordType diminished        = new ChordType(new Guid("d3e1aafa-22f7-4af5-811f-c6e91425599b"), "Diminished", "A chord with a root, minor third, and diminished fifth.");
        private static ChordType augmented         = new ChordType(new Guid("946f837a-4e02-4fbe-9e1a-c0b06353e591"), "Augmented", "A chord with a root, major third, and augmented fifth.");
        private static ChordType dominantSeventh   = new ChordType(new Guid("d0c96509-8257-4bfb-9e70-40d732f70407"), "Dominant Seventh", "A chord with a root, major third, perfect fifth, and minor seventh.");
        private static ChordType majorSeventh      = new ChordType(new Guid("5740d61d-f0b7-4410-aa1b-01e68a455778"), "Major Seventh", "A chord with a root, major third, perfect fifth, and major seventh.");
        private static ChordType minorSeventh      = new ChordType(new Guid("859cd9b1-b459-44de-bfb9-8259f920cc72"), "Minor Seventh", "A chord with a root, minor third, perfect fifth, and minor seventh.");
        private static ChordType halfDiminished    = new ChordType(new Guid("e8bde2fa-8eef-4198-a8b1-ff47827b6f3f"), "Half-Diminished", "A chord with a root, minor third, diminished fifth, and minor seventh.");
        private static ChordType diminishedSeventh = new ChordType(new Guid("609073bd-e890-43fb-87af-b3e5eeda770a"), "Diminished Seventh", "A chord with a root, minor third, diminished fifth, and diminished seventh.");
        private static ChordType suspendedSecond   = new ChordType(new Guid("03a94c03-b3e0-4539-8345-1a302361ecaa"), "Suspended Second", "A chord with a root, major second, and perfect fifth.");
        private static ChordType suspendedFourth   = new ChordType(new Guid("23419013-f6c3-4d1b-8a30-f3c3c4c59276"), "Suspended Fourth", "A chord with a root, perfect fourth, and perfect fifth.");

        public static void Seed()
        {
            if(!_dbContext.ChordTypes.Any())
            {
                _dbContext.ChordTypes.AddRange(major, minor, diminished, augmented, dominantSeventh, majorSeventh, minorSeventh, halfDiminished, diminishedSeventh, suspendedSecond, suspendedFourth);
                _dbContext.SaveChanges();
            }

            if(!_dbContext.Chords.Any())
            {
                Chord[] cChords =
                {
                    new Chord("C", major, "C-E-G"),
                    new Chord("Cm", minor, "C-D#/Eb-G"),
                    new Chord("Cdim", diminished, "C-D#/Eb-F#/Gb"),
                    new Chord("Caug", augmented, "C-E-G#/Ab"),
                    new Chord("C7", dominantSeventh, "C-E-G-A#/Bb"),
                    new Chord("Cmaj7", majorSeventh, "C-E-G-B"),
                    new Chord("Cmin7", minorSeventh, "C-D#/Eb-G-A#/Bb"),
                    new Chord("Cø7", halfDiminished, "C-D#/Eb-A#/Gb-A#/Bb"),
                    new Chord("Cdim7", diminishedSeventh, "C-D#/Eb-F#/Gb-A"),
                    new Chord("Csus2", suspendedSecond, "C-D-G"),
                    new Chord("Csus4", suspendedFourth, "C-F-G"),
                };

                _dbContext.Chords.AddRange(cChords);

                //add chords dynamically for all remaining notes from chromatic scale
                for (int i = 1; i < 8; i++)
                {
                    foreach (Chord chord in cChords)
                    {
                        Chord newChord = NoteTransposer.TransposeChord(chord, i);
                        _dbContext.Chords.Add(newChord);
                    }
                }

                _dbContext.SaveChanges();
            }   
        }
    }
}
