using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class ItemReorderService : IItemReorderService
    {
        public DataTable GetItemReorder(string ProductId, string ItemId, string SupId, string ReportType)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportItemReorder");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@PrdId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@ReportType", SqlDbType.NVarChar).Value = ReportType;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
