<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="CMS.Client.Admin.Header" %>
<%@ Register Src="~/Client/Admin/BlockWelCome.ascx" TagName="BlockWelCome" TagPrefix="panelBlockWelCome" %>
<div id="banner">
    <div id="menutop" style="display: none;">
        <ul class="MenuBarTop">
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/menutop_homepage.png" CssClass="icon_menutop" /><asp:Label
                        ID="Label1" runat="server" Text="Trang chủ" />
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Sitemap/Default.aspx">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/menutop_sitemap.png" CssClass="icon_menutop" /><asp:Label
                        ID="Label2" runat="server" Text="Sitemap" />
                </asp:HyperLink>
            </li>
            <%--<li>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/LichTuan.aspx">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/menutop_webmail.png" CssClass="icon_menutop" /><asp:Label ID="Label3" runat="server" Text="Lịch tuần" />    
                </asp:HyperLink>
            </li>--%>
            <li>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Contact/Default.aspx">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/menutop_contact.png" CssClass="icon_menutop" /><asp:Label
                        ID="Label4" runat="server" Text="Liên hệ" />
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/login/Default.aspx">
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/menutop_login.png" CssClass="icon_menutop" /><asp:Label
                        ID="lblLogin" runat="server" Text="Đăng nhập" />
                </asp:HyperLink>
            </li>
        </ul>
    </div>
    <div style="position: relative; top: 105px; left: 780px; width: 220px;" id="div_welcome"
        runat="server">
        <panelBlockWelCome:BlockWelCome ID="blockWelcome1" runat="server" />
    </div>
</div>
