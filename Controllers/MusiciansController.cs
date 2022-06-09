using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2_ko_s22106.Models.DTOs;
using kol2_ko_s22106.Services;
using Microsoft.AspNetCore.Mvc;
//using kol2-ko-s22106.Models;

namespace kol2_ko_s22106.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly IMusicService _service;
        public MusiciansController(IMusicService service)
        {
            _service = service;
        }

        [HttpGet("{IdMusician}")]
        public async Task<IActionResult> GetMusician(int IdMusician)
        {
            if (_service.GetMusicianById(IdMusician) is null)
            {
                return NotFound("Muzyk o podanym Id nie istnieje");
            }
            return Ok(await _service.GetTracksByMusician(IdMusician));
        }

        [HttpDelete("{IdMusician}")]
        public async Task<IActionResult> DeleteMusician(int IdMusician)
        {
            if (_service.GetMusicianById(IdMusician) is null)
            {
                return NotFound("Muzyk o podanym Id nie istnieje");
            }
            if (await _service.CheckMusicianTracks(IdMusician))
            {
                return BadRequest("Musician has tracks on album");
            }
            return Ok("");
        }

    }
}