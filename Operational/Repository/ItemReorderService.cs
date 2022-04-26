using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class RequistionService : IRequistionService
    {
        public DataTable GetRequistion(string FromDate, string Todate, string ProductId, string ItemId, string SupId)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportRequistion");
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

        public DataTable GetRequistion(string ChlnNo, string IsTemp)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_RequistionReport");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ChlnNo", SqlDbType.NVarChar).Value = ChlnNo;
                cmd.Parameters.Add("@IsTemp", SqlDbType.NVarChar).Value = IsTemp;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }

        public DataTable GetBuyRequistion(string RequisitionNo)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportBuyRequisition");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RequisitionNo", SqlDbType.NVarChar).Value = RequisitionNo;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
