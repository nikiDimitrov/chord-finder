using Chord_Finder.Model;
using Chord_Finder.Services;
using System.Text.RegularExpressions;
using System.Linq;

namespace Chord_Finder.Helpers
{
    using static Globals;
    public class ChordTracker
    {
        private static readonly AppDbContext _dbContext = new AppDbContext();
        private static List<Chord> detectedChords = new List<Chord>();

        public static void ProcessNotes(List<Note> notes) //connect notes to chords
        {
            List<string> abbreviatedNotesNames = new List<string>();

            foreach(Note note in notes)
            {
                string abbreviatedNoteName = Regex.Match(note.Name, noteRegexPattern).Value;
                if(!abbreviatedNotesNames.Contains(abbreviatedNoteName))
                {
                    abbreviatedNotesNames.Add(abbreviatedNoteName);
                }
            }

            abbreviatedNotesNames.Sort(new NoteNameComparer());
            string chordNotes = string.Join('-', abbreviatedNotesNames);

            Chord? foundChord = _dbContext.Chords.Where(c => c.Notes.Equals(chordNotes)).FirstOrDefault();

            if (foundChord != null)
            {
                detectedChords.Add(foundChord);
            }
        }

        public static List<Chord> GetChordSequence()
        {
            return detectedChords;
        }
    }
}
