using BLL.Interfaces;
using Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Usercontrollner : ControllerBase
    {
        private IUserBusiness _accBusiness;
        public Usercontrollner(IUserBusiness accBusiness)
        {
            _accBusiness = accBusiness;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _accBusiness.Login(model.userName, model.password);
            if (user == null) return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.userName, Email = user.email, token = user.token });
        }

    }
}
