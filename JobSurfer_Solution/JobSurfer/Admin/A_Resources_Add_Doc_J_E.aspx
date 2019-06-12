<%@ Page Title="Add Document Resources | Administrator | Jobsurfer.com" Language="C#" MasterPageFile="~/A_MasterPage/Master_Site_4.Master" 
    AutoEventWireup="true" CodeBehind="A_Resources_Add_Doc_J_E.aspx.cs" Inherits="JobSurfer.Admin.A_Resources_Add_Doc_J_E" %>

<%@ Register Src="~/A_WebFormControl/WFC_A_Resources_Add_Doc_J_E.ascx" TagPrefix="uc1" TagName="WFC_A_Resources_Add_Doc_J_E" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_A_Resources_Add_Doc_J_E runat="server" id="WFC_A_Resources_Add_Doc_J_E" />
</asp:Content>
