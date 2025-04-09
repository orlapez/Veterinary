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


        // Get para obtoner una lista de resultados
        // Select * from table

        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Pets.ToListAsync()); //200

        }



        //Get por parámetro
        //Select* from table Where Id=...

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var pet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);

            if (pet == null)
            {



                return NotFound();//404
            }

            return Ok(pet); //200

        }


        //Insertar datos o crear registros
        [HttpPost]

        public async Task<ActionResult> Post(Pet pet)
        {

            _context.Pets.Add(pet);

            await _context.SaveChangesAsync();
            return Ok(pet); //200




        }


        //Actualizar o modificar datos

        [HttpPut]

        public async Task<ActionResult> Put(Pet pet)
        {

            _context.Pets.Update(pet);

            await _context.SaveChangesAsync();
            return Ok(pet);

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Pets

               .Where(x => x.Id == id)
               .ExecuteDeleteAsync();






            if (filasafectadas == 0)
            {



                return NotFound();//404
            }

            return NoContent();//204

        }


    }
}
