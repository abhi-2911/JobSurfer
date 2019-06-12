<%@ Page Title="" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" AutoEventWireup="true" CodeBehind="E_RegisterPage.aspx.cs" Inherits="JobSurfer.Employer.E_RegisterPage" %>

<%@ Register Src="~/E_WebFormControl/WFC_E_RegisterPage.ascx" TagPrefix="uc1" TagName="WFC_E_RegisterPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_E_RegisterPage runat="server" id="WFC_E_RegisterPage" />
</asp:Content>
