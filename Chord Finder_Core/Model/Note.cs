namespace Chord_Finder_Core.Model
{
    public class Note
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Frequency { get; set; }

        public Note()
        {
            
        }

        public Note(string name, double frequency, Guid? id = null)
        {
            ID = id ?? Guid.Empty;
            Name = name;
            Frequency = frequency;
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
