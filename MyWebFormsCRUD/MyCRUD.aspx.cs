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
            cbCategory.Items.Insert(0, "Выбрать все");

            cbCategory2.DataSource = dt;
            cbCategory2.DataBind();
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
                    if(cbCategory.SelectedIndex != 0)
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
            {
                GetCategory();
                GetMusic();
            }
        }

       

        protected void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMusic();
        }

        void MusicAdd()
        {            
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pMusicAdd", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", tbName.Text);
                    cmd.Parameters.AddWithValue("@author", tbAuthor.Text);
                    cmd.Parameters.AddWithValue("@category_id", cbCategory2.SelectedValue);
                    cmd.Parameters.AddWithValue("@description", tbDesc.Text);
                    cmd.ExecuteNonQuery();
                }
                GetMusic();
                db.Close();
            }
        }

        protected void btIns_Click(object sender, EventArgs e)
        {
            MusicAdd();
        }

        protected void btClear_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbAuthor.Text = "";
            tbDesc.Text = "";
        }

        protected void GvMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            //id,name,author,category_id,description            
            music_id.Value = GvMusic.DataKeys[GvMusic.SelectedIndex].Values[0].ToString();
            tbName.Text = GvMusic.DataKeys[GvMusic.SelectedIndex].Values[1].ToString();
            tbAuthor.Text = GvMusic.DataKeys[GvMusic.SelectedIndex].Values[2].ToString();
            cbCategory2.SelectedValue = GvMusic.DataKeys[GvMusic.SelectedIndex].Values[3].ToString();
            tbDesc.Text = GvMusic.DataKeys[GvMusic.SelectedIndex].Values[4].ToString();
        }

        void MusicEdit()
        {
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pMusicEdit", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", music_id.Value);
                    cmd.Parameters.AddWithValue("@name", tbName.Text);
                    cmd.Parameters.AddWithValue("@author", tbAuthor.Text);
                    cmd.Parameters.AddWithValue("@category_id", cbCategory2.SelectedValue);
                    cmd.Parameters.AddWithValue("@description", tbDesc.Text);
                    cmd.ExecuteNonQuery();
                }
                GetMusic();
                db.Close();
            }
        }

        protected void btUpd_Click(object sender, EventArgs e)
        {
            MusicEdit();
        }
    }
}