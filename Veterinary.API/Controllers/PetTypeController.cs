using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;


namespace Veterinary.API.Controllers
{

    [ApiController]
    [Route("/api/pettypes")]
    public class PetTypeController : ControllerBase
    {

        private readonly DataContext _context;


        public PetTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.PetTypes.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> Post(PetType pettype)
        {
            _context.PetTypes.Add(pettype);
            await _context.SaveChangesAsync();
            return Ok(pettype);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, PetType petType)
        {
            _context.PetTypes.Update(petType);
            await _context.SaveChangesAsync();
            return Ok(petType);
        }


        //Delete from Owners where Id = 1
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pettypes = await _context.PetTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (pettypes == null)
            {
                return NotFound(); //404
            }
            _context.Remove(pettypes);
            await _context.SaveChangesAsync();
            return NoContent(); //204
        }

    }

}