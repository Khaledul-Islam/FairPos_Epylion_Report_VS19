using Operational.Service;
using System.Data;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        public DataTable GetPurchaseOrder(string challan_no)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_Get_PurchaseOrder");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Chln", SqlDbType.NVarChar).Value = challan_no;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }

        public DataTable GetPurchaseOrder(string FromDate, string Todate, string ProductId, string ItemId, string SupId, string CancelType)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = string.Format(@"SP_ReportPurchaseOrder");
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = FromDate;
                cmd.Parameters.Add("@Todate", SqlDbType.NVarChar).Value = Todate;
                cmd.Parameters.Add("@ProductId", SqlDbType.NVarChar).Value = ProductId;
                cmd.Parameters.Add("@ItemId", SqlDbType.NVarChar).Value = ItemId;
                cmd.Parameters.Add("@SupId", SqlDbType.NVarChar).Value = SupId;
                cmd.Parameters.Add("@CancelType", SqlDbType.NVarChar).Value = CancelType;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetPurchaseOrderPreview(string userId, string matrutitydays, string partialDel, string QutRefNo, string paymentTerms)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = @"SELECT        BuyOrder.CmpIDX, BuyOrder.Chln, BuyOrder.sBarCode, BuyOrder.BarCode, BuyOrder.BoxQty Qty, Product.PrdID, Product.PrdName, BuyOrder.sQty, BuyOrder.DiscPrcnt, BuyOrder.VATPrcnt, BuyOrder.PrdComm, 
                                                     BuyOrder.CPU, BuyOrder.RPU, BuyOrder.BuyDT, BuyOrder.EXPDT, BuyOrder.UserID, BuyOrder.SupID, Supplier.GenCName Supname, StyleSize.ItemName, 0 VatAmt, '" + paymentTerms + @"' PaymentTerms,
                                                     " + matrutitydays + " AS MaturtyDays, '" + partialDel + "' PartialDelivery, '" + QutRefNo + @"' QutRefNo, Supplier.RegName, Supplier.GenCCell TradePhone, Supplier.RegAdd1, MeasureUnit.UOMName, Supplier.chkVATCertificate
                                                        ,PackUOM,POPackQty, StyleSize.POPackSize,CAST(0 AS BIT) IS_CANCEL
                            FROM            Product INNER JOIN
                                                     StyleSize ON Product.PrdID = StyleSize.PrdID INNER JOIN
                                                     BuyOrderTemp BuyOrder ON StyleSize.sBarcode = BuyOrder.sBarCode INNER JOIN
                                                     Supplier ON BuyOrder.SupID = Supplier.SupID INNER JOIN
                                                     MeasureUnit ON StyleSize.UOMId = MeasureUnit.UOMId
                                                   
                            WHERE BuyOrder.UserID='" + userId + "' "; ;
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.Text;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
        public DataTable GetPurchaseOrderPreview2(string userId, string matrutitydays, string partialDel, string QutRefNo, string paymentTerms)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = @"SELECT        BuyOrder.CmpIDX, BuyOrder.Chln, BuyOrder.sBarCode, BuyOrder.BarCode, BuyOrder.BoxQty Qty, Product.PrdID, Product.PrdName, BuyOrder.sQty, BuyOrder.DiscPrcnt, BuyOrder.VATPrcnt, BuyOrder.PrdComm, 
                                                     BuyOrder.CPU, BuyOrder.RPU, BuyOrder.BuyDT, BuyOrder.EXPDT, BuyOrder.UserID, BuyOrder.SupID, Supplier.GenCName Supname, StyleSize.ItemName, 0 VatAmt, '" + paymentTerms + @"' PaymentTerms, 
                                                     " + matrutitydays + " AS MaturtyDays, '" + partialDel + "' PartialDelivery, '" + QutRefNo + @"' QutRefNo, Supplier.RegName, Supplier.GenCCell TradePhone, Supplier.RegAdd1, MeasureUnit.UOMName, Supplier.chkVATCertificate
                                                        ,PackUOM,POPackQty, StyleSize.POPackSize,CAST(0 AS BIT) IS_CANCEL
                            FROM            Product INNER JOIN
                                                     StyleSize ON Product.PrdID = StyleSize.PrdID INNER JOIN
                                                     BuyOrderTempEdit BuyOrder ON StyleSize.sBarcode = BuyOrder.sBarCode INNER JOIN
                                                     Supplier ON BuyOrder.SupID = Supplier.SupID INNER JOIN
                                                     MeasureUnit ON StyleSize.UOMId = MeasureUnit.UOMId
                                                 
                            WHERE BuyOrder.UserID='" + userId + "' ";
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.Text;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }

        public DataTable GetPurchaseOrderPreview3(string userId, string matrutitydays, string partialDel, string QutRefNo, string paymentTerms, string barcodeList)
        {
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                DataTable dt = new();
                string query = @"SELECT        BuyOrder.CmpIDX, BuyOrder.Chln, BuyOrder.sBarCode, BuyOrder.BarCode, BuyOrder.BoxQty Qty, Product.PrdID, Product.PrdName, BuyOrder.sQty, BuyOrder.DiscPrcnt, BuyOrder.VATPrcnt, BuyOrder.PrdComm, 
                                                     BuyOrder.CRPU CPU, BuyOrder.CRPU RPU, BuyOrder.BuyDT, BuyOrder.EXPDT, BuyOrder.UserID, BuyOrder.SupID, Supplier.GenCName Supname, StyleSize.ItemName, 0 VatAmt, '" + paymentTerms + @"' PaymentTerms, 
                                                     " + matrutitydays + " AS MaturtyDays, '" + partialDel + "' PartialDelivery, '" + QutRefNo + @"' QutRefNo, Supplier.RegName, Supplier.GenCCell TradePhone, Supplier.RegAdd1, MeasureUnit.UOMName, Supplier.chkVATCertificate
                                                        ,PackUOM,POPackQty, StyleSize.POPackSize, CAST(0 AS BIT) IS_CANCEL
                            FROM            Product INNER JOIN
                                                     StyleSize ON Product.PrdID = StyleSize.PrdID INNER JOIN
                                                     BuyOrderReqTemp BuyOrder ON StyleSize.sBarcode = BuyOrder.sBarCode INNER JOIN
                                                     Supplier ON BuyOrder.SupID = Supplier.SupID INNER JOIN
                                                     MeasureUnit ON StyleSize.UOMId = MeasureUnit.UOMId
                                                   
                            WHERE BuyOrder.UserID='" + userId + "' and BuyOrder.BarCode in (" + barcodeList + ") ";
                SqlCommand cmd = new(query, objConnection);
                cmd.CommandType = CommandType.Text;
                dt.Load(cmd.ExecuteReader());
                objConnection.Close();
                return dt;
            }
        }
    }
}
