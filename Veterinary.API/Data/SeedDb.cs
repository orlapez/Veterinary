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
            await CheckPetTypesAsync();
            await CheckServiceTypesAsync();


        }


        private async Task CheckPetTypesAsync()
        {
            if (!_context.PetTypes.Any())
            {
                _context.PetTypes.Add(new PetType { Name = "Dog" });
                _context.PetTypes.Add(new PetType { Name = "Cat" });
                _context.PetTypes.Add(new PetType { Name = "Bird" });
                _context.PetTypes.Add(new PetType { Name = "Rabbit" });
                await _context.SaveChangesAsync();
            }
        }

            private async Task CheckServiceTypesAsync()
        {
            if (!_context.ServiceTypes.Any())
            {
                _context.ServiceTypes.Add(new ServiceType { Name = "Vaccination" });
                _context.ServiceTypes.Add(new ServiceType { Name = "Checkup" });
                _context.ServiceTypes.Add(new ServiceType { Name = "Surgery" });
                _context.ServiceTypes.Add(new ServiceType { Name = "Grooming" });
                await _context.SaveChangesAsync();
            }   


        }
    }
}
