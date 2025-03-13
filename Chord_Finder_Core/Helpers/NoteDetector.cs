using Chord_Finder_Core.Model;
using Chord_Finder_Core.Services;

namespace Chord_Finder_Core.Helpers
{
    public class NoteDetector
    {
        private AppDbContext _dbContext;

        public NoteDetector(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Note> DetectNotes(List<double> frequencies)
        {
            return frequencies
                .Select(freq => _dbContext.Notes
                    .OrderBy(n => Math.Abs(n.Frequency - freq))
                    .First())
                .ToList();
        }
    }
}
