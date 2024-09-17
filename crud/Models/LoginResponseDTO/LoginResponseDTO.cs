using crud.Models.UserModel;

namespace crud.Models.LoginResponseDTO
{
    public class LoginResponseDTO
    {
        public Users User { get; set; }

        public string Token {  get; set; } 
    }
}
