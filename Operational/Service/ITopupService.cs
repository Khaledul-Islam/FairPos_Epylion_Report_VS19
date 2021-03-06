using System.Data;

namespace Operational.Service
{
    public interface ITopupService
    {
        DataTable GetTopup(string FromDate, string Todate, string Rfid);
        DataTable GetMemberBalanceDetails(string FromDate, string Todate, string Rfid);
        DataTable GetStaffTopupChln(string CollectionNo);
    }
}