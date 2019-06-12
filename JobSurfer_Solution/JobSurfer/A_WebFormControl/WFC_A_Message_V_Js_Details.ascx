<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_Message_V_Js_Details.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_Message_V_Js_Details" %>

<link href="../A_CSS/CSS_WFC_A_Message_V_Js_Details.css" rel="stylesheet" />


<div id="divA_3">

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="User Name" AssociatedControlID="textboxA1_3" ></asp:Label>
    <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" ReadOnly="True" ></asp:TextBox>

    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="Subject" AssociatedControlID="textboxB1_3" ></asp:Label>
    <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" ReadOnly="True"  TextMode="MultiLine"></asp:TextBox>


    <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Message" AssociatedControlID="textboxC1_3" ></asp:Label>
    <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" ReadOnly="True" TextMode="MultiLine" ></asp:TextBox>


</div>