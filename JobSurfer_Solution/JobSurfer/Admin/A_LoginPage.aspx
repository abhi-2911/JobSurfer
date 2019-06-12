<%@ Page Title="JobSurfer.in | Admin Login" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" AutoEventWireup="true" CodeBehind="A_LoginPage.aspx.cs" Inherits="JobSurfer.Admin.A_LoginPage" %>

<%@ Register Src="~/A_WebFormControl/WFC_A_LoginPage.ascx" TagPrefix="uc1" TagName="WFC_A_LoginPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_A_LoginPage runat="server" id="WFC_A_LoginPage" />
</asp:Content>
