using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPaymentsBusiness
    {
        List<Payments> GetAll();
        bool Create(Payments model);
        bool Update(Payments model);
        bool Delete(string id);
        Payments GetDatabyID(string id);
    }
}
