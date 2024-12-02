using System;
using System.Collections.Generic;
using System.Configuration;
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
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
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

        void GetMusic()
        {
            DataTable dt = new DataTable();
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pGetMusic", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category_id", cbCategory.SelectedValue);
                    dt.Load(cmd.ExecuteReader());
                }
                db.Close();
            }
            GvMusic.DataSource = dt;
            GvMusic.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                GetCategory();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetMusic();
        }

        protected void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMusic();
        }
    }
}