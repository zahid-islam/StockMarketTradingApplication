<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginErrorPage.aspx.cs"
    Inherits="iTradex.UI.Pages.Investor.LoginErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <title>iTradex Login and Registration</title>
    <link rel="icon" type="image/ico" href="../../img/iTradex-Icon.png">
    <link href="../../css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/mika-styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/Newstyle.css" rel="stylesheet" type="text/css" />
<%--    <link href="../../css/bootstrap.css" rel="stylesheet">--%>
    <link href="../../css/settings.css" rel="stylesheet">
   <%-- <link href="../../css/owl.carousel.css" rel="stylesheet">
    <link href="../../css/prettify.css" rel="stylesheet">
    <link href="../../css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.fancybox-thumbs.css" rel="stylesheet" type="text/css" />
    <link href="../../css/blue.css" rel="stylesheet">--%>
    <%--<link href='http://fonts.googleapis.com/css?family=Raleway:400,300,500,600,700,800,900' rel='stylesheet' type='text/css'>--%>
    <%--<link href="css/fontello.css" rel="stylesheet">--%>
    <link href="../../css/picons.css" rel="stylesheet">
</head>
<body class="full-layout">
    <form id="form1" runat="server">
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
    <div id="top">
        <div class="wrapperLgin">
            <a href="#" title="" class="logo-login">
                <img src="../../img/iTradex Logo.png" />
                <%--<img src="../../img/iTradex-Logo.png"  style="width:40%; height:40%;"/>--%></a>
            <asp:Label ID="lblAcctivation" runat="server" Text=""></asp:Label>
            <div class="topNav">
                <ul class="Reghelp">
                  <%--  <li><a href="#help" data-toggle="modal" class="help buttonM bRed mb"><i class="icon-help-2">
                    </i>Help?</a></li>--%>
                    <%-- <li><a href="../../Pages/Investor/RegAndLogin.aspx" class="buttonM bLightBlue  register mb" /><i class="icon-contact">
                    </i>Create an account</a></li>--%>
                   <%-- <li><a href="#" data-toggle="modal" class="help buttonM bSea mb"><i class="icon-phone">
                    </i>Contact</a></li>--%>
                </ul>
            </div>
            <div class="light-wrapper page-title">
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="body-wrapper">
        <%--<div class="dark-wrapper">--%>
           <div class="row-fluid">
           <div class=" offset1 span8" >

            <div class="container inner" style=" padding-top:45px !important; padding-bottom:28px !important; padding-left:0px !important;">
            <h1 style=" color:#7CD248 !important; font-size:32px !important; margin-left:-102px;"> Oops!</h1>
              
                <h2 style=" margin-left:-75px; color: Gray !important; font-size:25px !important;"> This is a technical problem.</h2>
                   
            <h2 style=" margin-left:-56px; color:Gray !important; font-size:20px !important;"> We're going to fix it up and have things back to normal soon.</h2>     
                
            </div>
       

           <div style=" border-width:1px; border-color:#7CD248;border-style:solid; margin-left:5px;">
            
        <p style="font-family:Courier New">
       <%-- <img src="../../img/error.jpg"/>--%>
      <b> ------Original Error Message-----</b><br />
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>    </p>
         <p style="font-family:Courier New"> <asp:Label ID="lblst" runat="server" Text=""></asp:Label> </p>
         
        </div>
        <p style=" margin-left:6px;">
          <asp:button id="btnBack" runat="server" class="btn btn-large " text="BACK TO PREVIOUS PAGE"
           OnClientClick="JavaScript:window.history.back(1);return false;"></asp:button> </p>
<%--                    <asp:button id="btnBack" runat="server" text="Back" 
OnClientClick="JavaScript: window.history.back(1); return false;"></asp:button>--%>
          
           </div>
 
        </div>
        </div>
      
        <footer class="footer">  
            <aside class="top">
                <div class="wrapperFooter">
                    <div class="row-fluid">
                        <div class="span3">
                            <a class="fLogo">
                                <div class="logo">
                                    <img src="../../img/iTradex-Logo-Footer.png" />
                                </div>
                            </a>
                            <h3 class="footerTitle ptb10" style=" margin-left:10px !important;">
                                About</h3>
                            <p>
                                iTradex is a cloud based portfolio service to allow the stock market investors to
                                view their portfolio, account profile, market status and place trade orders and
                                fund withdraw requistions.</p>
                        </div>
                        <div class="span3">
                            <h3 class="footerTitle">
                                Quick Links</h3>
                            <ul class="fNav">
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>Home</a></li>
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>About</a></li>
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>Contacts</a></li>
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>Sitemap</a></li>
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>Help</a></li>
                                <li></li>
                            </ul>
                        </div>
                        <div class="span3">
                            <h3 class="footerTitle">
                                Resources</h3>
                            <ul class="fNav">
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>Resources 1</a></li>
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>Resources 2</a></li>
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>Resources 3</a></li>
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>Resources 4</a></li>
                                <li><a href="#" title=""><i class="icon-arrow-17"></i>Resources 5</a></li>
                                <li></li>
                            </ul>
                        </div>
                        <div class="span3">
                            <h3 class="footerTitle">
                                Contact Address</h3>
                            <ul class="cAddress">
                                <li>Suite #8A. </li>
                                <li>Haque Chamber. 89/2</li>
                                <li>West Panthapath. </li>
                                <li>Dhaka - 1215</li>
                                <li>Tel: +8801711056793 (BD)</li>
                                <li>Email: info@bosl-int.com</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </aside>
            <aside class="bottom">
                <div class="wrapperFooter">
                    <div class="row-fluid">
                        <div class="span6">
                            <p class="pt10" style="margin-top: 11px;">
                                Copyright &copy; 2013-2014. <a href="http://bosl-int.com/">Business Object Solutions
                                    Limited</a> All Rights Reserved.</p>
                        </div>
                        <%-- <div class="span6">
              <ul class="socialNav">
                <li><span>Find Us On :</span></li>
            	<li><a class="linkedIN" href="" title="Linked in"><img src="../../img/linkedin.png" alt=""/></a></li>
                <li><a class="facebook" href="" title="facebook"><img src="../../img/facebook.png" alt=""/></a></li>
                <li><a class="twitter" href="" title="twitter"><img src="../../img/twitter.png" alt=""/></a></li>
                <li><a class="youtube" href="" title="youtube"><img src="../../img/youtube.png" alt=""/></a></li>
             </ul>
          </div>--%>
                    </div>
                </div>
            </aside>
            <a href="#" class="scrollup"><i class="icon-arrow-16"></i></a>
        </footer>
    </form>
</body>
</html>
