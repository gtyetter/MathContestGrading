<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MCG.aspx.cs" Inherits="MathContestGrading.MCG" %>

<!DOCTYPE html>
<style>
body {
    background-color: #5D6D7E;
    display: table-cell;
    vertical-align: middle;
}
html {
    display: table;
    margin: auto;
}
ul {
    list-style: none;

}
.Input {
    text-align: center;
}
.Instructions {
    text-align: center;
}


</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Math Contest Grading</title>
</head>

<body>
    <div class="logo">
        <img src="Image/Banner.png" style="height: 104px; width: 510px"/>
    </div>
    <div class="Instructions">
        <p>
            Select file paths and save to continue:
        </p>
    </div>
    <form id="form1" runat="server">
        <div class="Input">
            <ul>
                <li>
                    <asp:FileUpload ID="SeniorFileUpload" runat="server" />
                    <asp:Button ID="SaveSeniorFileBtn" runat="server" Text="Save" OnClick="SaveSeniorFileBtn_Click" />
                </li>

                <li>
                    <asp:FileUpload ID="JuniorFileUpload" runat="server" BackColor="White" />
                    <asp:Button ID="SaveJuniorFileBtn" runat="server" Text="Save" OnClick="SaveJuniorFileBtn_Click" BackColor="Black" BorderColor="White" ForeColor="White" />
                </li>

                <li>
                    <asp:FileUpload ID="SchoolFileUpload" runat="server" BackColor="White" BorderColor="White" ForeColor="Black" />
                    <asp:Button ID="SaveSchoolFileBtn" runat="server" Text="Save" OnClick="SaveSchoolFileBtn_Click" BackColor="Black" BorderColor="White" ForeColor="White" />
                </li>
            </ul>
        </div>

        <div class="Download">

        </div>
    </form>
</body>
</html>
