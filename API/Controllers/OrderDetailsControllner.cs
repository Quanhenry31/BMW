using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OderDetailsControllner : ControllerBase
    {
        private IOrderDetailsBusiness _OderDetailBLL;
        public OderDetailsControllner(IOrderDetailsBusiness oderdetaiBLL)
        {
            _OderDetailBLL = oderdetaiBLL;
        }
        [Route("get-by-id/{OrderDetailID}")]
        [HttpGet]
        public OrderDetails GetDatabyID(string OrderDetailID)
        {
            return _OderDetailBLL.GetDatabyID(OrderDetailID);
        }

        [Route("Create")]
        [HttpPost]
        public OrderDetails CreateCar([FromBody] OrderDetails model)
        {
            _OderDetailBLL.Create(model);
            return model;
        }
        [HttpDelete("delete-oder")]
        public IActionResult DeleteItem(string id)
        {
            _OderDetailBLL.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }
        [HttpGet("get-all_oder")]
        public IActionResult GetAll()
        {
            var dt = _OderDetailBLL.GetAll();
            return Ok(dt);
        }
        [HttpPut("update_oder")]
        public OrderDetails UpdateItem([FromBody] OrderDetails model)
        {
            _OderDetailBLL.Update(model);
            return model;
        }
    }
}
