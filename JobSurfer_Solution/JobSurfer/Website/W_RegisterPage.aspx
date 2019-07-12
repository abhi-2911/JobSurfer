<%@ Page Title="JobSurfer.in | Register As" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" 
    AutoEventWireup="true" CodeBehind="W_RegisterPage.aspx.cs" Inherits="JobSurfer.Website.W_RegisterPage" %>

<%@ Register Src="~/W_WebFormControl/WFC_W_RegisterPage.ascx" TagPrefix="uc1" TagName="WFC_W_RegisterPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_W_RegisterPage runat="server" id="WFC_W_RegisterPage" />
</asp:Content>
