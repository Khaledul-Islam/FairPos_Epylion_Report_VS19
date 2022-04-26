using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class QCService : IQCService
    {
        public DataTable GetQualityControlByQC_NO(string QC_NO)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_GetQualityControlByQC_NO");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@QC_NO", SqlDbType.NVarChar).Value = QC_NO;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
