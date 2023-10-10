using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICateRepository
    {
        List<Categories> GetAll();
        Categories GetDatabyID(string id);

        bool Create(Categories model);
        bool Delete(string id);
        bool Update(Categories model);
    }
}
