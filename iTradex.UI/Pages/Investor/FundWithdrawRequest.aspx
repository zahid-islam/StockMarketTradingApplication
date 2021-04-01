<%@ Page Title="" Language="C#" MasterPageFile="~/iTradex.Master" AutoEventWireup="true" CodeBehind="FundWithdrawRequest.aspx.cs" Inherits="iTradex.UI.Pages.Investor.FundWithdrawRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <link href="../../css/plugins.css" rel="stylesheet"/>
	<link href="../../css/zebra_tooltips.css" rel="stylesheet"/>
    <link rel="stylesheet" href="../../css/ui.daterangepicker.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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

        <div id="myModal2" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
              <h3 id="H2">Modal header</h3>
            </div>
            <div class="modal-body">
               <div class="row-fluiid" id="AddEditForm">
               <div class="span 12"></div>
               
               
               </div>



            </div>
            <div class="modal-footer">
              <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
              <button class="btn btn-primary">Save changes</button>
            </div>
        </div>

 <div class="wrapper"> 
	<div id="tabs">
		<%-- <ul class="tab">
			<li><a href="Dashboard.aspx" class="dashboard">Dashboard</a></li>
			<li><a href="Order.aspx" class="order">Order</a></li>
			<li class="active_otp"><a href="Transaction.aspx" class="transaction">Transaction</a></li>
			<li><a href="Ladger.aspx" class="ledger">Ledger</a></li>
			<li><a href="Tr" class="market_status">Market Status</a></li>
		  </ul>--%>
           <div class="row-fluid"> 
		     <div class="span6 tour_intro">
				<a class="btn btn-large tour-btn" title="You can visit and learn in short by click this link" href="javascript:void(0);" onclick="javascript:introJs().start();"><i class="icon-sun_stroke"></i> Cant Understand ? Click here.</a>
              </div>
			  <div class="span6">
				  <ul class="tab" data-step="3" data-intro="This is Main Navigation">
					<li ><a href="Dashboard.aspx" class="dashboard">Dashboard</a></li>
					<li><a href="Order.aspx" class="order">Order</a></li>
					<li class="active_otp"><a href="Transaction.aspx" class="transaction">Transaction</a></li>
					<li><a href="Ledger.aspx" class="ledger">Ledger</a></li>
					<li><a href="MarketStatus.aspx" class="market_status">Market Status</a></li>
				  </ul>
				 <!--smartphone navigation===========---> 
		       </div>
		 </div>
		  <div class="row-fluid" id="tabs-container">
			 <div class="span3 sidebar_widget_container">
			     <div class="sidebar_widget">
                      <div class="vertical_navigation">
                             <ul>
                            	<li><a href="#" title=""><i class="icon-book_alt2"> </i> Ledger</a></li>
                                <li><a class="active" href="FundWithdrawRequest.aspx" title=""> <i class="icon-briefcase-2"> </i> Fund Withdraw Request</a></li>
                                <li><a href="#" title=""> <i class="icon-remove"> </i> Fund Deposit </a></li>
                            </ul>                                              
                      </div>
                 </div><!--end sidebar widget 1-->
                </div> 
			 <div class="span9 widget_container" id="sortable">
             
                <div class="alert alert-block" id="seven">
                  <button data-dismiss="alert" class="close" type="button">X</button>
                  <h4>Warning!</h4>
                  <p>Best check yo self, you're not looking too good. Nulla vitae elit libero, a pharetra augue. Praesent commodo cursus magna, vel scelerisque nisl consectetur et.</p>
                </div>
            	
                <div id="six" class="row-fluid m_b30 remove4" id="eight">
                   <div class="span12">
                     <%--<header class="w_header light_gray"><h2><i class="icon-bars"></i> Filter Your Information</h2>
                        <ul class="control">
                        	<li class="dropdown">
                                <a class="w_settings dropdown-toggle" id="drop4" title="Settings" role="button" data-toggle="dropdown" href="#"></a>
                                <ul id="menu1" class="dropdown-menu  animated fadeInRight" role="menu" aria-labelledby="drop4">
                                  <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Action</a></li>
                                  <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Something else here</a></li>
                                  <li class="divider" role="presentation"></li>
                                  <li role="presentation"><a href="#ii" tabindex="-1" data-toggle="modal" role="menuitem">Help</a></li>
                                </ul>
                            </li>
                            <li><a title="You can collapse this widget by click here!" class="min" data-target="#rga" data-toggle="collapse"></a></li>
                            <li><a title="You can temporarily hide this widget by click here" id="cancel4" class="cancel"></a></li>
                        </ul>
                     </header>--%>


                     
                        <div id="ii" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
						<div class="modal-header">
							<button type="submit" class="close" data-dismiss="modal" aria-hidden="true">×</button>
							<h1 id="H1">Need Help ?</h1>
						</div>
						<div class="modal-body">
								<div class="bb-custom-wrapper">
									<div id="bb-bookblock" class="bb-bookblock">
										<!-- <div class="bb-item">
											<a href="#"><img src="images/demo1/1.jpg" alt="image01"/></a>
										</div>
										<div class="bb-item">
											<a href="#"><img src="images/demo1/2.jpg" alt="image02"/></a>
										</div>
										<div class="bb-item">
											<a href="#"><img src="images/demo1/3.jpg" alt="image03"/></a>
										</div>
										<div class="bb-item">
											<a href="#"><img src="images/demo1/4.jpg" alt="image04"/></a>
										</div>
										<div class="bb-item">
											<a href="#"><img src="images/demo1/5.jpg" alt="image05"/></a>
										</div> -->
										
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



                        <%-- <div id="rga" class="full_widget light_gray_border collapse in" data-step="4" data-intro="This Box Contains Date Picking Options">
                          	<div class="idate_picker" id="baseDateControl">
                                <h2>Select Your Date</h2>
                        		<div class="datepicker">
                                    <form id="dateRange" runat="server">
                                        <input type="text" placeholder="From" id="rangeBa" name="rangeBa" />
                                         <asp:TextBox ID="rangeBa" runat="server" placeholder="From"></asp:TextB>
                                        <input type="text" placeholder="To" id="rangeBb" name="rangeBb" />
                                        <%--<input type="submit" class="btn appBtn btn-primary" value="Apply" id="btnApply" />
                                        <asp:Button ID="btnSubmitDate" class="btn appBtn btn-primary" runat="server" 
                                            Text="Apply" onclick="btnSubmitDate_Click" />
                                    </form>
                                </div>
                            </div>
                         </div>--%>
                    </div>
                </div>
             
    		   <div class="row-fluid m_b30 remove5" id="nine" data-step="5" data-intro="This Box Contains Ladger Informations">
                   <div class="span12">
                     <header class="w_header paste"><h2><i class="icon-book-2"></i> Ledger</h2>
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
                     <div class="full_widget deepBlueborder collapse in" id="ledgerTable">
                       <div class="row-fluid">
                           <div class="span12 padding10">
							<div class="shownpars">
								<div role="grid" class="dataTables_wrapper" id="DataTables_Table_1_wrapper">
                                
                                    <asp:Repeater ID="rptLedger" runat="server">
                                    
                                  <HeaderTemplate>
                                
								<table cellspacing="0" cellpadding="0" border="0" class="dTable dataTable" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info">
                                
								<thead>
                                
                                   <tr role="row"> <th class="balanceForward" colspan="10" style="text-align: right ;"><strong><b>Balance Forward 0.00</b></strong></th></tr>
									<tr role="row">
                                 
										<th class="sorting_asc" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">Date<span style="display: block;" class="sorting"></span></th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Type</th>
										 <th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">Description</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Quantity</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Rate (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending">Ammount (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Comm (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Debit (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">Credit (tk)</th>
										<th class="sorting" role="columnheader" tabindex="0" aria-controls="DataTables_Table_1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Balance (tk)</th>		
                                        </tr>
								</thead>                            
                                	
                                		
								 <tbody role="alert" aria-live="polite" aria-relevant="all">
                                 </HeaderTemplate>
                                 <ItemTemplate>
									<tr class="gradeA odd">
										<td><%#DateTime.Parse(Eval("Date").ToString()).ToString("dd-MMM-yyyy")%></td>   <%--DataBinder.Eval(Container.DataItem, "Date", "{0: dd/MM/yyyy}"  "{0:d}")--%>
										<td><%# Eval("Type")%></td>
										<td><%# Eval("Description")%></td>
										<td><%# Eval("Quantity", "{0:00.}")%></td>
										<td><%# Eval("Rate", "{0:00.}")%></td>
										<td><%# Eval("Amount", "{0:###,###,0.00}")%></td>
										<td><%# Eval("Comm", "{0:###,###,0.00}")%></td>
										<td><%# Eval("Debit", "{0:###,###,0.00}")%></td>
										<td><%# Eval("Credit", "{0:###,###,0.00}")%></td>
										<td><%# Eval("Balance", "{0:###,###,0.00}")%></td>
									</tr>
                                    <%--<tr>--%>
                                    <%--<td>Balance</td>
                                    <td>Balance</td>
                                    </tr>--%>

									<%--<tr class="gradeA even">
									  <table>
                                      <tr>
                                      <td>dsr</td>
                                      <td>sv</td>
                                      </tr>
                                      <tr>
                                      <td>sers</td>
                                      <td>seb</td>
                                      </tr>
                                      <tr>
                                      <td>srsb</td>
                                      <td>bs</td>
                                      </tr>
                                      </table>
									</tr>--%>
									<%--<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA even">
									  <td>FUWANGFOOD</td>
									  <td>672</td>
									  <td>600</td>
									  <td>46.41</td>
									  <td>31,187.52</td>
									  <td>25.30</td>
									  <td>25.30</td>
									  <td>17,001.60</td>
									  <td>-14,187.20</td>
									  <td>16.50</td>
									</tr>
									<tr class="gradeA odd">
									   <td> SIBL</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>31187.52</td>
									  <td>22.48</td>
									  <td>18.90</td>
									  <td>18.90</td>
									  <td>18,900.00</td>
									  <td>-3,578.40</td>
									  <td>11.00</td>
									</tr>
									<tr class="gradeA even">
									  <td> UNITEDAIR</td>
									  <td>2,530</td>
									  <td>2,530</td>
									  <td>18.67</td>
									  <td>47,235.10</td>
									  <td>21.10</td>
									  <td>21.10</td>
									  <td>53,383.00</td>
									  <td>6,138.29</td>
									  <td>0.00</td>
									</tr>
									<tr class="gradeA odd">
										<td>AFTABAUTO</td>
										<td>500</td>
										<td>400	</td>
										<td>101.15</td>
										<td>50,575.00</td>
										<td>85.50</td>
										<td>85.50</td>
										<td>42,750.00</td>
										<td>-7,826.40</td>
										<td>22.04</td>
									</tr>
									<tr class="gradeA even">
									  <td>BANKASIA</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>30.26</td>
									  <td>30,260.00</td>
									  <td>21.40</td>
									  <td>21.40</td>
									  <td>21,400.00</td>
									  <td>-8,855.50</td>
									  <td>52.68</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA even">
									  <td>FUWANGFOOD</td>
									  <td>672</td>
									  <td>600</td>
									  <td>46.41</td>
									  <td>31,187.52</td>
									  <td>25.30</td>
									  <td>25.30</td>
									  <td>17,001.60</td>
									  <td>-14,187.20</td>
									  <td>16.50</td>
									</tr>
									<tr class="gradeA odd">
									   <td> SIBL</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>31187.52</td>
									  <td>22.48</td>
									  <td>18.90</td>
									  <td>18.90</td>
									  <td>18,900.00</td>
									  <td>-3,578.40</td>
									  <td>11.00</td>
									</tr>
									<tr class="gradeA even">
									  <td> UNITEDAIR</td>
									  <td>2,530</td>
									  <td>2,530</td>
									  <td>18.67</td>
									  <td>47,235.10</td>
									  <td>21.10</td>
									  <td>21.10</td>
									  <td>53,383.00</td>
									  <td>6,138.29</td>
									  <td>0.00</td>
									</tr>
									<tr class="gradeA odd">
										<td>AFTABAUTO</td>
										<td>500</td>
										<td>400	</td>
										<td>101.15</td>
										<td>50,575.00</td>
										<td>85.50</td>
										<td>85.50</td>
										<td>42,750.00</td>
										<td>-7,826.40</td>
										<td>22.04</td>
									</tr>
									<tr class="gradeA even">
									  <td>BANKASIA</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>30.26</td>
									  <td>30,260.00</td>
									  <td>21.40</td>
									  <td>21.40</td>
									  <td>21,400.00</td>
									  <td>-8,855.50</td>
									  <td>52.68</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA even">
									  <td>FUWANGFOOD</td>
									  <td>672</td>
									  <td>600</td>
									  <td>46.41</td>
									  <td>31,187.52</td>
									  <td>25.30</td>
									  <td>25.30</td>
									  <td>17,001.60</td>
									  <td>-14,187.20</td>
									  <td>16.50</td>
									</tr>
									<tr class="gradeA odd">
									   <td> SIBL</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>31187.52</td>
									  <td>22.48</td>
									  <td>18.90</td>
									  <td>18.90</td>
									  <td>18,900.00</td>
									  <td>-3,578.40</td>
									  <td>11.00</td>
									</tr>
									<tr class="gradeA even">
									  <td> UNITEDAIR</td>
									  <td>2,530</td>
									  <td>2,530</td>
									  <td>18.67</td>
									  <td>47,235.10</td>
									  <td>21.10</td>
									  <td>21.10</td>
									  <td>53,383.00</td>
									  <td>6,138.29</td>
									  <td>0.00</td>
									</tr>
									<tr class="gradeA odd">
										<td>AFTABAUTO</td>
										<td>500</td>
										<td>400	</td>
										<td>101.15</td>
										<td>50,575.00</td>
										<td>85.50</td>
										<td>85.50</td>
										<td>42,750.00</td>
										<td>-7,826.40</td>
										<td>22.04</td>
									</tr>
									<tr class="gradeA even">
									  <td>BANKASIA</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>30.26</td>
									  <td>30,260.00</td>
									  <td>21.40</td>
									  <td>21.40</td>
									  <td>21,400.00</td>
									  <td>-8,855.50</td>
									  <td>52.68</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA even">
									  <td>FUWANGFOOD</td>
									  <td>672</td>
									  <td>600</td>
									  <td>46.41</td>
									  <td>31,187.52</td>
									  <td>25.30</td>
									  <td>25.30</td>
									  <td>17,001.60</td>
									  <td>-14,187.20</td>
									  <td>16.50</td>
									</tr>
									<tr class="gradeA odd">
									   <td> SIBL</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>31187.52</td>
									  <td>22.48</td>
									  <td>18.90</td>
									  <td>18.90</td>
									  <td>18,900.00</td>
									  <td>-3,578.40</td>
									  <td>11.00</td>
									</tr>
									<tr class="gradeA even">
									  <td> UNITEDAIR</td>
									  <td>2,530</td>
									  <td>2,530</td>
									  <td>18.67</td>
									  <td>47,235.10</td>
									  <td>21.10</td>
									  <td>21.10</td>
									  <td>53,383.00</td>
									  <td>6,138.29</td>
									  <td>0.00</td>
									</tr>
									<tr class="gradeA odd">
										<td>AFTABAUTO</td>
										<td>500</td>
										<td>400	</td>
										<td>101.15</td>
										<td>50,575.00</td>
										<td>85.50</td>
										<td>85.50</td>
										<td>42,750.00</td>
										<td>-7,826.40</td>
										<td>22.04</td>
									</tr>
									<tr class="gradeA even">
									  <td>BANKASIA</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>30.26</td>
									  <td>30,260.00</td>
									  <td>21.40</td>
									  <td>21.40</td>
									  <td>21,400.00</td>
									  <td>-8,855.50</td>
									  <td>52.68</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA even">
									  <td>FUWANGFOOD</td>
									  <td>672</td>
									  <td>600</td>
									  <td>46.41</td>
									  <td>31,187.52</td>
									  <td>25.30</td>
									  <td>25.30</td>
									  <td>17,001.60</td>
									  <td>-14,187.20</td>
									  <td>16.50</td>
									</tr>
									<tr class="gradeA odd">
									   <td> SIBL</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>31187.52</td>
									  <td>22.48</td>
									  <td>18.90</td>
									  <td>18.90</td>
									  <td>18,900.00</td>
									  <td>-3,578.40</td>
									  <td>11.00</td>
									</tr>
									<tr class="gradeA even">
									  <td> UNITEDAIR</td>
									  <td>2,530</td>
									  <td>2,530</td>
									  <td>18.67</td>
									  <td>47,235.10</td>
									  <td>21.10</td>
									  <td>21.10</td>
									  <td>53,383.00</td>
									  <td>6,138.29</td>
									  <td>0.00</td>
									</tr>
									<tr class="gradeA odd">
										<td>AFTABAUTO</td>
										<td>500</td>
										<td>400	</td>
										<td>101.15</td>
										<td>50,575.00</td>
										<td>85.50</td>
										<td>85.50</td>
										<td>42,750.00</td>
										<td>-7,826.40</td>
										<td>22.04</td>
									</tr>
									<tr class="gradeA even">
									  <td>BANKASIA</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>30.26</td>
									  <td>30,260.00</td>
									  <td>21.40</td>
									  <td>21.40</td>
									  <td>21,400.00</td>
									  <td>-8,855.50</td>
									  <td>52.68</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA even">
									  <td>FUWANGFOOD</td>
									  <td>672</td>
									  <td>600</td>
									  <td>46.41</td>
									  <td>31,187.52</td>
									  <td>25.30</td>
									  <td>25.30</td>
									  <td>17,001.60</td>
									  <td>-14,187.20</td>
									  <td>16.50</td>
									</tr>
									<tr class="gradeA odd">
									   <td> SIBL</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>31187.52</td>
									  <td>22.48</td>
									  <td>18.90</td>
									  <td>18.90</td>
									  <td>18,900.00</td>
									  <td>-3,578.40</td>
									  <td>11.00</td>
									</tr>
									<tr class="gradeA even">
									  <td> UNITEDAIR</td>
									  <td>2,530</td>
									  <td>2,530</td>
									  <td>18.67</td>
									  <td>47,235.10</td>
									  <td>21.10</td>
									  <td>21.10</td>
									  <td>53,383.00</td>
									  <td>6,138.29</td>
									  <td>0.00</td>
									</tr>
									<tr class="gradeA odd">
										<td>AFTABAUTO</td>
										<td>500</td>
										<td>400	</td>
										<td>101.15</td>
										<td>50,575.00</td>
										<td>85.50</td>
										<td>85.50</td>
										<td>42,750.00</td>
										<td>-7,826.40</td>
										<td>22.04</td>
									</tr>
									<tr class="gradeA even">
									  <td>BANKASIA</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>30.26</td>
									  <td>30,260.00</td>
									  <td>21.40</td>
									  <td>21.40</td>
									  <td>21,400.00</td>
									  <td>-8,855.50</td>
									  <td>52.68</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA even">
									  <td>FUWANGFOOD</td>
									  <td>672</td>
									  <td>600</td>
									  <td>46.41</td>
									  <td>31,187.52</td>
									  <td>25.30</td>
									  <td>25.30</td>
									  <td>17,001.60</td>
									  <td>-14,187.20</td>
									  <td>16.50</td>
									</tr>
									<tr class="gradeA odd">
									   <td> SIBL</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>31187.52</td>
									  <td>22.48</td>
									  <td>18.90</td>
									  <td>18.90</td>
									  <td>18,900.00</td>
									  <td>-3,578.40</td>
									  <td>11.00</td>
									</tr>
									<tr class="gradeA even">
									  <td> UNITEDAIR</td>
									  <td>2,530</td>
									  <td>2,530</td>
									  <td>18.67</td>
									  <td>47,235.10</td>
									  <td>21.10</td>
									  <td>21.10</td>
									  <td>53,383.00</td>
									  <td>6,138.29</td>
									  <td>0.00</td>
									</tr>
									<tr class="gradeA odd">
										<td>AFTABAUTO</td>
										<td>500</td>
										<td>400	</td>
										<td>101.15</td>
										<td>50,575.00</td>
										<td>85.50</td>
										<td>85.50</td>
										<td>42,750.00</td>
										<td>-7,826.40</td>
										<td>22.04</td>
									</tr>
									<tr class="gradeA even">
									  <td>BANKASIA</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>30.26</td>
									  <td>30,260.00</td>
									  <td>21.40</td>
									  <td>21.40</td>
									  <td>21,400.00</td>
									  <td>-8,855.50</td>
									  <td>52.68</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA odd">
									  <td>BXPHARMA</td>
									  <td>484</td>
									  <td>484	</td>
									  <td>78.79</td>
									  <td>38,134.36</td>
									  <td>50.70</td>
									  <td>50.70</td>
									  <td>24,538.80</td>
									  <td>-13,594.11</td>
									  <td>17.62</td>
									</tr>
									<tr class="gradeA even">
									  <td>FUWANGFOOD</td>
									  <td>672</td>
									  <td>600</td>
									  <td>46.41</td>
									  <td>31,187.52</td>
									  <td>25.30</td>
									  <td>25.30</td>
									  <td>17,001.60</td>
									  <td>-14,187.20</td>
									  <td>16.50</td>
									</tr>
									<tr class="gradeA odd">
									   <td> SIBL</td>
									  <td>1,000</td>
									  <td>1,000</td>
									  <td>31187.52</td>
									  <td>22.48</td>
									  <td>18.90</td>
									  <td>18.90</td>
									  <td>18,900.00</td>
									  <td>-3,578.40</td>
									  <td>11.00</td>
									</tr>
									<tr class="gradeA even">
									  <td> UNITEDAIR</td>
									  <td>2,530</td>
									  <td>2,530</td>
									  <td>18.67</td>
									  <td>47,235.10</td>
									  <td>21.10</td>
									  <td>21.10</td>
									  <td>53,383.00</td>
									  <td>6,138.29</td>
									  <td>0.00</td>
									</tr>--%>
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
                            <input type="submit" class="btn appBtn btn-primary fwBtn" value="Apply" id="btnApply" data-toggle="modal" data-target="#myModal2" />
                            <input type="submit" class="btn appBtn btn-primary fwBtn2" value="Apply" id="btnApply" />
                   </div>
                     <%-- <table style="float: right;"  class="FinalCalculation">
                            <tr>
                            <td>Total Debit</td>
                            
                            <td text-align:"right"><asp:Label ID="lblDebit" runat="server" Text=""></asp:Label></td>
                            </tr>
                             <tr>
                            <td>Total Credit</td>
                            
                            <td><asp:Label ID="lblCredit" runat="server" Text=""></asp:Label></td>
                            </tr>
                             <tr>
                            <td>Closing Balance</td>
                            
                            <td><asp:Label ID="lblBalance" runat="server" Text=""></asp:Label></td>
                            </tr>
                            </table>--%>
                            
                            
                            

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


	        $('#rangeBa, #rangeBb').daterangepicker();

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

           var oTable = $('#DataTables_Table_1').dataTable({
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

   

        <%--<script>


            $(function () {


                var oTable = $('#DataTables_Table_1').dataTable({
                    "bJQueryUI": false,
                    "bAutoWidth": false,
                    "sPaginationType": "full_numbers",
                    "sDom": '<"H"fl>t<"F"ip>',
                    
                    "aLengthMenu": [15, 30, 50, 100],
                    "iDisplayLength": 15

                });



                /* Apply the jEditable handlers to the table */
                //                oTable.$('td').editable('../examples_support/editable_ajax.php', {
                //                    "callback": function (sValue, y) {
                //                        var aPos = oTable.fnGetPosition(this);
                //                        oTable.fnUpdate(sValue, aPos[0], aPos[1]);
                //                    },
                //                    "submitdata": function (value, settings) {
                //                        return {
                //                            "row_id": this.parentNode.getAttribute('id'),
                //                            "column": oTable.fnGetPosition(this)[2]
                //                        };
                //                    },
                //                    "height": "14px",
                //                    "width": "100%"
                //                });



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
            
            
        </script>--%>

       

           
         <%--<script type="text/javascript">	
			$(function(){
				 $('input').daterangepicker({dateFormat: 'M d, yy'}); 
			 
		</script>--%>
</asp:Content>
