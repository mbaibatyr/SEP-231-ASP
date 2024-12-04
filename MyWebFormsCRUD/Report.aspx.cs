using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using DataTable = System.Data.DataTable;

namespace MyWebFormsCRUD
{
    public partial class Report : System.Web.UI.Page
    {
        DataTable GetData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pGetMusic", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    dt.Load(cmd.ExecuteReader());
                }
                db.Close();
                return dt;
            }
        }
        byte[] MakeExcel()
        {
            var dt = GetData();
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet(dt, "report");
                ws.Columns("F").AdjustToContents();
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return ms.ToArray();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var p = Request.QueryString["param1"];
            switch (p)
            {
                case "0":
                    var bytes = MakeExcel();
                    //Response.Write("Excel");
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", "report.xlsx"));

                    //ms.CopyTo(Response.OutputStream);
                    Response.OutputStream.Write(bytes, 0, (int)bytes.Length);
                    Response.End();

                    break;
                case "1":
                    Response.Write("CSV");
                    break;
            }

        }
    }
}