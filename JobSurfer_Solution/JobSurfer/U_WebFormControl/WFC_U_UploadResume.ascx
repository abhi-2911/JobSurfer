<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_UploadResume.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_UploadResume" %>


<link href="../U_CSS/CSS_WFC_U_UploadResume.css" rel="stylesheet" />


<div id="divA1_3">
    
    <asp:Image CssClass="imageA_3" ID="imageA1_3" runat="server" ImageUrl="~/U_Images/ico_pdf_logo.png" /> <!--pdf logo-->

    <asp:FileUpload CssClass="fileuploadA_3" ID="fileuploadA1_3" runat="server" ToolTip="only .pdf file of less than 3MB allowed" />
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Resume Required" ControlToValidate="fileuploadA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Save" OnClick="buttonA1_3_Click" />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Update" OnClick="buttonB1_3_Click" />


    <asp:ValidationSummary CssClass="vsA_3" ID="vsA1_3" runat="server" HeaderText="Resolve the following Errors :" ShowMessageBox="True" ShowSummary="False"  />

</div>