<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="iTradex.UI.Pages.Investor.Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
<title>iTradex Login and Registration</title>

<link rel="icon" type="image/ico" href="../../img/favicon.png">
<link href="../../css/styles.css" rel="stylesheet" type="text/css" />
<!--[if IE]> <link href="css/ie.css" rel="stylesheet" type="text/css"> <![endif]-->
<link href="../../css/bootstrap.min.css" rel="stylesheet"/>

<script src="../../js/jquery-1.9.1.min.js"></script>
<script src="../../js/jquery-ui.min.js"></script>

<script type="text/javascript" src="../../js/jquery.sourcerer.js"></script>
<script src="../../js/zebra_tooltips.js"></script>

<script src="../../js/bootstrap.min.js"></script>
<script type="text/javascript" src="../../js/login.js"></script>
<script src="../../js/jquery.nicescroll.js"></script>
<script type="text/javascript" src="../../js/functions.js"></script>
</head>
<body>
    <%--<form id="form1" runat="server">--%>
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
	<div class="wrapper">
    	<a href="#" title="" class="logo"><img src="../../img/logo.png" alt="" /></a>
        <!-- Right top nav -->
        <div class="topNav">
			<ul>
				<li><a href="#help" data-toggle="modal" class="help buttonM bRed mb"><i class="icon-help-2"></i>Help?</a></li>
				<li><a id="logInSwitch" class="buttonM bBlue flip login mb"/><i class="icon-enter"></i>Login</a></li>
				<li><a id="registerSwitch" class="buttonM bLightBlue flip register mb" /><i class="icon-contact"></i>Create an account</a></li>
			</ul>
		</div>
        <div class="clear"></div>
    </div>
</div>
<!-- Top line ends -->


<div class="LR_wrap">
  
<!-- Login wrapper begins -->
<div class="loginWrapper">

	<!-- Current user form -->
    <form action="dashboard.aspx" id="login" runat=server>
        <div class="loginPic">
            <a href="#" title=""><img src="../../img/userLogin2.png" alt="" /></a>
            <span>Your Photograph</span>
            <div class="loginActions">
                <div><a href="#" title="You don't have an account yet? Register here" class="logleft flip register"></a></div>
                <div><a href="#" title="Forgot password?" class="logright"></a></div>
            </div>
        </div>
        
        <input type="email" name="login" placeholder="Email" class="loginEmail"/>
        <input type="password" name="password" placeholder="Password" class="loginPassword"/>
	    <div class="logControl">
            <div class="memory">
				<input type="checkbox" 
				class="check" id="remember1" />
				<label for="remember1">Remember me</label>
			</div>
            <input  />
            <asp:Button ID="btnLogin" runat="server" Text="Login" type="submit" name="submit" value="Login" class="buttonM bBlue" />
            <div class="clear"></div>
        </div>
	</form>
    
    <!-- New user form -->
    <form action="Dashboard.aspx" id="recover" >
        <div class="loginPic">
            <a href="#" title=""><img src="../../img/userLogin2.png" alt="" /></a>
            <div class="loginActions">
                <div><a href="#" title="Login" class="logback flip"></a></div>
                <div><a href="#" title="Forgot password?" class="logright"></a></div>
            </div>
        </div>
            
        
        <input type="email" name="login" placeholder="Email" class="loginUsername" required/>
          <input type="password" name="password" placeholder="Password" class="loginPassword" required/>
        <input type="password" name="password" placeholder="Confirm Password" class="loginPassword" required/>
    <%--<asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>--%>
        <input type="text" name="login" placeholder="Account Number" class="loginUsername" required/>
        <select  class="registrationSelect">
        <option selected>"---Security Question---"</option>
          <option value="Name">Your Name</option>
          <option value="saab">Ocupation</option>
          <option value="mercedes">Mercedes</option>
          <option value="audi">Audi</option>
       </select>
       <%--   <asp:Image ID="ImgCaptcha" runat="server" ImageUrl="~/captcha.ashx" /><br />
       Enter Verification Code
      <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
      <asp:Label ID="lblMessage" runat="server"></asp:Label>--%>
		<%--<input type="text" name="login" placeholder="Mobile No." class="loginUsername" required/>
        <input type="password" name="password" placeholder="Date of Birth" class="loginPassword" required/>--%>
             
        <div class="logControl">
			<div class="memory">
				<input type="checkbox" checked="checked" class="check" id="remember2" />
				<label for="remember2">I Agree</label>
				
			</div>
            <%--<asp:Button ID="btnRegistration" runat="server" Text="Register" type="submit" 
                name="submit" class="buttonM bBlue" onclick="btnRegistration_Click"  />--%>
			<%--<input type="submit" name="submit" value="Register" class="buttonM bBlue" id="btnRegistration" onclick=" btnRegistration_Click" />--%>
        </div>
	</form>

</div>
</div>
   <%-- </form>--%>
</body>
</html>
