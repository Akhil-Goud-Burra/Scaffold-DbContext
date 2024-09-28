using crud.Models.LoginRequestDTO;
using crud.Models.LoginResponseDTO;
using crud.Models.RegistrationRequestDTO;
using crud.Models.UserModel;

namespace crud.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser( string UserName );

        LoginResponseDTO Login(LoginRequestDTO loginRequestDTO);

        Users Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
