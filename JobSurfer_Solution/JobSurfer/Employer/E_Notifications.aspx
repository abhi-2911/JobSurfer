<%@ Page Title="Notifications | Employer | Jobsurfer.com" Language="C#" MasterPageFile="~/E_MasterPage/Master_Site_3.Master" AutoEventWireup="true" 
    CodeBehind="E_Notifications.aspx.cs" Inherits="JobSurfer.Employer.E_Notifications" %>

<%@ Register Src="~/E_WebFormControl/WFC_E_Notifications.ascx" TagPrefix="uc1" TagName="WFC_E_Notifications" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_E_Notifications runat="server" id="WFC_E_Notifications" />
</asp:Content>
