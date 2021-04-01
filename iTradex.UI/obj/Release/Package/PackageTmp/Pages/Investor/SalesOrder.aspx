<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true" CodeBehind="SalesOrder.aspx.cs" Inherits="iTradex.UI.Pages.Investor.SalesOrder" %>
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
                          <asp:TextBox ID="txtConfirmPassword" runat="server"  class="FundWithdrawlTextBox" TabIndex=3 ReadOnly required  placeholder="minimum 8 character" TextMode="Password" pattern=".{8,} "></asp:TextBox>
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
                    
                   <button id="Button2" runat=server  class="btn appBtn btn-primary btnFormPurchase btnChangePassword" onserverclick="btnPasswordSave_Click" tabindex=5><i class="icon-plus-2"></i> Save</button>
                   <button class="btn appBtn btn-danger btnForm2 btnChangePassword2"  data-dismiss="modal" aria-hidden="true"><i class="icon-cancel-2"></i> Close</button>
</div>

</div>
     
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

         <div id="myModal2" class="modal hide fade CrudModal2 " tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <%--<div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
              <h3 id="H2">Modal header</h3>
            </div>--%>
            <div class="PurchaseModalBody">
               <div id="AddEditForm">
                  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <fieldset class="fieldset3">
                <legend class="form-ligendSale">
                <span>Sales Order</span>
                </legend>
                  <div class="row-fluid">
                  <div class="firstDiv "  >                  
                      <ul class="formUl ">
                      <li>
                      <label class="EditFormLevel"><b>Account Ref</b></label>
                      <%--<span class="EditForm">Account Reference</span>--%>
                          <asp:TextBox ID="txtAccountReference" runat="server" ReadOnly=true class="FundWithdrawlTextBox" TabIndex=1 placeholder="Account Reference"></asp:TextBox>
                      </li>
                               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                         <li>
                        
                          <label class="EditFormLevel"><b>Instrument :</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                              <asp:DropDownList ID="ddlInstrument" runat="server" 
                                     Width="406px"  AppendDataBoundItems=true ontextchanged="ddlInstrument_TextChanged" AutoPostBack="true" TabIndex=2>
                                   <asp:ListItem Selected>----Please Select One----</asp:ListItem>      
                                     
                             </asp:DropDownList>
                          
                          </li>
                      <li>
                      <label class="EditFormLevel"><b>Share Quantity</b></label>
                      <%--<span class="EditForm">Share Quantity</span>--%>
                      <asp:TextBox ID="txtShareQuantity" runat="server" class="FundWithdrawlTextBox onlyNumeric" TabIndex=3 placeholder="Share Quantity"></asp:TextBox>
                      </li>

                      <li>
                      <label class="EditFormLevel"><b>Rate</b></label>
                     <%-- <span class="EditForm">Rate</span>--%>
                      <asp:TextBox ID="txtRate" runat="server" class="FundWithdrawlTextBox onlyNumericPoint" TabIndex=4 placeholder="Rate"></asp:TextBox>
                      </li>
                          </ContentTemplate>
                              </asp:UpdatePanel>
                       <li>
                  
                   <button id="Button1" runat=server  onserverclick="btnSave_Click" class="btn appBtn btn-primary btnFormPurchase " tabindex=5><i class="icon-plus-2"></i> Save</button>
                 <%--<asp:Button class="btn appBtn btn-success btnForm " ID="Button1" runat="server" Text="Save" onclick="btnSave_Click"/>--%>
                  <button class="btn appBtn btn-danger btnForm2"  data-dismiss="modal" aria-hidden="true"><i class="icon-cancel-2" tabindex=6></i> Close</button>
                  </li>
                      </ul>
                 
                  </div>
 
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
                    <li><a href="Dashboard.aspx" class="dashboard">
                    <i class="icon-bars"> </i>
                    Dashboard
                    </a></li>
                       <li><a href="Order.aspx"  class="order">
                    <i class="icon-cart"></i>
                   Order</a></li>
                    <li><a href="Transaction.aspx" class="transaction">
                    <i class="icon-calculate"></i>
                    Transaction</a></li>
                    <li><a href="Ledger.aspx" class="ledger">
                    <i class="icon-attachment"></i>
                    Ledger</a></li>
                    <li ><a href="MarketStatus.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Market Status</a></li>
                    <li><a href="InvestorProfile.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Investor Profile</a></li>
                     <li><a href="Ipo.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    IPO</a></li>
                    <li><a href="Reports.aspx" class="market_status">
                    <i class="icon-stats-up"></i>
                    Reports</a></li>
                </ul>
                <!--smartphone navigation===========--->
            </div>
        </div>

		  <div class="row-fluid" id="tabs-container">
			 <div class="span3 sidebar_widget_container">
			     <div class="sidebar_widget">
                      <div class="vertical_navigation">
                             <ul>
                            
                            	<li><a  href="Order.aspx" title=""><i class="icon-book_alt2"> </i>All Orders</a></li>
                                <li><a href="PurchaseOrder.aspx" title=""> <i class="icon-briefcase-2"> </i>Purchase Orders</a></li>
                               
                                <li><a class="active" href="SalesOrder.aspx" title=""><i class="icon-book_alt2"> </i>Sales Order</a></li>
                            </ul>                                              
                      </div>
                 </div><!--end sidebar widget 1-->
                </div> 
			 <div class="span9 widget_container" id="sortable">
             
                <div class="alert alert-success desk_view" id="seven">
                  <button data-dismiss="alert" class="close" type="button">x</button>
                    
                  <strong>Hello ! </strong><asp:Label ID="lblInvestorname" runat="server" Text="Label"></asp:Label> You Should successfully read this important alert message.
                  
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
    		   <div class="row-fluid m_b30 remove5" id="nine" data-step="5" data-intro="This Box Contains Ladger Informations">
                   <div class="span12  widget" >
                     <header class="whead w_header light"><h2><i class="icon-book-2"></i> Sales Orders </h2>
                        <ul class="control">
                        	<li class="dropdown">
                                <a href="#" data-toggle="dropdown" role="button" title="Settings" id="drop4" class="w_settings dropdown-toggle"></a>
                                <ul aria-labelledby="drop4" role="menu" class="dropdown-menu  animated fadeInRight" id="menu1">
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
                                
                                    <asp:Repeater ID="rptSalesOrder" runat="server">
                                    
                                  <HeaderTemplate>
                                
								<table cellspacing="0" cellpadding="0" border="0" class="dTable ">
                                
								<thead>
                                
                                  <%-- <tr role="row"> <th class="balanceForward" colspan="10" style="text-align: right ;"><strong><b>Balance Forward 0.00</b></strong></th></tr>--%>
									<tr role="row">
                                 
				
                                        
                                        
                                       <th>Transaction Date<span style="display: block;" class="sorting"></span></th>
                                       <th>Transaction Time</th>
										<th>Instrument</span></th>
										<th>Transaction Type</th>
                                        <%--<th>Memo</th>--%>
									    <th>Status</th>
										<th>Share Quantity</th>
										<th>Rate</th>
                                        <th>Total</th>
									
										
												
                                        </tr>
								</thead>                            
                                	
                                		
								 <tbody>
                                 </HeaderTemplate>
                                 <ItemTemplate>
									<tr class="gradeA odd">
                                    <td class="dttableleftalign"><%#DateTime.Parse(Eval("TransactionDate").ToString()).ToString("dd-MMM-yyyy")%></td>
										  <td class="dttableleftalign"><%#DateTime.Parse(Eval("TransactionTime").ToString()).ToString("T")%></td>
										<td class="dttableleftalign"><%# Eval("Instrument")%></td>
                                        <td class="dttableleftalign"><%# Eval("TransactionType")%></td>
										<%--<td class="dttableleftalign"><%# Eval("Memo")%></td>--%>
										 <td class="dttableleftalign"><%# Eval("Status")%></td>
										 <td class="dttablerightalign"><%# Eval("ShareQuantity", "{0:00.}")%></td>
										 <td class="dttablerightalign"><%# Eval("Rate", "{0:###,###,0.00}")%></td>
                                         <td class="dttablerightalign"><%# Eval("TotalAmount","{0:###,###,0.00}")%></td>
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
                     <button class="btn appBtn btn-primary fwBtn" id="btnAdd" data-toggle="modal" data-target="#myModal2"><i class="icon-plus-2"></i> Add </button>
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
           sUpdateURL: "AllOrders.aspx",
               "bJQueryUI": false,
               "bAutoWidth": false,
               "sPaginationType": "full_numbers",
               "sDom": '<"H"fl>t<"F"ip>',
               "aaSorting": [[0, "desc"]],
              
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

                  $(".onlyNumericPoint").keydown(function (event) {


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
        </form>
</asp:Content>
