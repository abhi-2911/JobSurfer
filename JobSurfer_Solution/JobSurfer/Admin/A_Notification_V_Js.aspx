﻿<%@ Page Title="View JobSeeker Notifications | Administrator | Jobsurfer.com" Language="C#" MasterPageFile="~/A_MasterPage/Master_Site_4.Master" AutoEventWireup="true" 
    CodeBehind="A_Notification_V_Js.aspx.cs" Inherits="JobSurfer.Admin.A_Notification_V_Js" %>

<%@ Register Src="~/A_WebFormControl/WFC_A_Notification_V_Js.ascx" TagPrefix="uc1" TagName="WFC_A_Notification_V_Js" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_A_Notification_V_Js runat="server" id="WFC_A_Notification_V_Js" />
</asp:Content>
