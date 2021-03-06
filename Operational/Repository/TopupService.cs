using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class TopupService : ITopupService
    {
        public DataTable GetTopup(string FromDate, string Todate, string Rfid)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportTopupDetails");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@Rfid", SqlDbType.NVarChar).Value = Rfid;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetMemberBalanceDetails(string FromDate, string Todate, string Rfid)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportMemberBalanceDetails");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@Rfid", SqlDbType.NVarChar).Value = Rfid;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetStaffTopupChln(string CollectionNo)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportStaffTopupChln");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CollectionNo", SqlDbType.NVarChar).Value = CollectionNo;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
