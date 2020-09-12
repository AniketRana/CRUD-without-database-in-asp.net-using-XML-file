using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CRUD_using_XMLFile
{
    public partial class Data : System.Web.UI.Page
    {
        string xmlfile = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                xmlfile = Server.MapPath("App_Data/Employees.xml");
                LoadData();
            }
        }
        public void LoadData()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("App_Data/Employees.xml"));
            grv.DataSource = ds;
            grv.DataBind();
        }
        public void reset()
        {
            txtid.Text = "";
            txtName.Text = "";
            txtCity.Text = "";
            txtAdd.Text = "";
            txtSal.Text = "";
            txtEmail.Text = "";
            txtid.Enabled = true;
            btnSUbmit.Text = "Submit";
            ddlGen.SelectedIndex = 0;
        }
        public void Insert()
        {

            XmlDocument xmlEmloyeeDoc = new XmlDocument();
            xmlEmloyeeDoc.Load(Server.MapPath("App_Data/Employees.xml"));
            XmlElement ParentElement = xmlEmloyeeDoc.CreateElement("Emp");
            XmlElement ID = xmlEmloyeeDoc.CreateElement("id");
            ID.InnerText = txtid.Text;
            XmlElement Name = xmlEmloyeeDoc.CreateElement("Name");
            Name.InnerText = txtName.Text;
            XmlElement city = xmlEmloyeeDoc.CreateElement("City");
            city.InnerText = txtCity.Text;
            XmlElement gender = xmlEmloyeeDoc.CreateElement("Gender");
            gender.InnerText = ddlGen.SelectedItem.Text;
            XmlElement address = xmlEmloyeeDoc.CreateElement("Address");
            address.InnerText = txtAdd.Text;
            XmlElement salary = xmlEmloyeeDoc.CreateElement("salary");
            salary.InnerText = txtSal.Text;
            XmlElement email = xmlEmloyeeDoc.CreateElement("Email");
            email.InnerText = txtEmail.Text;

            ParentElement.AppendChild(ID);
            ParentElement.AppendChild(Name);
            ParentElement.AppendChild(city);
            ParentElement.AppendChild(gender);
            ParentElement.AppendChild(address);
            ParentElement.AppendChild(salary);
            ParentElement.AppendChild(email);

            xmlEmloyeeDoc.DocumentElement.AppendChild(ParentElement);
            xmlEmloyeeDoc.Save(Server.MapPath("App_Data/Employees.xml"));
            LoadData();
        }

        protected void btnSUbmit_Click(object sender, EventArgs e)
        {
            if (btnSUbmit.Text.ToString().Equals("Update Record"))
            {
                DataSet ds = new DataSet();

                ds.ReadXml(Server.MapPath("App_Data/Employees.xml"));

                int xmlRow = Convert.ToInt32(Convert.ToString(ViewState["gridrow"]));

                ds.Tables[0].Rows[xmlRow]["Name"] = txtName.Text;
                ds.Tables[0].Rows[xmlRow]["City"] = txtCity.Text;
                ds.Tables[0].Rows[xmlRow]["Gender"] = ddlGen.SelectedItem.Text;
                ds.Tables[0].Rows[xmlRow]["Address"] = txtAdd.Text;
                ds.Tables[0].Rows[xmlRow]["salary"] = txtSal.Text;
                ds.Tables[0].Rows[xmlRow]["Email"] = txtEmail.Text;
                ds.WriteXml(Server.MapPath("App_Data/Employees.xml"));
                LoadData();

            }
            else
            {
                Insert();
                reset();
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected void grv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("App_Data/Employees.xml"));
            ds.Tables[0].Rows.RemoveAt(e.RowIndex);
            ds.WriteXml(Server.MapPath("App_Data/Employees.xml"));
            LoadData();
        }

        protected void grv_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grv.SelectedRow;
            txtid.Text = (row.FindControl("lblid") as Label).Text;
            txtName.Text = (row.FindControl("lblname") as Label).Text;
            txtCity.Text = (row.FindControl("lblcity") as Label).Text;
            
            if ((row.FindControl("lblgender") as Label).Text=="Male")
            {
                ddlGen.SelectedIndex = 0;
            }
            else
            {
                ddlGen.SelectedIndex = 1;
            }

            txtAdd.Text = (row.FindControl("lbladdress") as Label).Text;
            txtSal.Text = (row.FindControl("lblsalary") as Label).Text;
            txtEmail.Text = (row.FindControl("lblemail") as Label).Text;
            ViewState["gridrow"] = row.RowIndex.ToString();
            btnSUbmit.Text = "Update Record";
            txtid.Enabled = false;
        }
    }
}