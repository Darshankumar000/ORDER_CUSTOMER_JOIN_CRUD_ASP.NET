using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JOIN_CRUD
{
    public partial class Joincrud : System.Web.UI.Page
    {
        string strcon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2MCA\.NET\JOIN_CRUD\JOIN_CRUD\App_Data\Database1.mdf;Integrated Security=True";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            fillIdName();
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "insert into Orders(Custid,Orderdate,Shipdate,Orderamt,Paymentmode,Remarks) values(@Custid,@Orderdate,@Shipdate,@Orderamt,@Paymentmode,@Remarks)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Custid",ddcustid.SelectedValue);
            cmd.Parameters.AddWithValue("@Orderdate", txtorderdate.Text);
            cmd.Parameters.AddWithValue("@Shipdate", txtshipdate.Text);
            cmd.Parameters.AddWithValue("@Orderamt", txtorderamt.Text);
            cmd.Parameters.AddWithValue("@Paymentmode", ddpaymentmode.SelectedValue);
            cmd.Parameters.AddWithValue("@Remarks", txtremark.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Record inserted.....')</script>");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "update Orders set Custid=@Custid,Orderdate=@Orderdate,Shipdate=@Shipdate,Orderamt=@Orderamt,Paymentmode=@Paymentmode,Remarks=@Remarks where Orderid='"+txtorderid.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Custid", ddcustid.SelectedValue);
            cmd.Parameters.AddWithValue("@Orderdate", txtorderdate.Text);
            cmd.Parameters.AddWithValue("@Shipdate", txtshipdate.Text);
            cmd.Parameters.AddWithValue("@Orderamt", txtorderamt.Text);
            cmd.Parameters.AddWithValue("@Paymentmode", ddpaymentmode.SelectedValue);
            cmd.Parameters.AddWithValue("@Remarks", txtremark.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Record Updated.....')</script>");
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "select * from Orders where Orderid='"+txtorderid.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                ddcustid.SelectedValue = dr["Custid"].ToString();
                txtorderdate.Text = dr["Orderdate"].ToString();
                txtshipdate.Text = dr["Shipdate"].ToString();
                txtorderamt.Text = dr["Orderamt"].ToString();
                ddpaymentmode.SelectedValue = dr["Paymentmode"].ToString();
                txtremark.Text = dr["Remarks"].ToString();

            }
            con.Close();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "delete from Orders where Orderid='" + txtorderid.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Record Deleted.....')</script>");

        }

        public void fillIdName()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "select Custid from Customer";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddcustid.Items.Add(dr[0].ToString());
            }
            con.Close();
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            string query = "select o.Orderid,o.Custid,c.Name,c.City,c.State,o.Orderamt from Customer c ,Orders o where c.Custid=o.Custid";
            SqlDataAdapter adpt = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(ddsearch.SelectedValue=="Query1")
            {
                //Display all orders with orderid, custid, customer name, city, state, order amount.
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select o.Orderid,o.Custid,c.Name,c.City,c.State,o.Orderamt from Customer c,Orders o where c.Custid = o.custid";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if(ddsearch.SelectedValue=="Query2")
            {
                //) Display all orders with OrderID, CustID, customer name, city, state with order amount greater than 10000.
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select o.Orderid,o.Custid,c.Name,c.City,c.State,o.Orderamt from Customer c,Orders o Where c.Custid = o.Custid and o.Orderamt>10000";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if(ddsearch.SelectedValue=="Query3")
            {
                //Display customer details with total order amount
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select sum(o.Orderamt) from Orders o GROUP BY o.Custid ";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if(ddsearch.SelectedValue=="Query4")
            {
                //Display CustID, name, OrderAmount by Month and Year
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select * from Customer c,Orders o  Where c.Custid=o.Custid ORDER BY YEAR(o.Orderdate),MONTH(o.Orderdate)";
                SqlDataAdapter adpt = new SqlDataAdapter(query,con);
                DataSet ds = new DataSet();
                    adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if(ddsearch.SelectedValue=="Query5")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select Paymentmode,SUM(Orderamt) from Orders GROUP BY Paymentmode";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if (ddsearch.SelectedValue == "Query6")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "Select Paymentmode,Orderamt,Orderdate from Orders Where Orderdate <'30/12/2023' and Orderdate > '01/01/2023' ";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if (ddsearch.SelectedValue == "Query7")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if (ddsearch.SelectedValue == "Query8")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select Paymentmode,SUM(Orderamt) AS Total_Amount from Orders Group by Paymentmode";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();

                

            }
            else if (ddsearch.SelectedValue == "Query9")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select * from Orders o , Customer c where o.Orderamt between 10000 and 30000 and c.Custid=o.Custid ";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else if (ddsearch.SelectedValue == "Query10")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select * from Customer where Name in('Darshan','pradip','keyur')";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                con.Close();
            }
            else
            {
                Response.Write("Please select value");
            }
        }
    }
}


