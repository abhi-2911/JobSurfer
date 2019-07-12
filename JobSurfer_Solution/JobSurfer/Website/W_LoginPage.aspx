<%@ Page Title="JobSurfer.in | Login As" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" AutoEventWireup="true" CodeBehind="W_LoginPage.aspx.cs" Inherits="JobSurfer.Website.W_LoginPage" %>

<%@ Register Src="~/W_WebFormControl/WFC_W_LoginPage.ascx" TagPrefix="uc1" TagName="WFC_W_LoginPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_W_LoginPage runat="server" ID="WFC_W_LoginPage" />
</asp:Content>
