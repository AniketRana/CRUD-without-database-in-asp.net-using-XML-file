using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CRUD_using_XMLFile
{
    public partial class Data1 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
        SqlDataAdapter adp = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        string sql = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            txtid.Enabled = false;
            if (!IsPostBack)
            {
                loaddata();
            }
        }
        public void loaddata()
        {
            con.Open();
            sql = "Select * from Employee";
            adp = new SqlDataAdapter(sql, con);
            adp.Fill(dt);
            grv.DataSource = dt;
            grv.DataBind();
            con.Close();
        }

        protected void btnSUbmit_Click(object sender, EventArgs e)
        {
            if (btnSUbmit.Text.ToString().Equals("Update Record"))
            {
                con.Open();
                sql = "update employee set Name = '" + txtName.Text + "',";
                sql += "Designation = '" + txtDesignation.Text + "',";
                sql += "salary = '" + txtSal.Text + "'";
                sql += "where id = " + txtid.Text + "";

                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
                loaddata();
            }
            else
            {
                //Insert Code
                con.Open();

                sql = "insert into employee (Name,Designation,Salary) values ('"+txtName.Text+"','"+txtDesignation.Text+"','"+txtSal.Text+"')";
                
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
                loaddata();

                
            }
        }

        public void clear()
        {
            txtid.Enabled = false;
            btnSUbmit.Text = "Submit";
            txtid.Text = "";
            txtDesignation.Text = "";
            txtSal.Text = "";
            txtName.Text = "";
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void lbtnEdit_Command(object sender, CommandEventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string id = btn.CommandName;

            con.Open();
            sql = "Select * from employee where id = " + id + "";
            adp = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();

            txtid.Text = dt.Rows[0]["id"].ToString();
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
            txtSal.Text = dt.Rows[0]["Salary"].ToString();

            txtid.Enabled = false;
            btnSUbmit.Text = "Update Record";
        }

        protected void LbtnDelete_Command(object sender, CommandEventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string id = btn.CommandArgument;

            con.Open();
            sql = "delete from employee where id = "+id+"";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();            
            con.Close();
            loaddata();
        }
    }
}