using System.Data;

namespace Operational.Service
{
    public interface IInventoryService
    {
        DataTable GetInventory(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId);
        DataTable GetInventoryChallan(string UserIdOrChallan, bool IsTemp);
    }
}