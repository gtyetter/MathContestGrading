<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MCG.aspx.cs" Inherits="MathContestGrading.MCG" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Math Contest Grading</title>
</head>

<body>
    <form id="form1" runat="server">
    <div class="Input">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click"/>
    </div>
    <div class="validate"></div>
    <div class="grade"></div>
    <div class="output"></div>
    </form>
</body>
</html>
