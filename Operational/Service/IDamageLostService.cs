using System.Data;

namespace Operational.Service
{
    public interface IDamageLostService
    {
        DataTable GetDamageLost(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string StockType);
    }
}