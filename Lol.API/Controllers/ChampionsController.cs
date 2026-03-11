using Lol.API.Models.DbMysqlModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Lol.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private readonly ChampsContext _context = new ChampsContext();

        [HttpGet("/api/champions")]
        public async Task<IActionResult> GetAllChampions()
        {
            var champs = await _context.Orders.Select(x => x).ToListAsync();

            if (champs == null)
            {
                return NotFound("Nincs adat");
            }
            return Ok(new { champs = champs });
        }
        [HttpGet("/api/champions/id")]
        public async Task<IActionResult> GetAllChampionsById([FromQuery] int id)
        {
            var champofid = await _context.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (champofid == null)
            {
                return NotFound("Nincs adat");
            }
            return Ok(new { champs = champofid });
        }

    }
}
