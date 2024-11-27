using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebFormsCRUD
{
    public partial class MyCRUD : System.Web.UI.Page
    {

        void GetCategory()
        {            
            DataTable dt = new DataTable();
            using (SqlConnection db = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\байбатыровм\\Documents\\MyDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pGetCategory", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    dt.Load(cmd.ExecuteReader());
                }
                db.Close();
            }
            cbCategory.DataSource = dt;
            cbCategory.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCategory();
        }       
    }
}