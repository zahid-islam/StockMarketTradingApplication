<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true"
    CodeBehind="Active.aspx.cs" Inherits="iTradex.UI.Pages.Investor.Active" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../../css/dataTables.css" rel="stylesheet" type="text/css" />
    <link href="../../css/zebra_tooltips.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../css/ui.daterangepicker.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form id="Form1" runat="server"> 
 <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                ×</button>
            <h3 id="myModalLabel">
                Customize your settings</h3>
        </div>
        <div class="modal-body">
            <p>
            </p>
        </div>
        <div class="modal-footer">
            <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">
                Close</button>
            <button class="btn btn-primary">
                Save changes</button>
        </div>
    </div>
        <div id="AccountModal" class="modal hide fade" tabindex="-2" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
         <div class="modal-header">
         <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
         <h3 id="H1">Change Password</h3>
          </div>
          <asp:UpdatePanel ID="UpdatePanel5" runat="server">
         <ContentTemplate>
          <div class="PurchaseModalBody">
               <div id="Div3">
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
        <button id="Button3" runat=server  class="btn appBtn btn-primary btnFormPurchase btnChangePassword" onserverclick="btnPasswordChange_Click" tabindex=5><i class="icon-plus-2"></i> Save</button>
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
                                <li><a href="BrokerInformation.aspx" title=""><i class="icon-book_alt2"></i>Broker Information</a></li>
                                <li><a href="RegistrationConfirmation.aspx" title=""><i class="icon-book_alt2"></i>Pending
                                    Request</a></li>
                                <li><a class="active" href="Active.aspx" title=""><i class="icon-briefcase-2"></i>Active
                                    Users</a></li>
                                <%--<li><a  href="OnHold.aspx" title=""> <i class="icon-remove"> </i>Users On Hold</a></li>--%>
                                <li><a href="IpoInformation.aspx"><i class="icon-book_alt2"></i>Ipo Information</a></li>
                                <li><a href="FundWithdrawRequestBroker.aspx"><i class="icon-book_alt2"></i>Fund Withdraw
                                    Request</a></li>
                            </ul>
                        </div>
                    </div>
                    <!--end sidebar widget 1-->
                </div>
                <div class="span9 widget_container" >
                     <div id="six" class="row-fluid m_b30 remove4" id="eight">
                        <div class="span12 padding10">
                            <header class="w_header light_gray">
                                <h2>
                                    <i class="icon-bars"></i>Filter Your Information</h2>
                                <ul class="control">
                                    <li class="dropdown"><a class="w_settings dropdown-toggle" id="A4" title="Settings"
                                        role="button" data-toggle="dropdown" href="#"></a>
                                        <ul id="Ul1" class="dropdown-menu  animated fadeInRight" role="menu" aria-labelledby="drop4">
                                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Action</a></li>
                                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Something else here</a></li>
                                            <li class="divider" role="presentation"></li>
                                            <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">
                                                Help</a></li>
                                        </ul>
                                    </li>
                                    <li><a title="You can collapse this widget by click here!" class="min" data-target="#rga"
                                        data-toggle="collapse"></a></li>
                                    <li><a title="You can temporarily hide this widget by click here" id="cancel4" class="cancel">
                                    </a></li>
                                </ul>
                            </header>
                            <div id="ii" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                                aria-hidden="true">
                                <div class="modal-header">
                                    <button type="submit" class="close" data-dismiss="modal" aria-hidden="true">
                                        ×</button>
                                    <h1 id="H3">
                                        Need Help ?</h1>
                                </div>
                                <div class="modal-body">
                                    <div class="bb-custom-wrapper">
                                        <div id="bb-bookblock" class="bb-bookblock">
                                       
                                            <div class="bb-item">
                                                <h2>
                                                    This is a Full widget</h2>
                                                <p>
                                                    Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                    not start until after mouse is dragged beyond distance. Can be used to allow for
                                                    clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                    start. If specified, sorting will not start until after mouse is dragged beyond
                                                    distance. Can be used to allow for clicks on elements within a handle.
                                                </p>
                                            </div>
                                            <div class="bb-item">
                                                <a href="#">
                                                    <img src="../../../images/demo1/dboard.png" alt="image01" /></a>
                                            </div>
                                            <div class="bb-item">
                                                <h2>
                                                    This is a Full widget</h2>
                                                <p>
                                                    Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                    not start until after mouse is dragged beyond distance. Can be used to allow for
                                                    clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                    start. If specified, sorting will not start until after mouse is dragged beyond
                                                    distance. Can be used to allow for clicks on elements within a handle.
                                                </p>
                                            </div>
                                            <div class="bb-item">
                                                <h2>
                                                    This is a Full widget</h2>
                                                <p>
                                                    Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                    not start until after mouse is dragged beyond distance. Can be used to allow for
                                                    clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                    start. If specified, sorting will not start until after mouse is dragged beyond
                                                    distance. Can be used to allow for clicks on elements within a handle.
                                                </p>
                                            </div>
                                            <div class="bb-item">
                                                <h2>
                                                    This is a Full widget</h2>
                                                <p>
                                                    Tolerance, in pixels, for when sorting should start. If specified, sorting will
                                                    not start until after mouse is dragged beyond distance. Can be used to allow for
                                                    clicks on elements within a handle. Tolerance, in pixels, for when sorting should
                                                    start. If specified, sorting will not start until after mouse is dragged beyond
                                                    distance. Can be used to allow for clicks on elements within a handle.
                                                </p>
                                            </div>
                                        </div>
                                        <h3>
                                            For more information<a href="#">Go to FAQ Page.</a></h3>
                                        <nav>
                                            <a id="bb-nav-prev" href="#">Previous</a> <a id="bb-nav-next" href="#">Next</a>
                                            <a id="bb-nav-jump" href="#" title="Go to last item">Last page</a>
                                        </nav>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">
                                        Close</button>
                                </div>
                            </div>
                            <div id="rga" class="full_widget light_gray_border collapse in" data-step="4" data-intro="This Box Contains Date Picking Options">
                                <div class="idate_picker" id="baseDateControl" class="dateRange">
                                    <ul class="ledgerFilter">
                                        <li>
                                            <label>
                                                Status
                                            </label>
                                            <asp:DropDownList ID="ddlStatus" runat="server" 
                                                ontextchanged="ddlStatus_TextChanged" AutoPostBack=true>
                                                <asp:ListItem>---Select---</asp:ListItem>
                                                <asp:ListItem>Active</asp:ListItem>
                                                <asp:ListItem>Suspend</asp:ListItem>
                                                 <asp:ListItem>Verified</asp:ListItem>
                                                  <asp:ListItem>Rejected</asp:ListItem>
                                            </asp:DropDownList>
                                           
                                        </li>
                                        
                                        <li>
                                            <button id="Button4" runat=server onserverclick="btnSubmitDate_Click" class="btn appBtn btn-primary btnAcctivePage"> <i class="icon-checkmark"></i> Apply</button>
                                        </li>
                                        <li></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row-fluid m_b30 remove5" id="nine" data-step="5" data-intro="This Box Contains Ladger Informations">
                        <div class="span12  widget">
                            <header class="whead w_header light">
                                <h2>
                                    <i class="icon-book-2"></i>List Of Active Users</h2>
                                <ul class="control">
                                    <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" title="Settings"
                                        id="drop4" class="w_settings dropdown-toggle"></a>
                                        <ul aria-labelledby="drop4" role="menu" class="dropdown-menu  animated fadeInRight"
                                            id="menu1">
                                            <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Action</a></li>
                                            <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Another action</a></li>
                                            <li role="presentation"><a href="#" tabindex="-1" role="menuitem">Separated link</a></li>
                                            <li class="divider" role="presentation"></li>
                                            <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">
                                                Help</a></li>
                                        </ul>
                                    </li>
                                    <li><a data-toggle="collapse" data-target="#ledgerTable" class="min" title="You can collapse this widget by click here!">
                                    </a></li>
                                    <li><a class="cancel" id="cancel5" title="You can temporarily hide this widget by click here">
                                    </a></li>
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
                                                                <tr role="row">
                                                                 <th>
                                                                      
                                                                    </th>
                                                                    <th class="dttableleftalign">
                                                                        UserID<span style="display: block;" class="sorting"></span>
                                                                    </th>
                                                                    <th class="dttableleftalign">
                                                                        AccountNumber
                                                                    </th>
                                                                    <th class="dttableleftalign">
                                                                        BONumber
                                                                    </th>
                                                                    <th class="dttableleftalign">
                                                                        LastLogin Time
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="gradeA odd">
                                                            <td><asp:CheckBox ID="chkChecked"  CssClass="Checkbox" runat="server" /> </td>
                                                            <td class="dttableleftalign">
                                                                <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserID")%>'></asp:Label>
                                                            </td>
                                                            <td class="dttableleftalign">
                                                                <asp:Label ID="lblAccountNumber" runat="server" Text='<%# Eval("AccountNumber")%>'></asp:Label>
                                                                
                                                            </td>
                                                            <td class="dttableleftalign">
                                                            <asp:Label ID="lblBONumber" runat="server" Text='<%# Eval("BONumber")%>'></asp:Label>
                                                              
                                                            </td>
                                                           <td class="dttableleftalign">
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                                
                                                            </td>
                                                          
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody> </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                              
                            </div>
                        </div>
                        <button id="btnResetPin" runat="server" onserverclick="Resetpin_click" class="btn appBtn btn-primary btnReset FundWithdrawBrokerButton2 "><i class="icon-retweet"></i>&nbsp;Reset Pin</button>
                               
                        <button id="btnResetPassword" runat="server" onserverclick="Resetpassword_click" class="btn appBtn btn-primary btnReset FundWithdrawBrokerButton2 "><i class="icon-retweet"></i>&nbsp;Reset Password</button>
                               
                        <button id="btnAcctive" runat="server" onserverclick="btnAcctive_Click" class="btn appBtn btn-primary  FundWithdrawBrokerButton2 FundWithdrawBrokerButton3">
                        <i class="icon-checkmark"></i>Active</button>
                           
                        <button id="btnSuspend" runat="server" onserverclick="btnSuspend_Click" class="btn appBtn btn-danger FundWithdrawBrokerButton2 FundWithdrawBrokerButton3">
                        <i class="icon-cancel-2"></i>Suspend</button>

                        <button id="btnResendEmail" runat="server" onserverclick="btnResendEmail_click" class="btn appBtn btn-primary btnReset FundWithdrawBrokerButton2 "><i class="icon-retweet"></i>&nbsp;Resend Email</button>

                        <button id="btnDeleteUser" runat="server" onserverclick="btnDeletUser_click" class="btn appBtn btn-danger FundWithdrawBrokerButton2 FundWithdrawBrokerButton3">
                        <i class="icon-cancel-2"></i>Delete</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
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
        .sortable-placeholder
        {
            border: 2px dashed #ccc;
            margin-bottom: 30px;
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
     function openModal() {
         alert('');
     }
    </script>
</asp:Content>
