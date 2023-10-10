using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserHandBusiness
    {
        bool Create(UserHand model);
        bool Update(UserHand model);
        bool Delete(string id);
        UserHand GetDatabyID(string id);
    }
}
