<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true" CodeBehind="IpoInformation.aspx.cs" Inherits="iTradex.UI.Pages.Investor.IpoInformation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../../css/plugins.css" rel="stylesheet" type="text/css" />
<link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
	<link href="../../css/zebra_tooltips.css" rel="stylesheet"/>
    <link href="../../css/jquery-ui.css" rel="stylesheet" type="text/css" />
   <link rel="stylesheet" href="../../css/ui.daterangepicker.css" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form id="Form1" runat=server>
          
                 <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                           </cc1:ToolkitScriptManager>
<div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
		<div class="modal-header">
			<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
			<h3 id="myModalLabel">Customize your settings</h3>
		</div>
		<div class="modal-body">
			<p></p>
		</div>
		<div class="modal-footer">
			<button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Close</button>
			<button class="btn btn-primary">Save changes</button>
		</div>
	</div>


        <div id="Modal3" class="modal hide fade CrudModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <%--<div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
              <h3 id="H2">Modal header</h3>
            </div>--%>
              <div class="modal-body">
               <div id="Div3">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>  
                <fieldset class="fieldset SystemAdminAddFormFieldset">
                <legend class="form-ligend">
                <span>Ipo Information</span>
                </legend>
                  <div class="row-fluid">
                  <div class="span6 firstDiv">                  
                      <ul class="formUl">
                     

                      <li>
                      <label class="EditFormLevel PopUpLevel"><b>Company Name</b></label>
                     <%-- <span class="EditForm">Investor name of the account reference</span>--%>
                      <asp:TextBox ID="txtCompanyName1" runat="server"   class="FundWithdrawlTextBox" TabIndex="1" placeholder="Company Name"></asp:TextBox>
                      </li>

                        <li>
                          <label class="EditFormLevel PopUpLevel"><b>Address Line1</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                          <%--<asp:TextBox ID="txtBrokerName " runat="server" ></asp:TextBox>--%>
                            <asp:TextBox ID="txtAddressLine11" runat="server" class="FundWithdrawlTextBox" TabIndex="2" placeholder="Address Line1"></asp:TextBox>
                          </li>
                             <li>
                      <label class="EditFormLevel PopUpLevel"><b>Address Line2</b></label>
                      <%--<span class="EditForm">Account Balance</span>--%>
                      <asp:TextBox ID="txtAddressLine21" runat="server"  class="FundWithdrawlTextBox" TabIndex="3" placeholder="Address Line2"></asp:TextBox>
                      </li>
                    
                      <li>
                      <label class="EditFormLevel PopUpLevel"><b>City</b></label>
                      <%--<span class="EditForm">Account Balance</span>--%>
                      <asp:TextBox ID="txtCity1" runat="server"  class="FundWithdrawlTextBox" TabIndex="4" placeholder="City"></asp:TextBox>
                      </li>

                             <li>
                          <label class="EditFormLevel PopUpLevel"><b>Country</b></label>
                         
                          <asp:TextBox ID="txtCountry1" runat="server" class="auto FundWithdrawlTextBox" TabIndex="5" placeholder="Country"></asp:TextBox>
                         
                          </li>
                            <li>
                      <label class="EditFormLevel PopUpLevel "><b>Post Code</b></label>
                      <%--<span class="EditForm">Enter your account reference</span>--%>
                          <asp:TextBox ID="txtPostCode1" runat="server"  class="FundWithdrawlTextBox loginUsername" type="text" TabIndex="6" placeholder="Post Code"></asp:TextBox>
                      </li>
                          

                     
                      </ul>
                  </div>
                  <div class="span6 secondDiv" >                        
                         <ul class="formUl">
                          <li>
                          <label class="EditFormLevel PopUpLevel"><b>Declaration Date</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          
                         <%-- <input type=text id="txtDate"  name="txtBankName" class= "FundWithdrawlTextBox DateField" required />--%>
                         <asp:TextBox ID="txtDeclarationDate1" runat="server" class="FundWithdrawlTextBox DateField onlyNumeric" TabIndex="7" placeholder="Declaration Date (dd/mm/yyyy)"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender3" runat="server"
                             TargetControlID="txtDeclarationDate1"
                              CssClass="ClassName"
                             Format="dd/MM/yyyy"
                              />
                          </li>
                              <li>
                          <label class="EditFormLevel PopUpLevel"><b>Expiration Date</b></label>
                             
                         <%-- <input type=text id="txtDate"  name="txtBankName" class= "FundWithdrawlTextBox DateField" required />--%>
                         <asp:TextBox ID="txtExpirationDate1" runat="server" class="FundWithdrawlTextBox DateField onlyNumeric" TabIndex="8" placeholder="Expire Date (dd/mm/yyyy)"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender4" runat="server"
                             TargetControlID="txtExpirationDate1"
                              CssClass="ClassName"
                             Format="dd/MM/yyyy"
                              />
                         
                          </li>
                    
                                   <li>
                      <label class="EditFormLevel PopUpLevel "><b>Telephone</b></label>
                      <%--<span class="EditForm">Enter your account reference</span>--%>
                          <asp:TextBox ID="txtTelephone1" runat="server"  class="FundWithdrawlTextBox loginUsername" type="text" TabIndex="9" placeholder="Telephone"></asp:TextBox>
                      </li>
                
                          <li>
                          <label class="EditFormLevel PopUpLevel"><b>Fax</b></label>
                         <%-- <span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                          <asp:TextBox ID="txtfax1" runat="server" class="FundWithdrawlTextBox" TabIndex="10" placeholder="Fax"></asp:TextBox>
                          </li>
                            
                         
                           <li>
                          <label class="EditFormLevel PopUpLevel "><b>Market Lot</b></label>
                         <%-- <span class="EditForm">Enter your withdrawal amount</span>--%>
                          <asp:TextBox ID="txtNumberOfShare1" runat="server" class=" FundWithdrawlTextBox onlyNumeric"  TabIndex="11" placeholder="Market Lot" ></asp:TextBox>
                          <%--<input type=text class=" FundWithdrawlTextBox " name="txtWithdrawlAmmount" required />--%>
                          </li>
                        <li>
                          <label class="EditFormLevel PopUpLevel "><b>Buy Rate</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                         <asp:TextBox ID="txtBuyRate1" runat="server" name="number" class="FundWithdrawlTextBox onlyNumeric2 " TabIndex="12" placeholder="Buy Rate"></asp:TextBox>
                          <%--<input type=text  runat="server" class="FundWithdrawlTextBox onlyNumeric2" TabIndex="12" placeholder="Buy Rate" required />--%>
                          </li>
                         
                      </ul>
                  </div>
                  <ul>
                            <li>
                       <button id="Button3" runat=server onserverclick="btnUpdate_Click"  class="btn appBtn btn-primary btnForm " tabindex="13"><i class="icon-loop"></i>Update</button>
                        <button class="btn appBtn btn-danger btnForm2"  data-dismiss="modal" aria-hidden="true" tabindex="14"><i class="icon-cancel-2"></i> Close</button>
           
                  </li>
                  </ul>
                 
                  </div> 
               </fieldset>
               </div>

                

            </div>
            </div>



               <div id="myModal2" class="modal hide fade CrudModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <%--<div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
              <h3 id="H2">Modal header</h3>
            </div>--%>
              <div class="modal-body">
               <div id="AddEditForm">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>  
                <fieldset class="fieldset SystemAdminAddFormFieldset">
                <legend class="form-ligend">
                <span>Ipo Information</span>
                </legend>
                  <div class="row-fluid">
                  <div class="span6 firstDiv">                  
                      <ul class="formUl">
                     

                      <li>
                      <label class="EditFormLevel PopUpLevel"><b>Company Name</b></label>
                     <%-- <span class="EditForm">Investor name of the account reference</span>--%>
                      <asp:TextBox ID="txtCompanyName" runat="server"   class="FundWithdrawlTextBox" TabIndex="1" placeholder="Company Name"></asp:TextBox>
                      </li>

                        <li>
                          <label class="EditFormLevel PopUpLevel"><b>Address Line1</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                          <%--<asp:TextBox ID="txtBrokerName " runat="server" ></asp:TextBox>--%>
                            <asp:TextBox ID="txtAddressLine1" runat="server" class="FundWithdrawlTextBox" TabIndex="2" placeholder="Address Line1"></asp:TextBox>
                          </li>
                             <li>
                      <label class="EditFormLevel PopUpLevel"><b>Address Line2</b></label>
                      <%--<span class="EditForm">Account Balance</span>--%>
                      <asp:TextBox ID="txtAddressLine2" runat="server"  class="FundWithdrawlTextBox" TabIndex="3" placeholder="Address Line2"></asp:TextBox>
                      </li>
                    
                      <li>
                      <label class="EditFormLevel PopUpLevel"><b>City</b></label>
                      <%--<span class="EditForm">Account Balance</span>--%>
                      <asp:TextBox ID="txtCity" runat="server"  class="FundWithdrawlTextBox" TabIndex="4" placeholder="City"></asp:TextBox>
                      </li>

                             <li>
                          <label class="EditFormLevel PopUpLevel"><b>Country</b></label>
                         
                          <asp:TextBox ID="txtCountry" runat="server" class="auto FundWithdrawlTextBox" TabIndex="5" placeholder="Country"></asp:TextBox>
                         
                          </li>
                            <li>
                      <label class="EditFormLevel PopUpLevel "><b>Post Code</b></label>
                      <%--<span class="EditForm">Enter your account reference</span>--%>
                          <asp:TextBox ID="txtPostCode" runat="server"  class="FundWithdrawlTextBox loginUsername" type="text" TabIndex="6" placeholder="Post Code"></asp:TextBox>
                      </li>
                          

                     
                      </ul>
                  </div>
                  <div class="span6 secondDiv" >                        
                         <ul class="formUl">
                          <li>
                          <label class="EditFormLevel PopUpLevel"><b>Declaration Date</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          
                         <%-- <input type=text id="txtDate"  name="txtBankName" class= "FundWithdrawlTextBox DateField" required />--%>
                         <asp:TextBox ID="txtDeclarationDate" runat="server" class="FundWithdrawlTextBox DateField onlyNumeric" TabIndex="7" placeholder="Declaration Date (dd/mm/yyyy)" pattern="\d{1,2}/\d{1,2}/\d{4}" ></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                             TargetControlID="txtDeclarationDate"
                              CssClass="ClassName"
                             Format="dd/MM/yyyy"
                              />
                          </li>
                              <li>
                          <label class="EditFormLevel PopUpLevel"><b>Expiration Date</b></label>
                             
                         <%-- <input type=text id="txtDate"  name="txtBankName" class= "FundWithdrawlTextBox DateField" required />--%>
                         <asp:TextBox ID="txtExpirationDate" runat="server" class="FundWithdrawlTextBox DateField onlyNumeric" TabIndex="8" placeholder="Expire Date (dd/mm/yyyy)" pattern="\d{1,2}/\d{1,2}/\d{4}"  ></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                             TargetControlID="txtExpirationDate"
                              CssClass="ClassName"
                             Format="dd/MM/yyyy"
                              />
                         
                          </li>
                    
                                   <li>
                      <label class="EditFormLevel PopUpLevel "><b>Telephone</b></label>
                      <%--<span class="EditForm">Enter your account reference</span>--%>
                          <asp:TextBox ID="txtTelephone" runat="server"  class="FundWithdrawlTextBox loginUsername" type="text" TabIndex="9" placeholder="Telephone"></asp:TextBox>
                      </li>
                
                          <li>
                          <label class="EditFormLevel PopUpLevel"><b>Fax</b></label>
                         <%-- <span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                          <asp:TextBox ID="txtfax" runat="server" class="FundWithdrawlTextBox" TabIndex="10" placeholder="Fax"></asp:TextBox>
                          </li>
                            
                         
                           <li>
                          <label class="EditFormLevel PopUpLevel "><b>Market Lot</b></label>
                         <%-- <span class="EditForm">Enter your withdrawal amount</span>--%>
                          <asp:TextBox ID="txtNumberOfShare" runat="server" class=" FundWithdrawlTextBox onlyNumeric"  TabIndex="11" placeholder="Market Lot" ></asp:TextBox>
                          <%--<input type=text class=" FundWithdrawlTextBox " name="txtWithdrawlAmmount" required />--%>
                          </li>
                        <li>
                          <label class="EditFormLevel PopUpLevel "><b>Buy Rate</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                         <asp:TextBox ID="txtBuyRate" runat="server" name="number" class="FundWithdrawlTextBox onlyNumeric2 " TabIndex="12" placeholder="Buy Rate"></asp:TextBox>
                          <%--<input type=text  runat="server" class="FundWithdrawlTextBox onlyNumeric2" TabIndex="12" placeholder="Buy Rate" required />--%>
                          </li>
                         
                      </ul>
                  </div>
                  <ul>
                            <li>
                       <button id="Button1" runat=server onserverclick="btnSave_Click"  class="btn appBtn btn-primary btnForm " tabindex="13"><i class="icon-plus-2"></i>Save</button>
                        <button class="btn appBtn btn-danger btnForm2"  data-dismiss="modal" aria-hidden="true" tabindex="14"><i class="icon-cancel-2"></i> Close</button>
           
                  </li>
                  </ul>
                 
                  </div> 
               </fieldset>
               </div>

                

            </div>
            </div>

             <div id="AccountModal" class="modal hide fade" tabindex="-2" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
         <div class="modal-header">
         <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
         <h3 id="H2">Change Password</h3>
          </div>
          <asp:UpdatePanel ID="UpdatePanel5" runat="server">
         <ContentTemplate>
          <div class="PurchaseModalBody">
               <div id="Div1">
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
                          <asp:TextBox ID="txtConfirmPassword" runat="server"  class="FundWithdrawlTextBox" TabIndex=3 ReadOnly required  placeholder="minimum 8 character" TextMode="Password" pattern=".{8,}"></asp:TextBox>
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
        <button id="Button2" runat=server  class="btn appBtn btn-primary btnFormPurchase btnChangePassword" onserverclick="btnPasswordChange_Click" tabindex=5><i class="icon-plus-2"></i> Save</button>
        <button class="btn appBtn btn-danger btnForm2 btnChangePassword2"  data-dismiss="modal" aria-hidden="true"><i class="icon-cancel-2"></i> Close</button>
    </div>

 </div>

        

 <div class="wrapper"> 
	<div id="tabs">
		<%-- <ul class="tab">
			<li><a href="Dashboard.aspx" class="dashboard">Dashboard</a></li>
			<li><a href="Order.aspx" class="order">Order</a></li>
			<li class="active_otp"><a href="Transaction.aspx" class="transaction">Transaction</a></li>
			<li><a href="Ladger.aspx" class="ledger">Ledger</a></li>
			<li><a href="Tr" class="market_status">Market Status</a></li>
		  </ul>--%>
       <%--    <div class="row-fluid"> 
		     <div class="span4 tour_intro">
                <a class="btn btn-large tour-btn" title="You can visit and learn in short by click this link"
                    href="javascript:void(0);" onclick="javascript:introJs().start();"><i class="icon-sun_stroke">
                    </i>Cant Understand ? Click here.</a>
            </div>
            <div class="span8">
                <ul class="tab" data-step="3" data-intro="This is Main Navigation">
                    <li ><a href="Dashboard.aspx" class="dashboard">Dashboard</a></li>
                    <li><a href="Order.aspx" class="order">Order</a></li>
                    <li class="active_otp"><a href="Transaction.aspx" class="transaction">Transaction</a></li>
                    <li><a href="Ledger.aspx" class="ledger">Ledger</a></li>
                    <li ><a href="MarketStatus.aspx" class="market_status">Market Status</a></li>
                    <li><a href="InvestorProfile.aspx" class="market_status">Investor Profile</a></li>
                </ul>
                <!--smartphone navigation===========--->
            </div>
		 </div>--%>
		  <div class="row-fluid" id="tabs-container">
			 <div class="span3 sidebar_widget_container">
			     <div class="sidebar_widget">
                      <div class="vertical_navigation">
                             <ul>
                             <li><a  href="OrderBroker.aspx" title=""><i class="icon-book_alt2"> </i>Order</a></li>
                                <li><a href="BrokerInformation.aspx" title=""><i class="icon-book_alt2"> </i>Broker Information</a></li>
                            	<li><a href="RegistrationConfirmation.aspx" title=""><i class="icon-book_alt2"> </i>Pending Request</a></li>
                                <li><a href="Active.aspx" title=""> <i class="icon-briefcase-2"> </i>Active Users</a></li>
                                <%--<li><a  href="OnHold.aspx" title=""> <i class="icon-remove"> </i>Users On Hold</a></li>--%>
                                
                                <li><a class="active" href="IpoInformation.aspx"><i class="icon-book_alt2"> </i>Ipo Information</a></li>
                                <li><a  href="IPOAplication.aspx"><i class="icon-book_alt2">
                                </i>IPO Application</a></li>
                                <li><a href="FundWithdrawRequestBroker.aspx"><i class="icon-book_alt2"> </i>Fund Withdraw Request</a></li>
                            </ul>                                              
                      </div>
                 </div><!--end sidebar widget 1-->
                </div> 
			 <div class="span9 widget_container" id="sortable">
             

            	
           <%--     <div id="six" class="row-fluid m_b30 remove4" id="eight">
                   <div class="span12">
                        
                        <div id="ii" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
						<div class="modal-header">
							<button type="submit" class="close" data-dismiss="modal" aria-hidden="true">×</button>
							<h1 id="H1">Need Help ?</h1>
						</div>
						<div class="modal-body">
								<div class="bb-custom-wrapper">
									<div id="bb-bookblock" class="bb-bookblock">
										
										
										<div class="bb-item">
										  <h2>This is a Full widget</h2>
											<p>Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
											Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
											</p>
										</div>
										<div class="bb-item">
											<a href="#"><img src="../../images/demo1/dboard.png" alt="image01"/></a>
											
										</div>
										<div class="bb-item">
										 <h2>This is a Full widget</h2>
											<p>Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
											Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
											</p>
										</div>
										
										<div class="bb-item">
										  <h2>This is a Full widget</h2>
											<p>Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
											Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
											</p>
										</div>
										
										<div class="bb-item">
										 <h2>This is a Full widget</h2>
											<p>Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
											Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
											</p>
										</div>
										
									</div>
									<h3>For more information<a href="#">Go to FAQ Page.</a></h3>
									<nav>
										<a id="bb-nav-prev" href="#">Previous</a>
										<a id="bb-nav-next" href="#">Next</a>
										<a id="bb-nav-jump" href="#" title="Go to last item">Last page</a>
									</nav>
								</div>								
						</div>
						
						<div class="modal-footer">
							<button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Close</button>
						</div>
					</div>
                    </div>
                </div>--%>
             
    		   
                          <div class="row-fluid m_b30 remove5" id="nine" data-step="5" data-intro="This Box Contains Ladger Informations">
                   <div class="span12  widget" >
                     <header class="whead w_header light"><h2><i class="icon-book-2"></i> Ipo Information</h2>
                        <ul class="control">
                        	<li class="dropdown">
                                <a href="#" data-toggle="dropdown" role="button" title="Settings" id="A1" class="w_settings dropdown-toggle"></a>
                                <ul aria-labelledby="drop4" role="menu" class="dropdown-menu  animated fadeInRight" id="Ul1">
                                  <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Action</a></li>
                                  <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Another action</a></li>
                                  <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Separated link</a></li>
                                   <li class="divider" role="presentation"></li>
                                  <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">Help</a></li>
                                </ul>
                            </li>
                            <li><a data-toggle="collapse" data-target="#ledgerTable" class="min" title="You can collapse this widget by click here!"></a></li>
                            <li><a class="cancel" id="cancel5" title="You can temporarily hide this widget by click here"></a></li>
                        </ul>
                     </header>
                     <div class="full_widget light_border collapse in" id="ledgerTable">
                       <div class="row-fluid">
                           <div class="span12 padding10">
							<div class="shownpars">
								<div role="grid" class="dataTables_wrapper" id="DataTables_Table_1_wrapper">
                                
                                    <asp:Repeater ID="rptIpoInformation" runat="server">
                                    
                                  <HeaderTemplate>
                                
								<table cellspacing="0" cellpadding="0" border="0" class="dTable ">
                                
								<thead>
                                
                                  <%-- <tr role="row"> <th class="balanceForward" colspan="10" style="text-align: right ;"><strong><b>Balance Forward 0.00</b></strong></th></tr>--%>
									<tr role="row">
                                 
								<%--		<th class="sorting_asc" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">Date<span style="display: block;" class="sorting"></span></th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Type</th>
										 <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">Description</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Quantity</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Rate (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">Ammount (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Comm (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Debit (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Credit (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Balance (tk)</th>	--%>
                                        
                                          <th></th>
                                       <th class="dttableleftalign">Last Date <span style="display: block;" class="sorting"></span></th>
                                        
                                       <th class="dttableleftalign">Company Name</th>
										<th class="dttablerightalign">Market Lot</th>
										<th class="dttablerightalign">Offer Price</th>
                                        <%--<th>Declaration Date</th>--%>
                                        
										  <th class="dttablerightalign">Lot Price</th>
                                        </tr>
								</thead>                            
                                	
                                		
								 <tbody>
                                 </HeaderTemplate>
                                 <ItemTemplate>
									<tr class="gradeA odd">
                                              <td><asp:CheckBox ID="chkEdit"  CssClass="Checkbox" runat="server" />  </td>
			                                  <td class="dttableleftalign"><%#DateTime.Parse(Eval("ExpireDate").ToString()).ToString("dd-MMM-yyyy")%></td>
											<td class="dttableleftalign"><%# Eval("CompanyName")%></td>
                                          <%--  <td class="dttableleftalign"><%#DateTime.Parse(Eval("DeclarationDate").ToString()).ToString("dd-MMM-yyyy")%></td>--%>
                                        
										
										<td class="dttablerightalign"><%# Eval("NumberOfShare")%></td>
                                        <td class="dttablerightalign"><%# Eval("BuyRate", "{0:###,###,0.00}")%></td>
										<td class="dttablerightalign"><%# Eval("TotalAmount", "{0:###,###,0.00}")%></td> 
                                         <asp:HiddenField ID="hdfReference" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Reference") %>' /> 
									</tr>
                                   
                                    </ItemTemplate>
                                    <FooterTemplate>
								</tbody> 
                                
							</table>
                            </FooterTemplate>
                            </asp:Repeater>

                        
						</div> 
        

         

        </div>
        </div>
                            </div>
                          </div>
                     </div>
                     <button id="Button4" runat=server  class="btn appBtn btn-primary fwBtn FundWithdrawBrokerButton2" onserverclick="btnEdit_Click" tabindex=5><i class=" icon-pen_alt2"></i>Edit</button>
                     <button class="btn appBtn btn-primary fwBtn btnIpoInformation" id="btnAdd" data-toggle="modal" data-target="#myModal2"><i class="icon-plus-2"></i> Add </button>
                   </div>
               

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
    
	<%--<script type="text/javascript" src="../../js/jquery.jeditable.js"></script>--%>

   

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
	 .sortable-placeholder{
	border:2px dashed #ccc;
	 margin-bottom:30px;
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


	        //	       	        $('#rangeBa, #rangeBb').daterangepicker();

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
               //                                                       "aaSorting": [[0, "asc"]],
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

                       $(".onlyNumeric").keydown(function (event) {


                           if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                           // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
                           // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
                               // let it happen, don't do anything
                               return;
                           }
                           else {
                               // Ensure that it is a number and stop the keypress
                               if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                                   event.preventDefault();
                               }
                           }

                       });
</script>

	
               <script type="text/javascript">

                   $(".onlyNumeric2").keydown(function (event) {


                       if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 || event.keyCode == 190 ||
                       // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
                       // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
                           // let it happen, don't do anything
                           return;
                       }
                       else {
                           // Ensure that it is a number and stop the keypress
                           if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                               event.preventDefault();
                           }
                       }

                   });
</script>

          <script type="text/javascript">
              $(document).ready(function () {
  $("#rangeBa").datepicker({ dateFormat: "dd-M-yy" });

              });
    </script>

          <script type="text/javascript">
        function openModal() {
            $('#Modal3').modal('show');
        }
        </script>


        </form>
</asp:Content>
