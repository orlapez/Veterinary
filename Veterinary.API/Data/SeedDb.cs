using Veterinary.API.Helpers;
using Veterinary.Shared.Entities;
using Veterinary.Shared.Enums;

namespace Veterinary.API.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPetTypesAsync();
            await CheckServiceTypesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1", "OAP", "OAP", "orlapez@gmail.com", "CR 78 9687", UserType.Admin);

        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {

                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Address = address,



                    UserName = email,


                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
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
