using System.Data;

namespace Operational.Service
{
    public interface ISaleService
    {
        DataTable GetDailySales(string MonthFromDate, string MonthToDate, string YearFromDate, string YearToDate);
        DataTable GetItemWiseSales(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string FromStock);
        DataTable GetSalesInvoiceWiseDetails(string FromDate, string Todate, string ShopId, string ProductId, string Sbarcode, string SupId, string EmpId, string FromStock);
        DataTable GetSalesInvoiceWiseSummary(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock);
        DataTable GetSalesBasket(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock);
        DataTable GetSalesCasierSummary(string FromDate, string Todate, string ShopId, string BTID, string GroupID, string ProductId, string SupId, string FromStock);
        DataTable GetSalesFromStockPercent(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock);
        DataTable GetSalesStock(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string Take, string SortOrder, string FromStock);
        DataTable GetShopItemWiseSales(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock);
        DataTable GetSalesSlowMovingItems(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId);
        DataTable GetSupplierSalesContribution(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock);
        DataTable GetSupplierWIseGP(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock);
        DataTable GetSalesInvoice(string InvoiceNo);
        DataTable GetTempSOChallan(string UserId, bool IsTemp);
    }
}