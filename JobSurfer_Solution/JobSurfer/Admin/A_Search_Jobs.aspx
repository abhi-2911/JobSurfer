<%@ Page Title="Search Job | Administrator | Jobsurfer.com" Language="C#" MasterPageFile="~/A_MasterPage/Master_Site_4.Master" AutoEventWireup="true" 
    CodeBehind="A_Search_Jobs.aspx.cs" Inherits="JobSurfer.Admin.A_Search_Jobs" %>

<%@ Register Src="~/A_WebFormControl/WFC_A_Search_Jobs.ascx" TagPrefix="uc1" TagName="WFC_A_Search_Jobs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_A_Search_Jobs runat="server" id="WFC_A_Search_Jobs" />
</asp:Content>
