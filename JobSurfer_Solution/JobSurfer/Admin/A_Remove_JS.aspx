<%@ Page Title="Remove JobSeeker | Administrator | Jobsurfer.com" Language="C#" MasterPageFile="~/A_MasterPage/Master_Site_4.Master" 
    AutoEventWireup="true" CodeBehind="A_Remove_JS.aspx.cs" Inherits="JobSurfer.Admin.A_Remove_JS" %>

<%@ Register Src="~/A_WebFormControl/WFC_A_Remove_JS.ascx" TagPrefix="uc1" TagName="WFC_A_Remove_JS" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_A_Remove_JS runat="server" id="WFC_A_Remove_JS" />
</asp:Content>
