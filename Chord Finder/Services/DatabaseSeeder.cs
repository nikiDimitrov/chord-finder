namespace Chord_Finder.Services
{
    public static class DatabaseSeeder
    {
        //TODO: save chords of c major key in database and seed the others dynamically. link the notes and chords with the "c-e-g" format
        private static AppDbContext _dbContext = new AppDbContext();
        private static readonly List<string> chromaticScale = new List<string>()
        {
            "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab", "A", "A#/Bb", "B"
        };

        public static void SeedAllKeys()
        {
            for(int i = 1; i < chromaticScale.Count; i++)
            {
                //to finish
            }
        }
    }
}
