using System.Data;

namespace Operational.Service
{
    public interface IReceiveService
    {
        DataTable GetReceive(string FromDate, string Todate, string ProductId, string ItemId, string SupId);
        DataTable GetRecvChallanByChln(string Chln);
    }
}