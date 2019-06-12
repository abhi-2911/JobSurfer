<%@ Page Title="JobSearch | JobSeeker | Jobsurfer.com" Language="C#" MasterPageFile="~/U_MasterPage/Master_Site_2.Master" 
    AutoEventWireup="true" CodeBehind="U_JobSearch.aspx.cs" Inherits="JobSurfer.User.U_JobSearch" %>

<%@ Register Src="~/U_WebFormControl/WFC_U_JobSearch.ascx" TagPrefix="uc1" TagName="WFC_U_JobSearch" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_U_JobSearch runat="server" id="WFC_U_JobSearch" />
</asp:Content>
