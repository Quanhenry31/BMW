
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetDatabyID(string id);
        bool Create(Product model);
        bool Delete(string id);
        bool Update(Product model);
        public List<Product> Search(int pageIndex, int pageSize, out long total, string name);


    }
}
