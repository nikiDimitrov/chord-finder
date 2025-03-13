namespace Chord_Finder_Core.Helpers
{
    using static Globals;

    public class NoteNameComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            int note1Index = chromaticScale.IndexOf(x) + 1;
            int note2Index = chromaticScale.IndexOf(y) + 1;

            return note1Index - note2Index;
        }
    }
}
