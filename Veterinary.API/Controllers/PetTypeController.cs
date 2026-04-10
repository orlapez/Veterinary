using Microsoft.AspNetCore.Mvc;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Veterinary.API.Controllers
{

    [ApiController]
    [Route("/api/pettypes")]
    public class PetTypeController:Controller
    {
        private readonly DataContext _context;

        public PetTypeController(DataContext context)
        {
            _context = context;


        }


        // GET: api/owners --Tipo listado de propietarios- Select * from Owners
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.PetTypes.ToListAsync());

        }


        //Get By Id -- Tipo Select * from Owners where Id = 1

        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var pettypes = await _context.PetTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (pettypes == null)
            {
                return NotFound();



            }

            return Ok(pettypes);

        }

        // POST: api/owners -- Tipo Insert into Owners (Document, FirstName, LastName, FixedPhone, CellPhone, Address) values ('12345678', 'John', 'Doe', '555-1234', '555-5678', '123 Main St')
        [HttpPost]
        public async Task<ActionResult> Post(PetType pettypes)
        {

            _context.Add(pettypes);
            await _context.SaveChangesAsync();
            return Ok(pettypes);
        }

        // PUT: api/owners -- Tipo Update Owners set Document = '87654321', FirstName = 'Jane', LastName = 'Smith', FixedPhone = '555-4321', CellPhone = '555-8765', Address = '456 Elm St' where Id = 1
        [HttpPut]

        public async Task<ActionResult> Put(PetType pettypes)
        {

            _context.Update(pettypes);
            await _context.SaveChangesAsync();
            return Ok(pettypes);
        }

        

        // DELETE: api/owners/id -- Tipo Delete from Owners where Id = 1

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.PetTypes
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (filasAfectadas == 0)
            {
                return NotFound(); //404


            }

            return NoContent(); //204

        }




    }
}
