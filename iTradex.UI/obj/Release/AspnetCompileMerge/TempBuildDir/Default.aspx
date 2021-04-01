<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iTradex.UI.Pages.Investor.LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <title>iTradex Login and Registration</title>
    <link rel="icon" type="image/ico" href="img/iTradex-Icon.png">
    <link href="css/responsive.css" rel="stylesheet" type="text/css" />
     <link href="css/mika-styles.css" rel="stylesheet" type="text/css" />
     <link href="css/bootstrap.min.css" rel="stylesheet" />



    <link href="css/Newstyle.css" rel="stylesheet" type="text/css" />
   <link href="css/bootstrap.css" rel="stylesheet">
<link href="css/settings.css" rel="stylesheet">
<link href="../../css/owl.carousel.css" rel="stylesheet">
<link href="css/prettify.css" rel="stylesheet">
<link href="css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
<link href="css/jquery.fancybox-thumbs.css" rel="stylesheet" type="text/css" />

<link href="css/blue.css" rel="stylesheet">
<%--<link href='http://fonts.googleapis.com/css?family=Raleway:400,300,500,600,700,800,900' rel='stylesheet' type='text/css'>--%>
<%--<link href="css/fontello.css" rel="stylesheet">--%>
<link href="../../css/picons.css" rel="stylesheet">

   
 
</head>
 
    
<body class="full-layout">
<form class="forms" action="#" method="post" runat=server>
 
    <div id="help" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                ×</button>
            <h3 id="myModalLabel">
                Help Header</h3>
        </div>
        <div class="modal-body">
            <span class="description">
                <img src="img/registration-help.png" alt="registration-help" /></span>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">
                Close</button>
        </div>
    </div>

    <div id="top">
        
        <div class="wrapperLgin">
            <%--<a href="#" title="" class="logo-login">
               
            <img src="../../img/logo.png" /></a>--%>
            <asp:Label ID="lblAcctivation" runat="server" Text=""></asp:Label>
            <div class="topNav">
                <ul class="Reghelp">
                    <li><a href="#help" data-toggle="modal" class="help buttonM bRed mb"><i class="icon-help-2">
                    </i>Help?</a></li>
                   
              <%--      <li><a href="Pages/Investor/RegAndLogin.aspx" class="buttonM bLightBlue  register mb" /><i class="icon-contact">
                    </i>Create an account</a></li>--%>

                    <li><a href="#" data-toggle="modal" class="help buttonM bSea mb"><i class="icon-phone">
                    </i>Contact</a></li>
                </ul>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
 

 <div class="body-wrapper">
   

   <div class="light-wrapper page-title">
    <%--<div class="container inner">--%>
    <a href="#" title="" class="logo-login">
        <img src="img/MikaNew.png" alt="" width=250px class="loginPageImage"  /> </a>
                <%--<img src="img/MikaSecuritiesDSE.png" / alt="" width=250px class="loginPageImage" ></a>--%>
  <%--  </div>--%>
  </div>
  <div class="dark-wrapper">
    <div class="container inner">
      <div class="row">
        <div class="col-sm-6">
          <h3>Registered Customers?</h3>
          
         <p>Please enter your Account Code or Email Address and password to enter in your portfolio if you have already registered in iTradex.</p>
     
          <div class="divide15"></div>
          <div class="form-container">
            
              <fieldset>
                <ol>
                  <li class="form-row text-input-row email-field">
                    <asp:TextBox ID="txtEmail" runat="server"   class="text-input defaultText required email"  placeholder="Account Code or Email (Required)" required ></asp:TextBox>

                    <%--<input type="text" name="email" class="text-input defaultText required email"  placeholder="Username or Email (Required)" required/>--%>
                  </li>
                  <li class="form-row text-input-row password-field">
                    <input type="password" name="password" class="text-input defaultText required password"  placeholder="Password (Required)"required autocomplete="off"/>

                   <%-- <input type="text" name="password" class="text-input defaultText required password"  placeholder="Password (Required)" required/>--%>
                  </li>
                  <li class="button-row">
                  <asp:Button ID="btnLogin" runat="server" Text="Login" type="submit" name="submit"
                               class="btn btn-submit bm0 pull-left loginPageButton" OnClick="btnLogin_Click" />
                   <%-- <input type="submit" value="Login" name="submit" class="btn btn-submit bm0 pull-left loginPageButton" />--%>
                    <p class="forgot">Forgot your <a href="#">username</a> or <a href="Pages/Investor/ForgotPassword.aspx">password</a>?</p>
                  </li>
                </ol>
              </fieldset>
           
          </div>
                    <asp:Panel runat="server" ID="pnlMessage">
                        <div class="alert alert-danger desk_view" id="seven" style="margin-top:2px;">
                            <button data-dismiss="alert" class="close" type="button"></button>
                            <strong "> 
                            <asp:Label ID="lblShowMessage" runat="server" Text=""></asp:Label>
                            </strong>
                        </div>
                    </asp:Panel>
                  <br />
         
               <ul class="GuidelinesHeader">
              
                   <li><i class="icon-lock_fill iconLogin"></i><b>  Security Guidelines:</b></li>
                   </ul>


                <ul class="Guidelines">
                
                    <li>To avail iTRADEX service, you have to apply through your nearest branch with a application
                        form.</li>
                    <li>DO NOT share your password with anyone else.</li>
                    <li>DO NOT use the save password option on your computer.</li>
                    <li>DO NOT write down your password or reveal it to anyone.</li>
                    <li>If you feel your Online login ID or Password have been stolen or compromised, change
                        your password immediately.</li>
                    <li>Change your password regularly. We recommend changing your password every 60 to
                        90 days.</li>
                    <li>If you need any assistance please email to iitsupport@mikagroupbd.com</li>
                </ul>
            
          <!-- /.form-container --> 
          
        </div>
        <div class="col-sm-6">
          <h3>New User? Register Now!</h3>
          <p> Please click on the sign up button below to register your account in iTradex for your online portfolio service. You need to have a valid and active BO account. Please contact your broker if its not enlisted in iTradex.</p>
          <a href="Pages/Investor/RegAndLogin.aspx" class="btn loginPageButton">Sign Up</a>
          <div class="divide20"></div>
          <h3>Stay connected with us through the following</h3>
          <p></p>
          <div class="connect"> <a href="" target=_blank class="btn btn-large share-facebook loginPageButton"><i class="icon-facebook"></i>Facebook</a> <a href="#" class="btn btn-large share-twitter loginPageButton"><i class="icon-twitter"></i>Twitter</a> </div>
          <!-- /.connect --> 
          
        </div>
      </div>
    </div>
    <!-- /.container --> 
  </div>
  
  </div>



    
