<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MCG.aspx.cs" Inherits="MathContestGrading.MCG" %>

<!DOCTYPE html>
<style>
html {
    display: table;
    margin: auto;
}

body {
    background-color: #0F2E22;
    display: table-cell;
    vertical-align: middle;
}

.Container{
    margin-top: 20px;
    background-color: #1D664B;
    border-style: solid;
    border-color: white;
    border-width: thick;    
    border-radius: 25px;
    padding: 20px;
}

img.Logo {
    display: block;
    margin-left: auto;
    margin-right: auto;
    border: 2px solid white;
    border-width: thick;  
    height: 180px;
    width: 579px;
    }

.Instructions {
    color: white;
    text-align: center;
}

.Input {
    background-color: #699082;
    border-style: solid;
    border-color: white;
    border-width: thick;
    border-radius: 25px;
    padding: 20px;
    text-align: center;
    color: white;
}

ul li {
    list-style: none;
    margin-bottom:10px;
}
.container {
    width: 800px;
    margin: auto;
    padding: 20px;
}
.Upload {
    width: 100px;
    float: left;
}
.Progress {
    width: 800px;
    height: 40px;
    color: black;
    display: block;
    margin-left: auto;
    margin-right: auto; 
}
.Download {
    margin-right: 100px;
    width: 100px;
    float: right;
}

</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Math Contest Grading</title>
</head>

<body>
    <div class="Container">
        <img class ="Logo" src="Image/Banner2.png" />

        <div class="Instructions">
            <p>
                Select file paths and upload. Once upload is complete download the results.
            </p>
        </div>

        <form id="form1" runat="server">
            <div class="Input">
                <ul>
                    <li>
                        Upload Junior Files Here:&nbsp; 
                        <asp:FileUpload ID="JuniorFileUpload" runat="server"/>
                    </li>

                    <li>
                        Upload Senior Files Here:&nbsp;
                        <asp:FileUpload ID="SeniorFileUpload" runat="server"/>
                    </li>

                    <li>
                        Upload School Files Here:
                        <asp:FileUpload ID="SchoolFileUpload" runat="server"/>
                    </li>
                </ul>
            </div>

            <div class="container">
                <div class="Upload">
                    <asp:Button ID="UploadFileBtn" Width="200px" runat="server" Text="Upload" OnClick="SaveFileBtn_Click" />
                </div>
                <div class="Download">
                    <asp:Button ID="DownloadFilesBtn" Width="200px" runat="server" Text="Download" OnClick="DownloadFilesBtn_Click" />
                </div>
            </div>

            <div class="Progress">
            </div>

        </form>
    </div>
</body>
</html>
