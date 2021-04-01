<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegAndLogin.aspx.cs" Inherits="iTradex.UI.Pages.Investor.RegAndLogin" %>
 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
<title>iTradeX</title>

<link rel="icon" type="image/ico" href="../../img/favicon.png">
<link href="../../css/styles.css" rel="stylesheet" type="text/css" />
<!--[if IE]> <link href="css/ie.css" rel="stylesheet" type="text/css"> <![endif]-->
<link href="../../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../../css/DoWebCaptcha.css" rel="stylesheet" type="text/css" />
<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
<%--<script src="../../js/jquery-1.9.1.min.js"></script>
<script src="../../js/jquery-ui.min.js"></script>--%>

<script type="text/javascript" src="../../js/jquery.sourcerer.js"></script>
<script src="../../js/zebra_tooltips.js"></script>

<script src="../../js/bootstrap.min.js"></script>
<%--<script type="text/javascript" src="../../js/login.js"></script>--%>
<script src="../../js/jquery.nicescroll.js"></script>
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

</head>
<body>
  
    <!-- Modal -->
	<div id="help" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
		<div class="modal-header">
			<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
			<h3 id="myModalLabel">Help Header</h3>
		</div>
		<div class="modal-body">
			<span class="description"><img src="../../img/registration-help.png" alt="registration-help"/></span>
		</div>
		<div class="modal-footer">
			<button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Close</button>
		</div>
	</div>
  
<!-- Top line begins -->
<div id="top">
    
	<div class="wrapperLogin">
    	<a href="#" title="" class="logo"><img src="../../img/logo.png" alt="" /></a>
        <!-- Right top nav -->
        <div class="topNav">
			<ul>
				<li><a href="#help" data-toggle="modal" class="help buttonM  bRed mb"><i class="icon-help-2"></i>Help?</a></li>
				<li><a href="../../Default.aspx" class="buttonM bBlue  login mb"/><i class="icon-enter"></i>Login</a></li>
				<%--<li><a href="RegAndLogin.aspx"  class="buttonM bLightBlue  register mb" /><i class="icon-contact"></i>Create an account</a></li>--%>
			</ul>
		</div>
        <div class="clear"></div>
    </div>
</div>
<!-- Top line ends -->
<div class="row-fluid">
<div class="offset3 span6 offset3" >

    <asp:Panel runat="server" ID="pnlMessage">
                        <div class="alert alert-danger desk_view" id="seven">
                            <button data-dismiss="alert" class="close" type="button"></button>
                            <strong style="margin-left: 130px;"> 
                            <asp:Label ID="lblShowMessage" runat="server" Text=""></asp:Label>
                            </strong>
                        </div>
                    </asp:Panel>
                      <asp:Panel runat="server" ID="pnlLoginMessage">
                        <div class="alert alert-success desk_view" id="Div1">
                            <button data-dismiss="alert" class="close" type="button"></button>
                            <strong> 
                            <asp:Label ID="lblLoginMessage" runat="server" Text=""></asp:Label>
                            </strong>
                        </div>
                    </asp:Panel>
                    </div>
</div>

<div class="LR_wrap">
  
<!-- Login wrapper begins -->
<div class="loginWrapper">
 
    <!-- New user form -->
    <form id="Form1"   runat="server" autocomplete="off">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

           

         <label>Email Address</label>
        <%--<input type="email" name="Email" placeholder="user@mydomain.com" class="loginUsername" required tabindex="1" pattern="[^@]+@[^@]+\.[a-zA-Z]{3,6}"/>--%>
    <asp:TextBox ID="txtEmail" runat="server" type="email" name="Email" placeholder="user@mydomain.com" class="loginUsername" required tabindex="1" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" ></asp:TextBox>
        <label>Password</label>
        <input type="password" name="password" placeholder="minimum 8 characters" class="loginPassword"  id='p1'  required tabindex="2" pattern=".{8,}" title="8 characters minimum"/>

         <label>Confirm Password</label>
        <input type="password" name="ConfirmPassword" placeholder="Confirm Password" class="loginPassword" required onfocus="validatePass(document.getElementById('p1'), this);" oninput="validatePass(document.getElementById('p1'), this);" onkeyup="validatePass(document.getElementById('p1'), this); return false;" tabindex="3" />
     
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <label>Broker Name</label>
    <asp:DropDownList ID="ddlBroker" runat="server" class="DropDown" 
             AutoPostBack="true" 
            AppendDataBoundItems="true" required TabIndex="4" 
            onselectedindexchanged="ddlBroker_SelectedIndexChanged" >
            <asp:ListItem Selected>----Broker Name----</asp:ListItem>
          
    </asp:DropDownList>
    <label>BO Number</label>
     <asp:TextBox ID="txtPrefix" runat="server" type="text" name="login" placeholder="Prefix" class="loginUsername registrationPrefix" ReadOnly style="width:67px !important; font-weight:bold;"  ></asp:TextBox>
        <asp:TextBox ID="txtBONumber" runat="server" type="text"  placeholder="Last 8 digit" class="loginUsername registrationBONumber onlyNumeric" required TabIndex="5" style="width:85px !important;"  MaxLength="8" pattern=".{8,}" title="8 digits"></asp:TextBox>
            <label>Account/Trading Code (Exactly same as in your portfolio)</label>
    <asp:TextBox ID="txtAccountNumber" runat="server" type="text" name="AccountNumber" placeholder="Account/Trading Code" class=" loginUsername " required  TabIndex="6" MaxLength="10" title="Account/Trading Code"></asp:TextBox>
     <%--<input type="text"  name="BONumber" placeholder="BO Number" class="loginUsername registrationBONumber onlyNumeric" required/>--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    
       <%-- <input type="text" name="AccountNumber" placeholder="Account Number" class=" loginUsername " required />--%>
        <label>Secret Question</label>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <asp:DropDownList ID="ddlSecreteQuestion" runat="server" class="DropDown" TabIndex="7">
            <%--<asp:ListItem Selected>----Secret Question----</asp:ListItem>--%>
            <asp:ListItem>What is your birthplace?</asp:ListItem>
            <asp:ListItem>What is your first school?</asp:ListItem>
            <asp:ListItem>What is your mother name?</asp:ListItem>
            <asp:ListItem>What is your favourite colour?</asp:ListItem>
            <asp:ListItem>What is your National ID?</asp:ListItem>
    </asp:DropDownList>
    <label>Secret Question Answer</label>
            <asp:TextBox ID="txtSecretAnswer" runat="server" type="text" name="SecreteAnswer" placeholder="Secret Question Answer" class="loginUsername" required TabIndex="8"></asp:TextBox>
   <%-- <input type="text" name="SecreteAnswer" placeholder="Secrete Question Answer" class="loginUsername" required/>--%>
    </ContentTemplate>
    </asp:UpdatePanel>
   <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>--%>
        <asp:Image ID="ImgCaptcha" runat="server" ImageUrl="~/captcha.ashx" />
        <label>Verification</label>
      <asp:TextBox ID="txtInput" AutoPostBack="false" runat="server"  type="text"  placeholder="Enter verification code" class="loginUsername" required TabIndex="9" ></asp:TextBox>
      <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
    <label>Terms and Conditions</label> 
