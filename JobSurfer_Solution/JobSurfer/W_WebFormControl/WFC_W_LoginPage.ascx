<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_W_LoginPage.ascx.cs"
    Inherits="JobSurfer.W_WebFormControl.WFC_W_LoginPage" %>

<link href="../W_CSS/CSS_WFC_W_LoginPage.css" rel="stylesheet" />

<div id="divA_3">
    <img id="imgA_3" src="../W_Images/Login.jpg" />
    <p class="pA_3">Login As </p>

    <div id="divB_3">
        <asp:Button CssClass="ButA_3" ID="ButA1_3" runat="server" Text="JobSeeker" OnClick="ButA1_3_Click" />
        <asp:Button CssClass="ButB_3" ID="ButB1_3" runat="server" Text="Employer" OnClick="ButB1_3_Click" />
        <asp:Button CssClass="ButC_3" ID="ButC1_3" runat="server" Text="Admin" OnClick="ButC1_3_Click" />
    </div>
</div>
