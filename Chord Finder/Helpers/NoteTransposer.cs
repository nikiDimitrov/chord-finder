using Chord_Finder.Model;
using System.Text.RegularExpressions;

namespace Chord_Finder.Helpers
{
    using static Globals;

    public class NoteTransposer
    {
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

            string newChordName;
            if(chordToTranspose.Name.Length > 1)
            {
                newChordName = $"{transposedNotesList[0]}{chordToTranspose.Name.Skip(1)}";
            }
            else
            {
                newChordName = $"{transposedNotesList[0]}";
            }

            return new Chord(newChordName, chordToTranspose.ChordType, transposedNotes);
        }
    }
}
