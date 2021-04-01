<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopUpAddForm.aspx.cs" Inherits="iTradex.UI.Pages.Investor.PopUpAddForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
 <link rel="icon" type="image/ico" href="../../img/favicon.png">
    <link href="../../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="../../css/style.css" />
	
	<link href="../../css/iconMoon.css" rel="stylesheet"/>
    <link href="../../css/animate.css" rel="stylesheet"/>
	<link href="../../css/zebra_tooltips.css" rel="stylesheet"/>
    <link href="../../css/introjs.css" rel="stylesheet"/>
    
	<link href="../../css/responsive.css" rel="stylesheet"/>
	<noscript><link rel="stylesheet" type="text/css" href="../../css/noJS.css" /></noscript>
   <link href="../../css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
	<link href="../../css/zebra_tooltips.css" rel="stylesheet"/>
    <link rel="stylesheet" href="../../css/ui.daterangepicker.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div class="modal-body">
               <div id="AddEditForm">
                  
                <fieldset class="fieldset SystemAdminAddFormFieldset ">
                <legend class="form-ligend">
                <span>Update Broker Information</span>
                </legend>
                  <div class="row-fluid">
                  <div class="span6 firstDiv "  >                  
                      <ul class="formUl ">
                     

                      <li>
                      <label class="EditFormLevel PopUpLevel"><b>MemberID</b></label>
                     <%-- <span class="EditForm">Investor name of the account reference</span>--%>
                      <asp:TextBox ID="txtMemberID" runat="server"   class="FundWithdrawlTextBox" TabIndex="1" placeholder="MemberID"></asp:TextBox>
                      </li>

                        <li>
                          <label class="EditFormLevel PopUpLevel"><b>Broker Name</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                          <asp:TextBox ID="txtBrokerName" runat="server" class="FundWithdrawlTextBox" TabIndex="2" placeholder="Broker Name"></asp:TextBox>
                          </li>
                             <li>
                      <label class="EditFormLevel PopUpLevel"><b>DSEID</b></label>
                      <%--<span class="EditForm">Account Balance</span>--%>
                      <asp:TextBox ID="txtDSEID" runat="server"  class="FundWithdrawlTextBox" TabIndex="3" placeholder="DSEID"></asp:TextBox>
                      </li>
                    
                      <li>
                      <label class="EditFormLevel PopUpLevel"><b>CSEID</b></label>
                      <%--<span class="EditForm">Account Balance</span>--%>
                      <asp:TextBox ID="txtCSEID" runat="server"  class="FundWithdrawlTextBox" TabIndex="4" placeholder="CSEID"></asp:TextBox>
                      </li>
                      

                             <li>
                          <label class="EditFormLevel PopUpLevel"><b>CDBLID</b></label>
                         
                          <asp:TextBox ID="txtCDBLID" runat="server" class="auto FundWithdrawlTextBox" TabIndex="5" placeholder="CDBLID"></asp:TextBox>
                         
                          </li>

                       <li>
                      <label class="EditFormLevel PopUpLevel"><b>Clearing BOID</b></label>
                      <%--<span class="EditForm">Enter your reference</span>--%>
                    <%--  <input type=text name="txtCheque" class="FundWithdrawlTextBox" required />--%>
                      <asp:TextBox ID="txtBOID" runat="server" class="FundWithdrawlTextBox" TabIndex="6" placeholder="Clearing BOID"></asp:TextBox>
                      </li>
                          <%--<li>
                          <label class="EditFormLevel"><b>Reference</b></label>--%>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                         <%-- <asp:TextBox ID="txtReference" runat="server" class="FundWithdrawlTextBox" required></asp:TextBox>
                          </li>--%>
                          
                         
                      </ul>
                  </div>
                  <div class="span6 secondDiv" >                        
                         <ul class="formUl">
                          
                            <li>
                      <label class="EditFormLevel PopUpLevel"><b>Prefix</b></label>
                      <%--<span class="EditForm">Enter your account reference</span>--%>
                          <asp:TextBox ID="txtPrefix" runat="server"  class="FundWithdrawlTextBox loginUsername" type="text" TabIndex="7" placeholder="Prefix"></asp:TextBox>
                      </li>

                          <li>
                          <label class="EditFormLevel PopUpLevel"><b>Address</b></label>
                         <%-- <span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                          <asp:TextBox ID="txtAddress" runat="server" class="FundWithdrawlTextBox" 
                                  TabIndex="8" TextMode="MultiLine" placeholder="Address"></asp:TextBox>
                          </li>
                            <li>
                          <label class="EditFormLevel PopUpLevel"><b>Telephone</b></label>
                         <%-- <span class="EditForm">Branch of the bank</span>--%>
                          <%--<input type=text name="txtBranch" class="FundWithdrawlTextBox" required />--%>
                          <asp:TextBox ID="txtTelephone" runat="server" class="FundWithdrawlTextBox" TabIndex="9" prefix="Telephone"></asp:TextBox>
                          </li>

                           <li>
                          <label class="EditFormLevel PopUpLevel"><b>Fax</b></label>
                         <%-- <span class="EditForm">Enter your withdrawal amount</span>--%>
                          <asp:TextBox ID="txtFax" runat="server" class=" FundWithdrawlTextBox" TabIndex="10" placeholder="Fax"></asp:TextBox>
                          <%--<input type=text class=" FundWithdrawlTextBox " name="txtWithdrawlAmmount" required />--%>
                          </li>
                           <li>
                          <label class="EditFormLevel PopUpLevel"><b>Email</b></label>
                         <%-- <span class="EditForm">Enter your withdrawal amount</span>--%>
                          <asp:TextBox ID="txtEmail" runat="server" class=" FundWithdrawlTextBox" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" TabIndex="11" placeholder="user@mydomain.com"></asp:TextBox>
                          <%--<input type=text class=" FundWithdrawlTextBox " name="txtWithdrawlAmmount" required />--%>
                          </li>
                        <li>
                          <label class="EditFormLevel PopUpLevel"><b>Web</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                          <asp:TextBox ID="txtWeb" runat="server" class="FundWithdrawlTextBox" TabIndex="12" placeholder="Web Address"></asp:TextBox>
                          </li>
                      </ul>
                  </div>
                  <ul>
                  <li>
                       <button id="Button1" runat=server onserverclick="btnSave_Click"  class="btn appBtn btn-success btnForm SystemAdminAddForm " tabindex="13"><i class="icon-loop"></i> Update</button>
                        <button class="btn appBtn btn-danger btnForm2 SystemAdminCloseButton"  onclick="CloseWindow();"><i class="icon-cancel-2" tabindex="13"></i> Close</button>
                   <%--<button id="Button1"  class="btn appBtn btn-success btnForm "><i class="icon-plus-2"></i> Save</button>--%>
                 <%--<asp:Button class="btn appBtn btn-success btnForm " ID="Button1" runat="server" Text="Save" onclick="btnSave_Click"/>--%>
                  <%--<button class="btn appBtn btn-danger btnForm2"  data-dismiss="modal" aria-hidden="true"><i class="icon-cancel-2"></i> Close</button>--%>
                  </li>
                  </ul>
                 
                  </div> 
               </fieldset>
               </div>

                

            </div>
           


            <script type="text/javascript">
                
                   function CloseWindow()
	                    {
	                        window.open('','_parent','');
	                        window.close()
	                    }
            
           </script>
    </form>
</body>
</html>
