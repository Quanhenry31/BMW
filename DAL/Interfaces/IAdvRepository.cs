using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdvRepository
    {
        List<Advertisements> GetAll();
        bool Create(Advertisements model);
        bool Delete(string id);
        Advertisements GetDatabyID(string id);
        bool Update(Advertisements model);
    }
}
