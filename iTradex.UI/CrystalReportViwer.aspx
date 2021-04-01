﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrystalReportViwer.aspx.cs" Inherits="iTradex.UI.CrystalReportViwer" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html ">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" 
            AutoDataBind="true" />
    
    </div>
    </form>
</body>
</html>
