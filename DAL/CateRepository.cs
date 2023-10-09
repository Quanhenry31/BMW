using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CateRepository : ICateRepository
    {
        private IDatabaseHelper _db;
        public CateRepository(IDatabaseHelper db)
        {
            _db = db;
        }
        public List<Categories> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery("sp_getCategoriesALL");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<Categories>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Create(Categories model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "SP_AddCategories",
                "@categoryID", model.categoryID,
                "@name", model.name,
                "@description", model.description);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
