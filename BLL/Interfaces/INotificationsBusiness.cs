using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INotificationsBusiness
    {
        List<Notifications> GetAll();
        bool Create(Notifications model);
        bool Update(Notifications model);
        bool Delete(string id);
        Notifications GetDatabyID(string id);
    }
}
