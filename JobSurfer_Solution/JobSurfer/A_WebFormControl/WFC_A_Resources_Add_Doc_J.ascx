<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_Resources_Add_Doc_J.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_Resources_Add_Doc_J" %>

<link href="../A_CSS/CSS_WFC_A_Resources_Add_Doc_J.css" rel="stylesheet" />


<div id="divA1_3">

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Title" AssociatedControlID="textboxA1_3"></asp:Label>
    <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" MaxLength="100" ToolTip="Document Title Max Chars 100"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Document Title Required" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="Document" ></asp:Label>
    <asp:FileUpload CssClass="fileuploadA_3" ID="fileuploadA1_3" runat="server" ToolTip="only .pdf file of less than 3MB allowed" />
    <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Document Required" ControlToValidate="fileuploadA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Add"  OnClick="buttonA1_3_Click" />
    <asp:Label CssClass="successLabelA_3" ID="successLabelA1_3" runat="server" Text="Document Added"></asp:Label>

    <asp:ValidationSummary CssClass="vsumA_3" ID="vsumA1_3" runat="server" HeaderText="Resolve the Following :" ShowMessageBox="True" ShowSummary="False" />

</div>
