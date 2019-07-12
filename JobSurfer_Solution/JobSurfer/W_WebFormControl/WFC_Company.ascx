<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_Company.ascx.cs" 
    Inherits="JobSurfer.W_WebFormControl.WFC_Company" %>

<link href="../W_CSS/CSS_WFC_Company.css" rel="stylesheet" />

<div id="divA_3">
    <asp:Image CssClass="ImgA_3" ID="ImgA1_3" runat="server" ImageUrl="~/W_Images/com_1.JPG" />
    <asp:Image CssClass="ImgB_3" ID="ImgB1_3" runat="server" ImageUrl="~/W_Images/com_2.JPG" Visible="False" />
    <asp:Image CssClass="ImgC_3" ID="ImgC1_3" runat="server" ImageUrl="~/W_Images/com_3.JPG" Visible="False" />

    <asp:Button CssClass="ButA_3" ID="ButA1_3" runat="server" Text=">" OnClick="ButA1_3_Click" />
    <asp:Button CssClass="ButB_3" ID="ButB1_3" runat="server" Text="<" OnClick="ButB1_3_Click" Visible="False"  />
</div>
