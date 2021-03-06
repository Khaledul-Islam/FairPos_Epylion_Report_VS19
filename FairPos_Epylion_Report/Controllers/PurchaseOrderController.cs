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
    public class PurchaseOrderController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        public PurchaseOrderController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, IPurchaseOrderService purchaseOrderService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpGet]
        public IActionResult PurchaseOrderChallanWise(string challan_no, string ReportType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _purchaseOrderService.GetPurchaseOrder(challan_no));
                    param_list.Add("ReportType", ReportType);
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\PurchaseOrder\\PurchaseOrderChallanWise.rdlc";
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
        public IActionResult PurchaseOrderReportPreview(string userId, string matrutitydays, string partialDel, string QutRefNo, string paymentTerms, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _purchaseOrderService.GetPurchaseOrderPreview(userId, matrutitydays, partialDel, QutRefNo, paymentTerms));
                    param_list.Add("ReportType", "");
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\PurchaseOrder\\PurchaseOrderChallanWise.rdlc";
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
        public IActionResult PurchaseOrderReportPreview2(string userId, string matrutitydays, string partialDel, string QutRefNo, string paymentTerms, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _purchaseOrderService.GetPurchaseOrderPreview2(userId, matrutitydays, partialDel, QutRefNo, paymentTerms));
                    param_list.Add("ReportType", "");
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\PurchaseOrder\\PurchaseOrderChallanWise.rdlc";
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
        public IActionResult PurchaseOrderReportPreview3(string userId, string matrutitydays, string partialDel, string QutRefNo, string paymentTerms, string barcodeList, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _purchaseOrderService.GetPurchaseOrderPreview3(userId, matrutitydays, partialDel, QutRefNo, paymentTerms, barcodeList));
                    param_list.Add("ReportType", "");
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\PurchaseOrder\\PurchaseOrderChallanWise.rdlc";
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
        public IActionResult PurchaseOrderDetails(string FromDate, string Todate, string ProductId, string ItemId, string SupId, string CancelType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _purchaseOrderService.GetPurchaseOrder(FromDate, Todate, ProductId, ItemId, SupId, CancelType));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\PurchaseOrder\\PurchaseOrderDetails.rdlc";
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
        public IActionResult PurchaseOrderSummary(string FromDate, string Todate, string ProductId, string ItemId, string SupId, string CancelType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _purchaseOrderService.GetPurchaseOrder(FromDate, Todate, ProductId, ItemId, SupId, CancelType));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\PurchaseOrder\\PurchaseOrderSummary.rdlc";
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