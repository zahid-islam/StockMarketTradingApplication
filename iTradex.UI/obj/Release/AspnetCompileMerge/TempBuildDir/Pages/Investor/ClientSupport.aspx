<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true" CodeBehind="ClientSupport.aspx.cs" Inherits="iTradex.UI.ClientSupport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../../css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css">--%>
	<link href="../../css/zebra_tooltips.css" rel="stylesheet"/>
    <link rel="stylesheet" href="../../css/ui.daterangepicker.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="wrapper"> 
	<div id="tabs">
	
		  <div class="row-fluid" id="tabs-container">
			 <div class="span3 sidebar_widget_container vertical_navigation">
			     <div class="sidebar_widget">
                      <div class="vertical_navigation">
                             <ul>
                            	
                                <li><a  href="SystemAdmin.aspx" title=""><i class="icon-remove"> </i>Broker List</a></li>
                                <li><a class="active" href="ClientSupport.aspx" title=""><i class="icon-remove"> </i>Client Support</a></li>
                            </ul>                                              
                      </div>
                 </div>
                </div> 
			 <div class="span9 widget_container" id="sortable">
             
                <div class="alert alert-success desk_view" id="seven">
                  <button data-dismiss="alert" class="close" type="button">x</button>
                    
                  <strong>Hello ! </strong> <asp:Label ID="lblInvestorname" runat="server" Text="Label"></asp:Label> You Should successfully read this important alert message.
                  
                </div>
            	
               <%-- <div id="six" class="row-fluid m_b30 remove4" id="eight">
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
                </div>
             --%>

              <form id="login" runat=server autocomplete=off>
     <%--   <div class="loginPic">
            <a href="#" title=""><img src="../../img/userLogin2.png" alt="" /></a>
            <span>Your Photograph</span>
            <div class="loginActions">
                <div><a href="#" title="You don't have an account yet? Register here" class="logleft  register"></a></div>
                <div><a href="#" title="Forgot password?" class="logright"></a></div>
            </div>
        </div>--%>
         <%--<label>Email Address</label>
        <input type="email" name="Email" placeholder="Email" class="loginEmail" required/>--%>
        <label>Account Number</label>
        <input type=text name="accountNumber" placeholder="Account Number" class="loginPassword" required/>
          <asp:Panel ID="Panel1" runat="server">
            <%--<input type="submit" name="submit" value="Login" class="buttonM bBlue" onclick="btnLogin_Click" runat=server/>--%>
                    <asp:Button ID="btnLogin" runat="server" Text="Show" type="submit" name="submit"  class="buttonM bBlue clientSupport" onclick="btnLogin_Click" />
            </asp:Panel>
	   
	   </form>
    		
			 </div>
             
		 </div>
	</div>

<div class="loginWrapper">

	<!-- Current user form -->
    
    
                  
   
     
    

</div>
</asp:Content>
