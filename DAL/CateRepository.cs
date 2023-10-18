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
        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "SP_XoaCategories",
                "@categoryID", id);
                ;
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
        public bool Update(Categories model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "SP_SuaCategories",
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
        public Categories GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_getCategoriesID",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Categories>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Categories> Search(int pageIndex, int pageSize, out long total, string name)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_Categories",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@name", name

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<Categories>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
