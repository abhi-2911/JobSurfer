<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_E_UpdateJobs.ascx.cs" 
    Inherits="JobSurfer.E_WebFormControl.WFC_E_UpdateJobs" %>


<link href="../E_CSS/CSS_WFC_E_UpdateJobs.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Select Job ID"></asp:Label>

    <asp:DropDownList CssClass="ddlA_3" ID="ddlA1_3" runat="server" AppendDataBoundItems="True">
        <asp:ListItem>Select Job_ID</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Job_ID Required" ControlToValidate="ddlA1_3" ForeColor="Red" InitialValue="Select Job_ID">*</asp:RequiredFieldValidator>

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Edit" OnClick="buttonA1_3_Click" />

    <asp:ValidationSummary CssClass="vsumA_3" ID="vsumA1_3" runat="server" HeaderText="Resolve the Following :" ShowMessageBox="True" ShowSummary="False" />

</div>
