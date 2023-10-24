using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPaymentsRepository
    {
        List<Payments> GetAll();
        bool Create(Payments model);
        bool Delete(string id);
        Payments GetDatabyID(string id);
        bool Update(Payments model);
    }
}
