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
    public class InventoryController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        private readonly Dictionary<string, DataTable> data = new();
        private readonly Dictionary<string, string> param_list = new();
        private readonly ICommonService _commonService;
        private readonly IInventoryService _inventoryService;
        public InventoryController(IWebHostEnvironment iWebHostEnvironment, ICommonService commonService, IInventoryService inventoryService)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _commonService = commonService;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IActionResult Inventory(string FromDate, string Todate, string ShopId, string ProductId, string ItemId, string SupId, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    param_list.Add("FromDate", FromDate);
                    param_list.Add("Todate", Todate);
                    data.Add("ds", _inventoryService.GetInventory(FromDate, Todate, ShopId, ProductId, ItemId, SupId));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Inventory\\Inventory.rdlc";
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
        public IActionResult InventoryChallan(string UserIdOrChallan, bool IsTemp, string SecretKey)
        {
            string inpurformat = "PDF";
            try
            {
                if (_commonService.GetSecretKey() == SecretKey)
                {
                    data.Add("ds", _inventoryService.GetInventoryChallan(UserIdOrChallan, IsTemp));
                    var path = $"{_iWebHostEnvironment.WebRootPath}\\Reports\\rdlc\\Inventory\\InventoryChallanWise.rdlc";
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