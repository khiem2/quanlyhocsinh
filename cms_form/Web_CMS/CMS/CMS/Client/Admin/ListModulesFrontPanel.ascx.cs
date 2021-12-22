﻿using System;
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
    public partial class ListModulesFrontPanel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                ViewModulesFrontPanel(rdbPanel.SelectedValue);
            }

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
        public void ViewModulesFrontPanel(string Panel)
        {
            ModulesFrontPanelBSO _modulesFrontPanelBSO = new ModulesFrontPanelBSO();
            DataTable table = new DataTable();
            bool check_lag = Check_Viet.Checked;
            if (Panel.Equals("All"))
                if (check_lag)
                {
                    table = _modulesFrontPanelBSO.MixModulesFrontPanel_lag("vi-VN");
                }
                else
                {
                    //  table = _modulesFrontPanelBSO.MixModulesFrontPanel();
                    table = _modulesFrontPanelBSO.MixModulesFrontPanel_lag("en-US");
                }

            else
                if (check_lag)
                {
                    //table = _modulesFrontPanelBSO.MixModulesFrontPanel(Panel, "vi-VN");
                    table = _modulesFrontPanelBSO.MixModulesFrontPanel_lag_Vitri(Panel, "vi-VN");
                }
                else
                {
                    table = _modulesFrontPanelBSO.MixModulesFrontPanel_lag_Vitri(Panel, "en-US");
                    // table = _modulesFrontPanelBSO.MixModulesFrontPanel(Panel, "en-US");
                }
            //  table = _modulesFrontPanelBSO.MixModulesFrontPanel(Panel);

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(GridView1, table);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int mID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
            string cName = e.CommandName.ToLower().Trim();
            switch (cName)
            {
                case "edit":
                    Response.Redirect("~/Admin/editmodulesfrontpanel/" + mID + "/Default.aspx");
                    break;
                case "delete":
                    ModulesFrontPanelBSO _modulesFrontPanelBSO = new ModulesFrontPanelBSO();
                    _modulesFrontPanelBSO.DeleteModulesFrontPanel(mID);
                    ViewModulesFrontPanel(rdbPanel.SelectedValue);
                    break;
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");
            }
        }

        protected void chkHead_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow header = GridView1.HeaderRow;
            CheckBox b = (CheckBox)header.FindControl("chkHead");
            if (b != null)
                ToggleCheckBoxState(b.Checked);
        }
        protected void ToggleCheckBoxState(Boolean currentState)
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox foundCheckBox = (CheckBox)row.FindControl("chkItems");
                if (foundCheckBox != null)
                {
                    foundCheckBox.Checked = currentState;
                }
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void btn_Order_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtModulesFrontPanelOrder");
                int cOrder = Convert.ToInt32(textOrder.Text);
                int cateID = Convert.ToInt32(row.Cells[0].Text);
                ModulesFrontPanelBSO _modulesFrontPanelBSO = new ModulesFrontPanelBSO();
                _modulesFrontPanelBSO.ModulesFrontPanelUpOrder(cateID, cOrder);
            }
            ViewModulesFrontPanel(rdbPanel.SelectedValue);
        }

        protected void rdbPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewModulesFrontPanel(rdbPanel.SelectedValue);
        }
        protected void Viet_Check(object sender, EventArgs e)
        {
            ViewModulesFrontPanel(rdbPanel.SelectedValue);
        }
        protected void Eng_Check(object sender, EventArgs e)
        {
            ViewModulesFrontPanel(rdbPanel.SelectedValue);
        }

    }
}