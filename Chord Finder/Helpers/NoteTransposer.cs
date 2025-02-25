namespace Chord_Finder.Helpers
{
    public class NoteTransposer
    {
        private static readonly List<string> chromaticScale = new List<string>()
        {
            "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab", "A", "A#/Bb", "B"
        };

        public static string Transpose(string note, int semitones)
        {
            int index = chromaticScale.IndexOf(note);

            if (index == -1)
            {
                throw new ArgumentException($"Invalid note: {note}");
            }

            int newIndex = (index + semitones) % chromaticScale.Count;

            return chromaticScale[newIndex];
        }

        public static List<string> TransposeChord(List<string> chordNotes, int semitones)
        {
            List<string> transposedChord = new List<string>();

            foreach (var note in chordNotes)
            {
                transposedChord.Add(Transpose(note, semitones));
            }

            return transposedChord;
        }
    }
}
