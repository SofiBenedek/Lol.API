using Lol.API.Controllers;
using Lol.API.Models.DbMysqlModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using static Lol.API.Models.DbMysqlModels.Login;

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

            if (champs.Count == 0)
            {
                return NotFound("No Data found");
            }
            return Ok(new { champs = champs });
        }
        

        [HttpPost("/api/champions")]
        public async Task<ActionResult> AddChampion([FromBody] Order champs)
        {
            var maxid = await _context.Orders.MaxAsync(x => x.Id);
            if (string.IsNullOrEmpty(champs.Name))
                return NotFound("Champ name is necessary");

            if (string.IsNullOrEmpty(champs.Role))
                return NotFound("Champ role is necessary");

            if (string.IsNullOrEmpty(champs.Lane))
                return NotFound("Champ lane is necessary");

            if (champs.Difficulty == 0)
                return NotFound("Champ difficulty is necessary");

            if (champs.BlueEssence == 0)
                return NotFound("Champ blueessence is necessary");

            if (string.IsNullOrEmpty(champs.DamageType))
                return NotFound("Champ damagetype is necessary");

            if (string.IsNullOrEmpty(champs.Images))
                return NotFound("Champ image is necessary");

            if (string.IsNullOrEmpty(champs.Description))
                return NotFound("Champ description is necessary");
           
                if (Authenticator.loggedin)
                {
                    champs.Id = maxid + 1;
                    await _context.Orders.AddAsync(champs);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Saved", newchamp = champs });
                }
                else
                {
                    return Unauthorized(new { message = "Login is necessary"});
                }

            

        }

        [HttpGet("/api/champions/{id}")]
        public async Task<IActionResult> GetAllChampionsById(int id)
        {
            var champofid = await _context.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (champofid == null)
            {
                return NotFound("Id does not exist");
            }
            return Ok(new { champs = champofid });
        }

        [HttpDelete("/api/champions/{id}")]
        public async Task<ActionResult> DeleteChampion(int id)
        {
            var toDelete = await _context.Orders.FindAsync(id);
            if (toDelete == null)
            {
                return NotFound("Id does not exist");
            }
            else
            {
                if (Authenticator.loggedin)
                {


                    _context.Orders.RemoveRange(toDelete);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Delete was succesfull"});
                }
                else
                {
                    return Unauthorized("Login is necessary");
                }
            }

        }


    }
}