using BusinessLogicLayer;
using DAL;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class CarBLL : ICarBLL
    {
        private ICarRepository _res;
        public CarBLL(ICarRepository res)
        {
            _res = res;
        }
        public Cars GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        
    }
}