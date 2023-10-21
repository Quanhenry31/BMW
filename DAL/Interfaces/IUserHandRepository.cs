using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserHandRepository
    {
        List<UserHand> GetAll();
        bool Create(UserHand model);
        bool Update(UserHand model);
        bool Delete(string id);
        UserHand GetDatabyID(string id);

    }
}
