using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Api.Model
{
    public class Author
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<int> NotesId { get; set; }
    }
}
