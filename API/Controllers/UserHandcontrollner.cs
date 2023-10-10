using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using BusinessLogicLayer;
using BLL.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHandcontrollner : ControllerBase
    {
        private IUserHandBusiness _UserHandBLL;
        public UserHandcontrollner(IUserHandBusiness UserBLL)
        {
            _UserHandBLL = UserBLL;
        }


        [Route("Create_user")]
        [HttpPost]
        public UserHand CreateUser([FromBody] UserHand model)
        {
            _UserHandBLL.Create(model);
            return model;
        }
        [HttpPut("update-account")]
        public UserHand UpdateItem([FromBody] UserHand model)
        {
            _UserHandBLL.Update(model);
            return model;
        }
        [HttpDelete("delete-car")]
        public IActionResult DeleteItem(string id)
        {
            _UserHandBLL.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public UserHand GetDatabyID(string id)
        {
            return _UserHandBLL.GetDatabyID(id);
        }

    }
}
