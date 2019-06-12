<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_E_DeleteJob.ascx.cs" 
    Inherits="JobSurfer.E_WebFormControl.WFC_E_DeleteJob" %>

<link href="../E_CSS/CSS_WFC_E_DeleteJob.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Select To Remove"></asp:Label>

    <asp:DropDownList CssClass="ddlA_3" ID="ddlA1_3" runat="server" AppendDataBoundItems="True">
        <asp:ListItem>Select Job_ID</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Select a Job" ControlToValidate="ddlA1_3" ForeColor="Red" InitialValue="Select Job_ID">*</asp:RequiredFieldValidator>

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Remove" OnClick="buttonA1_3_Click" OnClientClick="return confirm('Are you Sure ?')" />
    <!--validation summary not required as confirm function is available here on the button-->
</div>
