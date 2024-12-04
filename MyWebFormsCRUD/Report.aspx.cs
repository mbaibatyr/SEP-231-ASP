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
        void MakeExcel()
        {
            var dt = GetData();
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet(dt, "report");
                ws.Columns("B").AdjustToContents();
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    //ms.CopyTo(Response.OutputStream);
                    Response.OutputStream.Write(ms.ToArray(), 0, (int)ms.Length);
                    Response.End();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var p = Request.QueryString["param1"];
            switch (p)
            {
                case "0":
                    Response.Write("Excel");
                    break;
                case "1":
                    Response.Write("CSV");
                    break;
            }

        }
    }
}