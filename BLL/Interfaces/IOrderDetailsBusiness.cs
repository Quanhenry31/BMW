using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderDetailsBusiness
    {
        List<OrderDetails> GetAll();
        OrderDetails GetDatabyID(string OrderDetailID);

        bool Create(OrderDetails model);
        bool Delete(string id);
        bool Update(OrderDetails model);
    }
}
