using crud.Models;
using crud.Models.LoginRequestDTO;
using crud.Models.RegistrationRequestDTO;
using crud.Models.UserModel;
using crud.Repository.IRepository;
using System.Data;

namespace crud.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext appDbContext;

        public UserRepository(MyDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool IsUniqueUser(string UserName)
        {
            var user = appDbContext.UsersTable.FirstOrDefault(u => u.UserName == UserName);

            if (user == null) return true;

            return false;
        }



        // We have to Validate the User.
        // After Validating, We have to Generate the Token for that User.
        // After Generating Token, We have to send this token back to frontend for Session Management.
        public Task<LoginRequestDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }



        public Users Register(RegistrationRequestDTO registrationRequestDTO)
        {
            Users users = new Users()
            {
                UserName = registrationRequestDTO.UserName,
                Password = registrationRequestDTO.Password,
                Name = registrationRequestDTO.Name,
                Role = registrationRequestDTO.Role
            };

            appDbContext.UsersTable.Add(users);
            appDbContext.SaveChanges();

            users.Password = "";

            return users;
        }
    }
}
