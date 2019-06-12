<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_E_RegisterPage.ascx.cs" 
    Inherits="JobSurfer.E_WebFormControl.WFC_E_RegisterPage" %>

<link href="../E_CSS/CSS_WFC_E_RegisterPage.css" rel="stylesheet" />


<div id="divA_3">
    <img id="imgA_3" src="../E_Images/Login_2.jpg" />
    <p class="pA_3">Register </p>

    <div id="divB_3">

        <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Username" AssociatedControlID="textboxA1_3"></asp:Label>
        <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" ToolTip="only alphabets and underscore a-z or A-Z or _ Min 4 & Max 10"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Enter UserName" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revA_3" ID="revA1_3" runat="server" ErrorMessage="only alphabets & underscore a-z or A-Z or _" ControlToValidate="textboxA1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z_]{4,10}$">*</asp:RegularExpressionValidator>
        <asp:CustomValidator CssClass="cvA_3" ID="cvA1_3" runat="server" ErrorMessage="Unique Username Required" ControlToValidate="textboxA1_3" ForeColor="Red" OnServerValidate="cvA1_3_ServerValidate">*</asp:CustomValidator>
        


        <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="First Name" AssociatedControlID="textboxB1_3"></asp:Label>
        <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" MaxLength="10" ToolTip="only ablphbets(a-z A-Z) min 4 and max 10 characters"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Enter First Name" ControlToValidate="textboxB1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revB_3" ID="revB1_3" runat="server" ErrorMessage="FirstName: only alphabets a-z or A-Z" ControlToValidate="textboxB1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z]{4,10}$">*</asp:RegularExpressionValidator>
        

        <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Last Name" AssociatedControlID="textboxC1_3"></asp:Label>
        <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" ToolTip="only ablphbets(a-z A-Z) min 4 and max 10 characters"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvC_3" ID="rfvC1_3" runat="server" ErrorMessage="Enter Last Name" ControlToValidate="textboxC1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revC_3" ID="revC1_3" runat="server" ErrorMessage="LastName: only alphabets a-z or A-Z" ControlToValidate="textboxC1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z]{4,10}$">*</asp:RegularExpressionValidator>


        <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" Text="Designation" AssociatedControlID="textboxD1_3"></asp:Label>
        <asp:TextBox CssClass="textboxD_3" ID="textboxD1_3" runat="server" MaxLength="20" ToolTip="Only alphabets(a-z or A-Z) Min 4 and Max 20"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvD_3" ID="rfvD1_3" runat="server" ErrorMessage="Enter Designation" ControlToValidate="textboxD1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revD_3" ID="revD1_3" runat="server" ErrorMessage="Designation: only alphabets a-z or A-Z" ControlToValidate="textboxD1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z ]{4,20}$">*</asp:RegularExpressionValidator>


        <asp:Label CssClass="labelE_3" ID="labelE1_3" runat="server" Text="Company Name" AssociatedControlID="textboxE1_3"></asp:Label>
        <asp:TextBox CssClass="textboxE_3" ID="textboxE1_3" runat="server" MaxLength="30" ToolTip="Alphabets and Numbers Min 4 and Max 30 Characters"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvE_3" ID="rfvE1_3" runat="server" ErrorMessage="Enter Company Name" ControlToValidate="textboxE1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revE_3" ID="revE1_3" runat="server" ErrorMessage="CompanyName: alphabets and numbers only" ControlToValidate="textboxE1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9 ]{4,30}$">*</asp:RegularExpressionValidator>


        <asp:Label CssClass="labelF_3" ID="labelF1_3" runat="server" Text="Email Id" AssociatedControlID="textboxF1_3"></asp:Label>
        <asp:TextBox CssClass="textboxF_3" ID="textboxF1_3" runat="server" MaxLength="30" ToolTip="Max 30 and Min 5"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvF_3" ID="rfvF1_3" runat="server" ErrorMessage="Enter Email ID" ControlToValidate="textboxF1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revF_3" ID="revF1_3" runat="server" ErrorMessage="Valid Email Required" ControlToValidate="textboxF1_3" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>


        <asp:Label CssClass="labelG_3" ID="labelG1_3" runat="server" Text="State" AssociatedControlID="ddlA1_3"></asp:Label>
        <asp:DropDownList CssClass="ddlA_3" ID="ddlA1_3" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlA1_3_SelectedIndexChanged" >
            <asp:ListItem Value="0">Select State</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator CssClass="rfvG_3" ID="rfvG1_3" runat="server" ErrorMessage="Select State" ControlToValidate="ddlA1_3" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>


        <asp:Label CssClass="labelH_3" ID="labelH1_3" runat="server" Text="City" AssociatedControlID="ddlB1_3"></asp:Label>
        <asp:DropDownList CssClass="ddlB_3" ID="ddlB1_3" runat="server" AppendDataBoundItems="True">
            <asp:ListItem Value="0">Select City</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator CssClass="rfvH_3" ID="rfvH1_3" runat="server" ErrorMessage="Select City" ControlToValidate="ddlB1_3" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>


        <asp:Label CssClass="labelI_3" ID="labelI1_3" runat="server" Text="Industry" AssociatedControlID="ddlC1_3"></asp:Label>
        <asp:DropDownList CssClass="ddlC_3" ID="ddlC1_3" runat="server" AppendDataBoundItems="True" >
            <asp:ListItem Value="0">Select Industry</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator CssClass="rfvI_3" ID="rfvI1_3" runat="server" ErrorMessage="Select Industry" ControlToValidate="ddlC1_3" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>


        <asp:Label CssClass="labelJ_3" ID="labelJ1_3" runat="server" Text="Address" AssociatedControlID="textboxG1_3"></asp:Label>
        <asp:TextBox CssClass="textboxG_3" ID="textboxG1_3" runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvJ_3" ID="rfvJ1_3" runat="server" ErrorMessage="Enter Address" ControlToValidate="textboxG1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revG_3" ID="revG1_3" runat="server" ErrorMessage="Address:Min 10 and Max 100 Characters" ControlToValidate="textboxG1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9 ,-]{10,100}$">*</asp:RegularExpressionValidator>


        <asp:Label CssClass="labelK_3" ID="labelK1_3" runat="server" Text="Contact Number" AssociatedControlID="textboxH1_3"></asp:Label>
        <asp:TextBox CssClass="textboxH_3" ID="textboxH1_3" runat="server" MaxLength="10" TextMode="Number" ToolTip="Mobile Number 10 Digits"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvK_3" ID="rfvK1_3" runat="server" ErrorMessage="Enter Contact Number" ControlToValidate="textboxH1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="revH_3" ID="revH1_3" runat="server" ErrorMessage="Enter Valid Contact Number" ControlToValidate="textboxH1_3" ForeColor="Red" ValidationExpression="^([6-9]{1,1})([0-9]{9,9})$">*</asp:RegularExpressionValidator>


        <asp:Label CssClass="labelL_3" ID="labelL1_3" runat="server" Text="Password" AssociatedControlID="textboxI1_3"></asp:Label>
        <asp:TextBox CssClass="textboxI_3" ID="textboxI1_3" runat="server" MaxLength="10" TextMode="Password" ToolTip="Min 4 and Max 10 Charcaters Required"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvL_3" ID="rfvL1_3" runat="server" ErrorMessage="Enter Password" ControlToValidate="textboxI1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:CustomValidator CssClass="cvB_3" ID="cvB1_3" runat="server" ErrorMessage="Password: Min 4 Characters" ControlToValidate="textboxI1_3" ForeColor="Red" OnServerValidate="cvB1_3_ServerValidate">*</asp:CustomValidator>


        <asp:Label CssClass="labelM_3" ID="labelM1_3" runat="server" Text="Confirm Password" AssociatedControlID="textboxJ1_3"></asp:Label>
        <asp:TextBox CssClass="textboxJ_3" ID="textboxJ1_3" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="rfvM_3" ID="rfvM1_3" runat="server" ErrorMessage="Re-enter Password" ControlToValidate="textboxJ1_3" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:CompareValidator CssClass="comparevA_3" ID="comparevA1_3" runat="server" ErrorMessage="Passwords Mismatch" ControlToCompare="textboxI1_3" ControlToValidate="textboxJ1_3" ForeColor="Red">*</asp:CompareValidator>

        
        <asp:Label CssClass="labelN_3" ID="labelN1_3" runat="server" Text="Profile Pic" AssociatedControlID="fileuploadA1_3"></asp:Label>
        <asp:FileUpload CssClass="fileuploadA_3" ID="fileuploadA1_3" runat="server" />
        <asp:RequiredFieldValidator CssClass="rfvN_3" ID="rfvN1_3" runat="server" ErrorMessage="Upload Profile Picture" ControlToValidate="fileuploadA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>

        <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Register" OnClick="buttonA1_3_Click" />
        <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Login" PostBackUrl="~/Employer/E_LoginPage.aspx" CausesValidation="False" />
        <asp:ValidationSummary CssClass="vsA_3" ID="vsA1_3" runat="server" HeaderText="Resolve The Following :" ShowMessageBox="True" ShowSummary="False" />


        <hr />

    </div>

</div>