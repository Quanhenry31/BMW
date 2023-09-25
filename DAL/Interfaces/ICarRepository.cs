
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICarRepository
    {
        Cars GetDatabyID(string id);
        bool Create(Cars model);
    }
}
