using System.ComponentModel.DataAnnotations;

namespace Chord_Finder.Model
{
    public class Note
    {
        [Key]
        private Guid id;
        private string name;
        private double frequency;

        public Guid ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                value = value.ToUpper();
                if (value == " ")
                {
                    throw new InvalidDataException("Note name shouldn't be empty!");
                }
                else
                {
                    name = value;
                }
            }
        }

        public double Frequency
        {
            get { return frequency; }
            private set 
            {
                if(value < 0)
                {
                    throw new InvalidDataException("Frequency can't be negative!");
                }
                else
                {
                    frequency = value;
                }
            }
        }

        public Note(string name, double frequency)
        {
            id = Guid.NewGuid();
            Name = name;
            Frequency = frequency;
        }
    }
}
