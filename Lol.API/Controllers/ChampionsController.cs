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

        [HttpPost("/api/champions")]
        public async Task<ActionResult> AddChampion([FromBody] Order champs)
        {
            var maxid = await _context.Orders.MaxAsync(x => x.Id);

            if (champs == null)
            {
                return NotFound("Nincs adat");
            }
            else
            {
                champs.Id = maxid + 1;
                await _context.Orders.AddAsync(champs);
                await _context.SaveChangesAsync();
                return Ok(new { newchamp = champs });
            }

        }

        [HttpGet("/api/champions/{id}")]
        public async Task<IActionResult> GetAllChampionsById(int id)
        {
            var champofid = await _context.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (champofid == null)
            {
                return NotFound("Nincs adat");
            }
            return Ok(new { champs = champofid });
        }

        [HttpDelete("/api/champions/{id}")]
        public async Task<ActionResult> DeleteChampion(int id)
        {
            var toDelete = await _context.Orders.FindAsync(id);
            if (toDelete == null)
            {
                return NotFound("Nincs adat");
            }
            else
            {
                _context.Orders.RemoveRange(toDelete);
                await _context.SaveChangesAsync();

                return Ok(new { champs = await _context.Orders.Select(x => x).ToListAsync() });
            }

        }


    }
}