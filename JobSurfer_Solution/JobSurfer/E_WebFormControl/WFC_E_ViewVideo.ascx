<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_E_ViewVideo.ascx.cs" 
    Inherits="JobSurfer.E_WebFormControl.WFC_E_ViewVideo" %>

<link href="../E_CSS/CSS_WFC_E_ViewVideo.css" rel="stylesheet" />


<div id="divA1_3">

    <asp:Image CssClass="imageA_3" ID="imageA1_3" runat="server" ImageUrl="~/E_Images/ico_youtube_logo.png" /> <!--youtube logo-->

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Click To View" />

    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Add Video"  PostBackUrl="~/Employer/E_AddVideo.aspx" />

</div>