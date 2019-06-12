<%@ Page Title="Remove JobSeeker Notification | Administrator | Jobsurfer.com" Language="C#" MasterPageFile="~/A_MasterPage/Master_Site_4.Master" AutoEventWireup="true" 
    CodeBehind="A_Notification_R_Js.aspx.cs" Inherits="JobSurfer.Admin.A_Notification_R_Js" %>

<%@ Register Src="~/A_WebFormControl/WFC_A_Notification_R_Js.ascx" TagPrefix="uc1" TagName="WFC_A_Notification_R_Js" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_A_Notification_R_Js runat="server" id="WFC_A_Notification_R_Js" />
</asp:Content>
