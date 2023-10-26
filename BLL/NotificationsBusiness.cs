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
    public class NotificationsBusiness : INotificationsBusiness
    {
        private INotificationsRepository _res;
        public NotificationsBusiness(INotificationsRepository res)
        {
            _res = res;
        }
        private string secret;
        public bool Create(Notifications model)
        {
            return _res.Create(model);
        }

        public bool Update(Notifications model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public Notifications GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<Notifications> GetAll()
        {
            return _res.GetAll();
        }
    }
}
