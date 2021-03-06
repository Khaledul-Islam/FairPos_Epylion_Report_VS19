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
    public class ArrivalController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, DataTable> data = new();
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly IArrivalService _arrivalService;
        public ArrivalController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, IArrivalService arrivalService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _arrivalService = arrivalService;
        }
        [HttpGet]
        public IActionResult ArrivalChallanWise(string ARRIVAL_NO, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("ARRIVAL_NO", ARRIVAL_NO);
                    data.Add("ds", _arrivalService.GetArrival(ARRIVAL_NO));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Arrival\\ArrivalChallanWise.rdlc";
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
        public IActionResult ArrivalDetails(string FromDate, string Todate, string ProductId, string ItemId, string SupId, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    data.Add("ds", _arrivalService.GetArrival(FromDate, Todate, ProductId, ItemId, SupId));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Arrival\\ArrivalDetails.rdlc";
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
        public IActionResult ArrivalSummary(string FromDate, string Todate, string ProductId, string ItemId, string SupId, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    data.Add("ds", _arrivalService.GetArrival(FromDate, Todate, ProductId, ItemId, SupId));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Arrival\\ArrivalSummary.rdlc";
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