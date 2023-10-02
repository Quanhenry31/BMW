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
        private IDatabaseHelper _dbHelper;
        public CarRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public Cars GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getcar",
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "SP_ThemCar",
                "@name", model.name,
                "@modelCode", model.modelCode,
                "@year", model.year,
                "@price", model.price,
                "@description", model.description,
                "@categoryID", model.categoryID);
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
9