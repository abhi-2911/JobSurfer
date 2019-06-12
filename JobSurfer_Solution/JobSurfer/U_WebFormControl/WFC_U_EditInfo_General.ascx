<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_EditInfo_General.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_EditInfo_General" %>

<link href="../U_CSS/CSS_WFC_U_EditInfo_General.css" rel="stylesheet" />

<div id="divA_3">
    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="First Name" AssociatedControlID="textboxA1_3"></asp:Label>
    <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" MaxLength="10" ToolTip="only ablphbets(a-z A-Z ) min 4 and max 10 characters"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Enter First Name" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="revA_3" ID="revA1_3" runat="server" ErrorMessage="a-z,A-Z" ControlToValidate="textboxA1_3" ValidationExpression="^[a-zA-Z]{4,10}$"></asp:RegularExpressionValidator>

    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="Last Name" AssociatedControlID="textboxB1_3"></asp:Label>
    <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" MaxLength="10" ToolTip="only ablphbets(a-z A-Z ) min 4 and max 10 characters"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Enter Last Name" ControlToValidate="textboxB1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="revB_3" ID="revB1_3" runat="server" ErrorMessage="a-z,A-Z" ControlToValidate="textboxB1_3" ValidationExpression="^[a-zA-Z]{4,10}$"></asp:RegularExpressionValidator>

    <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Email ID" AssociatedControlID="textboxC1_3"></asp:Label>
    <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" MaxLength="10" ToolTip="example@email.com"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvC_3" ID="rfvC1_3" runat="server" ErrorMessage="Enter Email ID" ControlToValidate="textboxC1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="revC_3" ID="revC1_3" runat="server" ErrorMessage="Not Valid" ControlToValidate="textboxC1_3" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

    <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" Text="Contact Number" AssociatedControlID="textboxD1_3"></asp:Label>
    <asp:TextBox CssClass="textboxD_3" ID="textboxD1_3" runat="server" MaxLength="10" TextMode="Number" ToolTip="9969016344 only digits allowed"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvD_3" ID="rfvD1_3" runat="server" ErrorMessage="Enter Contact Number" ControlToValidate="textboxD1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="revD_3" ID="revD1_3" runat="server" ErrorMessage="Not Valid" ControlToValidate="textboxD1_3" ValidationExpression="^([7-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Update" OnClick="buttonA1_3_Click" />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Profile" PostBackUrl="~/User/U_ProfilePage.aspx" />

    <asp:Label CssClass="labelE_3" ID="labelE1_3" runat="server" Text="Data Updated"></asp:Label>

    <asp:ValidationSummary ID="vsA1_3" runat="server" HeaderText="Resolve the following Errors :" ShowMessageBox="True" ShowSummary="False" />
</div>
