using kolokwium.Models.DTOs;
using kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly IMusicianService _service;

        public MusiciansController(IMusicianService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusician(int id)
        {
            MusicianGet musician;
            try
            {
                musician = await _service.GetMusician(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(musician);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            try
            {
                await _service.DeleteMusician(id);
            }
            catch (Exception e)
            {
                if (e.Message.Equals("NotFound"))
                {
                    return NotFound("Nie ma muzyka o podanym ID");
                }

                return BadRequest("Nie można usunąć muzyka");
            }
            return Ok("Usunięto muzyka o id: "+id);
        }
    }
}
