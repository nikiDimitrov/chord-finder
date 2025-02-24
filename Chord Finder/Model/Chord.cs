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

        private List<Note> notes;

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

        public List<Note> Notes
        {
            get { return notes; }
            set
            {
                if(Notes.IsNullOrEmpty())
                {
                    throw new ArgumentNullException("Chord cannot have no notes!");
                }
                else if(Notes.Count < 2)
                {
                    throw new InvalidDataException("Chord cannot have fewer than 2 notes - it's not a chord!");
                }
                else
                {
                    notes = value;
                }
            }
        }

        public Chord(string name, ChordType chordType, params Note[] notes)
        {
            id = Guid.NewGuid();
            Name = name;
            ChordType = chordType;

            if(chordType.ID != Guid.Empty)
            {
                ChordTypeID = chordType.ID;
            }

            Notes = notes.ToList();
        }
    }
}
