using Microsoft.IdentityModel.Tokens;


namespace Chord_Finder_Core.Model
{
    public class Chord
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid ChordTypeID { get; set; }
        public ChordType ChordType { get; set; }

        public string Notes { get; set; }

        public Chord()
        {
            
        }
        public Chord(string name, ChordType chordType, string notes, Guid? id = null)
        {
            ID = id ?? Guid.NewGuid();
            Name = name;
            ChordType = chordType;
            Notes = notes;
        }
    }
}
