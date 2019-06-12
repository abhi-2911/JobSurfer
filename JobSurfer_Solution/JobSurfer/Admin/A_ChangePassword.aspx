<%@ Page Title="Change Password | Administrator | Jobsurfer.com" Language="C#" MasterPageFile="~/A_MasterPage/Master_Site_4.Master" 
    AutoEventWireup="true" CodeBehind="A_ChangePassword.aspx.cs" Inherits="JobSurfer.Admin.A_ChangePassword" %>

<%@ Register Src="~/A_WebFormControl/WFC_A_ChangePassword.ascx" TagPrefix="uc1" TagName="WFC_A_ChangePassword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_A_ChangePassword runat="server" id="WFC_A_ChangePassword" />
</asp:Content>
