using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{

    [ApiController]
    [Route("/api/servicetypes")]

    public class ServiceTypesController:ControllerBase
    {

        private readonly DataContext _context;
        public ServiceTypesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ServiceTypes.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Post(ServiceType serviceType)
        {
            _context.ServiceTypes.Add(serviceType);
            await _context.SaveChangesAsync();
            return Ok(serviceType);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, ServiceType serviceType)
        {
            _context.ServiceTypes.Update(serviceType);
            await _context.SaveChangesAsync();
            return Ok(serviceType);
        }

        //Delete from ServiceType where Id = 1
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var servicetypes = await _context.ServiceTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (servicetypes == null)
            {
                return NotFound(); //404
            }
            _context.Remove(servicetypes);
            await _context.SaveChangesAsync();
            return NoContent(); //204
        }


    }
}
