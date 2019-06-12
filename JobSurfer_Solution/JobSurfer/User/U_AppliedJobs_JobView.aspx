<%@ Page Title="Applied JobDetails | JobSeeker | Jobsurfer.com" Language="C#" MasterPageFile="~/U_MasterPage/Master_Site_2.Master" 
    AutoEventWireup="true" CodeBehind="U_AppliedJobs_JobView.aspx.cs" Inherits="JobSurfer.User.U_AppliedJobs_JobView" %>

<%@ Register Src="~/U_WebFormControl/WFC_U_AppliedJobs_JobView.ascx" TagPrefix="uc1" TagName="WFC_U_AppliedJobs_JobView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_U_AppliedJobs_JobView runat="server" id="WFC_U_AppliedJobs_JobView" />
</asp:Content>
