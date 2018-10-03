using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTICLOUD
{
    public partial class food : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "select sitename,siteid,postype,regitered,updated from sites";
            SqlCommand cmd = null;
            SqlDataReader dbr = null;
            GTICLOUD.navbar.dropstring = "";
            sitebox.Text = "";
            try
            {

                if (Session["global"].ToString() == "" || Session["global"].ToString() == null)
                {


                    Response.Redirect("Default.aspx");

                }
                else
                {
                    GTICLOUD.navbar.dropstring += "  <li><a href='createsite.aspx'>Create Site</a></li>";
                    GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Settings</a></li>";
                    GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Logout</a></li>";


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

                                if (dbr["postype"].ToString().ToLower().Equals("food")) {



                                    sitebox.Text += "<div class='col s12 m4'>";
                                    sitebox.Text += "<div class='card white'>";
                                    sitebox.Text += "<div class='card-content black-text'>";
                                    sitebox.Text += "<span class='card-title'>" + dbr["sitename"].ToString() + "</span>";
                                    sitebox.Text += "<p> POS ID : " + dbr["siteid"].ToString() + "</p>";
                                    sitebox.Text += "<p> POS Type : " + dbr["postype"].ToString() + "</p>";
                                    sitebox.Text += "<p> <span>Updated :</span><span>" + dbr["regitered"].ToString() + "</span> </p>";
                                    sitebox.Text += " <p> <span>Created : </span><span>" + dbr["updated"].ToString() + "</span>  </p>";
                                    sitebox.Text += "</div>";
                                    sitebox.Text += "<div class='card-action'>";
                                    sitebox.Text += "<a href='site.aspx' class='theme-color'>GO TO SITE</a>";
                                    sitebox.Text += "</div></div></div>";
                                
                                }
                            
                               
                            }
                        }



                    }
                    catch (Exception ex)
                    {

                        Response.Redirect("Default.aspx");

                    }
                    finally
                    {

                        DB.CloseConn();
                        cmd.Dispose();
                        dbr.Dispose();
                    }




                    /*
                     
                                         <div class="col s12 m4">
                        <div class="card white">
                            <div class="card-content black-text">
                                <span class="card-title">Site One</span>
                                <p>
                                    Los Anglies South Zone(USA)
                                </p>
                                <p>
                                    <span>Updated :</span><span>2018-09-30 11:35 PM</span>
                                </p>
                                <p>
                                    <span>Created : </span><span>2018-09-30 11:35 PM</span>
                                </p>
                            </div>
                            <div class="card-action">
                                <a href="site.aspx" class="theme-color">GO TO SITE</a>
                            </div>
                        </div>
                    </div>
                     
                     */
                }

            }
            catch (Exception ex)
            {

                Response.Redirect("Default.aspx");
            }
        }
    }
}