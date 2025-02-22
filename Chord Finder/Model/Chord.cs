using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chord_Finder.Model
{
    public class Chord
    {
        [Key]
        private Guid id;
        private string name;

        [ForeignKey("ChordType")]
        private Guid chordTypeID;
        private ChordType chordType;

        private string noteIds;

        public Guid ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if(String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Chord name cannot be null!");
                }
                else
                {
                    name = value;
                }
            }
        }

        public Guid ChordTypeID
        {
            get { return chordTypeID; }
            private set { chordTypeID = value; }
        }

        public ChordType ChordType
        {
            get { return chordType; }
            private set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Chord type cannot be null!");
                }
                else
                {
                    chordType = value;
                }
            }
        }

        public string NoteIds 
        { 
            get { return noteIds; } 
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Notes cannot be null!");
                }
                else
                {
                    noteIds = value;
                }
            }
        } 

        [NotMapped]
        public List<Guid> NoteIdList
        {
            get => NoteIds?.Split(',').Select(Guid.Parse).ToList() ?? new List<Guid>();
            set => NoteIds = string.Join(",", value);
        }

        public Chord(string name, ChordType chordType, params Guid[] noteIds)
        {
            id = Guid.NewGuid();
            Name = name;
            ChordType = chordType;

            if(chordType.ID != Guid.Empty)
            {
                ChordTypeID = chordType.ID;
            }

            NoteIdList = noteIds.ToList();
        }
    }
}
