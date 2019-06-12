<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_Resources_Del_Vid_J.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_Resources_Del_Vid_J" %>

<link href="../A_CSS/CSS_WFC_A_Resources_Del_Vid_J.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Enter Video ID"></asp:Label>
    <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" MaxLength="5" TextMode="Number" ></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Video ID Required" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:CustomValidator CssClass="cvA_3" ID="cvA1_3" runat="server" ErrorMessage="Video ID Does Not Exist" ControlToValidate="textboxA1_3" ForeColor="Red"   OnServerValidate="cvA1_3_ServerValidate" >*</asp:CustomValidator>

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure ?')"   OnClick="buttonA1_3_Click"/>
    <!--validation summary not required as confirm function is available here on the button-->

</div>
