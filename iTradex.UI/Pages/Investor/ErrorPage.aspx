<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="iTradex.UI.Pages.Investor.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

     <link href="../../css/plugins.css" rel="stylesheet" />
    <link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
<div class="wrapper">
       <div class="row-fluid">
            <div class="span4 tour_intro">
      
            </div>
            <div class="span8">
                <ul class="tab" data-step="3" data-intro="This is Main Navigation">
                    <li><a href="Dashboard.aspx" class="dashboard">
                    <i class="icon-bars"> </i>
                    Dashboard
                    </a></li>
                    <li><a href="Order.aspx" class="order">
                    <i class="icon-cart"></i>
                    Order</a></li>
                    <li><a href="Transaction.aspx" class="transaction">
                    <i class="icon-calculate"></i>
                    Transaction</a></li>
                    <li><a href="Ledger.aspx" class="ledger">
                    <i class="icon-attachment"></i>
                    Ledger</a></li>
                    <li ><a href="MarketStatus.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Market Status</a></li>
                    <li><a href="InvestorProfile.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Investor Profile</a></li>
                    <li><a href="Ipo.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    IPO</a></li>
                     <li><a href="Tax.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Certificate</a></li>
                </ul>
                <!--smartphone navigation===========--->
            </div>
        </div>
        <div class="row-fluid" id="tabs-container"  style="height:80%;">
         <div class="span3 sidebar_widget_container">
             <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
         </div>

        </div>
    </div >
    </form>
</asp:Content>
