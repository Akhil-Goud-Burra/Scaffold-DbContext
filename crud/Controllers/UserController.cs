using crud.Models.LoginRequestDTO;
using crud.Models.RegistrationRequestDTO;
using crud.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{

    [Route("api/UsersAuAr/")]
    [ApiController]
    [ApiVersionNeutral]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO model)
        {

            var login_response = _userRepository.Login(model);

            if (login_response.User == null || string.IsNullOrEmpty(login_response.Token) )
            {
                return BadRequest(new { message = "Ivalid Username or Password is Incorrect" });
            }

            return Ok(login_response);
        }



        [HttpPost("register")]
        public IActionResult Register([FromBody] RegistrationRequestDTO model)
        {
            bool IfUserNameUnique = _userRepository.IsUniqueUser(model.UserName);

            if (!IfUserNameUnique)
            {
                return BadRequest(new { message = "UserName Already Exists" });
            }

            var user = _userRepository.Register(model);
            if (user == null)
            {
                return BadRequest(new { message = "Error while Registering" });
            }

            return Ok(user);
        }


    }
}
