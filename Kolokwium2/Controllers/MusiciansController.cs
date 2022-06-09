using System.Threading.Tasks;
using Kolokwium2.Models;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly IDbService _dbService;

        public MusiciansController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{idMusician}")]
        public async Task<IActionResult> GetMusician(int idMusician)
        {
            if (! await _dbService.CheckMusicianExists(idMusician))
            {
                return NotFound("Musician doesn't exist");
            }

            var result = await _dbService.GetMusician(idMusician);
            return Ok(result);
        }

        [HttpDelete("{idMusician}")]
        public async Task<IActionResult> DeleteMusician(int idMusician)
        {
            if (!await _dbService.CheckMusicianExists(idMusician))
            {
                return NotFound("Musician doesn't exist");
            }

            if (!await _dbService.CheckMusicianHasTracksNotOnAlbum(idMusician))
                return BadRequest("Musician has tracks on album");
            var result = await _dbService.DeleteMusician(idMusician);
            return Ok(result);
        }
        
    }
}