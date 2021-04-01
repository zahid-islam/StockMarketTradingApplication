<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true"
    CodeBehind="MarketStatus.aspx.cs" Inherits="iTradex.UI.Pages.Investor.MarketStatus" %>

<%@ Register src="../../UserControl/ucUpcomingIPOs.ascx" tagname="ucUpcomingIPOs" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/plugins.css" rel="stylesheet" />
    <link href="../../css/newsTicker.css" rel="stylesheet" type="text/css" />
    <link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css">--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form name="Dashboard" id="Dashboard" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

            <div id="AccountModal" class="modal hide fade" tabindex="-2" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
<div class="modal-header">
<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
<h3 id="H2">Change Password</h3>
</div>
 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
 <ContentTemplate>
   <div class="PurchaseModalBody">
               <div id="AddEditForm">
                  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <fieldset class="fieldset4">
                <legend class="form-ligendPassword">
                <span>Old Password</span>
                </legend>
                  <div class="row-fluid">
                  <div class="firstDiv "  >                  
                      <ul class="formUl ">
                      <li>
                      <label class="EditFormLevel"><b>Enter Your Old Password</b></label>
                      <%--<span class="EditForm">Account Reference</span>--%>
                          <asp:TextBox ID="txtOldPassword" runat="server"  class="FundWithdrawlTextBox" ontextchanged="textBox_TextChanged" AutoPostBack="true" TabIndex=1 placeholder="minimum 8 character" TextMode="Password" pattern=".{8,}"></asp:TextBox>
                      </li>
                           <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                      
                      </ul>
                 
                  </div>
 
                  </div> 
               </fieldset>
                 <fieldset class="fieldset4">
                <legend class="form-ligendPassword">
                <span>New Password</span>
                </legend>
                  <div class="row-fluid">
                  <div class="firstDiv "  >                  
                      <ul class="formUl ">
                      <li>
                      <label class="EditFormLevel"><b>Enter Your New Password</b></label>
                      <%--<span class="EditForm">Account Reference</span>--%>
                          <asp:TextBox ID="txtNewPassord" runat="server" class="FundWithdrawlTextBox" TabIndex=2  ReadOnly required placeholder="minimum 8 character" TextMode="Password" pattern=".{8,}"></asp:TextBox>
                      </li>
                      <li>
                      <label class="EditFormLevel"><b>Confirm Password</b></label>
                      <%--<span class="EditForm">Account Reference</span>--%>
                          <asp:TextBox ID="txtConfirmPassword" runat="server"  class="FundWithdrawlTextBox" TabIndex=3 ReadOnly required  placeholder="minimum 8 character" TextMode="Password" pattern=".{8,} "></asp:TextBox>
                      </li>
                      
                      </ul>
                 
                  </div>
 
                  </div> 
               </fieldset>
               </div>

                

            </div>
            </ContentTemplate>
              </asp:UpdatePanel>
             
                           <div class="modal-footer">
                    
                   <button id="Button1" runat=server  class="btn appBtn btn-primary btnFormPurchase btnChangePassword" onserverclick="btnSave_Click" tabindex=5><i class="icon-plus-2"></i> Save</button>
                   <button class="btn appBtn btn-danger btnForm2 btnChangePassword2"  data-dismiss="modal" aria-hidden="true"><i class="icon-cancel-2"></i> Close</button>
</div>

