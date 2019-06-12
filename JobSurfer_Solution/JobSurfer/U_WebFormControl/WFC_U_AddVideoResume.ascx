<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_AddVideoResume.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_AddVideoResume" %>

<link href="../U_CSS/CSS_WFC_U_AddVideoResume.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:Image CssClass="imageA_3" ID="imageA1_3" runat="server" ImageUrl="~/U_Images/ico_youtube_logo.png" /> <!--youtube logo-->

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Link"></asp:Label> <!--Link Label-->
    <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" MaxLength="50" TextMode="Url" ToolTip="Enter Youtube Video Link"></asp:TextBox> <!--Textbox for link-->
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Enter Youtube Video Link" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Save" OnClick="buttonA1_3_Click" />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Update" OnClick="buttonB1_3_Click" />

    <asp:ValidationSummary CssClass="vsumA_3" ID="vsumA1_3" runat="server" HeaderText="Please resolve the following  :" ShowMessageBox="True" ShowSummary="False" />

</div>
