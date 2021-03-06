using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Operational.Service;
using System;
using System.Collections.Generic;
using System.Data;

namespace FairPos_Epylion_Report.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, DataTable> data = new();
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly ISaleService _saleService;
        public SaleController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, ISaleService saleService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult DailySales(string MonthFromDate, string MonthToDate, string YearFromDate, string YearToDate, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    data.Add("ds", _saleService.GetDailySales(MonthFromDate, MonthToDate, YearFromDate, YearToDate));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\DailySales.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }

        [HttpGet]
        public IActionResult GroupWiseSales(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetItemWiseSales(FromDate, Todate, ShopId, ProductId, ItemId, SupId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\GroupWiseSales.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }

        [HttpGet]
        public IActionResult SalesInvoiceWiseDetails(string FromDate, string Todate, string ShopId, string ProductId, string Sbarcode, string SupId, string EmpId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetSalesInvoiceWiseDetails(FromDate, Todate, ShopId, ProductId, Sbarcode, SupId, EmpId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\InvoiceWiseSalesDetails.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }

        [HttpGet]
        public IActionResult SalesInvoiceWiseSummary(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetSalesInvoiceWiseSummary(FromDate, Todate, ShopId, ProductId, ItemID, SupId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\InvoiceWiseSalesSummary.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }

        [HttpGet]
        public IActionResult ItemWiseSales(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetItemWiseSales(FromDate, Todate, ShopId, ProductId, ItemId, SupId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\ItemWiseSales.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }
        [HttpGet]
        public IActionResult SalesBasket(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetSalesBasket(FromDate, Todate, ShopId, ProductId, ItemID, SupId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\SalesBasket.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }
        [HttpGet]
        public IActionResult SalesCasierSummary(string FromDate, string Todate, string ShopId, string BTID, string GroupID, string ProductId, string SupId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetSalesCasierSummary(FromDate, Todate, ShopId, BTID, GroupID, ProductId, SupId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\SalesCasierSummary.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }
        [HttpGet]
        public IActionResult SalesFromStockPercent(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetSalesFromStockPercent(FromDate, Todate, ShopId, ProductId, ItemID, SupId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\SalesFromStockPercent.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }
        [HttpGet]
        public IActionResult SalesStockReport(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string Take, string SortOrder, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetSalesStock(FromDate, Todate, ShopId, ProductId, ItemID, SupId, Take, SortOrder, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\SalesStockReport.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }
        [HttpGet]
        public IActionResult ShopItemWiseSales(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetShopItemWiseSales(FromDate, Todate, ShopId, ProductId, ItemID, SupId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\ShopItemWiseSales.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }
        [HttpGet]
        public IActionResult SalesSlowMovingItems(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    data.Add("ds", _saleService.GetSalesSlowMovingItems(FromDate, Todate, ShopId, ProductId, ItemID, SupId));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\SalesSlowMovingItems.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }

        [HttpGet]
        public IActionResult SupplierSalesContribution(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetSupplierSalesContribution(FromDate, Todate, ShopId, ProductId, ItemID, SupId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\SupplierSalesContribution.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }

        [HttpGet]
        public IActionResult SupplierWIseGP(string FromDate, string Todate, string ShopId, string ProductId, string ItemID, string SupId, string FromStock, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("FromStock", FromStock);
                    data.Add("ds", _saleService.GetSupplierWIseGP(FromDate, Todate, ShopId, ProductId, ItemID, SupId, FromStock));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\SupplierWIseGP.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }

        [HttpGet]
        public IActionResult SalesInvoice(string InvoiceNo, string Reprint, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("Reprint", Reprint);
                    data.Add("ds", _saleService.GetSalesInvoice(InvoiceNo));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\SaleInvoice.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }

        [HttpGet]
        public IActionResult SOChallan(string UserId, string ReportType, bool IsTemp, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("ReportType", ReportType);
                    data.Add("ds", _saleService.GetTempSOChallan(UserId, IsTemp));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Sale\\SOChallan.rdlc";
                    ReportDomain reportDomain = new(inpurformat, data, path, param_list);
                    return File(new ReportApplication().Load(reportDomain), reportDomain.mimeType, _commonService.GetReportFileName(System.Reflection.MethodBase.GetCurrentMethod(), inpurformat));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                IActionResult responses = StatusCode(503, ex.Message);
                return responses;
            }
        }
    }
}