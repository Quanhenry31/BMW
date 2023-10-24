using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace DAL
{
    public class CarRepository : ICarRepository
    {
        private IDatabaseHelper _db;
        public CarRepository(IDatabaseHelper db)
        {
            _db = db;
        }
        public Cars GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_getcar",
                     "@id",id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Cars>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(Cars  model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "SP_ThemCar",
                "@name", model.name,
                "@modelCode", model.modelCode,
                "@price", model.price,
                "@year", model.year,
                "@categoryID", model.categoryID,
                "@imgLink", model.imgLink,
                "@quantity", model.quantity
                );
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "SP_XoaCar",
                "@carID", id);
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
        public List<Cars> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery("sp_getcarALL");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<Cars>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Update(Cars model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "SP_SuaCar",
                "@carID", model.carID,
                "@name", model.name,
                "@modelCode", model.modelCode,
                "@price", model.price,
                "@year", model.year,
                "@categoryID", model.categoryID,
                "@imgLink", model.imgLink,
                 "@quantity", model.quantity);
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
        public List<Cars> Search(int pageIndex, int pageSize, out long total, string name)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_car",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@name", name
                   
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<Cars>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
