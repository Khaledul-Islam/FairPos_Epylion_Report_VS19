using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class StockService : IStockService
    {
        public DataTable GetConversionStock(string ConversionNo)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportConversionStockConversionNoWise");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ConversionNo", SqlDbType.NVarChar).Value = ConversionNo;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetDamageStock(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportDamageStockItemWise");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = Condition;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStockItemWise(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportStockItemWise");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = Condition;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStockItemWiseStaff(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportStockItemWiseStaff");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = Condition;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStockItemWiseWorker(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportStockItemWiseWorker");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = Condition;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStockPeriodical(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportStockPeriodical");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = Condition;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStockPeriodical2(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportStockPeriodical2");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = Condition;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStockProductWise(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string StockType)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportStockProductWise");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = Condition;
                cmd.Parameters.Add("@StockType", SqlDbType.NVarChar).Value = StockType;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStockReturnShopByChln(string Chln)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_StockReturnShopByChln");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Chln", SqlDbType.NVarChar).Value = Chln;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStockTransferByChln(string Chln)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_StockTransferByChln");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Chln", SqlDbType.NVarChar).Value = Chln;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStockDMLByChln(string Chln)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_StockDMLByChln");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Chln", SqlDbType.NVarChar).Value = Chln;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
