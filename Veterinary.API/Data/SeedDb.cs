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



        public async Task SeedDbAsync()
        {


            await _context.Database.EnsureCreatedAsync();
            await CheckPetTypesAsync();
          


        }


        private async Task CheckPetTypesAsync()
        {
            if (!_context.PetTypes.Any())
            {
                _context.PetTypes.Add(new PetType { Name = "Dog" });
                _context.PetTypes.Add(new PetType { Name = "Cat" });
                _context.PetTypes.Add(new PetType { Name = "Bird" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
