using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class ArrivalService : IArrivalService
    {
        public DataTable GetArrival(string FromDate, string Todate, string ProductId, string ItemId, string SupId)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportArrival");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }

        public DataTable GetArrival(string ARRIVAL_NO)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportArrival_ChallanWise");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ARRIVAL_NO", SqlDbType.NVarChar).Value = ARRIVAL_NO;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
