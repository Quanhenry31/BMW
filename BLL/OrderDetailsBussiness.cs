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
    public class OrderDetailsBussiness : IOrderDetailsBusiness
    {
        private IOrderDetailsRepository _res;
        public OrderDetailsBussiness(IOrderDetailsRepository res)
        {
            _res = res;
        }
        public OrderDetails GetDatabyID(string OrderDetailID)
        {
            return _res.GetDatabyID(OrderDetailID);
        }
        public List<OrderDetails> GetAll()
        {
            return _res.GetAll();
        }
        public bool Create(OrderDetails model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(OrderDetails model)
        {
            return _res.Update(model);
        }
    }
}
