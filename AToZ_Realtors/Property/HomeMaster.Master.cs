﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Property_cls;
using System.Data.SqlClient;
using System.Configuration;

namespace Property
{
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        #region Global
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        cls_Property clsobj = new cls_Property();

        #endregion Global
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["FirstName"] = null;
                BindMenusList();
                SiteSetting();
                bindBnanners();
                //GetTestimonials();
            }
        }

        
        private void BindMenusList()
        {
            StringBuilder StrMenu = new StringBuilder();
            DataTable dt = new DataTable();
            DataTable dtSubmenu = new DataTable();
            dt = clsobj.GetMenuList();
            if (dt.Rows.Count > 0)
            {
                string PageName = dt.Rows[0]["PageName"].ToString();
                StrMenu.Append("<a class='toggleMenu' href='#'></a>");
                StrMenu.Append("<ul class='nav'>");
                StrMenu.Append("<li><a href='../Home.aspx' title='Home'>Home</a></li>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsobj.PageID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    dtSubmenu = clsobj.GetSubMenuBy_PageID();
                    if (dtSubmenu.Rows.Count > 0)
                    {
                        StrMenu.Append("<li><a href=#>" + dt.Rows[i]["PageName"] + "</a>");//</li>
                        StrMenu.Append("<ul>");
                        for (int j = 0; j < dtSubmenu.Rows.Count; j++)
                        {
                            StrMenu.Append("<li><a href='../StaticPages.aspx?PageID=" + dtSubmenu.Rows[j]["id"] + "' title='" + dtSubmenu.Rows[j]["PageName"] + "'>" + dtSubmenu.Rows[j]["PageName"] + "</a> </li>");
                        }
                        StrMenu.Append("</ul>");
                        StrMenu.Append("</li>");
                    }
                    else
                    {
                        StrMenu.Append("<li><a href='../StaticPages.aspx?PageID=" + dt.Rows[i]["id"] + "' title='" + dt.Rows[i]["PageName"] + "'>" + dt.Rows[i]["PageName"] + "</a>");//</li>
                    }
                }
                StrMenu.Append("<li><a href=#>Exclusive</a>");//</li>
                StrMenu.Append("<ul >");
                StrMenu.Append("<li><a href='../my_haves_and_wants.aspx' title=''>My Haves and Wants</a></li>");
                StrMenu.Append("<li><a href='../Residential_Haves_and_Wants.aspx'>Residential Haves and Wants, Mostly Exclusive</a></li>");
                StrMenu.Append("<li><a href='../Ontario_Commercial_Mostly_Exclusive.aspx'>Ontario Commercial, Mostly Exclusive </a></li>");
                StrMenu.Append("<li><a href='../World_Commercial.aspx'> World Commercial</ a></li>");
                StrMenu.Append("<li><a href='../Business_Haves_and_Wants.aspx'>Business Haves and Wants </a></li>");
                StrMenu.Append("<li><a href='../For_Sale_by_Owner.aspx'>For Sale by Owner </a></li>");
                StrMenu.Append("</ul>");
                StrMenu.Append("<li>");
                StrMenu.Append("<a href='../Calculators.aspx' title='Calculators'>Calculators</a>");
                StrMenu.Append("</li>");
                StrMenu.Append("<li>");
                StrMenu.Append("<a href='../RealEstateNews.aspx' title='Real Estate News'>Real Estate News</a>");
                StrMenu.Append("</li>");
                StrMenu.Append("<li class='test'><a href='home_worth.aspx' title='Home Evaluation'>Home Evaluation</a></li>");
                StrMenu.Append("<li class='test' ><a href='VirtualTour.aspx' title='Virtual Tour'>Virtual Tour</a></li>");
                StrMenu.Append("<li class='test'><a href='ContactUs.aspx' title='Contact Us'>Contact Us</a></li>");
                StrMenu.Append("</ul>");
            }
            dynamicmenus.Text = StrMenu.ToString();
        }
        protected void SiteSetting()
        {
            try
            {
                DataTable dt = clsobj.GetSiteSettings();
                DataTable dt1 = clsobj.GetUserInfo();
                if (dt.Rows.Count > 0)
                {
                    //headerlblemailid.Text = Convert.ToString(dt.Rows[0]["Email"]);
                    lblemailid.Text = Convert.ToString(dt.Rows[0]["Email"]);
                    siteTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                    //lblemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                    //lblmobile.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                    //lblemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                    //lblBrkrOneName.Text = Convert.ToString(dt1.Rows[0]["FirstName"]) + " " + Convert.ToString(dt1.Rows[0]["LastName"]);
                    //lblphn.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                    lblph.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                    byte[] favimage = (byte[])dt.Rows[0]["Favicon.ico"];
                    if (favimage.Length > 0)
                    {
                        Session["MyFavicon"] = favimage;
                        favicon.Visible = true;
                        favicon.Href = "~/ShowFavicon.aspx";
                    }
                    else
                    {
                        favicon.Visible = false;
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void bindBnanners()
        {
            StringBuilder html = new StringBuilder();
            DataTable dt = clsobj.GetAllBanner();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Images;
                Images = "/admin/uploadfiles/" + dt.Rows[i]["FileName"].ToString();
                if (Images != "")
                {
                    html.AppendLine("<img src='" + Images + "'  data-thumb='" + Images + "'  alt='banner" + i + "' />");
                }
            }
            ltrImgsf.Text = html.ToString();
        }
    }
}