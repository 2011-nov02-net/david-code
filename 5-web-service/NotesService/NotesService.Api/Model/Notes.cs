using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Api.Model
{
    public class Notes
    {
        private readonly ICollection<Note> _notes = new List<Note>();

        public IReadOnlyCollection<Note> AllNotes => new List<Note>(_notes);

        public Notes()
        {
            _notes.Add(new() {Id = 1, AuthorId = 1, DateCreated = DateTime.UtcNow, LastUpdated = DateTime.UtcNow, Subjects = new List<String>{ "Random" }, Text = "This is just a Random String of characters" });
            _notes.Add(new() {Id = 2, AuthorId = 1, DateCreated = DateTime.UtcNow, LastUpdated = DateTime.UtcNow, Subjects = new List<String> { "Computers" }, Text = "This is a note on algorithms" });
            _notes.Add(new() {Id = 3, AuthorId = 2, DateCreated = DateTime.UtcNow, LastUpdated = DateTime.UtcNow, Subjects = new List<String> { "Random" }, Text = "This is just completely Random" });
            _notes.Add(new() {Id = 4, AuthorId = 2, DateCreated = DateTime.UtcNow, LastUpdated = DateTime.UtcNow, Subjects = new List<String> { "Joke", "Pun" }, Text = "Two fishes swimming down a river. They run into a concrete wall. One turns to the other and says \"dam\"" });
        }

        public bool AddNote(Note note)
        {
            if(note.Id == default)
            {
                note.Id = _notes.Max(x => x.Id) + 1;
            }
            else if(_notes.Any(x => x.Id == note.Id))
            {
                return false;
            }
            _notes.Add(note);
            return true;
        }

        public Note GetNote(int id)
        {
            return _notes.FirstOrDefault(x => x.Id == id);
        }
    }
}
