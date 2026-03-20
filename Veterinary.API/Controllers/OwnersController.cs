using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{

    [ApiController]
    [Route("/api/owners")]
    public class OwnersController : Controller
    {
        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;


        }


        // GET: api/owners --Tipo listado de propietarios
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Owners.ToListAsync());

        }


        //Get By Id

        [HttpGet("id:int")]

        public async Task<ActionResult>Get(int id)
        {

            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id==id);

                if (owner == null)
            {
                return NotFound();



            }

            return Ok(owner);

        }

        [HttpPost]
        public async Task <ActionResult> Post(Owner owner)
        {

            _context.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);


        }















    }
}