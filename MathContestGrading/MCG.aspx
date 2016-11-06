<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MCG.aspx.cs" Inherits="MathContestGrading.MCG" %>

<!DOCTYPE html>
<style>

    html {
        display: table;
        margin: auto;
    }

    body {
        background-color: white;
        display: table-cell;
        vertical-align: middle;
    }

    .Logo img{
        width: 1em;
    }

    .Instructions {
        text-align: center;
    }

    form{
        background-color: #145314;
        border-radius: 25px;
        padding: 20px;
        width: auto;
    }

    .Input {
        text-align: center;
    }

    ul {
        list-style: none;
    }

    .DownLoad{

    }

</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Math Contest Grading</title>
</head>

<body>
    
    <div class="Logo">
        <img src="Image/Banner.png" />
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
                </li>

                <li>
                    <asp:FileUpload ID="JuniorFileUpload" runat="server" />
                </li>

                <li>
                    <asp:FileUpload ID="SchoolFileUpload" runat="server" />
                </li>

                <li>
                    <asp:Button ID="UploadFileBtn" runat="server" Text="Save" OnClick="SaveFileBtn_Click" />
                </li>
            </ul>
        </div>

        <div class="Download">
            <asp:Button ID="DownloadFilesBtn" runat="server" Text="Download" OnClick="DownloadFilesBtn_Click" />
        </div>

    </form>
</body>
</html>
