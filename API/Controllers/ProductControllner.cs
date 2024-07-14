using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using BusinessLogicLayer;

namespace Product_api
{
    [Route("api/[controller]")]
    [ApiController]
    public class Productcontrollner : ControllerBase
    {
        private IProductBLL _ProductBLL;
        public Productcontrollner(IProductBLL productBLL)
        {
            _ProductBLL = productBLL;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public Product GetDatabyID(string id)
        {
            return _ProductBLL.GetDatabyID(id);
        }

        [Route("Create")]
        [HttpPost]
        public Product CreateCar([FromBody] Product model)
        {
            _ProductBLL.Create(model);
            return model;
        }
        [HttpDelete("delete-car")]
        public IActionResult DeleteItem(string id)
        {
            _ProductBLL.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _ProductBLL.GetAll();
            return Ok(dt);
        }
        [HttpPut("update-account")]
        public Product UpdateItem([FromBody] Product model)
        {
            _ProductBLL.Update(model);
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
                var data = _ProductBLL.Search(pageIndex, pageSize, out total, name);
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