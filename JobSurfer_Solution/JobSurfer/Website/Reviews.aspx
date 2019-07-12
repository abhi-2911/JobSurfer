<%@ Page Title="JobSurfer.in | Reviews" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="JobSurfer.Website.Reviews" %>

<%@ Register Src="~/W_WebFormControl/WFC_Reviews.ascx" TagPrefix="uc1" TagName="WFC_Reviews" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_Reviews runat="server" id="WFC_Reviews" />
</asp:Content>
