<%@ Page Title="Video Resources | JobSeeker | Jobsurfer.com" Language="C#" MasterPageFile="~/U_MasterPage/Master_Site_2.Master" AutoEventWireup="true" 
    CodeBehind="U_Resource_V.aspx.cs" Inherits="JobSurfer.User.U_Resource_V" %>

<%@ Register Src="~/U_WebFormControl/WFC_U_Resource_V.ascx" TagPrefix="uc1" TagName="WFC_U_Resource_V" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_U_Resource_V runat="server" id="WFC_U_Resource_V" />
</asp:Content>
