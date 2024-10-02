using Microsoft.EntityFrameworkCore;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;

        }



        public async Task SeedAsync()
        {

            await _context.Database.EnsureCreatedAsync();

            await CheckPetTypeAsync();





        }
        private async Task CheckPetTypeAsync()
        {

            if (!_context.PetTypes.Any())
            {
                _context.PetTypes.Add(new PetType { Name = "Dog" });
                _context.PetTypes.Add(new PetType { Name = "Cat" });
                _context.PetTypes.Add(new PetType { Name = "Hamster" });
                _context.PetTypes.Add(new PetType { Name = "Snake" });



            }

            await _context.SaveChangesAsync();
        }
    }
}