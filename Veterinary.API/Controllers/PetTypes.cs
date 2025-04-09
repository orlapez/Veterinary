using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{

    [ApiController]
    [Route("/api/pettypes")]
    public class PetTypes:ControllerBase
    {


        private readonly DataContext _context;

        public PetTypes(DataContext context)
        {
                _context = context; 
        }



        // Get para obtoner una lista de resultados
        // Select * from table

        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.PetTypes.ToListAsync()); //200

        }



        //Get por parámetro
        //Select* from table Where Id=...

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var pettypes = await _context.PetTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (pettypes == null)
            {



                return NotFound();//404
            }

            return Ok(pettypes); //200

        }


        //Insertar datos o crear registros
        [HttpPost]

        public async Task<ActionResult> Post(PetType pettypes)
        {

            _context.PetTypes.Add(pettypes);

            await _context.SaveChangesAsync();
            return Ok(pettypes); //200




        }


        //Actualizar o modificar datos

        [HttpPut]

        public async Task<ActionResult> Put(PetType pettypes)
        {

            _context.PetTypes.Update(pettypes);

            await _context.SaveChangesAsync();
            return Ok(pettypes);

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.PetTypes

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
