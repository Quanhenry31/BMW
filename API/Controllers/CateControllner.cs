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
        [Route("get-by-id/{id}")]
        [HttpGet]
        public Categories GetDatabyID(string id)
        {
            return _CateBll.GetDatabyID(id);
        }

        [Route("Create")]
        [HttpPost]
        public Categories CreateCar([FromBody] Categories model)
        {
            _CateBll.Create(model);
            return model;
        }
        [HttpDelete("delete-car")]
        public IActionResult DeleteItem(string id)
        {
            _CateBll.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }
        [HttpPut("update-cate")]
        public Categories UpdateItem([FromBody] Categories model)
        {
            _CateBll.Update(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var pageIndex = int.Parse(formData["pageIndex"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string name = "";
                if (formData.Keys.Contains("name") && !string.IsNullOrEmpty(Convert.ToString(formData["name"]))) { name = Convert.ToString(formData["name"]); }


                long total = 0;
                var data = _CateBll.Search(pageIndex, pageSize, out total, name);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        PageIndex = pageIndex,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