<div style="height:200px;width:240px;border:1px solid #ccc;font:16px/26px arial, Garamond, Serif;overflow:auto;">
<ol type="i" style="text-align:left;font-family: "Arial Narrow", Arial, sans-serif;">
  <li>To avail I TRADEX service, you have to apply through your nearest branch with an application form. </li>
  <li>DO NOT share your password with anyone. </li>
  <li>DO NOT use the save password option on your computer and any other electronic devices. </li>
  <li>If you feel your Online login ID or Password have been stolen or compromised, change your password immediately. </li>
  <li>Change your password regularly. We recommend changing your password every 60 to 90 days. </li>
<li>If you have any queries please email to iitsupport@mikagroupbd.com </li>
  <li>You will abide by all terms & conditions of GDSL BO Book <a href="http://gdslbd.com/uploads/AC_Op_Form.pdf" target="_blank">(page # 2, 3, & 4)</a>.</li>
  <li>You will abide by all terms & conditions of CDBL by Laws <a href="http://gdslbd.com/uploads/AC_Op_Form.pdf" target="_blank">7.3, 3(c)</a>. </li>
</ol>

<h4  style="text-align:left;">Charges:</h3>
<p  style="text-align:left;">Subscription Fee (BDT 300 per Annum) for I TRADEX Service will be debited from
clients BO Account at the time of activation of this service. GDSL Management has the
right to revise the subscription fees without any prior notice to the subscribers. </p>
<h4  style="text-align:left;">Expiry of Subscription:</h3>
<p  style="text-align:left;">The Subscription will be expired after one (1) year from the date of activation. </p>
<h4  style="text-align:left;">Auto renewal of Subscription: </h3>
<p  style="text-align:left;">In case of un-subscription from the service, subscribers need to inform to any of our
branch by written request before one (1) month of expiry of the service. Otherwise this
service will be auto renewed with applicable charges for next one (1) year.</p>
<h4  style="text-align:left;">Disclaimers: </h3>
<ol type="1"  style="text-align:left;">
  <li>GDSL will not be liable, if any subscribed Clients investment information is leaked due to mobile phone missing/lost or mishandling of email and/or password.</li>
  <li>GDSL will not be liable, if any problem caused by mobile network/internet service either by the Mobile Operator or by the Service Provider </li>
</ol>

<h5  style="text-align:left;">I Hereby declare that I have read the Terms and Conditions and agreed
to follow as mentioned.</h5>
</div>
	
         <%-- <uc:Captcha id="CaptchaUC" runat="server"/>--%>
        <div class="logControl">
			<div class="memory">
				<input type="checkbox"  class="check" id="remember2" required/>
				<label for="remember2"><a href="Agree.aspx" target="_blank">I Agree</a></label>
				
			</div>
            <asp:Button ID="btnRegistration" runat="server" Text="Register" 
                type="submit" name="submit"  class="buttonM bBlue" 
                onclick="btnRegistration_Click" TabIndex="10" />
                
    
           <%-- <asp:HiddenField ID="hdnSession" runat="server" />--%>
			<%--<input type="submit" name="submit" value="Register" class="buttonM bBlue" />--%>
        </div>
       <%-- </ContentTemplate>
         </asp:UpdatePanel>--%>
 

        </form>
	

</div>
</div>
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
</body>
</html>
