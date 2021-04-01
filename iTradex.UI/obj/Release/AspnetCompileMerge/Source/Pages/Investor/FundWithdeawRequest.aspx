<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true"
    CodeBehind="FundWithdeawRequest.aspx.cs" Inherits="iTradex.UI.Pages.Investor.FundWithdeawRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/plugins.css" rel="stylesheet" />
    <link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
    <link href="../../css/zebra_tooltips.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../css/ui.daterangepicker.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                ×</button>
            <h3 id="myModalLabel">
                Customize your settings</h3>
        </div>
        <div class="modal-body">
            <p>
            </p>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">
                Close</button>
            <button class="btn btn-primary">
                Save changes</button>
        </div>
    </div>
    <div id="AccountModal" class="modal hide fade" tabindex="-2" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                ×</button>
            <h3 id="H1">
                Change Password</h3>
        </div>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <div class="PurchaseModalBody">
                    <div id="Div3">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×</button>
                        <fieldset class="fieldset4">
                            <legend class="form-ligendPassword"><span>Old Password</span> </legend>
                            <div class="row-fluid">
                                <div class="firstDiv ">
                                    <ul class="formUl ">
                                        <li>
                                            <label class="EditFormLevel">
                                                <b>Enter Your Old Password</b></label>
                                            <asp:TextBox ID="txtOldPassword" runat="server" class="FundWithdrawlTextBox" OnTextChanged="textBox_PasswordTextChanged"
                                                AutoPostBack="true" TabIndex="1" placeholder="minimum 8 character" TextMode="Password"
                                                pattern=".{8,}"></asp:TextBox>
                                        </li>
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                    </ul>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset class="fieldset4">
                            <legend class="form-ligendPassword"><span>New Password</span> </legend>
                            <div class="row-fluid">
                                <div class="firstDiv ">
                                    <ul class="formUl ">
                                        <li>
                                            <label class="EditFormLevel">
                                                <b>Enter Your New Password</b></label>
                                            <asp:TextBox ID="txtNewPassord" runat="server" class="FundWithdrawlTextBox" TabIndex="2"
                                                ReadOnly required placeholder="minimum 8 character" TextMode="Password" pattern=".{8,}"></asp:TextBox>
                                        </li>
                                        <li>
                                            <label class="EditFormLevel">
                                                <b>Confirm Password</b></label>
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" class="FundWithdrawlTextBox"
                                                TabIndex="3" ReadOnly required placeholder="minimum 8 character" TextMode="Password"
                                                pattern=".{8,} "></asp:TextBox>
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
            <button id="Button1" runat="server" class="btn appBtn btn-primary btnFormPurchase btnChangePassword"
                onserverclick="btnSavePassword_Click" tabindex="5">
                <i class="icon-plus-2"></i>Save</button>
            <button class="btn appBtn btn-danger btnForm2 btnChangePassword2" data-dismiss="modal"
                aria-hidden="true">
                <i class="icon-cancel-2"></i>Close</button>
        </div>
    </div>
    <div id="PinNumber" class="modal hide fade" tabindex="-2" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                ×</button>
            <h3 id="H3">
                Pin number check</h3>
        </div>
        <div class="PurchaseModalBody">
            <div id="Div5">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <fieldset class="fieldset4">
                    <legend class="form-ligendPassword"><span>Pin Number</span> </legend>
                    <div class="row-fluid">
                        <div class="firstDiv ">
                            <ul class="formUl ">
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Enter Your Pin Number</b></label>
                                    <asp:TextBox ID="txtPin" runat="server" class="FundWithdrawlTextBox" TabIndex="1"
                                        placeholder="Pin Number" TextMode="Password"></asp:TextBox>
                                </li>
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            </ul>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <div class="modal-footer">
            <button runat="server" id="btnPin" onserverclick="btnCheckPin_Click" class="btn appBtn btn-primary btnForm btnPin ">
                <i class="icon-plus-2"></i>Submit</button>
            <button class="btn appBtn btn-danger btnForm2 btnPin2" data-dismiss="modal" aria-hidden="true">
                <i class="icon-cancel-2"></i>Close</button>
        </div>
    </div>
    <div id="myModal2" class="modal hide fade CrudModal" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-body">
            <div id="AddEditForm">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <fieldset class="fieldset">
                    <legend class="form-ligend"><span>Fund Withdrawl Request</span> </legend>
                    <div class="row-fluid">
                        <div class="span6 firstDiv ">
                            <ul class="formUl ">
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Account Ref</b></label>
                                    <span class="EditForm">Enter your account reference</span>
                                    <asp:TextBox ID="txtAccountReference" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Investor Name</b></label>
                                    <span class="EditForm">Investor name of the account reference</span>
                                    <asp:TextBox ID="txtInvestorName" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Ledger Balance</b></label>
                                    <span class="EditForm">Ledger Balance</span>
                                    <asp:TextBox ID="txtAccountBalance" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Cheque/TT Ref :</b></label>
                                    <span class="EditForm">Enter your reference</span>
                                    <%--<input type="text" name="txtCheque" class="FundWithdrawlTextBox"  />--%>
                                    <asp:TextBox ID="txtC" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>--%>
                                <%-- <li>
                                            <label class="EditFormLevel">
                                                <b>Pin Number :</b></label>
                                            <span class="EditForm">Enter your pin number and press enter</span>
                                           
                                            <asp:TextBox ID="pintext" runat="server" 
                                                class="FundWithdrawlTextBox" ></asp:TextBox>
                                        </li>--%>
                                <%--<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>--%>
                                <li>
                                    <button runat="server" id="btnSave" onserverclick="btnSave_Click" class="btn appBtn btn-primary btnForm btnFundwthdrawFrom ">
                                        <i class="icon-plus-2"></i>Save</button>
                                    <%--<asp:Button class="btn appBtn btn-success btnForm " ID="Button1" runat="server" Text="Save" onclick="btnSave_Click"/>--%>
                                    <button class="btn appBtn btn-danger btnForm2 btnFundwthdrawFrom2" data-dismiss="modal"
                                        aria-hidden="true">
                                        <i class="icon-cancel-2"></i>Close</button>
                                </li>
                                <%--   </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </ul>
                        </div>
                        <div class="span6 secondDiv">
                            <ul class="formUl">
                                <li>
                                    <label class="EditFormLevel PopUpLevel">
                                        <b>Transaction Date</b></label>
                                    <%--<span class="EditForm">Select Payment Type</span>--%>
                                    <%-- <input type=text id="txtDate"  name="txtBankName" class= "FundWithdrawlTextBox DateField" required />--%>
                                    <asp:TextBox ID="txtTransactionDate" runat="server" ReadOnly="true" class="FundWithdrawlTextBox DateField onlyNumeric"
                                        TabIndex="7" placeholder="Declaration Date (dd/mm/yyyy)" pattern="\d{1,2}/\d{1,2}/\d{4}"></asp:TextBox>
                                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                             TargetControlID="txtTransactionDate"
                              CssClass="ClassName"
                             Format="dd/MM/yyyy"
                              />--%>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Payment Type :</b></label>
                                    <span class="EditForm">Select Payment Type</span>
                                    <asp:DropDownList ID="ddlPaymentType" runat="server" class="FundWthDrawlDropDown">
                                        <asp:ListItem>Cheque</asp:ListItem>
                                        <asp:ListItem>P_BEFTN</asp:ListItem>
                                    </asp:DropDownList>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Bank Name</b></label>
                                    <span class="EditForm">Select Payment Type</span>
                                    <%-- <input type="text" name="txtBankName" class="FundWithdrawlTextBox" />--%>
                                    <asp:TextBox ID="txtBankName" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Branch</b></label>
                                    <span class="EditForm">Branch of the bank</span>
                                    <%--<input type="text" name="txtBranch" class="FundWithdrawlTextBox"  />--%>
                                    <asp:TextBox ID="txtBranch" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Withdrawal Amount :</b></label>
                                    <span class="EditForm">Enter your withdrawal amount</span>
                                    <%-- <asp:TextBox ID="txtWithdrawlAmmount" runat="server" class="auto FundWithdrawlTextBox" placeholder="Only Numeric"  ></asp:TextBox>--%>
                                    <input type="text" id="withdrawlAmountBalance" onkeypress="myFunction()" onkeyup="myFunction()" class=" FundWithdrawlTextBox onlyNumeric"
                                        placeholder="Only Numeric" name="txtWithdrawlAmmount" />
                                    <span class="EditForm" id="witdrawAmountConfirm" style="color:Red"></span></li>
                            </ul>
                        </div>
                        <ul>
                        </ul>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>

    <div id="myModal3" class="modal hide fade CrudModal" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-body">
            <div id="Div6">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <fieldset class="fieldset">
                    <legend class="form-ligend"><span>Fund Withdrawl Request</span> </legend>
                    <div class="row-fluid">
                        <div class="span6 firstDiv ">
                            <ul class="formUl ">
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Account Ref</b></label>
                                    <span class="EditForm">Enter your account reference</span>
                                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Investor Name</b></label>
                                    <span class="EditForm">Investor name of the account reference</span>
                                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Ledger Balance</b></label>
                                    <span class="EditForm">Ledger Balance</span>
                                    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Confirmation Code :</b></label>
                                    <span class="EditForm" style="color:Red">Enter your confirm code</span>
                                    <input type="text" id="TextBox4" name="confirmCode" class="FundWithdrawlTextBox"  />
                                   <%-- <asp:TextBox ID="TextBox4" runat="server" class="FundWithdrawlTextBox"></asp:TextBox>--%>
                                </li>
                                <li>
                                    <button runat="server" id="Button2" onserverclick="btnSave_Click_1st" class="btn appBtn btn-primary btnForm btnFundwthdrawFrom ">
                                        <i class="icon-plus-2"></i>Save</button>
                                    <%--<asp:Button class="btn appBtn btn-success btnForm " ID="Button1" runat="server" Text="Save" onclick="btnSave_Click"/>--%>
                                    <button class="btn appBtn btn-danger btnForm2 btnFundwthdrawFrom2" data-dismiss="modal"
                                        aria-hidden="true">
                                        <i class="icon-cancel-2"></i>Close</button>
                                </li>
                                <%--   </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </ul>
                        </div>
                        <div class="span6 secondDiv">
                            <ul class="formUl">
                                <li>
                                    <label class="EditFormLevel PopUpLevel">
                                        <b>Transaction Date</b></label>
                                    <asp:TextBox ID="TextBox5" runat="server" ReadOnly="true" class="FundWithdrawlTextBox DateField onlyNumeric"
                                        TabIndex="7" placeholder="Declaration Date (dd/mm/yyyy)" pattern="\d{1,2}/\d{1,2}/\d{4}"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Payment Type :</b></label>
                                    <span class="EditForm">Selected Payment Type</span>
                                     <asp:TextBox ID="TextBox9" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Bank Name</b></label>
                                    <span class="EditForm">Bank Name of account</span>
                                    <%-- <input type="text" name="txtBankName" class="FundWithdrawlTextBox" />--%>
                                    <asp:TextBox ID="TextBox6" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Branch</b></label>
                                    <span class="EditForm">Branch of the bank</span>
                                    <%--<input type="text" name="txtBranch" class="FundWithdrawlTextBox"  />--%>
                                    <asp:TextBox ID="TextBox7" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                                </li>
                                <li>
                                    <label class="EditFormLevel">
                                        <b>Withdrawal Amount :</b></label>
                                    <span class="EditForm">Requested withdrawal amount</span>
                                     <asp:TextBox ID="TextBox8" runat="server" ReadOnly="true" class="FundWithdrawlTextBox"></asp:TextBox>
                            </ul>
                        </div>
                        <ul>
                        </ul>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>

    <div class="wrapper">
        <div id="tabs">
            <div class="row-fluid">
                <div class="span4 tour_intro">
                    <a class="btn btn-large tour-btn" title="You can visit and learn in short by click this link"
                        href="javascript:void(0);" onclick="javascript:introJs().start();"><i class="icon-sun_stroke">
                        </i>Need help? Click here.</a>
                </div>
                <div class="span8">
                    <ul class="tab" data-step="3" data-intro="This is Main Navigation">
                        <li><a href="Dashboard.aspx" class="dashboard"><i class="icon-bars"></i>Dashboard </a>
                        </li>
                        <li><a href="Order.aspx" class="order"><i class="icon-cart"></i>Order</a></li>
                        <li class="active_otp"><a href="Transaction.aspx" class="transaction"><i class="icon-calculate">
                        </i>Transaction</a></li>
                        <li><a href="Ledger.aspx" class="ledger"><i class="icon-attachment"></i>Ledger</a></li>
                        <li><a href="MarketStatus.aspx" class="market_status"><i class="icon-stats-up"></i>Market
                            Status</a></li>
                        <li><a href="InvestorProfile.aspx" class="market_status"><i class="icon-stats-up"></i>
                            Investor Profile</a></li>
                        <li><a href="Ipo.aspx" class="market_status"><i class="icon-stats-up"></i>IPO</a></li>
                        <li><a href="Reports.aspx" class="market_status"><i class="icon-stats-up"></i>Reports</a></li>
                    </ul>
                    <!--smartphone navigation===========--->
                </div>
            </div>
            <div class="row-fluid" id="tabs-container">
                <div class="span3 sidebar_widget_container">
                    <div class="sidebar_widget">
                        <div class="vertical_navigation">
                            <ul>
                                <li><a href="Transaction.aspx" title=""><i class="icon-book_alt2"></i>Transaction Statement</a></li>
                                <li><a class="active" href="FundWithdeawRequest.aspx" title=""><i class="icon-briefcase-2">
                                </i>Fund Withdraw Request</a></li>
                                <%-- <li><a href="#" title=""> <i class="icon-remove"> </i> Fund Deposit </a></li>--%>
                            </ul>
                        </div>
                    </div>
                    <!--end sidebar widget 1-->
                </div>
                <div class="span9 widget_container">
                    <asp:Panel runat="server" ID="pnlMessage">
                        <div class="alert alert-danger desk_view" id="seven">
                            <button data-dismiss="alert" class="close" type="button">
                                x</button>
                            <strong>
                                <asp:Label ID="lblShowMessage" runat="server" Text="Label"></asp:Label>
                            </strong>
                        </div>
                    </asp:Panel>
                    <div class="row-fluid m_b30 remove5" id="nine" data-step="5" data-intro="This Box Contains Ladger Informations">
                        <div class="span12 widget">
                            <header class="whead w_header paste">
                                <h2 style="color: Black;">
                                    <i class="icon-book-2"></i>Fund Withdraw Requests
                                </h2>
                                <ul class="control">
                                    <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                        id="drop4" class="w_settings dropdown-toggle"></a>
                                        <ul aria-labelledby="drop4" role="menu" class="dropdown-menu  animated fadeInRight"
                                            id="menu1">
                                            <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Action</a></li>
                                            <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Another action</a></li>
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
                                    <div class="span12 padding10">
                                        <div class="shownpars">
                                            <div role="grid" class="dataTables_wrapper" id="DataTables_Table_1_wrapper">
                                                <asp:Repeater ID="rptFundWithdrawRequest" runat="server">
                                                    <HeaderTemplate>
                                                        <table cellspacing="0" cellpadding="0" border="0" class="dTable">
                                                            <thead>
                                                                <%--<tr role="row"> <th class="balanceForward" colspan="10" style="text-align: right ;"><strong><b>Balance Forward 0.00</b></strong></th></tr>--%>
                                                                <tr role="row">
                                                                    <%--	<th class="sorting_asc" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">Account Ref<span style="display: block;" class="sorting"></span></th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Transaction Date</th>
										 <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">Your Reference</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Total Amount</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Total Vat</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">Net Ammount</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Payment Type</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Status</th>--%>
                                                                    <%--<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Market Category</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Face Value</th>	
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Market Price</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">PE Ratio</th>
                                        <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Latest EPS</th>	
                                        </tr>--%>
                                                                    <th class="dttableleftalign">
                                                                        Account Ref<span style="display: block;" class="sorting"></span>
                                                                    </th>
                                                                    <th class="dttableleftalign">
                                                                        Transaction Date
                                                                    </th>
                                                                    <th class="dttableleftalign">
                                                                        Your Reference
                                                                    </th>
                                                                    <th class="dttablerightalign">
                                                                        Total Amount
                                                                    </th>
                                                                    <th class="dttablerightalign">
                                                                        Total Vat
                                                                    </th>
                                                                    <th class="dttablerightalign">
                                                                        Net Ammount
                                                                    </th>
                                                                    <th class="dttableleftalign">
                                                                        Payment Type
                                                                    </th>
                                                                    <th class="dttableleftalign">
                                                                        Status
                                                                    </th>
                                                            </thead>
                                                            <tbody role="alert" aria-live="polite" aria-relevant="all">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="gradeA odd">
                                                            <%--<td><%#DateTime.Parse(Eval("Date").ToString()).ToString("dd-MMM-yyyy")%></td>--%>
                                                            <%--DataBinder.Eval(Container.DataItem, "Date", "{0: dd/MM/yyyy}"  "{0:d}")--%>
                                                            <td class="dttableleftalign">
                                                                <%# Eval("AccountRef")%>
                                                            </td>
                                                            <td class="dttableleftalign">
                                                                <%#DateTime.Parse(Eval("TransactionDate").ToString()).ToString("dd-MMM-yyyy")%>
                                                            </td>
                                                            <td class="dttableleftalign">
                                                                <%# Eval("YourReference")%>
                                                            </td>
                                                            <td class="dttablerightalign">
                                                                <%# Eval("TotalAmount", "{0:###,###,0.00}")%>
                                                            </td>
                                                            <td class="dttablerightalign">
                                                                <%# Eval("TotalVat", "{0:###,###,0.00}")%>
                                                            </td>
                                                            <td class="dttablerightalign">
                                                                <%# Eval("NetAmount", "{0:###,###,0.00}")%>
                                                            </td>
                                                            <td class="dttableleftalign">
                                                                <%# Eval("PaymentType")%>
                                                            </td>
                                                            <td class="dttableleftalign">
                                                                <%# Eval("Status")%>
                                                            </td>
                                                            <%--<td><%# Eval("Balance", "{0:###,###,0.00}")%></td>--%>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody> </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="Div1" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                                aria-hidden="true">
                                <div class="modal-header">
                                    <button type="submit" class="close" data-dismiss="modal" aria-hidden="true">
                                        ×</button>
                                    <h1 id="H2">
                                        Need Help ?</h1>
                                </div>
                                <div class="modal-body">
                                    <div class="bb-custom-wrapper">
                                        <div id="Div2" class="bb-bookblock">
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
                                                    <img src="../../../images/demo1/dboard.png" alt="image01" /></a>
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
                                            <a id="A1" href="#">Previous</a> <a id="A2" href="#">Next</a> <a id="A3" href="#"
                                                title="Go to last item">Last page</a>
                                        </nav>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">
                                        Close</button>
                                </div>
                            </div>
                        </div>
                        <button class="btn appBtn btn-primary fwBtn" id="btnAdd" data-toggle="modal" runat="server"
                            data-target="#myModal2">
                            <i class="icon-plus-2"></i>Add
                        </button>
                        <%--<asp:Button ID="Button2" OnClick="btnCheckPin_Click" runat="server" Text="Button" />  --%>
                        <%--<button class="btn appBtn btn-primary fwBtn2">
                            <i class=" icon-file-pdf"></i>Print</button>--%>
                        <%--<input type="button" class="btn appBtn  fwBtn2" value="Print" id="btnPrint" onClick="window.print()" />--%>
                    </div>
                    <%-- <asp:Label ID="lblWithdrawMessage" runat="server" Text=""></asp:Label>--%>
                </div>
            </div>
        </div>
    </div>
    <script src="../../js/jquery-1.9.1.min.js"></script>
    <script src="../../js/jquery-ui.min.js"></script>
    <script src="../../js/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../js/jquery.bpopup.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.sortable.min.js"></script>
    <script src="../../js/zebra_tooltips.js"></script>
    <script src="../../js/intro.js"></script>
    <script type="text/javascript" src="../../js/date.js"></script>
    <script type="text/javascript" src="../../js/daterangepicker.jQuery.js"></script>
    <script src="../../js/jquery.nicescroll.js"></script>
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


            //	        $('#rangeBa, #rangeBb').daterangepicker();

        });
    </script>
    <script type="text/javascript">
        $("#sortable").sortable({
            placeholder: "sortable-placeholder",
            forcePlaceholderSize: true,
            delay: 150,
            tolerance: "intersect",
            revert: true
        });



    </script>
    <script src="../../js/bootstrap.min.js"></script>
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

            // ===== Dynamic data table =====//

            var oTable = $('.dTable').dataTable({
                "bJQueryUI": false,
                "bAutoWidth": false,
                "sPaginationType": "full_numbers",
                "sDom": '<"H"fl>t<"F"ip>',
                "aaSorting": [[1, "desc"]],
                //             "asSorting": [ "asc", "desc" ] , //first sort desc, then asc

                "aLengthMenu": [[15, 30, 50, -1], [15, 30, 50, 100]],
                "iDisplayLength": 15


            });



            /* Apply the jEditable handlers to the table */
            oTable.$('td').editable('../examples_support/editable_ajax.php', {
                "callback": function (sValue, y) {
                    var aPos = oTable.fnGetPosition(this);
                    oTable.fnUpdate(sValue, aPos[0], aPos[1]);
                },
                "submitdata": function (value, settings) {
                    return {
                        "row_id": this.parentNode.getAttribute('id'),
                        "column": oTable.fnGetPosition(this)[2]
                    };
                },
                "height": "14px",
                "width": "100%"
            });


            //===== Dynamic table toolbars =====//		

            $('#dyn .tOptions').click(function () {
                $('#dyn .tablePars').slideToggle(200);
            });

            $('#dyn2 .tOptions').click(function () {
                $('#dyn2 .tablePars').slideToggle(200);
            });


            $('.tOptions').click(function () {
                $(this).toggleClass("act");
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

        function myFunction()
        {
            //var ledgerBalance = document.getElementById("txtAccountBalance").value;
            var ledgerBalance = document.getElementById('<%=txtAccountBalance.ClientID%>').value;
            var witdrawBalance = document.getElementById("withdrawlAmountBalance").value;
            if (isNaN(witdrawBalance) || witdrawBalance > ledgerBalance) {
                document.getElementById('witdrawAmountConfirm').innerHTML = "Withdrawl balance must be less than Ledger Balance";
            }
            if (witdrawBalance < ledgerBalance) 
            {
                document.getElementById('witdrawAmountConfirm').innerHTML = "";
            }
        };

        $(".onlyNumeric").keydown(function (event) {


            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 || event.keyCode == 190 ||
            // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
            // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
                return;
                }
            else {
                // Ensure that it is a number and stop the keypress
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105))
                {
                    event.preventDefault();
                }
            }

        });
    </script>
    <script type="text/javascript">
        function openModal() {
            $('#myModal2').modal('show');
        }
        function openModal3() {
            $('#myModal3').modal('show');
        }
        function closeModal() {
            $('#PinNumber').modal('hide');
        }
        function ValidateDate() {
            //            $('#EmailModal').modal('show');
            alert('Please select valid date');

        }
        function WithdrawlAmmount() {
            //            $('#EmailModal').modal('show');
            alert('Please enter withdrawl ammount');

        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#ctl00_MainContent_Button2").click(function (event) {
                event.preventDefault();
            });
        });
    </script>
    </form>
</asp:Content>
