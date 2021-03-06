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
    public class StockController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, DataTable> data = new();
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly IStockService _stockService;
        public StockController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, IStockService stockService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _stockService = stockService;
        }

        [HttpGet]
        public IActionResult ConversionStockChallanWise(string ConversionNo, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    data.Add("ds", _stockService.GetConversionStock(ConversionNo));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\ConversionStockChallanWise.rdlc";
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
        public IActionResult DamageStock(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetDamageStock(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\DamageItemWiseStock.rdlc";
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
        public IActionResult StockItemWise(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockItemWise(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\ItemWiseStock.rdlc";
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
        public IActionResult StockSupplierWise(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockItemWise(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\SupplierWiseStock.rdlc";
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
        public IActionResult StockItemWiseReportStaff(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockItemWiseStaff(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\ItemWiseStockStaff.rdlc";
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
        public IActionResult StockItemWiseReportWorker(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockItemWiseWorker(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\ItemWiseStockWorker.rdlc";
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
        public IActionResult StockPeriodical(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockPeriodical(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\Periodical.rdlc";
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
        public IActionResult StockPeriodicalStaff(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockPeriodical(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\PeriodicalStaff.rdlc";
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
        public IActionResult StockPeriodicalWorker(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockPeriodical(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\PeriodicalWorker.rdlc";
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
        public IActionResult StockPeriodical2(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockPeriodical2(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\Periodical2.rdlc";
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
        public IActionResult StockPeriodical2WS(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockPeriodical2(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\Periodical2WS.rdlc";
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
        public IActionResult StockProductWise(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string Condition, string StockType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("Condition", Condition);
                    data.Add("ds", _stockService.GetStockProductWise(FromDate, Todate, ShopId, ProductId, ItemId, SupId, Condition, StockType));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\ProductWiseStock.rdlc";
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
        public IActionResult StockReturnShopByChln(string Chln, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    data.Add("ds", _stockService.GetStockReturnShopByChln(Chln));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\StockReturnShopByChln.rdlc";
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
        public IActionResult StockTransferByRcvChallan(string Chln, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    data.Add("ds", _stockService.GetStockReturnShopByChln(Chln));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\StockTransferByRcvChallan.rdlc";
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
        public IActionResult StockTransferByChln(string Chln, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    data.Add("ds", _stockService.GetStockTransferByChln(Chln));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\StockTransferByChln.rdlc";
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
        public IActionResult StockDMLByChln(string Chln, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    data.Add("ds", _stockService.GetStockDMLByChln(Chln));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Stock\\StockDMLByChln.rdlc";
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

        //complete this action method
        //query = string.Format("SP_ReportStockTransferDetails '{0}','{1}','{2}','{3}' ",FromDate, ToDate, fromStock, toStock);
        [HttpGet]
        public IActionResult StockTransferDetails(string FromDate, string ToDate, string fromStock, string toStock, string SecretKey)
        {
            return Ok();
        }
        
        //complete this action method
        //query = string.Format("SP_ReportStockTransferDetails '{0}','{1}','{2}','{3}' ",FromDate, ToDate, fromStock, toStock);
        [HttpGet]
        public IActionResult StockTransferSummary(string FromDate, string ToDate, string fromStock, string toStock, string SecretKey)
        {
            return Ok();
        }
    }
}