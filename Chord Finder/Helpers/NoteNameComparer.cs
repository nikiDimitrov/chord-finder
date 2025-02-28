using Chord_Finder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chord_Finder.Helpers
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
