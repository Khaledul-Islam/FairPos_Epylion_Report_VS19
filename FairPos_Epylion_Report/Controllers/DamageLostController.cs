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
    public class DamageLostController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, DataTable> data = new();
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly IDamageLostService _damageLostService;
        public DamageLostController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, IDamageLostService damageLostService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _damageLostService = damageLostService;
        }

        [HttpGet]
        public IActionResult DamageLostDetails(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string StockType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("StockType", StockType);
                    data.Add("ds", _damageLostService.GetDamageLost(FromDate, Todate, ShopId, ProductId, ItemId, SupId, StockType));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\DamageLost\\DamageLostDetails.rdlc";
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
        public IActionResult DamageLostSummary(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string StockType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    param_list.Add("StockType", StockType);
                    data.Add("ds", _damageLostService.GetDamageLost(FromDate, Todate, ShopId, ProductId, ItemId, SupId, StockType));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\DamageLost\\DamageLostSummary.rdlc";
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