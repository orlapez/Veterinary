using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;

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


            return Ok(await  _context.Owners.ToListAsync());

        }



        //Get por parámetro
        //Select* from table Where Id=...

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var owner=await _context.Owners.FirstOrDefaultAsync(x=>x.Id==id);

            if (owner == null)
            {



                return NotFound();
            }

            return Ok(owner);




        }




    }
}
