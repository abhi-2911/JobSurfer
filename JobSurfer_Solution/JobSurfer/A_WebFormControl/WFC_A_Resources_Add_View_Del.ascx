<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_Resources_Add_View_Del.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_Resources_Add_View_Del" %>


<link href="../A_CSS/CSS_WFC_A_Resources_Add_View_Del.css" rel="stylesheet" />


<div id="divA1_3">
    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Add" PostBackUrl="~/Admin/A_Resources_Add_Vid_Doc.aspx"   />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="View" PostBackUrl="~/Admin/A_Resources_View_Vid_Doc.aspx"  />
    <asp:Button CssClass="buttonC_3" ID="buttonC1_3" runat="server" Text="Remove" PostBackUrl="~/Admin/A_Resources_Del_Vid_Doc.aspx"  />

    <hr id="hrA1_3" />
    <hr id="hrB1_3" />
</div>