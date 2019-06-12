<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_Message_Details.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_Message_Details" %>

<link href="../U_CSS/CSS_WFC_U_Message_Details.css" rel="stylesheet" />


<div id="divA_3">

    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="Subject" AssociatedControlID="textboxB1_3" ></asp:Label>
    <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" ReadOnly="True"  TextMode="MultiLine"></asp:TextBox>


    <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Message" AssociatedControlID="textboxC1_3" ></asp:Label>
    <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" ReadOnly="True" TextMode="MultiLine" ></asp:TextBox>


</div>
