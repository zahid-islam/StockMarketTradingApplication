<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="iTradex.UI.Pages.Investor.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/plugins.css" rel="stylesheet" />
    <link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form name="Dashboard" id="Dashboard" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="wrapper">
            <div class="row-fluid">
                <div class="span4 tour_intro">
                    <ul>

                        <li><a class="btn btn-large tour-btn" title="You can visit and learn in short by click this link"
                            href="javascript:void(0);" onclick="javascript:introJs().start();"><i class="icon-sun_stroke"></i>Need help? Click here.</a></li>
                    </ul>
                </div>
                <div class="span8">
                    <ul class="tab" data-step="3" data-intro="This is Main Navigation">
                        <li class="active_otp"><a href="Dashboard.aspx" class="dashboard">
                            <i class="icon-bars"></i>
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
                        <li><a href="MarketStatus.aspx" class="market_status">
                            <i class="icon-stats-up"></i>
                            Market Status</a></li>
                        <li><a href="InvestorProfile.aspx" class="market_status">
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
                        <button class="PrintButton borderNone" type="button" runat="server" onserverclick="btPrint_Click">
                            <i class="icon-file-pdf"></i>Printable Version
                        </button>
                    </div>

                    <div class="sidebar_widget" data-step="5" data-intro="You know from here available balance, Immatured balance, Unclear Cheque as well as Ledger Balance  ">
                        <header class="green">
                        <h2>
                            <i class="icon-lab"></i>Account Status till today</h2>
                    </header>
                        <div class="sidebar_widget_wrap green_border">
                            <table class="iStock_data_table">
                                <tr>
                                    <td style="width: 120px;">Available Balance
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAvailableBalanceTillToday" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Immatured Balance
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblImmaturedBalance" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Unclear Cheque
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="UnclearCheque" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ledger Balance
                                    </td>
                                    <td>:
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
                        <header class="blue">
                        <h2>
                            <i class="icon-tab-2"></i>Deposit/Widthdraw Status</h2>
                    </header>
                        <div class="sidebar_widget_wrap blue_border">
                            <table class="iStock_data_table total_separator">
                                <tr>
                                    <td style="width: 120px;">Total Deposit
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalDeposit" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Realized Gain/Loss
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRealizedGainLossDeposite" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Total Widthdraw
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalWidthdraw" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Accured Interest
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAccuredInterestCharge" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Current Deposit
                                    </td>
                                    <td>:
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
                        <header class="dark">
                        <h2>
                            <i class="icon-suitcase-2"></i>Capital Gain/Loss</h2>
                    </header>
                        <div class="sidebar_widget_wrap dark_border">
                            <table class="iStock_data_table total_separator_dark">
                                <tr>
                                    <td style="width: 115px;">Realized Gain/Loss
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRealizedGainLoss" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Unrealized Gain/Loss
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUnrealizedGainLoss" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Net Gain/Loss
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblnetGainLoss" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <!--end sidebar widget 3-->
                    <div>
                        <button class="btn deposit-btn appBtn btn-success fwBtn" id="btnDepositModal" data-toggle="modal" runat="server"
                            data-target="#openDepositModal">
                            MAKE DEPOSIT
                        </button>
                    </div>
                </div>
                <div class="span9 widget_container" id="sortable">
                    <div class="alert alert-success desk_view" id="one">
                        <button data-dismiss="alert" class="close" type="button">
                            x</button>
                        <strong>Hello !</strong>
                        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                        You Should successfully read this important alert message.
                    </div>
                    <!--Start tagline-->
                    <div class="row-fluid m_b30" id="two" data-step="8" data-intro="Your tagline information goes here">
                        <div class="span4">
                            <div class="tagline1 relative">
                                <div class="t_l">
                                    <a href="#" class="tagLineIcon" title=""><i class="icon-battery-3"></i></a>
                                    <div class="tlText">
                                        <h2>0%</h2>
                                        <span>Margin Usage</span>
                                        <i class="icon-arrow-right-7"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span4">
                            <div class="tagline2 relative">
                                <div class="t_l">
                                    <a href="#" class="tagLineIcon" title=""><i class="icon-meter-slow"></i></a>
                                    <div class="tlText">
                                        <h2>75%</h2>
                                        <span>Equity-Debt Ratio</span>
                                        <i class="icon-arrow-right-7"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span4">
                            <div class="tagline3 relative">
                                <div class="t_l">
                                    <a href="#" class="tagLineIcon" title=""><i class="icon-loading"></i></a>
                                    <div class="tlText">
                                        <h2>Safe</h2>
                                        <span>Exposure Status</span>
                                        <i class="icon-arrow-right-7"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tag line------------>
                    <div class="row-fluid m_b30 remove" id="three" data-step="9" data-intro="Investor information">
                        <div class="span12">
                            <header class="w_header light">
                            <h2 style="color:black;">
                                <i class="icon-card"></i>Investor Information</h2> 
                            <ul class="control pull-right">
                                <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                    id="drop4" class="w_settings dropdown-toggle"></a>
                                    <ul aria-labelledby="drop4" role="menu" class="dropdown-menu animated fadeInRight"  
                                        id="menu1">
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Another action</a></li>
                                        <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Something else here</a></li>
                                        <li class="divider" role="presentation"></li>
                                        <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">
                                            Help</a></li>
                                    </ul>
                                </li>
                                <li><a data-toggle="collapse" data-target="#investor_info" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel1" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                            <div id="ii" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                                aria-hidden="true">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        ×</button>
                                    <h1 id="myModalLabel">Need Help ?</h1>
                                </div>
                                <div class="modal-body">
                                    <div class="bb-custom-wrapper">
                                        <div id="bb-bookblock" class="bb-bookblock">
                                            <div class="bb-item">
                                                <h2>This is a Full widget</h2>
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
                                                <h2>This is a Full widget</h2>
                                                <p>
                                                    Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                not start until after mouse is dragged beyond distance. Can be used to allow for
                                                clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                start. If specified, sorting will not start until after mouse is dragged beyond
                                                distance. Can be used to allow for clicks on elements within a handle.
                                                </p>
                                            </div>
                                            <div class="bb-item">
                                                <h2>This is a Full widget</h2>
                                                <p>
                                                    Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                not start until after mouse is dragged beyond distance. Can be used to allow for
                                                clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                start. If specified, sorting will not start until after mouse is dragged beyond
                                                distance. Can be used to allow for clicks on elements within a handle.
                                                </p>
                                            </div>
                                            <div class="bb-item">
                                                <h2>This is a Full widget</h2>
                                                <p>
                                                    Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                not start until after mouse is dragged beyond distance. Can be used to allow for
                                                clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                start. If specified, sorting will not start until after mouse is dragged beyond
                                                distance. Can be used to allow for clicks on elements within a handle.
                                                </p>
                                            </div>
                                        </div>
                                        <h3>For more information<a href="#">Go to FAQ Page.</a></h3>
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
                            <div class="full_widget light_gray_border collapse in" id="investor_info">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <div class="row-fluid">
                                            <div class="span5">
                                                <table class="investor_table">
                                                    <tr>
                                                        <td>Name
                                                        </td>
                                                        <td class="leftAlign">:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Account Number
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAccountNumber" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>BO Number
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBoNumber" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Account Type
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAccountType" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Investor Group
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInvestorGroup" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Branch
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBranch" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="span4">
                                                <table class="investor_table">
                                                    <tr>
                                                        <td>Account Status
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAccountStatus" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Account Category
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAccountCategory" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Joint Holder
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblJointHolder" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Nationality
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNationality" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Contact
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblContact" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Available Balance
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAvailableBalance" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="span3">
                                                <asp:Image ID="imgPhoto" ImageUrl="GetPhoto.ashx?imgid=1" class="investor_pic" AlternateText="User picture"
                                                    runat="server" Width="150" Height="150"></asp:Image>
                                                <%--<img class="investor_pic" src="../../img/investor-pic.png" alt="investor picture" />--%>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid m_b30" id="four">
                        <div class="span6 remove2" data-step="10" data-intro="This box contain Investor Signature Picture ">
                            <header class="w_header green">
                            <h2>
                                <i class="icon-user-3"></i>Investor Signature</h2>
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
                                <li><a data-toggle="collapse" data-target="#signature" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel2" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                            <div class="half_widget deepBlueborder collapse in" id="signature">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <span class="FixedSignature">
                                            <a href="#myModal" role="button" class="btn" data-toggle="modal">
                                                <asp:Image ID="imgSignature" ImageUrl="GetSignature.ashx?imgid=1" AlternateText="signature"
                                                    runat="server"></asp:Image>
                                            </a>
                                            <%--<img src="../../img/signature.png" alt="signature" />--%>
                                        </span>
                                        <!-- Modal -->
                                        <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                                <h3 id="H1">Signature</h3>
                                            </div>
                                            <div class="modal-body">
                                                <asp:Image ID="Image1" ImageUrl="GetSignature.ashx?imgid=1" AlternateText="signature" Width="350px" Height="250px" runat="server"></asp:Image>
                                            </div>
                                            <div class="modal-footer">
                                                <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                                            </div>
                                        </div>
                                        <script>
                                            $('#myModal').modal(options);
                                        </script>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div id="AccountModal" class="modal hide fade" tabindex="-2" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                        <h3 id="H2">Change Password</h3>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div class="PurchaseModalBody">
                                                <div id="AddEditForm">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                                    <fieldset class="fieldset4">
                                                        <legend class="form-ligendPassword">
                                                            <span>Old Password</span>
                                                        </legend>
                                                        <div class="row-fluid">
                                                            <div class="firstDiv ">
                                                                <ul class="formUl ">
                                                                    <li>
                                                                        <label class="EditFormLevel"><b>Enter Your Old Password</b></label>
                                                                        <%--<span class="EditForm">Account Reference</span>--%>
                                                                        <asp:TextBox ID="txtOldPassword" runat="server" class="FundWithdrawlTextBox" OnTextChanged="textBox_TextChanged" AutoPostBack="true" TabIndex="1" placeholder="minimum 8 character" TextMode="Password" pattern=".{8,}"></asp:TextBox>
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
                                                            <div class="firstDiv ">
                                                                <ul class="formUl ">
                                                                    <li>
                                                                        <label class="EditFormLevel"><b>Enter Your New Password</b></label>
                                                                        <%--<span class="EditForm">Account Reference</span>--%>
                                                                        <asp:TextBox ID="txtNewPassord" runat="server" class="FundWithdrawlTextBox" TabIndex="2" ReadOnly required placeholder="minimum 8 character" TextMode="Password" pattern=".{8,}"></asp:TextBox>
                                                                    </li>
                                                                    <li>
                                                                        <label class="EditFormLevel"><b>Confirm Password</b></label>
                                                                        <%--<span class="EditForm">Account Reference</span>--%>
                                                                        <asp:TextBox ID="txtConfirmPassword" runat="server" class="FundWithdrawlTextBox" TabIndex="3" ReadOnly required placeholder="minimum 8 character" TextMode="Password" pattern=".{8,}"></asp:TextBox>
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

                                        <button id="Button1" runat="server" class="btn appBtn btn-primary btnFormPurchase btnChangePassword" onserverclick="btnSave_Click" tabindex="5"><i class="icon-plus-2"></i>Save</button>
                                        <button class="btn appBtn btn-danger btnForm2 btnChangePassword2" data-dismiss="modal" aria-hidden="true"><i class="icon-cancel-2"></i>Close</button>
                                    </div>

                                </div>


                            </div>
                        </div>
                        <div class="span6 remove3" data-step="11" data-intro="This box contain Investor Score Card information ">
                            <header class="w_header scoreCard">
                            <h2>
                                <i class="icon-card"></i>Current Investment Position</h2>
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
                                <li><a data-toggle="collapse" data-target="#scoreCard" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel3" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                            <div class="half_widget scoreCard_wrap collapse in" id="scoreCard">
                                <%--<span class="signature">--%>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table class="scoreCard_info">
                                            <tr>
                                                <td>Total Cost of Securities
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCostOfSecurity" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Martket value of securities
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMarketValueOfSecurity" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Exposure(%)
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblExposure" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Total Equity
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTotalEquity" runat="server" Text="0.00"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Purchase Power
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPurchasePower" runat="server" Text="0.00"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <%-- </span>--%>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid m_b30 remove5" id="five" data-step="12" data-intro="This box contain Ledger information">
                        <div class="span12 widget">
                            <header class="whead w_header light">
                            <h2>
                                <i class="icon-book-2"></i>Current Stock Ledger</h2>
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
                                <li><a data-toggle="collapse" data-target="#ledgerTable" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel5" title="You can temporarily hide this widget by click here">
                                </a></li>
                            </ul>
                        </header>
                            <div class="full_widget light_border collapse in" id="ledgerTable">
                                <div class="row-fluid">
                                    <div class="span12 padding10 ">
                                        <div class="shownpars">
                                            <div role="grid" class="dataTables_wrapper" id="DataTables_Table_1_wrapper">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Repeater ID="rptLedger" runat="server">
                                                            <HeaderTemplate>
                                                                <table cellpadding="0" cellspacing="0" border="0" class="dTable">
                                                                    <thead>
                                                                        <tr role="row">
                                                                            <th class="dttableleftalign">Instrument<span class="sorting" style="display: block;"></span>
                                                                            </th>
                                                                            <th class="dttablerightalign">Total
                                                                            </th>
                                                                            <th class="dttablerightalign">Saleable
                                                                            </th>
                                                                            <th class="dttablerightalign">Avg. Cost
                                                                            </th>
                                                                            <th class="dttablerightalign">Total Cost
                                                                            </th>
                                                                            <th class="dttablerightalign">Opening Price
                                                                            </th>
                                                                            <th class="dttablerightalign">Current Price
                                                                            </th>
                                                                            <th class="dttablerightalign">Market Value
                                                                            </th>
                                                                            <th class="dttablerightalign">Unrealized Gain
                                                                            </th>
                                                                            <th class="dttablerightalign">PE Ratio
                                                                            </th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr class="gradeA odd">
                                                                    <td class="dttableleftalign">
                                                                        <%# Eval("ShortName")%>
                                                                    </td>
                                                                    <td class="dttablerightalign">
                                                                        <%# Eval("NetBalance", "{0:#,#}")%>
                                                                    </td>
                                                                    <td class="dttablerightalign">
                                                                        <%# Eval("MaturedBalance", "{0:0,#}")%>
                                                                    </td>
                                                                    <td class="dttablerightalign">
                                                                        <%# Eval("AverageBuyingPrice", "{0:#,##0.00}")%>
                                                                    </td>
                                                                    <td class="dttablerightalign">
                                                                        <%# Eval("TotalCost", "{0:#,##0.00}")%>
                                                                    </td>
                                                                    <td class="dttablerightalign">
                                                                        <%# Eval("MarketPrice", "{0:#,##0.00}")%>
                                                                    </td>
                                                                    <td class="dttablerightalign">
                                                                        <%# Eval("MarketPrice", "{0:#,##0.00}")%>
                                                                    </td>
                                                                    <td class="dttablerightalign">
                                                                        <%--<%# (Convert.ToDecimal(Eval("NetBalance", "{0:#,#0.0}")) * Convert.ToDecimal(Eval("MarketPrice", "{0:#,#0.0}")))%>--%>
                                                                        <%# Eval("MarketValue", "{0:#,##0.00}")%>
                                                                    </td>
                                                                    <td class="dttablerightalign">
                                                                        <%# Eval("UnRealisedGain", "{0:#,##0.00}")%>
                                                                    </td>
                                                                    <td class="dttablerightalign">
                                                                        <%# Eval("PERatio", "{0:#,##0.00}")%>
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
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid m_b30 remove4" id="six" data-step="13" data-intro="This box contain Realize Gain Analysis information and show them into a chart">
                        <div class="span12">
                            <header class="w_header light_gray">
                            <h2>
                                <i class="icon-bars"></i>Segmentwise Investment</h2>
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
                                <li><a data-toggle="collapse" data-target="#rga" class="min" title="You can collapse this widget by click here!">
                                </a></li>
                                <li><a class="cancel" id="cancel4" title="You can temporarily hide this widget by click here">
                                </a></li>             
                            </ul>
                        </header>
                            <div class="full_widget light_gray_border collapse in" id="rga" style="overflow-x: scroll;">
                                <%--<div id="linechart" style="width:800px;height:300px;"></div>--%>
                                <%--<img class="lineChart" src="../../img/line-chart.png" alt="line-chart" />--%>
                                <div id="Bar-chart" style="height: 500px; font-size: 12px;">
                                </div>
                                <div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="openDepositModal" class="modal hide fade" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-body">
                <div id="DepositForm">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <fieldset class="fieldset" style="width: 84% !important">
                        <legend class="form-ligend"><span>MAKE DEPOSIT</span> </legend>
                        <div class="row-fluid">
                            <div class="allDivWidth firstDiv">
                                <ul class="formUl">
                                    <li>
                                        <span class="required-label EditForm">Confirm your Account Number</span>
                                        <asp:TextBox ID="txtAccountNumber" runat="server" placeholder="Account Number" class="FundWithdrawlTextBox"></asp:TextBox>
                                    </li>

                                    <li>
                                        <span class="required-label EditForm">Please select your preferred Payment Mode</span>
                                        <asp:DropDownList ID="PaymentModeDropDownList" runat="server" class="dropdownForDeposit FundWthDrawlDropDown">
                                        </asp:DropDownList>
                                    </li>

                                    <li>
                                        <span class="required-label EditForm">Enter the amount you want to deposit</span>
                                        <asp:TextBox ID="txtAmount" type="number" runat="server" placeholder="0.00 BDT" class="FundWithdrawlTextBox"></asp:TextBox>
                                    </li>

                                    <li>
                                        <span class="required-label EditForm">Enter the reasone for deposit. E.g. IPO, BO, Account Fee etc.</span>
                                        <asp:TextBox ID="txtYourReference" autocomplete="off" runat="server" placeholder="Your Reference" class="FundWithdrawlTextBox"></asp:TextBox>
                                    </li>

                                    <li>
                                        <button runat="server" id="btnDepositCancel" onserverclick="btnCancel_Click" class="btn appBtn btn-inverse btnForm btnFundwthdrawFrom">
                                            CANCEL</button>
                                        <button runat="server" id="btnDepositProceed" onserverclick="btnDepositProceed_Click" class="btn appBtn btn-success btnForm btnFundwthdrawFrom">
                                            PROCEED</button>
                                    </li>

                                    <li style="display: inline-flex;">
                                        <asp:CheckBox ID="policyCheckBox" runat="server" style="padding-top: 3px" CssClass="Checkbox" onclick="javascript: ShowHideDiv(this)" />

                                        <span style="padding-left: 5px">By clicking CHECK box you agree to our 
                                        </span>
                                        <asp:Button CssClass="terms" ID="Button2" runat="server" OnClick="btnTermsAndPolicy_Click" Text="Terms and Privacy Policy" OnClientClick="document.forms[0].target = '_blank';" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>

        <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
        <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
        <script src="../../js/jquery.cookie.js"></script>
        <script src="../../js/zebra_tooltips.js"></script>
        <script src="../../js/bootstrap.min.js"></script>
        <script src="../../js/intro.js"></script>
        <script src="../../js/jquery.dataTables.js"></script>
        <script src="../../js/jquery.nicescroll.js"></script>


        <script src="../../js/jsapi.js" type="text/javascript"></script>

        <script type="text/javascript">
            google.load('visualization', '1', { packages: ['corechart'] });
        </script>
        <script type="text/javascript">
            function openModal() {
                $('#openDepositModal').modal('show');
            }

            function closePopup() {
                $('#btnDepositCancel').modal('hide');
            }

            function ShowHideDiv(policyCheckBox) {
                var btn = document.getElementById("<%=btnDepositProceed.ClientID%>");
                policyCheckBox.checked ? btn.disabled = false
                    : btn.disabled = true;
            }
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: "Dashboard.aspx/GetData",
                    data: '{}',
                    //data: '{"AccNo":' +  + '}',
                    success: function (response) {
                        drawVisualization(response.d);
                    }
                });
            })
            function drawVisualization(dataValues) {
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'ColumnName');
                data.addColumn('number', 'Total Investment');
                data.addColumn('number', 'Current Market Value');
                for (var i = 1; i < dataValues.length; i++) {
                    data.addRow([dataValues[i].ColumnName, dataValues[i].Investment, dataValues[i].Value]);
                }
                var formatter = new google.visualization.NumberFormat(
                    { negativeColor: 'red', negativeParens: true, pattern: '###,###' });
                formatter.format(data, 1);
                formatter.format(data, 2);

                new google.visualization.ColumnChart(document.getElementById('Bar-chart')).
                    draw(data, {
                        title: "",
                        hAxis: { title: 'Category', titleTextStyle: { color: '#333' } },
                        vAxis: { title: 'Amount in BDT', titleTextStyle: { color: '#333' } },
                        legend: { position: 'bottom', alignment: 'start' },
                        chartArea: { left: 110, width: "100%" },
                        width: data.getNumberOfRows() * 130,
                        bar: { groupWidth: 90 },
                        colors: ['#3366CC', 'green'],
                        fontSize: 14

                    });
            }

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
            .sortable-placeholder {
                border: 2px dashed #ccc;
                margin-bottom: 30px;
            }

            .deposit-btn {
                width: 100%;
                height: 40px;
                margin: auto;
            }

            .required-label {
                font-weight: bold;
            }

                .required-label:before {
                    color: #e32;
                    content: '*';
                    display: inline;
                }

            .pseudolink {
                color: blue;
                cursor: pointer;
            }

            .terms {
                margin-left: 5px;
                color: blue;
                font-size: 12px;
                background: white;
            }

            .dropdownForDeposit {
                width: 87% !important;
            }

            .allDivWidth {
                padding-left: 26px !important;
                width: 100%;
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

                //===== Dynamic data table =====//

                var oTable = $('.dTable').dataTable({
                    "bJQueryUI": false,
                    "bAutoWidth": false,
                    "sPaginationType": "full_numbers",
                    "sDom": '<"H"fl>t<"F"ip>',
                    "aLengthMenu": [[10, 15, 30, -1], [10, 15, 30, 50]],
                    "iDisplayLength": 10
                    //"bServerSide": true,
                    //"sAjaxSource": "Dashboard.aspx/GetStockLedger" 
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
                $('#cancel5').click(function () {
                    $('.remove5').hide(function () {
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
        <script type="text/javascript">
            function validatePass(p1, p2) {
                //        var badColor = "#ff6666";
                if (p1.value != p2.value || p1.value == '' || p2.value == '') {
                    p2.setCustomValidity('Passwords Do Not Match');
                    //	        p2.style.backgroundColor = badColor;
                } else {
                    p2.setCustomValidity('');
                }
            }
        </script>
    </form>
</asp:Content>
