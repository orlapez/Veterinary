using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{

    [ApiController]
    [Route("/api/pets")]
    public class PetsController : ControllerBase
    {
        private readonly DataContext _context;

        public PetsController(DataContext context) {

            _context = context;


        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Pets.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Post(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return Ok(pet);
        }   
    }
}

