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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_hd2",
                "@UserID", model.@UserID,
                "@OrderDate", model.@OrderDate,
                "@Address", model.Address,
                "@DateCreated", model.DateCreated,
                "@DateOk", model.DateOk,
                "@Time", model.Time,
                "@allPrice", model.allPrice,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoa_don_update",
                 "@OrderID", model.@OrderID,
                "@OrderDate", model.@OrderDate,
                "@Address", model.Address,
                "@DateCreated", model.DateCreated,
                "@DateOk", model.DateOk,
                "@Time", model.Time,
                "@allPrice", model.allPrice,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
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
        public Orders GetDatabyID(string OrderID)
        {
            string msgError = "";
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_get_oder_by_id",
                     "@OrderID",
                     OrderID);
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
