using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrdersRepository
    {
        List<Orders> GetAll();
        Orders GetDatabyID(string id);

        bool Create(Orders model);
        bool Delete(string id);
        bool Update(Orders model);
    }
}
