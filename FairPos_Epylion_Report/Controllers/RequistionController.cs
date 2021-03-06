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
    public class RequistionController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly IRequistionService _requistionService;
        public RequistionController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, IRequistionService requistionService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _requistionService = requistionService;
        }

        [HttpGet]
        public IActionResult RequistionChallanWise(string ChlnNo, string IsTemp, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _requistionService.GetRequistion(ChlnNo, IsTemp));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Requistion\\RequistionChallanWise.rdlc";
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
        public IActionResult BuyRequistionChallanWise(string RequisitionNo, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _requistionService.GetBuyRequistion(RequisitionNo));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Requistion\\BuyRequistionChallanWise.rdlc";
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
        public IActionResult RequistionDetails(string FromDate, string Todate, string ProductId, string ItemId, string SupId, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _requistionService.GetRequistion(FromDate, Todate, ProductId, ItemId, SupId));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Requistion\\RequistionDetails.rdlc";
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
        public IActionResult RequistionSummary(string FromDate, string Todate, string ProductId, string ItemId, string SupId, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _requistionService.GetRequistion(FromDate, Todate, ProductId, ItemId, SupId));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Requistion\\RequistionSummary.rdlc";
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