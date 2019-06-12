<%@ Page Title="Admin Panel | Administrator | Jobsurfer.com" Language="C#" MasterPageFile="~/A_MasterPage/Master_Site_4.Master" 
    AutoEventWireup="true" CodeBehind="A_FrontPage.aspx.cs" Inherits="JobSurfer.Admin.A_FrontPage" %>

<%@ Register Src="~/A_WebFormControl/WFC_A_FrontPage.ascx" TagPrefix="uc1" TagName="WFC_A_FrontPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_A_FrontPage runat="server" id="WFC_A_FrontPage" />
</asp:Content>
