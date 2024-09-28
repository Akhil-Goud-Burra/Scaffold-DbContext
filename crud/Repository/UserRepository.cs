using crud.Models;
using crud.Models.LoginRequestDTO;
using crud.Models.LoginResponseDTO;
using crud.Models.RegistrationRequestDTO;
using crud.Models.UserModel;
using crud.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace crud.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext appDbContext;

        private string SecretKey;

        public UserRepository(MyDbContext appDbContext, IConfiguration _configuration)
        {
            this.appDbContext = appDbContext;
            SecretKey = _configuration.GetValue<string>("ApiSettings:Secret");
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
        public LoginResponseDTO Login(LoginRequestDTO loginRequestDTO)
        {

            // UserName and Password Validation Check
            var user = appDbContext.UsersTable.FirstOrDefault
            (
                u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower()

                && u.Password.ToLower() == loginRequestDTO.Password.ToLower()
            );

            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }

            //If user Found: Generate JWT Token     
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Role)
                    }
                ),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = TokenHandler.CreateToken(tokenDescriptor);


            LoginResponseDTO login_response_dto = new LoginResponseDTO()
            {
                Token = TokenHandler.WriteToken(token),
                User = user
            };


            return login_response_dto;
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
