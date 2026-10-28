using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{

    [ApiController]
    [Route("/api/owners")]
    public class OwnersController : ControllerBase
    {

        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;
        }

        //Select * from Owners
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Owners.ToListAsync());


        }


        [AllowAnonymous]
        //Select * from Owners where Id = 1
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
            if (owner == null)
            {
                return NotFound(); //404
            }
            return Ok(owner);


        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        //Insert into Owners (Document, FirstName, LastName, FixedPhone, CellPhone, Address) values ('123456789', 'John', 'Doe', '123-456-7890', '098-765-4321', '123 Main St')
        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {
            _context.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }

        //Update Owners set Document = '123456789', FirstName = 'John', LastName = 'Doe', FixedPhone = '123-456-7890', CellPhone = '098-765-4321', Address = '123 Main St' where Id = 1
        [HttpPut]
        public async Task<ActionResult> Put(Owner owner)
        {
            _context.Update(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }

        //Delete from Owners where Id = 1
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
            if (owner == null)
            {
                return NotFound(); //404
            }
            _context.Remove(owner);
            await _context.SaveChangesAsync();
            return NoContent(); //204
        }


        //Update Owners set Document = '123456789', FirstName = 'John', LastName = 'Doe', FixedPhone = '123-456-7890', CellPhone = '098-765-4321', Address = '123 Main St' where Id = 1
        [HttpPatch]

        public async Task<ActionResult> Patch(Owner owner)
        {
            _context.Update(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);

        }


        [HttpGet("paginated")]
        public async Task<ActionResult> GetPaginated(int page = 1, int pageSize = 5)
        {


            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 5;
            if (pageSize > 50) pageSize = 50;
            var query = _context.Owners
            .AsNoTracking()//AsNoTracking() is used to improve performance when you don't need to track changes to the entities
            .OrderBy(x => x.Id);

            var totalRecords = await query.CountAsync(); //CountAsync() is used to get the total number of records in the query

            var data = await query
                .Skip((page - 1) * pageSize) //Skip() is used to skip the records that are not needed for the current page
                .Take(pageSize)//Take() is used to take the records that are needed for the current page
                .ToListAsync();//ToListAsync() is used to execute the query and get the results as a list1

            var totalPages =
            (int)Math.Ceiling(totalRecords / (double)pageSize); //Math.Ceiling() is used to round up the total number of pages  


            return Ok(new
            {
                TotalRecords = totalRecords, //TotalRecords is used to get the total number of records in the query
                TotalPages = totalPages, //TotalPages is used to get the total number of pages
                Page = page, //Page is used to get the current page
                PageSize = pageSize, //PageSize is used to get the number of records per page
                Data = data //Data is used to get the records for the current page
            });


        }


        [HttpGet("filter")] 
        public async Task<ActionResult> GetFiltered(string text)
        {

            var query = _context.Owners

            .AsNoTracking()//AsNoTracking() is used to improve performance when you don't need to track changes to the entities 
            .AsQueryable(); //AsQueryable() is used to create a query that can be filtered


            if(!string.IsNullOrWhiteSpace(text)) //Check if the text is not null or empty
            {
                text= text.Trim().ToLower(); //Trim() is used to remove the white spaces from the text and ToLower() is used to convert the text to lower case
                query = query.Where( x => //select * from Owners where FirstName like '%text%' or LastName like '%text%' or Document like '%text%'
              x.FirstName.ToLower().Contains(text) ||//Where() is used to filter the query and Contains() is used to check if the text is contained in the first name
              x.LastName.ToLower().Contains(text) ||//Where() is used to filter the query and Contains()
              x.Document.ToLower().Contains(text));  //Where() is used to filter the query and Contains()



            }

            var data = await query
                .OrderBy(x => x.FirstName) //OrderBy() is used to order the query by first name
                .ThenBy(x => x.LastName) //ThenBy() is used to order the query by last name
                .ToListAsync(); //ToListAsync() is used to execute the query and get the results as a list

            return Ok(data);
        }

        [HttpGet("{id:int}/hateoas")]
        public async Task<ActionResult> GetwithLinks(int id)
        {
            var owner = await _context.Owners
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (owner == null)
            {
                return NotFound(); //404
            }
            var response = new
            {
                owner,
                links = new List<object>
                {
                    new { rel = "self", href = Url.Action("Get", new { id = owner.Id }) },
                    new { rel = "update", href = Url.Action("Put") },
                    new { rel = "delete", href = Url.Action("Delete", new { id = owner.Id }) }
                }
            };
            return Ok(response);
        }



    }
}