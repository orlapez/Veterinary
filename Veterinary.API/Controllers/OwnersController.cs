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
    [Route("/api/Owners")]
    public class OwnersController : ControllerBase
    {
        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From owners

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Owners.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);

            if (owner == null)
            {


                return NotFound();
            }

            return Ok(owner);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Owner Owner)
        {
            _context.Add(Owner);
            await _context.SaveChangesAsync();
            return Ok(Owner);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(Owner Owner)
        {
            _context.Update(Owner);
            await _context.SaveChangesAsync();
            return Ok(Owner);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

          
            var FilaAfectada = await _context.Owners
                .Where(x => x.Id == id)//5
                .ExecuteDeleteAsync();  

            if (FilaAfectada == 0)
            {


                return NotFound();//404
            }

            return NoContent();//204


        }


    }
}






