
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogicLayer;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Carcontrollner : ControllerBase
    {
        private ICarBLL _CarBLL;
        public Carcontrollner(ICarBLL carBLL)
        {
            _CarBLL = carBLL;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public Cars GetDatabyID(string id)
        {
            return _CarBLL.GetDatabyID(id);
        }

        [Route("Create")]
        [HttpPost]
        public Cars CreateCar([FromBody] Cars model)
        {
            _CarBLL.Create(model);
            return model;
        } 

    }
}