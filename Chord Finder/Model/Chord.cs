using Microsoft.IdentityModel.Tokens;
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

        private string notes;

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

        public string Notes
        {
            get { return notes; }
            set
            {
                if(notes.IsNullOrEmpty())
                {
                    throw new ArgumentNullException("Chord cannot have no notes!");
                }
                else
                {
                    notes = value;
                }
            }
        }

        public Chord(Guid id, string name, ChordType chordType, string notes)
        {
            this.id = id;
            Name = name;
            ChordType = chordType;

            if (chordType.ID != Guid.Empty)
            {
                ChordTypeID = chordType.ID;
            }

            Notes = notes;
        }

        public Chord(string name, ChordType chordType, string notes)
        {
            id = Guid.NewGuid();
            Name = name;
            ChordType = chordType;

            if(chordType.ID != Guid.Empty)
            {
                ChordTypeID = chordType.ID;
            }

            Notes = notes;
        }
    }
}
