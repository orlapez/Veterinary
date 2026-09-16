using Microsoft.AspNetCore.Mvc;
using Veterinary.API.Data;
using Microsoft.EntityFrameworkCore;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{

    [ApiController]
    [Route("/api/agendas")]
    public class AgendasController: ControllerBase
    {
        private readonly DataContext _context;

        public AgendasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Agendas.ToListAsync());


        }

        [HttpPost]
        public async Task<ActionResult> Post(Agenda agenda)
        {
            _context.Add(agenda);
            await _context.SaveChangesAsync();
            return Ok(agenda);
        }



    }
}
