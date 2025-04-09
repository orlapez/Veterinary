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
            await CheckPetType();
        }

        public async Task CheckPetType()
        {

            if (!_context.PetTypes.Any())
            {

                _context.PetTypes.Add(new PetType { Name = "Perro" });
                _context.PetTypes.Add(new PetType { Name = "Gato" });
                _context.PetTypes.Add(new PetType { Name = "Canario" });
                _context.PetTypes.Add(new PetType { Name = "Hamster" });




            }

            await _context.SaveChangesAsync();




        }

    }

}
