using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using BusinessLogicLayer;

namespace Car
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
        [HttpDelete("delete-car")]
        public IActionResult DeleteItem(string id)
        {
            _CarBLL.Delete(id);
            return Ok(new { message = "xoas thanh cong" });
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _CarBLL.GetAll();
            return Ok(dt);
        }
        [HttpPut("update-account")]
        public Cars UpdateItem([FromBody] Cars model)
        {
            _CarBLL.Update(model);
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
                var data = _CarBLL.Search(pageIndex, pageSize, out total, name);
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