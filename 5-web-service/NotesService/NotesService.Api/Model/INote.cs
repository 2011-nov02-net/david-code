using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Api.Model
{
    public interface INote
    {
        public int Id { get; }
        public DateTime DateCreated { get; }
        public DateTime LastUpdated { get; }
        public int AuthorId { get; }
        public ICollection<string> Subjects { get; }
    }
}
