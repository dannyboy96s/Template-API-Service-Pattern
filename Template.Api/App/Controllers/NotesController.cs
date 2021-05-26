using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Template.Api.Domain.Aggregates;
using Template.Api.App.Service;

namespace Template.Api.App.Controllers
{
    [ApiController]
    [Route("template-api/v1/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _service;

        public NotesController(INotesService service)
            => _service = service ?? throw new ArgumentNullException(nameof(service));

        
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CreatedResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] Notes notes) {
            var result = await _service.CreateNotesAsync(notes);
            //
            return Created($"{Request.Path.Value}/{result.Id}", result);
        }

        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] Notes notes) {
            var result = await  _service.UpdateNoteAsync(notes);
            //
            return Accepted(result);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(string id) {
            var result = await  _service.DeleteNoteAsync(id);
            //
            return Accepted(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(string id) {
            var result = await _service.GetNoteAsync(id);
            //
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync() {
            var result = await _service.GetAllAsync();
            //
            return Ok(result);
        }
    }
}