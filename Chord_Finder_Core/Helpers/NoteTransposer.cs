using Chord_Finder_Core.Model;
using System.Text.RegularExpressions;

namespace Chord_Finder_Core.Helpers
{
    using static Globals;

    public class NoteTransposer
    {
        private static Regex chordNameWithoutRootRegex = new Regex(chordNameWithoutRootRegexPattern);

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

        public static Chord TransposeChord(Chord chordToTranspose, int semitones)
        {
            //transpose notes
            List<string> transposedNotesList = new List<string>();

            List<string> chordNotesSplit = chordToTranspose.Notes.Split('-').ToList();

            foreach (var note in chordNotesSplit)
            {
                transposedNotesList.Add(Transpose(note, semitones));
            }

            string transposedNotes = string.Join('-', transposedNotesList);

            string oldChordName = chordToTranspose.Name;
            string newChordName;

            if (chordToTranspose.Name.Length > 1)
            {
                newChordName = transposedNotesList[0] + chordNameWithoutRootRegex.Match(oldChordName).Value;
            }
            else
            {
                newChordName = $"{transposedNotesList[0]}";
            }

            return new Chord(newChordName, chordToTranspose.ChordTypeID, transposedNotes);
        }
    }
}
