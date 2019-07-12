<%@ Page Title="JobSurfer.in | The Site for JobSeekers" Language="C#" MasterPageFile="~/W_MasterPage/Master_Site_1.Master" 
    AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="JobSurfer.Website.HomePage" %>

<%@ Register Src="~/W_WebFormControl/WFC_HomePage.ascx" TagPrefix="uc1" TagName="WFC_HomePage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_HomePage runat="server" id="WFC_HomePage" />
</asp:Content>
