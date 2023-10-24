using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsControllner : ControllerBase
    {
        private IPaymentsBusiness _PaymentBLL;
        public PaymentsControllner(IPaymentsBusiness PayBLL)
        {
            _PaymentBLL = PayBLL;
        }
        [Route("Create")]
        [HttpPost]
        public Payments CreateUser([FromBody] Payments model)
        {
            _PaymentBLL.Create(model);
            return model;
        }
        [HttpPut("update")]
        public Payments UpdateItem([FromBody] Payments model)
        {
            _PaymentBLL.Update(model);
            return model;
        }
        [HttpDelete("delete")]
        public IActionResult DeleteItem(string id)
        {
            _PaymentBLL.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public Payments GetDatabyID(string id)
        {
            return _PaymentBLL.GetDatabyID(id);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _PaymentBLL.GetAll();
            return Ok(dt);
        }
    }
}
