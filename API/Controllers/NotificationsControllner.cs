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
    public class NotificationsControllner : ControllerBase
    {
        private INotificationsBusiness _NotiBLL;
        public NotificationsControllner(INotificationsBusiness NotiBLL)
        {
            _NotiBLL = NotiBLL;
        }

        [Route("Create")]
        [HttpPost]
        public Notifications CreateUser([FromBody] Notifications model)
        {
            _NotiBLL.Create(model);
            return model;
        }
        [HttpPut("update")]
        public Notifications UpdateItem([FromBody] Notifications model)
        {
            _NotiBLL.Update(model);
            return model;
        }
        [HttpDelete("delete")]
        public IActionResult DeleteItem(string id)
        {
            _NotiBLL.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public Notifications GetDatabyID(string id)
        {
            return _NotiBLL.GetDatabyID(id);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _NotiBLL.GetAll();
            return Ok(dt);
        }
    }
}
