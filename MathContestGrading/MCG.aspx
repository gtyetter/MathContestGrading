<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MCG.aspx.cs" Inherits="MathContestGrading.MCG" %>

<!DOCTYPE html>
<style>
    html {
        display: table;
        margin: auto;
    }

body {
        background-color: #145314;
    display: table-cell;
    vertical-align: middle;
}

    .Container{
        border-style: solid;
        border-color: white;
        border-width: thick;    
        border-radius: 25px;
}

    .Logo img {
}

    .Instructions {
    text-align: center;
}

    .Input {
        background-color: #145314;
        border-style: solid;
        border-color: white;
        border-width: thick;
        border-radius: 25px;
        padding: 20px;
    }

    .Input {
    text-align: center;
    color: white;
}

    ul {
        list-style: none;
    }

    .DownLoad {
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Math Contest Grading</title>
</head>

<body>
    <div class="Container">
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
                    <asp:FileUpload ID="SeniorFileUpload" runat="server" BackColor="White" />
                </li>

                <li>
                    <asp:FileUpload ID="JuniorFileUpload" runat="server" />
                </li>

                <li>
                    <asp:FileUpload ID="SchoolFileUpload" runat="server" />
                </li>
            </ul>
        </div>

            <div class="Upload">
                <asp:Button ID="UploadFileBtn" runat="server" Text="Save" OnClick="SaveFileBtn_Click" />
            </div>

            <div class="Progress">

            </div>

        <div class="Download">
                <asp:Button ID="DownloadFilesBtn" runat="server" Text="Download" OnClick="DownloadFilesBtn_Click" />
            </div>

        </form>
        </div>
</body>
</html>
