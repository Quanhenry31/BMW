using BusinessLogicLayer;
using DAL;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class CarBLL : ICarBLL
    {
        private ICarRepository _res;
        private string secret;
        public CarBLL(ICarRepository res)
        {
            _res = res;
        }
        public Cars GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        
        public bool Create (Cars model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<Cars> GetAll()
        {
            return _res.GetAll();
        }
        public bool Update(Cars model)
        {
            return _res.Update(model);
        }

        public List<Cars> Search(int pageIndex, int pageSize, out long total, string name)
        {
            return _res.Search(pageIndex, pageSize, out total, name);
        }
    }
}