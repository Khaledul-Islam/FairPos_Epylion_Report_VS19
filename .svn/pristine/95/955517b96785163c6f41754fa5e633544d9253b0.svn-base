using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class TransferService : ITransferService
    {
        public DataTable GetTransfer(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string StockType)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportShopTransferDetails");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@StockType", SqlDbType.NVarChar).Value = StockType;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
