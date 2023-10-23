using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL;

namespace BLL
{
    public class UserHandBusiness : IUserHandBusiness
    {

        private IUserHandRepository _res;
        public UserHandBusiness(IUserHandRepository res)
        {
            _res = res;
        }
        private string secret;
        public bool Create(UserHand model)
        {
            return _res.Create(model);
        }
       
        public bool Update(UserHand model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public UserHand GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<UserHand> GetAll()
        {
            return _res.GetAll();
        }
  
    }
}
