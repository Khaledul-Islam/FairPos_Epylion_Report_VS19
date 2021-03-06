using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class SaleService : ISaleService
    {
        public DataTable GetDailySales(string MonthFromDate, string MonthToDate, string YearFromDate, string YearToDate)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_DailySalesReport");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MonthFromDate", SqlDbType.NVarChar).Value = MonthFromDate;
                cmd.Parameters.Add("@MonthToDate", SqlDbType.NVarChar).Value = MonthToDate;
                cmd.Parameters.Add("@YearFromDate", SqlDbType.NVarChar).Value = YearFromDate;
                cmd.Parameters.Add("@YearToDate", SqlDbType.NVarChar).Value = YearToDate;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetItemWiseSales(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_ItemWiseSalesReport");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetSalesInvoiceWiseDetails(string FromDate, string Todate, string ShopId, string ProductId, string Sbarcode, string SupId, string EmpId, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportSalesInvoiceWiseDetails");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@Sbarcode", SqlDbType.NVarChar).Value = Sbarcode;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@EmpId", SqlDbType.NVarChar).Value = EmpId;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetSalesInvoiceWiseSummary(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportSalesInvoiceWiseSummary");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemID", SqlDbType.NVarChar).Value = ItemID;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetSalesBasket(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_SalesBasket");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemID", SqlDbType.NVarChar).Value = ItemID;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetSalesCasierSummary(string FromDate, string Todate, string ShopId, string BTID, string GroupID, string ProductId, string SupId, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_SalesCasierSummaryReport");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@BTID", SqlDbType.NVarChar).Value = BTID;
                cmd.Parameters.Add("@GroupID", SqlDbType.NVarChar).Value = GroupID;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetSalesFromStockPercent(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_SalesFromStockPercent");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemID", SqlDbType.NVarChar).Value = ItemID;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetSalesStock(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string Take, string SortOrder, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_SalesStockReport");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemID", SqlDbType.NVarChar).Value = ItemID;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@Take", SqlDbType.NVarChar).Value = Take;
                cmd.Parameters.Add("@SortOrder", SqlDbType.NVarChar).Value = SortOrder;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetShopItemWiseSales(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_ShopItemWiseSalesReport");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemID", SqlDbType.NVarChar).Value = ItemID;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetSalesSlowMovingItems(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_SalesSlowMovingItems");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemID", SqlDbType.NVarChar).Value = ItemID;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }

        public DataTable GetSupplierSalesContribution(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_SupplierSalesContribution");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemID", SqlDbType.NVarChar).Value = ItemID;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }

        public DataTable GetSupplierWIseGP(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Report_SupplierWIseGP");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemID", SqlDbType.NVarChar).Value = ItemID;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@FromStock", SqlDbType.NVarChar).Value = FromStock;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }

        public DataTable GetSalesInvoice(string InvoiceNo)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_SalesInvoice");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = InvoiceNo;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }

        public DataTable GetTempSOChallan(string UserId, bool IsTemp)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = IsTemp ? "SP_ReportTempSOChallan" : "SP_ReportSOChallan";
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (IsTemp)
                {
                    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
                }
                else
                {
                    cmd.Parameters.Add("@Chln", SqlDbType.NVarChar).Value = UserId;
                }

                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
