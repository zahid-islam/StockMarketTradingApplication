<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true" CodeBehind="SystemAdmin.aspx.cs" Inherits="iTradex.UI.Pages.Investor.SystemAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../../css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css">--%>
	<link href="../../css/zebra_tooltips.css" rel="stylesheet"/>
    <link rel="stylesheet" href="../../css/ui.daterangepicker.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <form id="Form1" runat=server>
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
                <span>Add New Broker Information</span>
                </legend>
                  <div class="row-fluid">
                  <div class="span6 firstDiv">                  
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
                          <%--<asp:TextBox ID="txtBrokerName " runat="server" ></asp:TextBox>--%>
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
                          <asp:TextBox ID="txtAddress" runat="server" class="FundWithdrawlTextBox" TabIndex="8" TextMode="MultiLine" placeholder="Address"></asp:TextBox>
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
                          <asp:TextBox ID="txtEmail" runat="server" class=" FundWithdrawlTextBox" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" TabIndex="11" placeholder="user@mydomain.com"></asp:TextBox>
                          <%--<input type=text class=" FundWithdrawlTextBox " name="txtWithdrawlAmmount" required />--%>
                          </li>
                        <li>
                          <label class="EditFormLevel PopUpLevel"><b>Web</b></label>
                          <%--<span class="EditForm">Select Payment Type</span>--%>
                          <%--<input type=text name="txtBankName" class= "FundWithdrawlTextBox" required />--%>
                          <asp:TextBox ID="txtWeb" runat="server" class="FundWithdrawlTextBox" TabIndex="12" placeholder="web"></asp:TextBox>
                          </li>
                      </ul>
                  </div>
                  <ul>
                  <li>
                       <button id="Button1" runat=server onserverclick="btnSave_Click"  class="btn appBtn btn-success btnForm SystemAdminAddForm " tabindex="13"><i class="icon-plus-2"></i> Add</button>
                        <button class="btn appBtn btn-danger btnForm2 SystemAdminCloseButton"  data-dismiss="modal" aria-hidden="true" tabindex="13"><i class="icon-cancel-2"></i> Close</button>
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

        

 <div class="wrapper"> 
	<div id="tabs">
	
		  <div class="row-fluid" id="tabs-container">
			 <div class="span3 sidebar_widget_container vertical_navigation">
			     <div class="sidebar_widget">
                      <div class="vertical_navigation">
                             <ul>
                            	
                                <li><a class="active" href="SystemAdmin.aspx" title=""><i class="icon-remove"> </i>Broker List</a></li>
                                <li><a  href="ClientSupport.aspx" title=""><i class="icon-remove"> </i>Client Support</a></li>
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
    		   <div class="row-fluid m_b30 remove5" id="nine" data-step="5" data-intro="This Box Contains Ladger Informations">
                   <div class="span12  widget" >
                     <header class="whead w_header light"><h2><i class="icon-book-2"></i>Broker List</h2>
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
                                
                                    <asp:Repeater ID="rptShowBrokerData" runat="server">
                                    
                                  <HeaderTemplate>
                                
								<table cellspacing="0" cellpadding="0" border="0" class="dTable ">
                                
								<thead>
                                
                                  <%-- <tr role="row"> <th class="balanceForward" colspan="10" style="text-align: right ;"><strong><b>Balance Forward 0.00</b></strong></th></tr>--%>
									<tr role="row">
                                 
								
                                        
                                         <th>Update<span style="display: block;" class="sorting"></span></th>
										<th>MemberID</th>
										 <th>BrokerName</th>
									    
                                            <th>DSEID</th>
                                    
                                              <th>CSEID</th>
                                         
                                          <th>CDBLID</th>
                                         
										    <th>ExchangeID</th>
												
                                        </tr>
								</thead>                            
                                	
                                		
								 <tbody>
                                 </HeaderTemplate>
                                 <ItemTemplate>
									<tr class="gradeA odd">
										<%--<td></td> --%>  <%--DataBinder.Eval(Container.DataItem, "Date", "{0: dd/MM/yyyy}"  "{0:d}")--%>
										<%--<td class="dttableleftalign"><%# Eval("Prefix")%></td>--%>
                                        <td>
                                                <asp:HyperLink ID="DetailsEditCustomer" runat="server" Text='Edit' NavigateUrl=<%# "Javascript:OpenWindow('PopUpAddForm.aspx?ID=" + DataBinder.Eval(Container.DataItem, "MemberID").ToString() + "')" %> ></asp:HyperLink>   </td>
                                          
										<td class="dttablerightalign"><%# Eval( "MemberID")%></td>
										 <td class="dttablerightalign"><%# Eval("BrokerName")%></td>
                                        <td class="dttablerightalign"><%# Eval("DSEID")%></td>
                                        
                                        <td class="dttablerightalign"><%# Eval("CSEID")%></td>
                                       
                                       
                                        <td class="dttablerightalign"><%# Eval("CDBLID")%></td>
                                         <td class="dttablerightalign"><%# Eval("ExchangeID")%></td>
                                        
										
										<%--<td><%#DateTime.Parse(Eval("").ToString()).ToString("dd-MMM-yyyy")%></td>--%>
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
                      <button class="btn appBtn btn-success fwBtn" id="btnAdd" data-toggle="modal" data-target="#myModal2"><i class="icon-plus-2"></i> Add </button>
                          
                            <%--<button class="btn appBtn  fwBtn2 btn-info" data-toggle="modal" data-target="#myModal2" ><i class=" icon-pen_alt2"></i> Edit </button>--%>
                   </div>
                  

                </div> 
			 </div>
             
		 </div>
	</div>
	<%--<script src="../../js/jquery-1.9.1.min.js"></script>
	<script src="../../js/jquery-ui.min.js"></script>--%>
	<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
	<script src="../../js/jquery.cookie.js" type="text/javascript"></script>
	<script src="../../js/jquery.bpopup.min.js" type="text/javascript"></script>

	<script type="text/javascript" src="../../js/jquery.dataTables.js"></script>
    <%--<script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/jquery.dataTables.min.js"></script>--%>
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
        <script type="text/javascript">
        function OpenWindow(strChildPageUrl) {
            var testwindow = window.open(strChildPageUrl, "Child", "width=800px,height=450px,top=0,left=0,scrollbars=1,menubar=no,directories=0,titlebar=0,toolbar=0");
            testwindow.moveTo(100, 0);
        }
         </script>
        </form>
</asp:Content>
