<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintRDLC.aspx.cs" Inherits="Lab02_ASP.PrintRDLC" %>
<<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
              <rsweb:ReportViewer ID="rptReportViewer" runat="server" Width="100%" Height="600px"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
