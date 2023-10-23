using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrdersRepository : IOrdersRepository
    {
      private IDatabaseHelper _db;
        public OrdersRepository(IDatabaseHelper db)
        {
            _db = db;
        }
        public List<Orders> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery("sp_getOrderALL");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<Orders>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Create(Orders model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "Proc_InsertOrder",
                "@UserID", model.@UserID,
                "@OrderDate", model.@OrderDate,
                "@Status", model.Status,
                "@Address", model.Address,
                "@quantity", model.quantity,
                "@DateCreated", model.DateCreated,
                "@DateOk", model.DateOk,
                "@Time", model.Time,
                "@allPrice", model.allPrice);
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "Proc_DeleteOrder",
                "@OrderID", id);
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
        public bool Update(Orders model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "Proc_UpdateOrder",
                 "@OrderID", model.@OrderID,
                "@OrderDate", model.@OrderDate,
                "@Status", model.Status,
                "@Address", model.Address,
                "@quantity", model.quantity,
                "@DateCreated", model.DateCreated,
                "@DateOk", model.DateOk,
                "@Time", model.Time,
                "@allPrice", model.allPrice);
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
        public Orders GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_getOrder_ID",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Orders>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
