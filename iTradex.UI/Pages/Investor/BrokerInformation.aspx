<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true" CodeBehind="BrokerInformation.aspx.cs" Inherits="iTradex.UI.BrokerInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../../css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
	<link href="../../css/zebra_tooltips.css" rel="stylesheet"/>
    <link rel="stylesheet" href="../../css/ui.daterangepicker.css" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form id="Form1" runat=server>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
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
                        <asp:TextBox ID="txtOldPassword" runat="server"  class="FundWithdrawlTextBox" ontextchanged="textBox_TextChanged" AutoPostBack="true" TabIndex=1 placeholder="minimum 8 character" TextMode="Password" pattern=".{8,}" EnableViewState=false></asp:TextBox>
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
	
		  <div class="row-fluid" id="tabs-container">
			 <div class="span3 sidebar_widget_container">
			     <div class="sidebar_widget">
                      <div class="vertical_navigation">
                             <ul>
                             <li><a  href="OrderBroker.aspx" title=""><i class="icon-book_alt2"> </i>Order</a></li>
                                <li><a class="active" href="BrokerInformation.aspx" title=""><i class="icon-book_alt2"> </i>Broker Information</a></li>
                            	<li><a href="RegistrationConfirmation.aspx" title=""><i class="icon-book_alt2"> </i>Pending Request</a></li>
                                <li><a href="Active.aspx" title=""> <i class="icon-briefcase-2"> </i>Active Users</a></li>
                                <%--<li><a  href="OnHold.aspx" title=""> <i class="icon-remove"> </i>Users On Hold</a></li>--%>
                                
                                <li><a href="IpoInformation.aspx"><i class="icon-book_alt2"> </i>Ipo Information</a></li>
                                <li><a href="IPOAplication.aspx"><i class="icon-book_alt2">
                                </i>IPO Application</a></li>
                                <li><a href="FundWithdrawRequestBroker.aspx"><i class="icon-book_alt2"> </i>Fund Withdraw Request</a></li>
                            </ul>                                              
                      </div>
                 </div><!--end sidebar widget 1-->
                </div> 
			 <div class="span9 widget_container" id="sortable">
             
                <%--<div class="alert alert-success desk_view" id="seven">
                  <button data-dismiss="alert" class="close" type="button">x</button>
                    
                  <strong>Hello ! </strong><asp:Label ID="lblInvestorname" runat="server" Text="Label"></asp:Label> You Should successfully read this important alert message.
                  
                </div>--%>
            	

                
           
            <div class="modal-body">
               <div id="AddEditForm">
                  
                <fieldset class="fieldset BrokerInformationFieldset">
                <legend class="form-ligend">
                <span>Broker Information</span>
                </legend>
                  <div class="row-fluid">
                  <div class="span6 firstDiv">                  
                      <ul class="formUl ">
                     

                      <li>
                      <label class="EditFormLevel PopUpLevel"><b>MemberID</b></label>
                     <%-- <span class="EditForm">Investor name of the account reference</span>--%>
                      <asp:TextBox ID="txtMemberID" runat="server" class="FundWithdrawlTextBox" TabIndex="1" placeholder="MemberId"></asp:TextBox>
                      </li>

                        <li>
                          <label class="EditFormLevel PopUpLevel"><b>Broker Name</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                          <asp:TextBox ID="txtBrokerName" runat="server" class="FundWithdrawlTextBox" TabIndex="2" placeholder="Broker Name"></asp:TextBox>
                          </li>
                             <li>
                      <label class="EditFormLevel PopUpLevel"><b>DSEID</b></label>
                    
                      <asp:TextBox ID="txtDSEID" runat="server"  class="FundWithdrawlTextBox" TabIndex="3" placeholder="DSEID"></asp:TextBox>
                      </li>
                    
                      <li>
                      <label class="EditFormLevel PopUpLevel"><b>CSEID</b></label>
                     
                      <asp:TextBox ID="txtCSEID" runat="server"  class="FundWithdrawlTextBox" TabIndex="4" placeholder="CSEID"></asp:TextBox>
                      </li>
                      

                             <li>
                          <label class="EditFormLevel PopUpLevel"><b>CDBLID</b></label>
                         
                          <asp:TextBox ID="txtCDBLID" runat="server" class="auto FundWithdrawlTextBox" TabIndex="5" placeholder="CDBLID"></asp:TextBox>
                         
                          </li>

                       <li>
                      <label class="EditFormLevel PopUpLevel"><b>Clearing BOID</b></label>
              
                      <asp:TextBox ID="txtBOID" runat="server" class="FundWithdrawlTextBox" TabIndex="6" placeholder="Clearing BOID"></asp:TextBox>
                      </li>
                          
                          
                         
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
                          <asp:TextBox ID="txtTelephone" runat="server" class="FundWithdrawlTextBox" TabIndex="9" placeholder="Telephone"></asp:TextBox>
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
                          <asp:TextBox ID="txtEmail" runat="server" class=" FundWithdrawlTextBox" pattern="[^@]+@[^@]+\.[a-zA-Z]{3,6}" TabIndex="11" placeholder="user@mydomain.com"></asp:TextBox>
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
                       <button id="Button1" runat=server onserverclick="btnSave_Click"  class="btn appBtn btn-primary btnForm SystemAdminAddForm " tabindex="13"><i class="icon-loop"></i> Update</button>
                  
                   <%--<button id="Button1"  class="btn appBtn btn-success btnForm "><i class="icon-plus-2"></i> Save</button>--%>
                 <%--<asp:Button class="btn appBtn btn-success btnForm " ID="Button1" runat="server" Text="Save" onclick="btnSave_Click"/>--%>
                  <%--<button class="btn appBtn btn-danger btnForm2"  data-dismiss="modal" aria-hidden="true"><i class="icon-cancel-2"></i> Close</button>--%>
                  </li>
                  </ul>
                 
                  </div> 
               </fieldset>
               </div>

                

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
        </form>

</asp:Content>
