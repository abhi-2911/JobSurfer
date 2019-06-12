<%@ Page Title="Professional Info | JobSeeker | Jobsurfer.com" Language="C#" MasterPageFile="~/U_MasterPage/Master_Site_2.Master" AutoEventWireup="true" 
    CodeBehind="U_EditInfo_Professional.aspx.cs" Inherits="JobSurfer.User.U_EditInfo_Professional" %>

<%@ Register Src="~/U_WebFormControl/WFC_U_EditInfo_Professional.ascx" TagPrefix="uc1" TagName="WFC_U_EditInfo_Professional" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_U_EditInfo_Professional runat="server" id="WFC_U_EditInfo_Professional" />
</asp:Content>
