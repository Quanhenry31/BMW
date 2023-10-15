using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ICarBLL
    {
     
        List<Cars> GetAll();

        Cars GetDatabyID(string id);
        bool Create(Cars model);
        bool Delete(string id);
        bool Update(Cars model);
        public List<Cars> Search(int pageIndex, int pageSize, out long total, string name);

    }
}
