using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using BusinessLogicLayer;
namespace BusinessLogicLayer
{
    public class CateBusiness : ICateBusiness
    {
        private ICateRepository _res;
        public CateBusiness(ICateRepository res)
        {
            _res = res;
        }
        public List<Categories> GetAll()
        {
            return _res.GetAll();
        }
        public bool Create(Categories model)
        {
            return _res.Create(model);
        }
    }
}
