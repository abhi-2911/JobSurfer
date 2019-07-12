<%@ Page Title="JobSurfer.in | About Us" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="JobSurfer.Website.AboutUs" %>

<%@ Register Src="~/W_WebFormControl/WFC_AboutUs.ascx" TagPrefix="uc1" TagName="WFC_AboutUs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_AboutUs runat="server" id="WFC_AboutUs" />
</asp:Content>