<footer class="footer footerLogin">
    
     <aside class="bottom">
     <div class="wrapper">
        <div class="row-fluid">
          <div class="span6"> <p class="pt10">Copyright &copy; 2013-2014. <a href="http://bosl-int.com/"> Business Object Solutions Limited</a> All Rights Reserved.</p></div>
          <div class="span6">
              <ul class="socialNav">
                <li><span>Find Us On :</span></li>
            	<li><a class="linkedIN" href="http://www.linkedin.com/company/business-object-solutions-ltd" title="Linked in"><img src="img/linkedin.png" alt=""/></a></li>
                <li><a class="facebook" href="https://www.facebook.com/pages/Business-Object-Solutions-Ltd/21948020965?fref=ts" title="facebook"><img src="img/facebook.png" alt=""/></a></li>
                <li><a class="twitter" href="" title="twitter"><img src="img/twitter.png" alt=""/></a></li>
                <li><a class="youtube" href="" title="youtube"><img src="img/youtube.png" alt=""/></a></li>
             </ul>
          </div>
         </div>
      </div>
    </aside>
    
    </footer>

    <script type="text/javascript">
        $(document).ready(function () {
            var x = document.getElementById("Email").val();
            document.getElementById("Email").innerHTML = x;
            console.log(x);
        });
    </script>
     </form>
    </body>
    
</html>


