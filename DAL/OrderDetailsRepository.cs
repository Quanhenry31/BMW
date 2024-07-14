using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private IDatabaseHelper _db;
        public OrderDetailsRepository(IDatabaseHelper db)
        {
            _db = db;
        }
        public List<OrderDetails> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery("sp_getOrderDetailsALL");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<OrderDetails>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Create(OrderDetails model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "Proc_InsertOrderDetails",
                "@carID", model.carID,
                "@OrderID", model.OrderID,
                "@Quantity", model.Quantity,
                "@Allmoney", model.Allmoney);
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "Proc_DeleteOrderDetails",
                "@OrderDetailID", id);
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
        public bool Update(OrderDetails model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "Proc_UpdateOrderDetails",
                "@OrderDetailID", model.OrderDetailID,
                "@carID", model.carID,
                "@OrderID", model.OrderID,
                "@Quantity", model.Quantity,
              
                "@Allmoney", model.Allmoney);
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
        public OrderDetails GetDatabyID(string OrderID)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_getOrderDetail_ID",
                     "@OrderID",
                     OrderID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<OrderDetails>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
