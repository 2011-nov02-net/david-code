using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Api.Model
{
    public class Note : INote
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

        public int AuthorId { get; set; }

        public ICollection<string> Subjects { get; set; }
        public string Text { get; set; }
    }
}
