using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{

    [ApiController]
    [Route("/api/owners")]
    public class OwnersController:ControllerBase
    {

        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;
        }

        //Select * from Owners
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Owners.ToListAsync());


        }

        //Select * from Owners where Id = 1
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> Get(int id)
        {

         var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
            if (owner == null)
            {
                return NotFound(); //404
            }
            return Ok(owner);


        }

        //Insert into Owners (Document, FirstName, LastName, FixedPhone, CellPhone, Address) values ('123456789', 'John', 'Doe', '123-456-7890', '098-765-4321', '123 Main St')
        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {
            _context.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }









    }
}
