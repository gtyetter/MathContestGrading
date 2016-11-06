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
    color: white;
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
                    <asp:FileUpload ID="SeniorFileUpload" runat="server" BackColor="White" />
                </li>

                <li>
                    <asp:FileUpload ID="JuniorFileUpload" runat="server" />
                </li>

                <li>
                    <asp:FileUpload ID="SchoolFileUpload" runat="server" />
                </li>

                <li>
                    <asp:Button ID="SaveSchoolFileBtn" runat="server" Text="Save" OnClick="SaveFileBtn_Click" Width="217px" />
                </li>
            </ul>
        </div>

        <div class="Download">

        </div>
    </form>
</body>
</html>
