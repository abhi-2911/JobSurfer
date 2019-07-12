<%@ Page Title="JobSurfer.in | Companies" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="JobSurfer.Website.Company" %>

<%@ Register Src="~/W_WebFormControl/WFC_Company.ascx" TagPrefix="uc1" TagName="WFC_Company" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_Company runat="server" id="WFC_Company" />
</asp:Content>
