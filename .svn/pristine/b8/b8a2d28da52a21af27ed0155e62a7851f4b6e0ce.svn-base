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
    public class TransferController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, DataTable> data = new();
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly ITransferService _transferService;
        public TransferController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, ITransferService transferService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _transferService = transferService;
        }

        [HttpGet]
        public IActionResult TransferDetails(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string StockType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("StockType", StockType);
                    data.Add("ds", _transferService.GetTransfer(FromDate, Todate, ShopId, ProductId, ItemId, SupId, StockType));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Transfer\\TransferDetails.rdlc";
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
        public IActionResult TransferSummary(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string StockType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("StockType", StockType);
                    data.Add("ds", _transferService.GetTransfer(FromDate, Todate, ShopId, ProductId, ItemId, SupId, StockType));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Transfer\\TransferSummary.rdlc";
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