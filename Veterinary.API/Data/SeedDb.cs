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
            await CheckPetType();
            await CheckRolesAsync();
            await CheckUserAsync("1", "OAP", "OAP", "orlapez@gmail.com", "CR 78 9687", UserType.Admin);

        }


        private async Task<User> CheckUserAsync(string documento, string firstName, string lastName, string email, string direccion,  UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {

                    Documento = documento,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Address = direccion,

                 


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
