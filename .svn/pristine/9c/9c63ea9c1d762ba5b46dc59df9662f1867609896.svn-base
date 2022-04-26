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
    public class ItemReorderController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly IItemReorderService _itemReorderService;
        public ItemReorderController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, IItemReorderService itemReorderService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _itemReorderService = itemReorderService;
        }

        [HttpGet]
        public IActionResult ItemReorder(string ProductId, string ItemId, string SupId, string ReportType, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    Dictionary<string, DataTable> data = new();
                    data.Add("ds", _itemReorderService.GetItemReorder(ProductId, ItemId, SupId, ReportType));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\ItemReorder\\ItemReorder.rdlc";
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