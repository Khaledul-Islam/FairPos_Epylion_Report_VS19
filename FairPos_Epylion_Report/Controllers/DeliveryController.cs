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
    public class DeliveryController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, DataTable> data = new();
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly IDeliveryService _deliveryService;
        public DeliveryController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, IDeliveryService deliveryService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _deliveryService = deliveryService;
        }


        [HttpGet]
        public IActionResult QualityControlByQC_NO(string DeliveryChlnNo, string ReportType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    data.Add("ds", _deliveryService.GetDeliveryByDeliveryChlnNo(DeliveryChlnNo));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Delivery\\DeliveryChallanWise.rdlc";
                    param_list.Add("ReportType", ReportType);
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
        public IActionResult DeliveryNoteByDebitNoteNo(string DebitNoteNo, string ReportType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    data.Add("ds", _deliveryService.GetDeliveryNoteByDebitNoteNo(DebitNoteNo));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Delivery\\DeliveryNoteByDebitNoteNo.rdlc";
                    param_list.Add("ReportType", ReportType);
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