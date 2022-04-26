using BarcodeLib;
using Operational.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Operational.Repository
{
    public class CommonService : ICommonService
    {
        public Dictionary<string, string> GetShopInfo(string ShopID)
        {
            Dictionary<string, string> shop_info = new();
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                string query = "SELECT top 1 [ShopID] ,[ShopName] ,[VillAreaRoad] ,[Post] ,[Pstation] ,[District] ,[Contact] ,[Phone] ,[VatRegNo] FROM [dbo].[ShopList] Where ShopID='" + ShopID + "'";
                SqlCommand cmd = new(query, objConnection);
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        shop_info.Add("ShopID", dataReader["ShopID"].ToString());
                        shop_info.Add("ShopName", dataReader["ShopName"].ToString());
                        shop_info.Add("VillAreaRoad", dataReader["VillAreaRoad"].ToString());
                        shop_info.Add("Post", dataReader["Post"].ToString());
                        shop_info.Add("Pstation", dataReader["Pstation"].ToString());
                        shop_info.Add("District", dataReader["District"].ToString());
                        shop_info.Add("Contact", dataReader["Contact"].ToString());
                        shop_info.Add("Phone", dataReader["Phone"].ToString());
                        shop_info.Add("VatRegNo", dataReader["VatRegNo"].ToString());
                    }
                }

                objConnection.Close();
                return shop_info;
            }
        }
        public string GetBarcodeImage(string barcodeImage)
        {
            Barcode barcodeAPI = new();
            int imageWidth = 290;
            int imageHeight = 120;
            Color foreColor = Color.Black;
            Color backColor = Color.Transparent;
            string data = barcodeImage;
            Image barcodeImg = barcodeAPI.Encode(TYPE.CODE128B, data, foreColor, backColor, imageWidth, imageHeight);
            return ImageToByteArray(barcodeImg);
        }
        private string ImageToByteArray(Image imageIn)
        {
            using (MemoryStream m = new())
            {
                imageIn.Save(m, ImageFormat.Png);
                byte[] imageBytes = m.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
        public string GetSecretKey()
        {
            return "1";
        }
        public string GetReportFileName(dynamic method, string inpurformat)
        {
            return method.Name + "_" + DateTime.Now.ToString("TyyOMMUddHHmmssffff") + "." + inpurformat.ToLower();
        }
    }
}
