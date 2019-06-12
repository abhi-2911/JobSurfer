<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_LoginPage.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_LoginPage" %>

<link href="../A_CSS/CSS_WFC_A_LoginPage.css" rel="stylesheet" />

<div id="divA_3">
    <img id="imgA_3" src="../A_Images/job_15.jpg" />
    <p class="pA_3">Admin Login </p>

    <div id="divB_3">
        <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Username"></asp:Label>
        <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Enter Username" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


        <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="Password"></asp:Label>
        <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Enter Password" ControlToValidate="textboxB1_3" ForeColor="Red">*</asp:RequiredFieldValidator>

        <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Login" OnClick="buttonA1_3_Click" />

        <asp:ValidationSummary CssClass="vsumA_3" ID="vsumA1_3" runat="server" HeaderText="Resolve following Error(s) : " ShowMessageBox="True" ShowSummary="False" />

    </div>
</div>
