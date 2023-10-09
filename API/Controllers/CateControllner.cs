using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using BusinessLogicLayer;
namespace Cate
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateControllner : ControllerBase
    {
        private ICateBusiness _CateBll;
        public CateControllner(ICateBusiness cateBLL)
        {
            _CateBll = cateBLL;
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _CateBll.GetAll();
            return Ok(dt);
        }
        [Route("Create")]
        [HttpPost]
        public Categories CreateCar([FromBody] Categories model)
        {
            _CateBll.Create(model);
            return model;
        }
    }
}
