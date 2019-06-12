<%@ Page Title="Edit Posted Jobs | Employer | Jobsurfer.com" Language="C#" MasterPageFile="~/E_MasterPage/Master_Site_3.Master" 
    AutoEventWireup="true" CodeBehind="E_UpdateJobs.aspx.cs" Inherits="JobSurfer.Employer.E_UpdateJobs" %>

<%@ Register Src="~/E_WebFormControl/WFC_E_UpdateJobs.ascx" TagPrefix="uc1" TagName="WFC_E_UpdateJobs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WFC_E_UpdateJobs runat="server" id="WFC_E_UpdateJobs" />
</asp:Content>
