using Chord_Finder.Model;
using Chord_Finder.Services;
using Microsoft.IdentityModel.Tokens;

namespace Chord_Finder.Helper
{
    public static class NotesStringToListHelper
    {
        private static AppDbContext _dbContext = new AppDbContext();

        public static string NotesListToString(List<Note> notes)
        {
            return string.Join('-', notes.Select(n => n.ToString()).ToList());
        }

        public static List<Note> NotesStringToList(string notesString)
        {
            List<Note> notes = new List<Note>();

            List<string> notesStringList = notesString.Split('-').ToList();
            if(notesStringList.IsNullOrEmpty())
            {
                return new List<Note>();
            }

            foreach(string noteString in notesStringList)
            {
                Note note = _dbContext.Notes.First(n => n.Name.Equals(noteString));

                if(note != null)
                {
                    notes.Add(note);
                }
            }

            return notes;
        }
    }
}
