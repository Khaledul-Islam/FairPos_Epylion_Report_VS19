using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class DeliveryService : IDeliveryService
    {
        public DataTable GetDeliveryByDeliveryChlnNo(string DeliveryChlnNo)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_GetDeliveryByDeliveryChlnNo");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DeliveryChlnNo", SqlDbType.NVarChar).Value = DeliveryChlnNo;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetDeliveryNoteByDebitNoteNo(string DebitNoteNo)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_GetDeliveryNote");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DebitNoteNo", SqlDbType.NVarChar).Value = DebitNoteNo;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}