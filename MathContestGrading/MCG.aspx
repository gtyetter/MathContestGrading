<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MCG.aspx.cs" Inherits="MathContestGrading.MCG" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Math Contest Grading</title>
</head>

<body>
    <div class="logo">

    </div>
    <form id="form1" runat="server">
        <div class="Input">
            <ul>
                <li>
                    <asp:FileUpload ID="SeniorFileUpload" runat="server" />
                    <asp:Button ID="SaveSenoirFileBtn" runat="server" Text="Save" OnClick="SaveSenoirFileBtn_Click" />
                </li>

                <li>
                    <asp:FileUpload ID="JuniorFileUpload" runat="server" />
                    <asp:Button ID="SaveJuniorFileBtn" runat="server" Text="Save" OnClick="SaveJuniorFileBtn_Click" />
                </li>

                <li>
                    <asp:FileUpload ID="SchoolFileUpload" runat="server" />
                    <asp:Button ID="SaveSchoolFileBtn" runat="server" Text="Save" OnClick="SaveSchoolFileBtn_Click" />
                </li>
            </ul>
        </div>

        <div class="Download">

        </div>
    </form>
</body>
</html>
