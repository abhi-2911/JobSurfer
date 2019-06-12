<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_List_JS_E_J.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_List_JS_E_J" %>

<link href="../A_CSS/CSS_WFC_A_List_JS_E_J.css" rel="stylesheet" />

<div id="divA1_3">
    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Jobseeker" PostBackUrl="~/Admin/A_List_JS.aspx"   />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Employer" PostBackUrl="~/Admin/A_List_E.aspx"  />
    <asp:Button CssClass="buttonC_3" ID="buttonC1_3" runat="server" Text="Jobs" PostBackUrl="~/Admin/A_List_J.aspx"  />

    <hr id="hrA1_3" />
    <hr id="hrB1_3" />
</div>