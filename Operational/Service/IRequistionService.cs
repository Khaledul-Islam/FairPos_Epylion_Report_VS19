using System.Data;

namespace Operational.Service
{
    public interface IRequistionService
    {
        DataTable GetRequistion(string FromDate, string Todate, string ProductId, string ItemId, string SupId);
        DataTable GetRequistion(string ChlnNo, string IsTemp);
        DataTable GetBuyRequistion(string RequisitionNo);
    }
}