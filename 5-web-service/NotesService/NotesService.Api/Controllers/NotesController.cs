using Microsoft.AspNetCore.Mvc;
using NotesService.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Api.Controllers
{
    [Route("api/notes")]
    public class NotesController : Controller
    {
        private readonly Notes _notes;

        public NotesController(Notes notes)
        {
            _notes = notes;
        }

        // Get /api/notes
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_notes.AllNotes); 
        }

        // Get /api/notes/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_notes.GetNote(id));
        }
    }
}
