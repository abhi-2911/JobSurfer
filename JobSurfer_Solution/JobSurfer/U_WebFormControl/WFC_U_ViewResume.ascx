<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_ViewResume.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_ViewResume" %>


<link href="../U_CSS/CSS_WFC_U_ViewResume.css" rel="stylesheet" />


<div id="divA1_3">

    <asp:Image CssClass="imageA_3" ID="imageA1_3" runat="server" ImageUrl="~/U_Images/ico_pdf_logo.png" /> <!--pdf logo-->

    <asp:LinkButton CssClass="linkbuttonA_3" ID="linkbuttonA1_3" runat="server" OnClick="linkbuttonA1_3_Click">Click To View</asp:LinkButton>

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Upload Resume" PostBackUrl="~/User/U_UploadResume.aspx" />
</div>
