<%@ Page Title="Message Details | JobSeeker | Jobsurfer.com" Language="C#" MasterPageFile="~/U_MasterPage/Master_Site_2.Master" AutoEventWireup="true" 
    CodeBehind="U_Message_Details.aspx.cs" Inherits="JobSurfer.User.U_Message_Details" %>

<%@ Register Src="~/U_WebFormControl/WFC_U_Message_Details.ascx" TagPrefix="uc1" TagName="WFC_U_Message_Details" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_U_Message_Details runat="server" id="WFC_U_Message_Details" />
</asp:Content>
