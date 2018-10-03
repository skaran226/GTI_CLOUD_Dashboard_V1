using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;

namespace GTICLOUD
{
    public partial class Fixed_side_nav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string query = "select *from sidenav";
            SqlCommand cmd = null;
            SqlDataReader dbr = null;

            dynamic_list.Text = "";
            try
            {

                if (Session["global"].ToString() == "" || Session["global"].ToString() == null)
                {


                    Response.Redirect("Default.aspx");

                }
                else
                {


                    try
                    {
                        DB.CloseConn();
                         cmd = DB.ExecuteReader(query);
                         dbr = cmd.ExecuteReader();

                        if (dbr.HasRows == false)
                        {


                        }
                        else
                        {

                            while (dbr.Read())
                            {

                                if (Session["global"].Equals("Admin") || Session["global"].Equals("Technician") || Session["global"].Equals("Account Manager"))
                                {
                                    dynamic_list.Text += "<li><a href='" + dbr["redirect"].ToString() + "'>" + dbr["content_name"].ToString() + "</a></li><li class='divider'></li>";

                                }
                                else
                                {

                                    dynamic_list.Text = "<li><a href='#!'>In Progress</a></li>";

                                }

                            }
                        }



                    }
                    catch (Exception ex)
                    {

                        Response.Redirect("Default.aspx");

                    }
                    finally {

                        DB.CloseConn();
                        cmd.Dispose();
                        dbr.Dispose();
                    }


                }


            }
            catch (Exception ex)
            {

                Response.Redirect("Default.aspx");
            }

        }
    }
}