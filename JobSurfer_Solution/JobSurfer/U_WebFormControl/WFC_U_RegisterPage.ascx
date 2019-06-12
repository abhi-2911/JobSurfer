<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_RegisterPage.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_RegisterPage" %>

<link href="../U_CSS/CSS_WFC_U_RegisterPage.css" rel="stylesheet" />

<div id="divA_3">
    <img id="imgA_3" src="../U_Images/Login_2.jpg" />
    <p class="pA_3">Register </p>

    <div id="divB_3">

        <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Username" AssociatedControlID="textboxA1_3"></asp:Label>
        <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" MaxLength="10" ToolTip="only ablphbets(a-z A-Z _) min 4 and max 10 characters"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Enter Username" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revA_3" ID="revA1_3" runat="server" ErrorMessage="a-z,A-Z,_" ControlToValidate="textboxA1_3" ValidationExpression="^[a-zA-Z_]{4,10}$"></asp:RegularExpressionValidator>
        <asp:CustomValidator CssClass="cvA_3" ID="cvA1_3" runat="server" ErrorMessage="Username already exists" ControlToValidate="textboxA1_3" OnServerValidate="cvA1_3_ServerValidate" ForeColor="Red">*</asp:CustomValidator>

        

        <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="First Name" AssociatedControlID="textboxB1_3"></asp:Label>
        <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" MaxLength="10" ToolTip="only ablphbets(a-z A-Z ) min 4 and max 10 characters"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Enter First Name" ControlToValidate="textboxB1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revB_3" ID="revB1_3" runat="server" ErrorMessage="a-z,A-Z" ControlToValidate="textboxB1_3" ValidationExpression="^[a-zA-Z]{4,10}$"></asp:RegularExpressionValidator>
        

        <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Last Name" AssociatedControlID="textboxC1_3"></asp:Label>
        <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" MaxLength="10" ToolTip="only ablphbets(a-z A-Z ) min 4 and max 10 characters"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvC_3" ID="rfvC1_3" runat="server" ErrorMessage="Enter Last Name" ControlToValidate="textboxC1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revC_3" ID="revC1_3" runat="server" ErrorMessage="a-z,A-Z" ControlToValidate="textboxC1_3" ValidationExpression="^[a-zA-Z]{4,10}$"></asp:RegularExpressionValidator>


        <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" Text="Email Id" AssociatedControlID="textboxD1_3"></asp:Label>
        <asp:TextBox CssClass="textboxD_3" ID="textboxD1_3" runat="server" MaxLength="30" ToolTip="example@email.com"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvD_3" ID="rfvD1_3" runat="server" ErrorMessage="Enter Email Id" ControlToValidate="textboxD1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revD_3" ID="revD1_3" runat="server" ErrorMessage="Not Valid" ControlToValidate="textboxD1_3" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>


        <asp:Label CssClass="labelE_3" ID="labelE1_3" runat="server" Text="Contact Number" AssociatedControlID="textboxE1_3"></asp:Label>
        <asp:TextBox CssClass="textboxE_3" ID="textboxE1_3" runat="server" MaxLength="10" TextMode="Number" ToolTip="9969016344 only digits allowed"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvE_3" ID="rfvE1_3" runat="server" ErrorMessage="Enter Contact Number" ControlToValidate="textboxE1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revE_3" ID="revE1_3" runat="server" ErrorMessage="Not Valid" ControlToValidate="textboxE1_3" ValidationExpression="^([7-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>


        <asp:Label CssClass="labelF_3" ID="labelF1_3" runat="server" Text="Password" AssociatedControlID="textboxF1_3"></asp:Label>
        <asp:TextBox CssClass="textboxF_3" ID="textboxF1_3" runat="server" MaxLength="10" TextMode="Password" ToolTip="max 10 characters allowed"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvF_3" ID="rfvF1_3" runat="server" ErrorMessage="Enter Password" ControlToValidate="textboxF1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:CustomValidator CssClass="cvB_3" ID="cvB1_3" runat="server" ErrorMessage="Min 4 char." ControlToValidate="textboxF1_3" ForeColor="Red" OnServerValidate="cvB1_3_ServerValidate">*</asp:CustomValidator>


        <asp:Label CssClass="labelG_3" ID="labelG1_3" runat="server" Text="Confirm Password" AssociatedControlID="textboxG1_3"></asp:Label>
        <asp:TextBox CssClass="textboxG_3" ID="textboxG1_3" runat="server" MaxLength="10" TextMode="Password" ToolTip="max 10 characters allowed"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvG_3" ID="rfvG1_3" runat="server" ErrorMessage="Re-Enter Password" ControlToValidate="textboxG1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:CompareValidator CssClass="comparevA_3" ID="comparevA1_3" runat="server" ErrorMessage="Passwords do not Match" ControlToCompare="textboxF1_3" ControlToValidate="textboxG1_3" ForeColor="Red">*</asp:CompareValidator>

        
        <asp:Label CssClass="labelH_3" ID="labelH1_3" runat="server" Text="Profile Pic" AssociatedControlID="fileuploadA1_3"></asp:Label>
        <asp:FileUpload CssClass="fileuploadA_3" ID="fileuploadA1_3" runat="server" ToolTip="only .jpg or .png file of less than 4MB allowed" />
        <asp:RequiredFieldValidator CssClass="rfvH_3" ID="rfvH1_3" runat="server" ErrorMessage="Upload Profile Picture" ControlToValidate="fileuploadA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


        <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Register" OnClick="buttonA1_3_Click" />
        <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Login" CausesValidation="False" PostBackUrl="~/User/U_LoginPage.aspx" />

        <asp:ValidationSummary ID="vsA1_3" runat="server" HeaderText="Resolve the following Errors :" ShowMessageBox="True" ShowSummary="False" />
    </div>

</div>
