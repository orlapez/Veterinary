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
    [Route("/api/agendas")]
    public class AgendasController:ControllerBase
    {

        private readonly DataContext _context;
        public AgendasController(DataContext context)
        {

            _context = context;

        }



        //Get por Lista--- Select * From Agendas
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Agendas.ToListAsync());


        }


        //Get por parámetro--- Select * from Agenda Where id=2
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var agenda = await _context.Agendas.FirstOrDefaultAsync(x => x.Id == id);
            if (agenda == null)
            {

                return NotFound();

            }
            else
            {
                return Ok(agenda);



            }

        }




        // Post- insertar un nuevo Agenda

        [HttpPost]

        public async Task<ActionResult> Post(Agenda agenda)
        {

            _context.Add(agenda);
            await _context.SaveChangesAsync();

            return Ok(agenda);



        }



        // Put- modificar un Agenda
        [HttpPut]

        public async Task<ActionResult> Put(Agenda agenda)
        {

            _context.Update(agenda);
            await _context.SaveChangesAsync();

            return Ok(agenda);



        }



        // Delete-- Borrar un registro

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.Agendas
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
