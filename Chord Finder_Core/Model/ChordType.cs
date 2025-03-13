using System.ComponentModel.DataAnnotations;

namespace Chord_Finder_Core.Model
{
    public class ChordType
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Chord> Chords { get; set; } = null!;

        public ChordType()
        {
            
        }
        public ChordType(string name, string description, Guid? id = null)
        {
            ID = id ?? Guid.NewGuid();
            Name = name;
            Description = description;
        }
    }
}
