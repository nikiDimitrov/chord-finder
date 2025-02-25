using Chord_Finder.Model;
using Chord_Finder.Services;


namespace Chord_Finder.Helpers
{
    public static class NoteDetector
    {
        private static readonly AppDbContext _dbContext = new AppDbContext();

        public static List<Note> DetectNotes(List<double> frequencies)
        {
            return frequencies
                .Select(freq => _dbContext.Notes
                    .OrderBy(n => Math.Abs(n.Frequency - freq))
                    .First())
                .ToList();
        }
    }
}
