using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdvBusiness : IAdvBusiness
    {
        private IAdvRepository _res;
        public AdvBusiness(IAdvRepository res)
        {
            _res = res;
        }
        private string secret;
        public bool Create(Advertisements model)
        {
            return _res.Create(model);
        }

        public bool Update(Advertisements model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public Advertisements GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<Advertisements> GetAll()
        {
            return _res.GetAll();
        }
    }
}
