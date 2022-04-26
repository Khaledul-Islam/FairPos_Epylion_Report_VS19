using System.Data;

namespace Operational.Service
{
    public interface IStockService
    {
        DataTable GetConversionStock(string ConversionNo);
        DataTable GetDamageStock(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition);
        DataTable GetStockItemWise(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition);
        DataTable GetStockItemWiseStaff(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition);
        DataTable GetStockItemWiseWorker(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition);
        DataTable GetStockPeriodical(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition);
        DataTable GetStockPeriodical2(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition);
        DataTable GetStockProductWise(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string StockType);
        DataTable GetStockReturnShopByChln(string Chln);
        DataTable GetStockTransferByChln(string Chln);
        DataTable GetStockDMLByChln(string Chln);
    }
}