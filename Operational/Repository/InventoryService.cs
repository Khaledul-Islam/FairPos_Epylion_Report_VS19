using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class InventoryService : IInventoryService
    {
        public DataTable GetInventory(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportInventory");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ShopId", SqlDbType.NVarChar).Value = ShopId;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }

        public DataTable GetInventoryChallan(string UserIdOrChallan, bool IsTemp)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = IsTemp ? (@"SELECT '' InvenotryNo, Inventory.sBarCode, Inventory.BarCode, Inventory.StockBoxQty, Inventory.WriteOffBoxQty, Inventory.WriteOnBoxQty, Inventory.BoxSize, 
                Inventory.CREATE_BY, GETDATE() CREATE_DATE, vStyleSize.UOMName, vStyleSize.ItemFullName, vStyleSize.BoxUOMName, Inventory.RPU FROM TempInventory Inventory 
                INNER JOIN vStyleSize ON Inventory.sBarCode = vStyleSize.sBarcode WHERE Inventory.CREATE_BY = '" + UserIdOrChallan + "'") :
                @"SELECT Inventory.InvenotryNo, Inventory.sBarCode, Inventory.BarCode, Inventory.StockBoxQty, Inventory.WriteOffBoxQty, Inventory.WriteOnBoxQty, Inventory.BoxSize, Inventory.CREATE_BY, 
                Inventory.CREATE_DATE, vStyleSize.UOMName, vStyleSize.ItemFullName, vStyleSize.BoxUOMName, Inventory.RPU FROM Inventory INNER JOIN vStyleSize ON Inventory.sBarCode = vStyleSize.sBarcode
                WHERE Inventory.InvenotryNo = '" + UserIdOrChallan + "'";
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.Text;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
