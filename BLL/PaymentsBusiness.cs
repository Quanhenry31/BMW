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
    public class PaymentsBusiness : IPaymentsBusiness
    {
        private IPaymentsRepository _res;
        public PaymentsBusiness(IPaymentsRepository res)
        {
            _res = res;
        }
        private string secret;
        public bool Create(Payments model)
        {
            return _res.Create(model);
        }

        public bool Update(Payments model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public Payments GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<Payments> GetAll()
        {
            return _res.GetAll();
        }
    }
}
