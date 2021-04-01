<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUpcomingIPOs.ascx.cs" Inherits="KaziEquitiesWebSite.userControl.ucUpcomingIPOs" %>
<li name="ucUpcomingIPOs" class="drugable component clo_1 ucResearchReports">
    <div class="holder">
        <style type="text/css">
            .IOPsTitle
            {
                font-weight:bold;
                text-align:center;
                text-decoration:none;
                color:#1076C0;
                
            }
            .IOPDate
            {
                margin-left:5px;
            }
            .align-center
            {
                text-align:center;
            }
            #marIPO
            {
                padding-left:5px;
            }
             #marIPO a
            {
                text-decoration:none;
            }
        </style>
        <center>
         <marquee id="marIPO" style="width:75%; height:165px;" bgcolor="#ffffee" truespeed="" scrolldelay="30" scrollamount="1" onmouseover="this.stop();" onmouseout="this.start();" direction="up" behavior="scroll" align="top">
         <%
             if (DSEParser.DSESite.UpcomingIPOs.Count > 0)
             {
                 foreach (DSEParser.UpComingIPO oUpComingIPO in DSEParser.DSESite.UpcomingIPOs)
                 {
                   %>
                   <p> 
                   <a href="<%=oUpComingIPO.FileLink%>">
                    <span class="IOPsTitle" > <%=oUpComingIPO.InstrumentName%></span>
                   </a>
                  <br />
                   <span class="IOPDate" >Open Date:  <%=oUpComingIPO.OpenDate.ToString("dd/MM/yyyy")%></span><br /><span class="IOPDate" >Close Date:  <%=oUpComingIPO.CloseDate.ToString("dd/MM/yyyy")%></span>
                    <hr color="99ccff" size="1" noshade="">
                   <br />
                   </p>
                   <%
                }
             }
             else
             {
                  %>
                   <p> 
                  
                    <span class="IOPsTitle" > No upcoming IPO</span>                   
                  </p>
                   <%
             }
              %>
        
         </marquee>
        </center>
        <br class="clearfloat" />
    </div>
</li>