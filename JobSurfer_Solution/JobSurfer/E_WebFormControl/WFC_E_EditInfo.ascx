<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_E_EditInfo.ascx.cs" 
    Inherits="JobSurfer.E_WebFormControl.WFC_E_EditInfo" %>

<link href="../E_CSS/CSS_WFC_E_EditInfo.css" rel="stylesheet" />


<div id="divA1_3">


        <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="State" AssociatedControlID="ddlA1_3"></asp:Label>
        <asp:DropDownList CssClass="ddlA_3" ID="ddlA1_3" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlA1_3_SelectedIndexChanged"  >
        <asp:ListItem Value="0">Select State</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Select State" ControlToValidate="ddlA1_3" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>


        <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="City" AssociatedControlID="ddlB1_3"></asp:Label>
        <asp:DropDownList CssClass="ddlB_3" ID="ddlB1_3" runat="server" AppendDataBoundItems="True">
        <asp:ListItem Value="0">Select City</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Select City" ControlToValidate="ddlB1_3" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>


        <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="First Name" AssociatedControlID="textboxA1_3"></asp:Label>
        <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" MaxLength="10" ToolTip="only ablphbets(a-z A-Z) min 4 and max 10 characters"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvC_3" ID="rfvC1_3" runat="server" ErrorMessage="Enter First Name" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revA_3" ID="revA1_3" runat="server" ErrorMessage="FirstName: only alphabets a-z or A-Z" ControlToValidate="textboxA1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z]{4,10}$">*</asp:RegularExpressionValidator>



        <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" Text="Last Name" AssociatedControlID="textboxB1_3"></asp:Label>
        <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" ToolTip="only ablphbets(a-z A-Z) min 4 and max 10 characters"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvD_3" ID="rfvD1_3" runat="server" ErrorMessage="Enter Last Name" ControlToValidate="textboxB1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revB_3" ID="revB1_3" runat="server" ErrorMessage="LastName: only alphabets a-z or A-Z" ControlToValidate="textboxB1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z]{4,10}$">*</asp:RegularExpressionValidator>


        <asp:Label CssClass="labelE_3" ID="labelE1_3" runat="server" Text="Designation" AssociatedControlID="textboxC1_3"></asp:Label>
        <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" MaxLength="20" ToolTip="Only alphabets(a-z or A-Z) Min 4 and Max 20"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvE_3" ID="rfvE1_3" runat="server" ErrorMessage="Enter Designation" ControlToValidate="textboxC1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revC_3" ID="revC1_3" runat="server" ErrorMessage="Designation: only alphabets a-z or A-Z" ControlToValidate="textboxC1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z ]{4,20}$">*</asp:RegularExpressionValidator>
        

        <asp:Label CssClass="labelF_3" ID="labelF1_3" runat="server" Text="Email Id" AssociatedControlID="textboxD1_3"></asp:Label>
        <asp:TextBox CssClass="textboxD_3" ID="textboxD1_3" runat="server" MaxLength="30" ToolTip="Max 30 and Min 5"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvF_3" ID="rfvF1_3" runat="server" ErrorMessage="Enter Email ID" ControlToValidate="textboxD1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revD_3" ID="revD1_3" runat="server" ErrorMessage="Valid Email Required" ControlToValidate="textboxD1_3" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>


        <asp:Label CssClass="labelG_3" ID="labelG1_3" runat="server" Text="Contact Number" AssociatedControlID="textboxE1_3"></asp:Label>
        <asp:TextBox CssClass="textboxE_3" ID="textboxE1_3" runat="server" MaxLength="10" TextMode="Number" ToolTip="Mobile Number 10 Digits"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvG_3" ID="rfvG1_3" runat="server" ErrorMessage="Enter Contact Number" ControlToValidate="textboxE1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revE_3" ID="revE1_3" runat="server" ErrorMessage="Enter Valid Contact Number" ControlToValidate="textboxE1_3" ForeColor="Red" ValidationExpression="^([6-9]{1,1})([0-9]{9,9})$">*</asp:RegularExpressionValidator>

        <hr />

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Update" OnClick="buttonA1_3_Click"  />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Profile" PostBackUrl="~/Employer/E_ProfilePage.aspx"  />
    <asp:Label CssClass="labelH_3" ID="labelH1_3" runat="server" Text="updated"></asp:Label>

    <asp:ValidationSummary CssClass="vsumA_3" ID="vsumA1_3" runat="server" HeaderText="Resolve the following :" ShowMessageBox="True" ShowSummary="False" />
</div>