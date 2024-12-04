using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    if (cbCategory.SelectedIndex != 0)
                        cmd.Parameters.AddWithValue("@category_id", cbCategory.SelectedValue);
                    dt.Load(cmd.ExecuteReader());
                }
                db.Close();
            }
        }
        void MakeExcel()
        {

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