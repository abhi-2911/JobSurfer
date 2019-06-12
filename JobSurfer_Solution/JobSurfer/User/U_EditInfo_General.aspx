<%@ Page Title="General Info | JobSeeker | Jobsurfer.com" Language="C#" MasterPageFile="~/U_MasterPage/Master_Site_2.Master" 
    AutoEventWireup="true" CodeBehind="U_EditInfo_General.aspx.cs" Inherits="JobSurfer.User.U_EditInfo_General" %>

<%@ Register Src="~/U_WebFormControl/WFC_U_EditInfo_General.ascx" TagPrefix="uc1" TagName="WFC_U_EditInfo_General" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_U_EditInfo_General runat="server" id="WFC_U_EditInfo_General" />
</asp:Content>
