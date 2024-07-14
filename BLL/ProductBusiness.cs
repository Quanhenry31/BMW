using BusinessLogicLayer;
using DAL;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class ProductBLL : IProductBLL
    {
        private IProductRepository _res;
        private string secret;
        public ProductBLL(IProductRepository res)
        {
            _res = res;
        }
        public Product GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        
        public bool Create (Product model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<Product> GetAll()
        {
            return _res.GetAll();
        }
        public bool Update(Product model)
        {
            return _res.Update(model);
        }

        public List<Product> Search(int pageIndex, int pageSize, out long total, string name)
        {
            return _res.Search(pageIndex, pageSize, out total, name);
        }


        List<Product> IProductBLL.Search(int pageIndex, int pageSize, out long total, string name)
        {
            throw new NotImplementedException();
        }
    }
}