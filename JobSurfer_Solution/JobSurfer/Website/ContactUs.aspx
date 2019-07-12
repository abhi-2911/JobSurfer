<%@ Page Title="JobSurfer.in | Contact Us" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="JobSurfer.Website.ContactUs" %>

<%@ Register Src="~/W_WebFormControl/WFC_ContactUs.ascx" TagPrefix="uc1" TagName="WFC_ContactUs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_ContactUs runat="server" id="WFC_ContactUs" />
</asp:Content>
