<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_Message_V_S_R.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_Message_V_S_R" %>

<link href="../A_CSS/CSS_WFC_A_Message_V_S_R.css" rel="stylesheet" />

<div id="divA1_3">
    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="View" PostBackUrl="~/Admin/A_Message_V_Js_Em.aspx"    />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Send" PostBackUrl="~/Admin/A_Message_S_Js_Em.aspx"  />
    <asp:Button CssClass="buttonC_3" ID="buttonC1_3" runat="server" Text="Remove" PostBackUrl="~/Admin/A_Message_R_Js_Em.aspx"  />

    <hr id="hrA1_3" />
    <hr id="hrB1_3" />
</div>