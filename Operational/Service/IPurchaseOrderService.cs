using System.Data;

namespace Operational.Service
{
    public interface IPurchaseOrderService
    {
        DataTable GetPurchaseOrder(string challan_no);
        DataTable GetPurchaseOrder(string FromDate, string Todate, string ProductId, string ItemId, string SupId, string CancelType);
        DataTable GetPurchaseOrderPreview(string userId, string matrutitydays, string partialDel, string QutRefNo, string paymentTerms);
        DataTable GetPurchaseOrderPreview2(string userId, string matrutitydays, string partialDel, string QutRefNo, string paymentTerms);
        DataTable GetPurchaseOrderPreview3(string userId, string matrutitydays, string partialDel, string QutRefNo, string paymentTerms, string barcodeList);
    }
}
