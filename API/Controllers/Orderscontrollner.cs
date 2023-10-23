using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using BusinessLogicLayer;
using BLL.Interfaces;

namespace Orderss
{  
        [Route("api/[controller]")]
        [ApiController]
        public class Oderscontroller : ControllerBase
        {
            private IOrdersBusiness _OderBLL;
            public Oderscontroller(IOrdersBusiness oderBLL)
            {
                _OderBLL = oderBLL;
            }
            [Route("get-by-id/{id}")]
            [HttpGet]
            public Orders GetDatabyID(string id)
            {
                return _OderBLL.GetDatabyID(id);
            }

            [Route("Create")]
            [HttpPost]
            public Orders CreateCar([FromBody] Orders model)
            {
                _OderBLL.Create(model);
                return model;
            }
            [HttpDelete("delete-oder")]
            public IActionResult DeleteItem(string id)
            {
                _OderBLL.Delete(id);
                return Ok(new { message = "xoas thanh cong" });
            }
            [HttpGet("get-all_oder")]
            public IActionResult GetAll()
            {
                var dt = _OderBLL.GetAll();
                return Ok(dt);
            }
            [HttpPut("update_oder")]
            public Orders UpdateItem([FromBody] Orders model)
            {
                _OderBLL.Update(model);
                return model;
            }
        }
}