</div>

    <div class="wrapper">
        <div class="row-fluid">
            <div class="span4 tour_intro">
                <a class="btn btn-large tour-btn" title="You can visit and learn in short by click this link"
                    href="javascript:void(0);" onclick="javascript:introJs().start();"><i class="icon-sun_stroke">
                    </i>Need help? Click here.</a>
            </div>
            <div class="span8">
                <ul class="tab" data-step="3" data-intro="This is Main Navigation">
                    <li ><a href="Dashboard.aspx" class="dashboard">
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
                    <li class="active_otp"><a href="MarketStatus.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Market Status</a></li>
                    <li><a href="InvestorProfile.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Investor Profile</a></li>
                      <li><a href="Order.aspx" target=_blank class="order">
                    <i class="icon-cart"></i>
                   Order</a></li>

                     <li><a href="Reports.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Reports</a></li>

                </ul>
                <!--smartphone navigation===========--->
            </div>
        </div>
        <div class="row-fluid" id="tabs-container">
            <div class="span3 sidebar_widget_container">
                <div class="alert alert-success res_view" id="one">
                    <button data-dismiss="alert" class="close" type="button">
                        x</button>
                    <strong>Hello !</strong> You Should successfully read this important alert message.
                </div>
                <div class="sidebar_header" data-step="4" data-intro="Portfolio statemet meaning your account related details information goes here">
                    <h2>
                        <i class="icon-file-pdf"></i> Printable Version</h2>
                </div>
                <div class="sidebar_widget" data-step="5" data-intro="You know from here available balance, Immatured balance, Unclear Cheque as well as Ledger Balance  ">
                    <header class="blue">
                        <h2>
                            <i class="icon-lab"></i>Account Status till today</h2>
                    </header>
                    <div class="sidebar_widget_wrap green_border">
                        <table class="iStock_data_table">
                            <tr>
                                <td style="width: 120px;">
                                    Available Balance
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblAvailableBalanceTillToday" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Immatured Balance
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblImmaturedBalance" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unclear Cheque
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="UnclearCheque" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ledger Balance
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="LedgerBalance" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!--end sidebar widget 1-->
                <div class="sidebar_widget" data-step="6" data-intro="Total Deposit, Realized Gain/Loss, Total Widthdraw, Accured Interest Charge and Current Deposit Total">
                    <header class="green">
                        <h2>
                            <i class="icon-tab-2"></i>Deposit / Widthdraw</h2>
                    </header>
                    <div class="sidebar_widget_wrap blue_border">
                        <table class="iStock_data_table total_separator">
                            <tr>
                                <td style="width: 120px;">
                                    Total Deposit
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalDeposit" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Realized Gain/Loss
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblRealizedGainLossDeposite" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Total Widthdraw
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalWidthdraw" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Accured Interest Charge
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblAccuredInterestCharge" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Current Deposit Total
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblCurrentDepositTotal" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!--end sidebar widget 2-->
                <div class="sidebar_widget" data-step="7" data-intro="Total Deposit, Realized Gain/Loss, Total Widthdraw, Accured Interest Charge and Current Deposit Total">
                    <header class="blue">
                        <h2>
                            <i class="icon-suitcase-2"></i>Capital / Gain</h2>
                    </header>
                    <div class="sidebar_widget_wrap dark_border">
                        <table class="iStock_data_table total_separator_dark">
                            <tr>
                                <td style="width: 115px;">
                                    Realized Gain/Loss
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblRealizedGainLoss" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unrealized Gain/Loss
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblUnrealizedGainLoss" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Net Gain/Loss
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblnetGainLoss" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!--end sidebar widget 3-->
            </div>
            <div class="span9 widget_container" id="sortable">
                <div class="alert alert-success desk_view" id="Div5">
                    <button data-dismiss="alert" class="close" type="button">
                        x</button>
                    <strong>Hello !</strong>
                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                    You Should successfully read this important alert message.
                </div>
            <%--<div class="span12 " data-step="10" data-intro="This box contain Investor Signature Picture ">
                <asp:Literal ID="ltrTickerPrice" runat="server">
                </asp:Literal>
            </div>--%>

                <div class="row-fluid m_b30" id="four">
                    <div class="span6 remove" data-step="10" data-intro="This box contain Investor Signature Picture ">
                        <header class="w_header paste">
                            <h2>
                                <i class="icon-user-3"></i>Top Gainers</h2>
                            <ul class="control">
                                <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                    id="drop4" class="w_settings dropdown-toggle"></a>
                                    <ul aria-labelledby="drop4" role="menu" class="dropdown-menu animated fadeInRight"
                                        id="menu1">
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Another action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Something else here</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Separated link</a></li>
                                        <li class="divider" role="presentation"></li>
                                        <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">
                                            Help</a></li>
                                    </ul>
                                </li>
                                <li><a data-toggle="collapse" data-target="#News" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel1" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div class="half_widget deepBlueborder collapse in" id="News">
                                <span class="signature">
                                    <div class="shownpars">
                                        <div role="grid" class="dataTables_wrapper" id="Div4">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:Repeater ID="rptPriceTop" runat="server">
                                                        <HeaderTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" class="dTable dataTable" id="DataTables_Table_1"
                                                                aria-describedby="DataTables_Table_1_info">
                                                                <thead>
                                                                    <tr role="row">
                                                                        <th class="sorting_asc" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">
                                                                            Name<span style="display: block;" class="sorting"></span>
                                                                        </th>
                                                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">
                                                                            Current Price
                                                                        </th>
                                                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">
                                                                            Variance
                                                                        </th>
                                                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">
                                                                            Percentage
                                                                        </th>
                                                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">
                                                                            &nbsp;
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr class="gradeA odd">
                                                                <td class="dttableleftalign">
                                                                    <%# Eval("ShortName")%>
                                                                </td>
                                                                <td class="dttablerightalign">
                                                                    <%# Eval("CurrentPrice", "{0:#,##0.00}")%>
                                                                </td>
                                                                <td class="dttablerightalign">
                                                                    <%# Eval("UpDownValue", "{0:#,##0.00}")%>
                                                                </td>
                                                                <td class="dttablerightalign">
                                                                    <%# Eval("UpDownPercent", "{0:#,##0.00}")%>
                                                                </td>
                                                                <td class="dttablerightalign <%# Eval("Status")%>">
                                                                    
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                        </tbody> </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                </span>
                        </div>
                    </div>
                    

                    <div class="span6 remove2" data-step="11" data-intro="This box contain Investor Score Card information ">
                        <header class="w_header scoreCard">
                            <h2>
                                <i class="icon-card"></i>Top Losers</h2>
                            <ul class="control">
                                <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                    id="A2" class="w_settings dropdown-toggle"></a>
                                    <ul aria-labelledby="drop4" role="menu" class="dropdown-menu animated fadeInRight"
                                        id="Ul2">
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Another action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Something else here</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Separated link</a></li>
                                        <li class="divider" role="presentation"></li>
                                        <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">
                                            Help</a></li>
                                    </ul>
                                </li>
                                <li><a data-toggle="collapse" data-target="#newsTicker" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel2" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div class="half_widget scoreCard_wrap collapse in" id="newsTicker">
                            <span class="signature">
                                <div class="shownpars">
                                        <div role="grid" class="dataTables_wrapper" id="DataTables_Table_1_wrapper">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:Repeater ID="rptPriceTicker" runat="server">
                                                        <HeaderTemplate>
                                                            <table  cellpadding="0" cellspacing="0" border="0" id="dTables">
                                                                <thead>
                                                                    <tr role="row">
                                                                        <th class="sorting_asc" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">
                                                                            Name<span style="display: block;" class="sorting"></span>
                                                                        </th>
                                                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">
                                                                            Current Price
                                                                        </th>
                                                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">
                                                                            Variance
                                                                        </th>
                                                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">
                                                                            Percentage
                                                                        </th>
                                                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                            rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">
                                                                            &nbsp;
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr class="gradeA odd">
                                                                <td class="dttableleftalign">
                                                                    <%# Eval("ShortName")%>
                                                                </td>
                                                                <td class="dttablerightalign">
                                                                    <%# Eval("CurrentPrice", "{0:#,##0.00}")%>
                                                                </td>
                                                                <td class="dttablerightalign">
                                                                    <%# Eval("UpDownValue", "{0:#,##0.00}")%>
                                                                </td>
                                                                <td class="dttablerightalign">
                                                                    <%# Eval("UpDownPercent", "{0:#,##0.00}")%>
                                                                </td>
                                                                <td class="dttablerightalign <%# Eval("Status")%>">
                                                                    
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody> </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                            </span>
                        </div>
                    </div>
                </div>

                <%--Second Portlet row--%>
                <div class="row-fluid m_b30" id="three">
                     <div id="Div3" class="span6 remove3" data-step="10" data-intro="This box contain Investor Signature Picture ">
                        <header class="w_header paste">
                            <h2>
                                <i class="icon-user-3"></i>Upcoming IPOs</h2>
                            <ul class="control">
                                <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                    id="A3" class="w_settings dropdown-toggle"></a>
                                    <ul aria-labelledby="drop4" role="menu" class="dropdown-menu animated fadeInRight"
                                        id="Ul3">
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Another action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Something else here</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Separated link</a></li>
                                        <li class="divider" role="presentation"></li>
                                        <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">
                                            Help</a></li>
                                    </ul>
                                </li>
                                <li><a data-toggle="collapse" data-target="#IPOs" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel3" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div class="half_widget deepBlueborder collapse in" id="IPOs">
                        <span class="FixedSignature">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                 <span class="signature">
                                    <uc1:ucUpcomingIPOs ID="ucUpcomingIPOs2" runat="server" />
                                 </span>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </span>
                        </div>
                    </div>
                    <%--Second portlet--%>
                    <div id="Div1" class="span6 remove3" data-step="10" data-intro="This box contain Investor Signature Picture ">
                        <header class="w_header paste">
                            <h2>
                                <i class="icon-user-3"></i>Market News</h2>
                            <ul class="control">
                                <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                    id="A1" class="w_settings dropdown-toggle"></a>
                                    <ul aria-labelledby="drop4" role="menu" class="dropdown-menu animated fadeInRight"
                                        id="Ul1">
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Another action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Something else here</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Separated link</a></li>
                                        <li class="divider" role="presentation"></li>
                                        <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">
                                            Help</a></li>
                                    </ul>
                                </li>
                                <li><a data-toggle="collapse" data-target="#IPOs" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="A4" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div id="ii" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                            aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    ×</button>
                                <h1 id="myModalLabel">
                                    Need Help ?</h1>
                            </div>
                            <div class="modal-body">
                                <div class="bb-custom-wrapper">
                                    <div id="bb-bookblock" class="bb-bookblock">
                                        <div class="bb-item">
                                            <h2>
                                                This is a Full widget</h2>
                                            <p>
                                                Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                not start until after mouse is dragged beyond distance. Can be used to allow for
                                                clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                start. If specified, sorting will not start until after mouse is dragged beyond
                                                distance. Can be used to allow for clicks on elements within a handle.
                                            </p>
                                        </div>
                                        <div class="bb-item">
                                            <a href="#">
                                                <img src="../../images/demo1/dboard.png" alt="image01" /></a>
                                        </div>
                                        <div class="bb-item">
                                            <h2>
                                                This is a Full widget</h2>
                                            <p>
                                                Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                not start until after mouse is dragged beyond distance. Can be used to allow for
                                                clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                start. If specified, sorting will not start until after mouse is dragged beyond
                                                distance. Can be used to allow for clicks on elements within a handle.
                                            </p>
                                        </div>
                                        <div class="bb-item">
                                            <h2>
                                                This is a Full widget</h2>
                                            <p>
                                                Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                not start until after mouse is dragged beyond distance. Can be used to allow for
                                                clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                start. If specified, sorting will not start until after mouse is dragged beyond
                                                distance. Can be used to allow for clicks on elements within a handle.
                                            </p>
                                        </div>
                                        <div class="bb-item">
                                            <h2>
                                                This is a Full widget</h2>
                                            <p>
                                                Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                not start until after mouse is dragged beyond distance. Can be used to allow for
                                                clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                start. If specified, sorting will not start until after mouse is dragged beyond
                                                distance. Can be used to allow for clicks on elements within a handle.
                                            </p>
                                        </div>
                                    </div>
                                    <h3>
                                        For more information<a href="#">Go to FAQ Page.</a></h3>
                                    <nav>
                                        <a id="bb-nav-prev" href="#">Previous</a> <a id="bb-nav-next" href="#">Next</a>
                                        <a id="bb-nav-jump" href="#" title="Go to last item">Last page</a>
                                    </nav>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">
                                    Close</button>
                            </div>
                        </div>
                        <div class="half_widget deepBlueborder collapse in" id="Div2">
                        <span class="Signature">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Repeater ID="rptNews" runat="server">
                                            <HeaderTemplate>
                                                <table  cellpadding="0" cellspacing="0" border="0" id="dataTableNews">
                                                    <thead>
                                                        <tr role="row">
                                                            <th class="sorting_asc" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">
                                                                Date<span style="display: block;" class="sorting"></span>
                                                            </th>
                                                            <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1"
                                                                rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">
                                                                News
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="gradeA odd">
                                                    <td class="dttableleftalign date">
                                                        <%# Eval("NewsDate", "{0:dd MMM yyyy}")%>
                                                    </td>
                                                    <td class="dttableleftalign">
                                                        <b class="instrument"><%# Eval("Instrument")%></b><br />
                                                        <%# Eval("News")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody> </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
    <%--<script src="../../js/jquery-1.9.1.min.js"></script>
    <script src="../../js/jquery-ui.min.js"></script>--%>
    <script src="../../js/jquery.cookie.js"></script>
    <script src="../../js/zebra_tooltips.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <script src="../../js/intro.js"></script>
    <%--<script src="../../js/jquery.dataTables.js"></script>--%>
    <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/jquery.dataTables.min.js"></script>
    <script src="../../js/jquery.nicescroll.js"></script>
    
    <%--niceScroll Intialization--%>
    <script type="text/javascript">
        $(document).ready(
		function () {
		    $("html").niceScroll();
		}
		);

    </script>
    <style>
        .sortable-placeholder
        {
            border: 2px dashed #ccc;
            margin-bottom: 30px;
        }
    </style>
    <script type="text/javascript">
       
        $(function () {
            new $.Zebra_Tooltips($('.tooltips'), {
                'background_color': '#f97e76',
                'color': '#FFF'
            });

            new $.Zebra_Tooltips($('.contactTooltips'), {
                'background_color': '#6bcbca',
                'color': '#FFF'
            });

            new $.Zebra_Tooltips($('.logoutTooltips'), {
                'background_color': '#00afd1',
                'color': '#FFF'
            });

            new $.Zebra_Tooltips($('.min'), {
                'background_color': '#1fbba6',
                'color': '#FFF'
            });
            new $.Zebra_Tooltips($('.cancel'), {
                'background_color': '#f97e76',
                'color': '#FFF'
            });
            new $.Zebra_Tooltips($('.tour-btn'), {
                'background_color': '#1fbba6',
                'color': '#FFF'
            });

            $("#sortable").sortable({
                placeholder: "sortable-placeholder",
                forcePlaceholderSize: true,
                delay: 150,
                tolerance: "intersect",
                revert: false,
                cancel: ".half_widget,.full_widget"
            });
        });
             //for collecting datatable info;
            $.fn.dataTableExt.oApi.fnPagingInfo = function (oSettings) {
                return {
                    "iStart": oSettings._iDisplayStart,
                    "iEnd": oSettings.fnDisplayEnd(),
                    "iLength": oSettings._iDisplayLength,
                    "iTotal": oSettings.fnRecordsTotal(),
                    "iFilteredTotal": oSettings.fnRecordsDisplay(),
                    "iPage": oSettings._iDisplayLength === -1 ?
			    0 : Math.ceil(oSettings._iDisplayStart / oSettings._iDisplayLength),
                    "iTotalPages": oSettings._iDisplayLength === -1 ?
			    0 : Math.ceil(oSettings.fnRecordsDisplay() / oSettings._iDisplayLength)
                };
            };

            //===== Dynamic data table =====//
            $(function () {
                var oTable = $('#DataTables_Table_1').dataTable({
                    "bJQueryUI": false,
                    "bAutoWidth": false,
                    "sDom": '<"H"fl>t<"F"ip>',
                    "aLengthMenu": [[5, 10, 20, -1], [5, 10, 20, "All"]],
                    "iDisplayLength": 5,
                    "aaSorting": [[2, "desc"]],
                    "fnHeaderCallback": function () {
                        if (this.fnPagingInfo().iEnd == this.fnPagingInfo().iTotal) {
                            this.fnPageChange('first');
                            //alert('Now on page' + this.fnPagingInfo().iTotal);
                        }
                        //"bServerSide": true,
                        //"sAjaxSource": "Dashboard.aspx/GetStockLedger" 
                    }
                });
                setInterval(
                function () {
                    oTable.fnPageChange('next');
                    //if (oTable.fnPageChange('last') = true) {
                    //oTable.fnPageChange('first');
                    //}
                }, 3000  /* 10000 ms = 10 sec */
            );
            });
        
    </script>
    <script>
        $.fn.dataTableExt.oApi.fnPagingInfo = function (oSettings) {
            return {
                "iStart": oSettings._iDisplayStart,
                "iEnd": oSettings.fnDisplayEnd(),
                "iLength": oSettings._iDisplayLength,
                "iTotal": oSettings.fnRecordsTotal(),
                "iFilteredTotal": oSettings.fnRecordsDisplay(),
                "iPage": oSettings._iDisplayLength === -1 ?
			0 : Math.ceil(oSettings._iDisplayStart / oSettings._iDisplayLength),
                "iTotalPages": oSettings._iDisplayLength === -1 ?
			0 : Math.ceil(oSettings.fnRecordsDisplay() / oSettings._iDisplayLength)
            };
        };

        $(function () {
            var oTable = $('#dTables').dataTable({
                "bJQueryUI": false,
                "bAutoWidth": false,
                "sDom": '<"H"fl>t<"F"ip>',
                "aLengthMenu": [[5, 10, 20, -1], [5, 10, 20, "All"]],
                "iDisplayLength": 5,
                "aaSorting": [[2, "asc"]],
                "fnHeaderCallback": function () {
                    if (this.fnPagingInfo().iEnd == this.fnPagingInfo().iTotal) {
                        this.fnPageChange('first');
                    //alert( 'Now on page'+ this.fnPagingInfo().iTotal );
                    }
                
                //    that.fnDraw(true);
                }  
            });

            setInterval(
                function () {
                        oTable.fnPageChange('next');
                }, 3000  /* 10000 ms = 10 sec */
                );
        });
                //===== Dynamic data table =====//
           $(function () {
                var oTable = $('#dataTableNews').dataTable({
                    "bJQueryUI": false,
                    "bAutoWidth": false,
                    //"sPaginationType": "full_numbers",
                    "sDom": '<"H"fl>t<"F"ip>',
                    "aLengthMenu": [[5, 10, 20, -1], [5, 10, 20, "All"]],
                    "iDisplayLength": 5,
                    fnDrawCallback: function () {
                        $("#dataTableNews thead").remove();
                    }
                });
            });

            
    </script>
    <script>
        $(function () {
            $('#cancel1').click(function () {
                $('.remove').hide(function () {
                    $(this).addClass('animated rotateOutDownRight');
                });
            });

            $('#cancel2').click(function () {
                $('.remove2').hide(function () {
                    $(this).addClass('animated rotateOutDownRight');
                });
            });
            $('#cancel3').click(function () {
                $('.remove3').hide(function () {
                    $(this).addClass('animated rotateOutDownRight');
                });
            });
            $('#cancel4').click(function () {
                $('.remove4').hide(function () {
                    $(this).addClass('animated rotateOutDownRight');
                });
            });

        });      
    </script>
    <script type="text/javascript" src="../../js/modernizr.custom.79639.js"></script>
    <script type="text/javascript" src="../../js/jquerypp.custom.js"></script>
    <script type="text/javascript" src="../../js/jquery.bookblock.js"></script>
    <script type="text/javascript">
        $(function () {

            var Page = (function () {

                var config = {
                    $bookBlock: $('#bb-bookblock'),
                    $navNext: $('#bb-nav-next'),
                    $navPrev: $('#bb-nav-prev'),
                    $navJump: $('#bb-nav-jump'),
                    bb: $('#bb-bookblock').bookblock({
                        speed: 800,
                        shadowSides: 0.8,
                        shadowFlip: 0.7
                    })
                },
						init = function () {

						    initEvents();

						},
						initEvents = function () {

						    var $slides = config.$bookBlock.children(),
									totalSlides = $slides.length;

						    // add navigation events
						    config.$navNext.on('click', function () {

						        config.bb.next();
						        return false;

						    });

						    config.$navPrev.on('click', function () {

						        config.bb.prev();
						        return false;

						    });

						    config.$navJump.on('click', function () {

						        config.bb.jump(totalSlides);
						        return false;

						    });

						    // add swipe events
						    $slides.on({
						        'swipeleft': function (event) {
						            config.bb.next();
						            return false;

						        },
						        'swiperight': function (event) {
						            config.bb.prev();
						            return false;
						        }
						    });
						};

                return { init: init };

            })();

            Page.init();

        });
    </script>
    </form>
</asp:Content>
