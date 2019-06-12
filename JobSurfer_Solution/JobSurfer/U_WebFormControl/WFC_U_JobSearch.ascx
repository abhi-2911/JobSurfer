<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_JobSearch.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_JobSearch" %>

<link href="../U_CSS/CSS_WFC_U_JobSearch.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text=" Select Industry " AssociatedControlID="ddlA1_3"></asp:Label>
    <asp:DropDownList CssClass="ddlA_3" ID="ddlA1_3" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlA1_3_SelectedIndexChanged">
        <asp:ListItem Value="Select Industry">Select Industry</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Industry Required" ControlToValidate="ddlA1_3" ForeColor="Red" InitialValue="Select Industry">*</asp:RequiredFieldValidator>

    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text=" Select Role " AssociatedControlID="ddlB1_3"></asp:Label>
    <asp:DropDownList CssClass="ddlB_3" ID="ddlB1_3" runat="server" AppendDataBoundItems="True">
        <asp:ListItem>Select Role</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Role Required" ControlToValidate="ddlB1_3" ForeColor="Red" InitialValue="Select Role">*</asp:RequiredFieldValidator>

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Search" OnClick="buttonA1_3_Click" />
    <asp:ValidationSummary CssClass="vsumA_3" ID="vsumA1_3" runat="server" HeaderText="Resolve The Following :" ShowMessageBox="True" ShowSummary="False" />

</div>
