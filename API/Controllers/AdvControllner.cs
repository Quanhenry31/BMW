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
        public class AdvControllner : ControllerBase
        {
            private IAdvBusiness _AdvBLL;
            public AdvControllner(IAdvBusiness AdvBLL)
            {
                _AdvBLL = AdvBLL;
            }

            [Route("Create")]
            [HttpPost]
            public Advertisements CreateUser([FromBody] Advertisements model)
            {
                _AdvBLL.Create(model);
                return model;
            }
            [HttpPut("update")]
            public Advertisements UpdateItem([FromBody] Advertisements model)
            {
                _AdvBLL.Update(model);
                return model;
            }
            [HttpDelete("delete")]
            public IActionResult DeleteItem(string id)
            {
                _AdvBLL.Delete(id);
                return Ok(new { message = "xoas thanh cong" });
            }
            [Route("get-by-id/{id}")]
            [HttpGet]
            public Advertisements GetDatabyID(string id)
            {
                return _AdvBLL.GetDatabyID(id);
            }

            [HttpGet("get-all")]
            public IActionResult GetAll()
            {
                var dt = _AdvBLL.GetAll();
                return Ok(dt);
            }
        }
}
