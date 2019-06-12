<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_ChangeProfilePic.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_ChangeProfilePic" %>

<link href="../U_CSS/CSS_WFC_U_ChangeProfilePic.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:Image CssClass="imageA_3" ID="imageA1_3" runat="server" /> <!--profile pic-->

    <asp:FileUpload CssClass="fileuploadA_3" ID="fileuploadA1_3" runat="server" ToolTip="only .jpg or .png file of less than 4MB allowed" />
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Upload Profile Picture" ControlToValidate="fileuploadA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Upload" OnClick="buttonA1_3_Click" />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Profile" CausesValidation="False" PostBackUrl="~/User/U_ProfilePage.aspx" />


    <asp:ValidationSummary CssClass="vsA_3" ID="vsA1_3" runat="server" HeaderText="Resolve the following Errors :" ShowMessageBox="True" ShowSummary="False"  />

</div>