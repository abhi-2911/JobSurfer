<%@ Page Title="JobSurfer.in | User Registration" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" AutoEventWireup="true" CodeBehind="U_RegisterPage.aspx.cs" Inherits="JobSurfer.User.U_RegisterPage" %>

<%@ Register Src="~/U_WebFormControl/WFC_U_RegisterPage.ascx" TagPrefix="uc1" TagName="WFC_U_RegisterPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_U_RegisterPage runat="server" id="WFC_U_RegisterPage" />
</asp:Content>
