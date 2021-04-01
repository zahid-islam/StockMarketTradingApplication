<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovedOriginal.aspx.cs" Inherits="iTradex.UI.ApprovedOriginal" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Approved Page</title>
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=1.0">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <style>
        .backButtonDasboard {
            background-color: lawngreen;
            border: none;
            height: 40px;
        }

        .headStyleDash {
            text-align: center;
            color: darkgreen;
        }

        li {
            display: block;
            text-align: center;
            margin: 5px;
        }
    </style>
</head>

<body>
    <h2 class="headStyleDash">Payment successful</h2>
    <form runat="server" id="form1">
        <ul style="list-style-type: none;">
            <li>
                <asp:Label ID="lblTtransactionType" runat="server" Text="Transaction Type"></asp:Label>
            </li>
            <li>
                <asp:Label ID="lblPurchaseAmount" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:Label ID="lblCurrency" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:Label ID="lblResponseCode" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:Label ID="lblOrderStatus" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:Label ID="lblApprovalCode" runat="server" Text=""></asp:Label>
            </li>
        </ul>

        <div style="text-align: center;">
            <button type="button" class="backButtonDasboard" runat="server" id="btnBackToDashboardFromAppr" onserverclick="btnBacktoDashboard_Click">
            Go Back to Dashboard</button>
        </div>

    </form>
    <hr />
</body>
</html>
