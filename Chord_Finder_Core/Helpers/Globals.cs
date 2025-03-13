namespace Chord_Finder_Core.Helpers
{
    public static class Globals
    {
        internal static readonly List<string> chromaticScale = new List<string>()
        {
            "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab", "A", "A#/Bb", "B"
        };

        internal static string noteRegexPattern = "[^1-9]";
        internal static string chordNameWithoutRootRegexPattern = "[^(A-G)#|b\\/(A-G)#|b]+";

        internal static string notePrefix = "Note";
        internal static string chordTypePrefix = "CType";
        internal static string chordPrefix = "Chord";
    }
}
