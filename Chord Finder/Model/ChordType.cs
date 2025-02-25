using System.ComponentModel.DataAnnotations;

namespace Chord_Finder.Model
{
    public class ChordType
    {
        [Key]
        private Guid id;

        private string name;
        private string description;

        public Guid ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name of chord type cannot be null!");
                }
                else
                {
                    name = value;
                }
            }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public ChordType(string name, string description)
        {
            id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public ChordType(Guid id, string name, string description)
        {
            this.id = id;
            Name = name;
            Description = description;
        }
    }
}
