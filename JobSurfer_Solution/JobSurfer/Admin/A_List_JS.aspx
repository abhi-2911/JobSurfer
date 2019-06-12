<%@ Page Title="List JobSeekers | Administrator | Jobsurfer.com" Language="C#" MasterPageFile="~/A_MasterPage/Master_Site_4.Master" AutoEventWireup="true" 
    CodeBehind="A_List_JS.aspx.cs" Inherits="JobSurfer.Admin.A_List_JS" %>

<%@ Register Src="~/A_WebFormControl/WFC_A_List_JS.ascx" TagPrefix="uc1" TagName="WFC_A_List_JS" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_A_List_JS runat="server" id="WFC_A_List_JS" />
</asp:Content>
