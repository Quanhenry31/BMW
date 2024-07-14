using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrdersBusiness
    {
        List<Orders> GetAll();
        Orders GetDatabyID(string OrderID);
        Orders GetDatabyUserID(string UserID);

        bool Create(Orders model);
        bool Delete(string id);
        bool Update(Orders model);
    }
}
