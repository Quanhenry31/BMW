using BLL.Interfaces;
using BusinessLogicLayer;
using DAL;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrdersBusiness : IOrdersBusiness
    {
        private IOrdersRepository _res;
        public OrdersBusiness(IOrdersRepository res)
        {
            _res = res;
        }
        public Orders GetDatabyID(string OrderID)
        {
            return _res.GetDatabyID(OrderID);
        }

        public Orders GetDatabyUserID(string UserID)
        {
            return _res.GetDatabyUserID(UserID);
        }
        public List<Orders> GetAll()
        {
            return _res.GetAll();
        }
        public bool Create(Orders model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(Orders model)
        {
            return _res.Update(model);
        }
    }
}
