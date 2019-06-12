<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_ChangePassword.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_ChangePassword" %>


<link href="../A_CSS/CSS_WFC_A_ChangePassword.css" rel="stylesheet" />


<div id="divA_3">

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Old Password" AssociatedControlID="textboxA1_3" ToolTip="Enter Old Password"></asp:Label>
    <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" CausesValidation="True" MaxLength="10" TextMode="Password" ToolTip="Enter Old Password"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Enter Old Password" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="New Password" AssociatedControlID="textboxB1_3" ToolTip="Enter New Password"></asp:Label>
    <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" CausesValidation="True" MaxLength="10" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Enter New Password" ControlToValidate="textboxB1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:CustomValidator CssClass="cvA_3" ID="cvA1_3" runat="server" ErrorMessage="Min. Password 4 Char" ControlToValidate="textboxB1_3" ForeColor="Red" OnServerValidate="cvA1_3_ServerValidate"  >*</asp:CustomValidator>


    <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Confirm Password" AssociatedControlID="textboxC1_3" ToolTip="Re-enter New Password"></asp:Label>
    <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" CausesValidation="True" MaxLength="10" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvC_3" ID="rfvC1_3" runat="server" ErrorMessage="Re-enter New Password" ControlToValidate="textboxC1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:CompareValidator CssClass="comparevA_3" ID="comparevA1_3" runat="server" ErrorMessage="Password Mismatch" ControlToCompare="textboxB1_3" ControlToValidate="textboxC1_3" ForeColor="Red">*</asp:CompareValidator>


     <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Update Password" OnClick="buttonA1_3_Click"   />

    <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" Text="Password Changed"></asp:Label>

    <asp:ValidationSummary CssClass="vsumA_3" ID="vsumA1_3" runat="server" HeaderText="Resolve the Errors" ShowMessageBox="True" ShowSummary="False" />

</div>
