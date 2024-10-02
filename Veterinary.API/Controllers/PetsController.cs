using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{


    [ApiController]
    [Route("/api/pets")]

    public class PetsController:ControllerBase
    {

        private readonly DataContext _context;
        public PetsController(DataContext context)
        {

            _context = context;

        }


        //Get por Lista--- Select * From Owners
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Pets.ToListAsync());


        }


        //Get por parámetro--- Select * from Owner Where id=2
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var pet= await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (pet== null)
            {

                return NotFound();

            }
            else
            {
                return Ok(pet);



            }

        }




        // Post- insertar un nuevo Owner

        [HttpPost]

        public async Task<ActionResult> Post(Pet pet)
        {

            _context.Add(pet);
            await _context.SaveChangesAsync();

            return Ok(pet);



        }



        // Put- modificar un Owner
        [HttpPut]

        public async Task<ActionResult> Put(Pet pet)
        {

            _context.Update(pet);
            await _context.SaveChangesAsync();

            return Ok(pet);



        }



        // Delete-- Borrar un registro

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.Pets
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();






            if (FilasAfectadas == 0)
            {

                return NotFound();

            }
            else
            {
                return NoContent();



            }
        }
















    }
}
