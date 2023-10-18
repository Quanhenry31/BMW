using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ICateBusiness
    {
        List<Categories> GetAll();
        Categories GetDatabyID(string id);

        bool Create(Categories model);
        bool Delete(string id);

        bool Update(Categories model);
        public List<Categories> Search(int pageIndex, int pageSize, out long total, string name);

    }
}
