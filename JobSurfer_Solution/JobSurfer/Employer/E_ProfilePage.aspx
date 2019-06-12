<%@ Page Title="ProfilePage | Employer | Jobsurfer.com" Language="C#" MasterPageFile="~/E_MasterPage/Master_Site_3.Master" 
    AutoEventWireup="true" CodeBehind="E_ProfilePage.aspx.cs" Inherits="JobSurfer.Employer.E_ProfilePage" %>

<%@ Register Src="~/E_WebFormControl/WFC_E_ProfilePage.ascx" TagPrefix="uc1" TagName="WFC_E_ProfilePage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_E_ProfilePage runat="server" id="WFC_E_ProfilePage" />
</asp:Content>
