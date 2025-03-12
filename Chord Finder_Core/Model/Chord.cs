namespace Chord_Finder_Core.Model
{
    public class Chord
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid ChordTypeID { get; set; }
        public virtual ChordType ChordType { get; set; }

        public string Notes { get; set; }

        public Chord()
        {
            
        }

        public Chord(string name, Guid chordTypeID, string notes, Guid? id = null)
        {
            ID = id ?? Guid.Empty;
            Name = name;
            ChordTypeID = chordTypeID;
            Notes = notes;
        }
    }
}
