using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("/api/owners")]
    public class OwnersController : ControllerBase
    {

        private readonly DataContext _context;

        public OwnersController(DataContext context)

        {

            _context = context;

        }

        //get de lista - Select * from owners
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Owners.ToListAsync());

        }


        //Get con parámetro {id}
        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {

            var busqueda = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);

            if (busqueda == null)
            {

                return NotFound();



            }
            else
            {

                return Ok(busqueda);
            }

        }
        //Crear un nuevo Owner

        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);

        }


        //Actualizar un Owner
        [HttpPut]
        public async Task<ActionResult> Put(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);

        }


        // Eliminar un
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Owners
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (filasafectadas == 0)
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
