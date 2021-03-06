<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsgList.ascx.cs" Inherits="WebMedi.Client.Modules.News.NewsgList" %>
    <div class="col-md-9 main-content">
        <div class="row navigater">
            <span>
                <asp:Literal ID="title_cate" runat="server"></asp:Literal>
            </span><span class="content_Text">
                <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
        </div>
        <div id="CateNewsPanel" runat="server">
            <h4>
            </h4>
            <asp:DataList ID="DataListCateNews" runat="server" OnItemDataBound="DataListCateNews_ItemDataBound">
                <ItemTemplate>
                    <div class="row main-category">
                        <div class="col-md-3 main-img">
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID")+"/"+GetString(Eval("Title")) +"/default.aspx" %>'>
                                <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal></asp:HyperLink>
                        </div>
                        <div class="col-md-9 main-text">
                            <div class="row text-title">
                                <h5>
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="main_title_news" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID")+"/"+GetString(Eval("Title")) +"/default.aspx" %>'
                                        Text='<%# Eval("Title") %>'></asp:HyperLink>
                                    <asp:Label ID="LabelDate" runat="server" Text='<%#" ("+ Convert.ToString(Eval("PostDate")).Substring(0,10)+")" %>'
                                        CssClass="date"></asp:Label>
                                </h5>
                            </div>
                            <div class="row text-body">
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx" %>'>
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></asp:HyperLink>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ShortDescribe") %>' CssClass="main_desc_news"></asp:Label>
                            </div>
                            <div class="row detail">
                                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID")+"/"+GetString(Eval("Title")) +"/default.aspx" %>'>Chi tiết ...</asp:HyperLink></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <!--Tin tuc khác -->
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <div class="main_article_list_other">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>' NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx"%>'></asp:HyperLink>
                            <asp:Label ID="LabelDate" runat="server" Text='<%#" ("+ Convert.ToString(Eval("PostDate")).Substring(0,10)+")" %>'
                                CssClass="date"></asp:Label>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <!--End Tin tức khác-->
        </div>
        <!-- ********************************************* -->
        <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
            <ItemTemplate>
                <div class="main_title_catenews">
                    <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl='<%#"~/catenewsg/"+Eval("GroupCate")+"/"+Eval("CateNewsID") +"/"+GetString(Eval("CateNewsName")) +"/default.aspx" %>'><%#Eval("CateNewsName")%></asp:HyperLink></div>
                <div class="main_linecate">
                </div>
                <h4>
                </h4>
                <asp:DataList ID="Datalist2" runat="server" OnItemDataBound="DataList2_ItemDataBound"
                    RepeatColumns="1" CellPadding="0" HorizontalAlign="Justify" RepeatDirection="Horizontal"
                    ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <div class="row main-category">
                            <div class="col-md-3 main-img">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx" %>'>
                                    <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal></asp:HyperLink>
                            </div>
                            <div class="col-md-9 main-text">
                                <div class="row text-title">
                                    <h5>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx"%>'
                                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                                        <asp:Label ID="LabelDate" runat="server" Text='<%#" ("+ Convert.ToString(Eval("PostDate")).Substring(0,10)+")" %>'
                                            CssClass="date"></asp:Label>
                                    </h5>
                                </div>
                                <div class="row text-body">
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx" %>'>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></asp:HyperLink>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ShortDescribe") %>' CssClass="main_desc_news"></asp:Label>
                                </div>
                                <div class="row detail">
                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx" %>'>Chi tiết ...</asp:HyperLink></div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:DataList>
            </ItemTemplate>
        </asp:DataList>
        <div class="row" style="border-bottom: 2px solid #018a44; margin-top:10px;"></div>
    </div>
<asp:HiddenField ID="hddGroupCate" runat="server" />
