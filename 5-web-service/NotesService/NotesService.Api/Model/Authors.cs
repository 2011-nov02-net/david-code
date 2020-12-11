using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Api.Model
{
    public class Authors
    {
        private readonly ICollection<Author> _authors = new List<Author>();

        public Authors()
        {
            _authors.Add(new() {Id = 1, Name = "David", NotesId = {1, 2} });
            _authors.Add(new() {Id = 2, Name = "Steve", NotesId = {3, 4} });
        }

        public bool AddAuthor(Author author)
        {
            if (author.Id == default)
            {
                author.Id = _authors.Max(x => x.Id) + 1;
            }
            else if (_authors.Any(x => x.Id == author.Id))
            {
                return false;
            }
            _authors.Add(author);
            return true;
        }
    }
}
