using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Data;

namespace CMS.Client.Admin
{
    public partial class listofficial : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
            {
                btn_editpage.Visible = true;
                btn_enable.Visible = true;
                btn_disable.Visible = true;
                btn_delall.Visible = true;

            }
            else
            {
                btn_editpage.Visible = false;
                btn_enable.Visible = false;
                btn_disable.Visible = false;
                btn_delall.Visible = false;
            }

            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
            {
                btn_enable_approval.Visible = true;
                btn_disable_approval.Visible = true;

            }
            else
            {
                btn_enable_approval.Visible = false;
                btn_disable_approval.Visible = false;
            }

            if (!IsPostBack)
                ViewOfficial();
        }
        #region NavigationTitle
        private void NavigationTitle(string url)
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region ViewOfficial
        private void ViewOfficial()
        {
            int group = 4;
            OfficialBSO officialBSO = new OfficialBSO();
            DataTable table = new DataTable();

            if (!Session["Admin_UserName"].Equals("administrator"))
            {
                string strCate = GetCateParentIDArrayByID(group);
                if (strCate != "")
                    table = officialBSO.GetOfficialByCateHomeList(strCate);
            }
            else
            {
                table = officialBSO.GetOfficialAll();
            }

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvOfficial, table);
            BindCateSearch(group);
        }
        #endregion

        private string GetCateParentIDArrayByID(int group)
        {
            string strArrayID = "";

            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table1 = cateNewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());

            if (table1.Rows.Count > 0)
            {
                foreach (DataRow subrow in table1.Rows)
                {
                    strArrayID += subrow["CateNewsID"].ToString() + ",";
                    // strArrayID += GetCateParentIDArrayByID(Convert.ToInt32(subrow["CateNewsID"].ToString()));
                }

            }

            return strArrayID;

        }

        //#region BindCateSearch
        //private void BindCateSearch()
        //{
        //    ddlCateNewsSearch.Items.Clear();
        //    CateNewsBSO catenewsBSO = new CateNewsBSO();
        //    DataTable table = catenewsBSO.GetCateNews(Language.language);
        //    DataView dataView = new DataView(table);
        //    dataView.RowFilter = "GroupCate = 4";
        //    ddlCateNewsSearch.DataSource = dataView;
        //    ddlCateNewsSearch.DataTextField = "CateNewsName";
        //    ddlCateNewsSearch.DataValueField = "CateNewsID";
        //    ddlCateNewsSearch.Items.Add(new ListItem("~~~ Trong tat ca ~~~", "0"));
        //    ddlCateNewsSearch.DataBind();
        //}
        //#endregion

        #region BindCateSearch
        private void BindCateSearch(int group)
        {
            ddlCateNewsSearch.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlCateNewsSearch, table, "~~ Trong tất cả ~~", "0", "CateNewsName", "CateNewsID", "");
        }
        #endregion

        #region OfficialID
        private string OfficialID()
        {
            string officialId = "";
            foreach (GridViewRow rows in grvOfficial.Rows)
            {
                CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
                if (checkbox.Checked)
                    officialId += rows.Cells[0].Text + ",";
            }
            return officialId;
        }

        #endregion

        protected void grvOfficial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvOfficial.PageIndex = e.NewPageIndex;
            ViewOfficial();
        }
        protected void grvOfficial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = new ETO.Admin();
            switch (cName)
            {
                case "_listfiles":
                    Response.Redirect("~/Admin/listofficialfiles/" + Id + "/Default.aspx");
                    break;

                case "_addfiles":
                    Response.Redirect("~/Admin/editofficialfiles/" + Id + "/0/Default.aspx");
                    break;


                case "_view":
                    break;

                case "_edit":
                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        Response.Redirect("~/Admin/editofficial/" + Id + "/Default.aspx");

                    }
                    else
                    {
                        //  Response.Redirect("~/Admin/Default.aspx?dll=listnews");
                    }

                    break;
                case "_delete":
                    admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                    if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                    {
                        OfficialBSO officialBSO = new OfficialBSO();
                        officialBSO.DeleteOfficial(Id);
                        ViewOfficial(); ;

                    }
                    else
                    {
                        //  Response.Redirect("~/Admin/Default.aspx?dll=listnews");
                    }

                    break;
            }
        }
        protected void grvOfficial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                //    image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");

                ImageButton image_view = (ImageButton)e.Row.FindControl("btn_view");
                image_view.Attributes.Add("onclick", "javascript:window.open('~/Client/Admin/ViewOfficial.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "OfficialID") + "','_blank','width=800,height=600');");

                ImageButton image_edit = (ImageButton)e.Row.FindControl("btn_edit");

                AdminBSO adminBSO = new AdminBSO();
                ETO.Admin admin = new ETO.Admin();
                admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
                }
                else
                {
                    image_edit.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                    image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn không có đủ quyền ???');");
                }
            }
        }
        protected void btn_enable_Click(object sender, EventArgs e)
        {
            if (OfficialID() != "")
            {
                OfficialBSO officialBSO = new OfficialBSO();
                officialBSO.UpdateOfficial(OfficialID(), "1");
            }
            ViewOfficial();
        }
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            if (OfficialID() != "")
            {
                OfficialBSO officialBSO = new OfficialBSO();
                officialBSO.UpdateOfficial(OfficialID(), "0");
            }
            ViewOfficial();
        }
        protected void btn_enable_approval_Click(object sender, EventArgs e)
        {
            if (OfficialID() != "")
            {
                OfficialBSO officialBSO = new OfficialBSO();
                officialBSO.UpdateOfficial(OfficialID(), "1", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewOfficial();
        }
        protected void btn_disable_approval_Click(object sender, EventArgs e)
        {
            if (OfficialID() != "")
            {
                OfficialBSO officialBSO = new OfficialBSO();
                officialBSO.UpdateOfficial(OfficialID(), "0", Session["Admin_UserName"].ToString(), DateTime.Now);
            }
            ViewOfficial();
        }
        protected void btn_delall_Click(object sender, EventArgs e)
        {
            if (OfficialID() != "")
            {
                OfficialBSO officialBSO = new OfficialBSO();
                officialBSO.DeleteOfficial(OfficialID());
            }
            ViewOfficial();
        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text != "")
            {
                int cId = Convert.ToInt32(ddlCateNewsSearch.SelectedValue);
                OfficialBSO officialBSO = new OfficialBSO();
                DataTable table = officialBSO.OfficialSearch(txtKeyword.Text, cId, Language.language);
                commonBSO commonBSO = new commonBSO();
                commonBSO.FillToGridView(grvOfficial, table);
                BindCateSearch(4);
            }
        }

    }
}