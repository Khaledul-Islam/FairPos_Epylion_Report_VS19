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
    public class TopupController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, DataTable> data = new();
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly ITopupService _TopupService;
        public TopupController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, ITopupService TopupService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _TopupService = TopupService;
        }

        [HttpGet]
        public IActionResult TopupDetails(string FromDate, string Todate, string Rfid, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Rfid = string.IsNullOrEmpty(Rfid) ? "" : Rfid;
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("ToDate", Todate);
                    param_list.Add("Rfid", Rfid);
                    data.Add("ds", _TopupService.GetTopup(FromDate, Todate, Rfid));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Topup\\TopupDetails.rdlc";
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
        public IActionResult TopupSummary(string FromDate, string Todate, string Rfid, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Rfid = string.IsNullOrEmpty(Rfid) ? "" : Rfid;
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("ToDate", Todate);
                    param_list.Add("Rfid", Rfid);
                    data.Add("ds", _TopupService.GetTopup(FromDate, Todate, Rfid));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Topup\\TopupSummary.rdlc";
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
        public IActionResult MemberBalanceDetails(string FromDate, string Todate, string Rfid, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Rfid = string.IsNullOrEmpty(Rfid) ? "" : Rfid;
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("ToDate", Todate);
                    param_list.Add("Rfid", Rfid);
                    data.Add("ds", _TopupService.GetMemberBalanceDetails(FromDate, Todate, Rfid));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Topup\\MemberBalance.rdlc";
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
        public IActionResult StaffTopupChln(string CollectionNo, string Reprint, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("Reprint", Reprint);
                    data.Add("ds", _TopupService.GetStaffTopupChln(CollectionNo));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Topup\\StaffTopupChln.rdlc";
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