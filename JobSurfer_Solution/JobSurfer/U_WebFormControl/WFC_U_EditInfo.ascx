<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_EditInfo.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_EditInfo" %>

<link href="../U_CSS/CSS_WFC_U_EditInfo.css" rel="stylesheet" />


<div id="divA1_3">
    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="General Info" PostBackUrl="~/User/U_EditInfo_General.aspx" />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Professional Info" PostBackUrl="~/User/U_EditInfo_Professional.aspx" />
</div>
