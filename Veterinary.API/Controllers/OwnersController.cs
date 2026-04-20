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


        // GET: api/owners --Tipo listado de propietarios- Select * from Owners
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Owners.ToListAsync());

        }


        //Get By Id -- Tipo Select * from Owners where Id = 1

        [HttpGet("{id:int}")]

        public async Task<ActionResult>Get(int id)
        {

            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id==id);

                if (owner == null)
            {
                return NotFound();



            }

            return Ok(owner);

        }

        // POST: api/owners -- Tipo Insert into Owners (Document, FirstName, LastName, FixedPhone, CellPhone, Address) values ('12345678', 'John', 'Doe', '555-1234', '555-5678', '123 Main St')
        [HttpPost]
        public async Task <ActionResult> Post(Owner owner)
        {

            _context.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }

        // PUT: api/owners -- Tipo Update Owners set Document = '87654321', FirstName = 'Jane', LastName = 'Smith', FixedPhone = '555-4321', CellPhone = '555-8765', Address = '456 Elm St' where Id = 1
        [HttpPut]

        public async Task<ActionResult> Put(Owner owner)
        {

            _context.Update(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }

        // PATCH: api/owners/id -- Tipo Update Owners set Document = '87654321', FirstName = 'Jane', LastName = 'Smith', FixedPhone = '555-4321', CellPhone = '555-8765', Address = '456 Elm St' where Id = 1
        [HttpPatch("id:int")]
        public async Task<ActionResult> Patch(int id, Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest();
            }
            var existingOwner = await _context.Owners.FindAsync(id);
            if (existingOwner == null)
            {
                return NotFound();
            }
            // Update only the fields that are not null or default
            if (!string.IsNullOrEmpty(owner.Document))
                existingOwner.Document = owner.Document;
            if (!string.IsNullOrEmpty(owner.FirstName))
                existingOwner.FirstName = owner.FirstName;
            if (!string.IsNullOrEmpty(owner.LastName))
                existingOwner.LastName = owner.LastName;
            if (!string.IsNullOrEmpty(owner.FixedPhone))
                existingOwner.FixedPhone = owner.FixedPhone;
            if (!string.IsNullOrEmpty(owner.CellPhone))
                existingOwner.CellPhone = owner.CellPhone;
            if (!string.IsNullOrEmpty(owner.Address))
                existingOwner.Address = owner.Address;
            await _context.SaveChangesAsync();
            return Ok(existingOwner);


        }

        // DELETE: api/owners/id -- Tipo Delete from Owners where Id = 1

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.Owners
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (filasAfectadas == 0)
            {
                return NotFound(); //404


            }

            return NoContent(); //204

        }








        }
}