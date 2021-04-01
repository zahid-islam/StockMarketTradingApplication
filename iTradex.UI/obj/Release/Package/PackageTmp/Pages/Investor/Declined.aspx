<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Declined.aspx.cs" Inherits="iTradex.UI.Pages.Investor.Declined" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Declined Page</title>
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=1.0">
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet"/>
    <style>
        .backButton{
            background-color: lawngreen;
            border: none;
            height: 40px
        }
        .headStyle{
            color: blueviolet;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="headStyle">
            Payment is not successful, Please check credential.
        </h1>
        <div style="margin: 5%; text-align: center;">
            <button runat="server" id="btnBackToDashboard" onserverclick="btnDepositProceed_Click" class="backButton">
                Go Back to Dashboard</button>
        </div>
    </form>
</body>
</html>
