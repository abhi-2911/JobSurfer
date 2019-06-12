<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_Message_S_Js.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_Message_S_Js" %>

<link href="../A_CSS/CSS_WFC_A_Message_S_Js.css" rel="stylesheet" />

<div id="divA_3">

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="User Name" AssociatedControlID="textboxA1_3" ></asp:Label>
    <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" CausesValidation="True" MaxLength="20" ToolTip="Enter JobSeeker UserName"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Enter JobSeeker UserName" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:CustomValidator CssClass="cvA_3" ID="cvA1_3" runat="server" ErrorMessage="JobSeeker UserName InValid" ControlToValidate="textboxA1_3" ForeColor="Red" OnServerValidate="cvA1_3_ServerValidate">*</asp:CustomValidator>


    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="Subject" AssociatedControlID="textboxB1_3" ></asp:Label>
    <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" CausesValidation="True" MaxLength="100" ToolTip="Enter Message Subject. Max Chars 100"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Enter Message Subject" ControlToValidate="textboxB1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Message" AssociatedControlID="textboxC1_3" ></asp:Label>
    <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" CausesValidation="True" MaxLength="300" TextMode="MultiLine" ToolTip="Enter Message. Max Chars 300."></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvC_3" ID="rfvC1_3" runat="server" ErrorMessage="Enter Message" ControlToValidate="textboxC1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


     <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Send Message" OnClick="buttonA1_3_Click"   />

    <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" Text="Message Sent"></asp:Label>

    <asp:ValidationSummary CssClass="vsumA_3" ID="vsumA1_3" runat="server" HeaderText="Resolve the Following Error :" ShowMessageBox="True" ShowSummary="False" />

</div>