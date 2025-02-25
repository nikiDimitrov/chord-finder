using Chord_Finder.Model;
using Chord_Finder.Services;

namespace Chord_Finder.Helpers
{
    public static class ChordTracker
    {
        private static readonly AppDbContext _dbContext = new AppDbContext();
        private static List<Chord> detectedChords = new List<Chord>();

        public static void ProcessNotes(List<Note> notes) //connect notes to chords
        {
            List<Note> sortedNotes = notes.OrderBy(n => n.Name).ToList();

            //if(_dbContext.Chords.
        }
    }
}
