using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INotificationsRepository
    {
        List<Notifications> GetAll();
        bool Create(Notifications model);
        bool Delete(string id);
        Notifications GetDatabyID(string id);
        bool Update(Notifications model);
    }
}
