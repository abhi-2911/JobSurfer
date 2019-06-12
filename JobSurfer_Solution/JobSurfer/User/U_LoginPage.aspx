<%@ Page Title="JobSurfer.in | JobSeeker Login" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master"
    AutoEventWireup="true" CodeBehind="U_LoginPage.aspx.cs" Inherits="JobSurfer.User.U_LoginPage" %>

<%@ Register Src="~/U_WebFormControl/WFC_U_LoginPage.ascx" TagPrefix="uc1" TagName="WFC_U_LoginPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_U_LoginPage runat="server" id="WFC_U_LoginPage" />
</asp:Content>
