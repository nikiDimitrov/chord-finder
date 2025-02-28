using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chord_Finder.Helpers
{
    public static class Globals
    {
        internal static readonly List<string> chromaticScale = new List<string>()
        {
            "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab", "A", "A#/Bb", "B"
        };

        internal static string noteRegexPattern = "[^1-9]";

    }
}
