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



        // Get para obtoner una lista de resultados
        // Select * from table

        [HttpGet]
        public async Task<ActionResult> Get()
        {


          return Ok(await  _context.Owners.ToListAsync()); //200

        }



        //Get por parámetro
        //Select* from table Where Id=...

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var owner=await _context.Owners.FirstOrDefaultAsync(x=>x.Id==id);

            if (owner == null)
            {



                return NotFound();//404
            }

            return Ok(owner); //200

        }


        //Insertar datos o crear registros
        [HttpPost]

        public async Task<ActionResult>Post(Owner owner)
        {

            _context.Owners.Add(owner);

            await _context.SaveChangesAsync();
            return Ok(owner); //200




        }


        //Actualizar o modificar datos

        [HttpPut]

        public async Task<ActionResult> Put(Owner owner)
        {

            _context.Owners.Update(owner);

            await _context.SaveChangesAsync();
            return Ok(owner);

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Owners
            
               .Where(x=>x.Id==id) 
               .ExecuteDeleteAsync();
                
                
                
                
                
                
                if (filasafectadas== 0)
            {



                return NotFound();//404
            }

            return NoContent();//204

        }




    }
}
