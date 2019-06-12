<%@ Page Title="JobSurfer.in | Employer Login" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" AutoEventWireup="true" CodeBehind="E_LoginPage.aspx.cs" Inherits="JobSurfer.Employer.E_LoginPage" %>

<%@ Register Src="~/E_WebFormControl/WFC_E_LoginPage.ascx" TagPrefix="uc1" TagName="WFC_E_LoginPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_E_LoginPage runat="server" id="WFC_E_LoginPage" />
</asp:Content>
