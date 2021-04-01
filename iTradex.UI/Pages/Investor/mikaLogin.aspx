<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mikaLogin.aspx.cs" Inherits="iTradex.UI.Pages.Investor.mikaLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <title>iTradex Login and Registration</title>
    <link rel="icon" type="image/ico" href="../../img/favicon.png">
    <%--<link href="../../css/styles.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../css/mika-styles.css" rel="stylesheet" type="text/css" />
    <!--[if IE]> <link href="css/ie.css" rel="stylesheet" type="text/css"> <![endif]-->
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <%--<link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/css/bootstrap-combined.min.css" rel="stylesheet"/>--%>
    <%--<link href="../../css/DoWebCaptcha.css" rel="stylesheet" type="text/css" />--%>
</head>
<body>
    <!-- Modal -->
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
                <img src="../../img/registration-help.png" alt="registration-help" /></span>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">
                Close</button>
        </div>
    </div>
    <!-- Top line begins -->
    <div id="top">
        <div class="wrapperLgin">
            <a href="#" title="" class="logo-login">
                <img src="../../img/MikaSecuritiesDSE.png" / alt="" width=250px ></a>
            <asp:Label ID="lblAcctivation" runat="server" Text=""></asp:Label>
            <div class="topNav">
                <ul class="Reghelp">
                    <li><a href="#help" data-toggle="modal" class="help buttonM bRed mb"><i class="icon-help-2">
                    </i>Help?</a></li>
                    <%--<li><a href="LoginPage.aspx" id="logInSwitch" class="buttonM bBlue flip  login mb"/><i class="icon-enter"></i>Login</a></li>--%>
                    <li><a href="RegAndLogin.aspx" class="buttonM bLightBlue  register mb" /><i class="icon-contact">
                    </i>Create an account</a></li>
                </ul>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <!-- Top line ends -->
    <div class="container">
        <div class="row">
            <div class="span8 guidlinewrapper ">
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
                    <li>For any query please call +880 2 9820561 Ext- 234 or mail to itrading@mikasecurities.net</li>
                    <li>To avail access to the service, download the application form from the download
                        section.</li>
                </ul>
            </div>
            <div class="span4">
                <div class="loginWrapper">
                    <!-- Current user form -->
                    <form id="login" runat="server" autocomplete="off">
                    <%--   <div class="loginPic">
            <a href="#" title=""><img src="../../img/userLogin2.png" alt="" /></a>
            <span>Your Photograph</span>
            <div class="loginActions">
                <div><a href="#" title="You don't have an account yet? Register here" class="logleft  register"></a></div>
                <div><a href="#" title="Forgot password?" class="logright"></a></div>
            </div>
        </div>--%>
                    <label>
                        Email Address</label>
                    <input type="email" name="Email" placeholder="Email" class="loginEmail" required />
                    <label>
                        Password</label>
                    <input type="password" name="password" placeholder="Password" class="loginPassword"
                        required />
                    <div class="logControl">
                        <div class="memory">
                            <%--<input type="checkbox" 
				class="check" id="remember1" />--%>
                            <asp:CheckBox ID="chkCookie" runat="server" type="checkbox" class="check" />
                            <label for="remember1">
                                Remember me</label>
                        </div>
                        <%--<asp:Button ID="btnLogin" runat="server" Text="Login" type="submit" 
                name="submit" class="buttonM bBlue" onclick="btnLogin_Click" />--%>
                        <asp:Panel ID="Panel1" runat="server">
                            <%--<input type="submit" name="submit" value="Login" class="buttonM bBlue" onclick="btnLogin_Click" runat=server/>--%>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" type="submit" name="submit"
                                class="buttonM bBlue" OnClick="btnLogin_Click" />
                        </asp:Panel>
                        <div class="clear">
                            <label for="remember1">
                                <%--<asp:Label ID="lblMessage" runat="server"></asp:Label>--%>
                            </label>
                        </div>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    

</body>
<footer class="footer footerLogin">
    
     <aside class="bottom">
     <div class="wrapper">
        <div class="row-fluid">
          <div class="span6"> <p class="pt10">Copyright &copy; 2012-2013. <a href="www.bosl-int.com"> Bussiness Object Solution Limited</a> All Rights Reserved.</p></div>
          <div class="span6">
              <ul class="socialNav">
                <li><span>Find Us On :</span></li>
            	<li><a class="linkedIN" href="" title="Linked in"><img src="../../img/linkedin.png" alt=""/></a></li>
                <li><a class="facebook" href="" title="facebook"><img src="../../img/facebook.png" alt=""/></a></li>
                <li><a class="twitter" href="" title="twitter"><img src="../../img/twitter.png" alt=""/></a></li>
                <li><a class="youtube" href="" title="youtube"><img src="../../img/youtube.png" alt=""/></a></li>
             </ul>
          </div>
         </div>
      </div>
    </aside>
    
    </footer>

</html>

