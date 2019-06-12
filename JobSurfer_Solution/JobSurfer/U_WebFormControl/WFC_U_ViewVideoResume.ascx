<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_ViewVideoResume.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_ViewVideoResume" %>


<link href="../U_CSS/CSS_WFC_U_ViewVideoResume.css" rel="stylesheet" />


<div id="divA1_3">

    <asp:Image CssClass="imageA_3" ID="imageA1_3" runat="server" ImageUrl="~/U_Images/ico_youtube_logo.png" /> <!--youtube logo-->

    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Click To View" />

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Add Video Resume" PostBackUrl="~/User/U_AddVideoResume.aspx" />

</div>