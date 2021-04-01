<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true" CodeBehind="InvestorProfile.aspx.cs" Inherits="iTradex.UI.Pages.Investor.InvestorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/plugins.css" rel="stylesheet" />
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
 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
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
                    <li ><a href="MarketStatus.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Market Status</a></li>
                    <li class="active_otp"><a href="InvestorProfile.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Investor Profile</a></li>
                     <li><a href="Ipo.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    IPO</a></li>
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
                <div class="alert alert-success desk_view" id="Div2">
                    <button data-dismiss="alert" class="close" type="button">
                        x</button>
                    <strong>Hello !</strong>
                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                    You Should successfully read this important alert message.
                </div>

                <div class="row-fluid m_b30" id="four">
                    <div class="span6 remove" data-step="10" data-intro="This box contain Investor Signature Picture ">
                        <header class="w_header paste">
                            <h2>
                                <i class="icon-user-3"></i>Account Information</h2>
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
                                <li><a data-toggle="collapse" data-target="#AccountInformation" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel1" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div class="half_widget deepBlueborder collapse in" id="AccountInformation">
                            <span class="signature">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                <span class="FixedSignature">
                                    <table class="investor_table">
                                        <tr>
                                            <td style="width: 110px;">Account Number </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAccountNumber" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Account Name </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAccountName" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>BO Number </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBONumber" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Account Type </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAccountType" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Category </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Joint Holder </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblJointHolder" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </span>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </span>
                        </div>
                    </div>
                    <div class="span6 remove2" data-step="11" data-intro="This box contain Investor Score Card information ">
                        <header class="w_header scoreCard">
                            <h2>
                                <i class="icon-card"></i>Investor Photo & Signature</h2>
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
                                <li><a data-toggle="collapse" data-target="#InvestorPhoto" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel2" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div class="half_widget scoreCard_wrap collapse in" id="InvestorPhoto">
                            <span class="signature">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                    <span class="FixedSignature">
                                        <div style="float:left;">
                                        <asp:Image ID="imgPhoto" ImageUrl="GetInvestorPhoto.ashx?imgid=1" class="investor_pic" AlternateText="investor picture"
                                                runat="server" Width="100%" Height="150"></asp:Image>
                                        </div>
                                        <div style="float:left;">
                                            <asp:Image ID="Image1" ImageUrl="GetInvestorSignature.ashx?imgid=1" class="investor_pic" AlternateText="investor Signature"
                                                runat="server" Width="100%"></asp:Image>
                                        </div>
                                    </span>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span>
                        </div>
                    </div>
                </div>

                <div class="row-fluid m_b30" id="Div1">
                    <div class="span6 remove3" data-step="10" data-intro="This box contain Investor Signature Picture ">
                        <header class="w_header paste">
                            <h2>
                                <i class="icon-user-3"></i>Personal Information</h2>
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
                                <li><a data-toggle="collapse" data-target="#PersonalInfo" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel3" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div class="half_widget deepBlueborder collapse in" id="PersonalInfo">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table class="investor_table">
                                        <tr>
                                            <td style="width:130px;">Inverstor Name</td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInverstorName" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Date Of Birth </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="txtDateOfBirth" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                                <asp:Label ID="lblDateOfBirth" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Nationality </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="txtNationality" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                                <asp:Label ID="lblNationality" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Tax ID </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="txtTaxID" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                                <asp:Label ID="lblTaxID" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Sex </td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="txtSex" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                                <asp:Label ID="lblSex" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="span6 remove4" data-step="11" data-intro="This box contain Investor Score Card information ">
                        <header class="w_header scoreCard">
                            <h2>
                                <i class="icon-card"></i>Address</h2>
                            <ul class="control">
                                <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                    id="A3" class="w_settings dropdown-toggle"></a>
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
                                <li><a data-toggle="collapse" data-target="#Address" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel4" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div class="half_widget scoreCard_wrap collapse in" id="Address">
                            <span class="FixedSignature">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <table class="investor_table">
                                    <tr>
                                        <td>Address1</td>
                                        <td>
                                        :
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtAddress1" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                            <asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Address2 </td>
                                        <td>
                                        :
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtAddress2" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                            <asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>City/State </td>
                                        <td>
                                        :
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtCityState" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                            <asp:Label ID="lblCityState" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Post Code</td>
                                        <td>
                                        :
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtPostCode" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                            <asp:Label ID="lblPostCode" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Country </td>
                                        <td>
                                        :
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="txtCountry" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                            <asp:Label ID="lblCountry" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </span>
                        </div>
                    </div>
                </div>
                <%--third row--%>
                <div class="row-fluid m_b30" id="Div6">
                    <div class="span6 remove5" data-step="10" data-intro="This box contain Investor Signature Picture ">
                        <header class="w_header paste">
                            <h2>
                                <i class="icon-user-3"></i>Contact Information</h2>
                            <ul class="control">
                                <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                    id="A9" class="w_settings dropdown-toggle"></a>
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
                                <li><a data-toggle="collapse" data-target="#ContactInfo" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel5" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div class="half_widget deepBlueborder collapse in" id="ContactInfo">
                        <span class="FixedSignature">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <table class="investor_table">
                                        <tr>
                                            <td>Mobile</td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Telephone</td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Email</td>
                                            <td>
                                            :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </span>
                        </div>
                    </div>
                    <div class="span6 remove6" data-step="11" data-intro="This box contain Investor Score Card information ">
                        <header class="w_header scoreCard">
                            <h2>
                                <i class="icon-card"></i>Bank Information</h2>
                            <ul class="control">
                                <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                    id="A11" class="w_settings dropdown-toggle"></a>
                                    <ul aria-labelledby="drop4" role="menu" class="dropdown-menu animated fadeInRight"
                                        id="Ul4">
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Another action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Something else here</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Separated link</a></li>
                                        <li class="divider" role="presentation"></li>
                                        <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">
                                            Help</a></li>
                                    </ul>
                                </li>
                                <li><a data-toggle="collapse" data-target="#BankInfo" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel6" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                        <div class="half_widget scoreCard_wrap collapse in" id="BankInfo">
                            <span class="FixedSignature">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                    <span class="FixedSignature">
                                        <table class="investor_table">
                                            <tr>
                                                <td style="width:130px;">Account Number </td>
                                                <td>
                                                :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAcNo" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Account Name</td>
                                                <td>
                                                :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAcName" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Bank</td>
                                                <td>
                                                :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblBank" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Branch </td>
                                                <td>
                                                :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblBranch" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr> 
                                                <td>Routing Number </td>
                                                <td>
                                                :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRoutingNo" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </span>
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
    <script src="../../js/jquery.totemticker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#vertical-ticker').totemticker({
                row_height: '40px',
                next: '#ticker-next',
                previous: '#ticker-previous',
                stop: '#stop',
                start: '#start',
                mousestop: true,
                row_height: '50px',
                speed: 300,
                interval: 800,
                max_items: 5,
                mousestop: true,
                direction: 'down'
            });
        });
    </script>
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
                revert: true, 
                cancel: ".half_widget,.full_widget"
            });

            //===== Dynamic data table =====//

            var oTable = $('#DataTables_Table_1').dataTable({
                "bJQueryUI": false,
                "bAutoWidth": false,
                "sPaginationType": "full_numbers",
                "sDom": '<"H"fl>t<"F"ip>',
                "aLengthMenu": [[10, 15, 30, -1], [10, 15, 30, 50]],
                "iDisplayLength": 10
                //"bServerSide": true,
                //"sAjaxSource": "Dashboard.aspx/GetStockLedger" 
            });

        });$(function () {
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
            $('#cancel5').click(function () {
                $('.remove5').hide(function () {
                    $(this).addClass('animated rotateOutDownRight');
                });
            });
            $('#cancel6').click(function () {
                $('.remove6').hide(function () {
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
