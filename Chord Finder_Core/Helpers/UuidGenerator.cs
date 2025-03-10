using System;

namespace Chord_Finder_Core.Helpers
{
    public static class UuidGenerator
    {
        public static Guid GenerateUuid(int category, int index)
        {
            string hexCategory = category.ToString("X8"); 
            string hexIndex = index.ToString("X4"); 

            string uuidString = $"{hexCategory}-0000-0000-0000-{hexIndex}00000000";
            return Guid.Parse(uuidString);
        }
    }
}
