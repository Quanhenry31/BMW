using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseHelper _db;

        public UserRepository(IDatabaseHelper db)
        {
            _db = db;
        }

        public Users Login(string username, string password)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "SP_Login",
                    "@taikhoan", username,
                    "@matkhau", password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<Users>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   
    }
}
