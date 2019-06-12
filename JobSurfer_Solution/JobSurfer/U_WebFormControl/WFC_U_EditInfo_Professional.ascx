<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_EditInfo_Professional.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_EditInfo_Professional" %>

<link href="../U_CSS/CSS_WFC_U_EditInfo_Professional.css" rel="stylesheet" />


<div id="divA_3">
    <p class="pA_3" id="pA1_3">Employment </p>

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Your Designation" AssociatedControlID="textboxA1_3" ToolTip="Enter Your Designation"></asp:Label>
    <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" MaxLength="20" ValidationGroup="employment_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Enter Your Designation" ControlToValidate="textboxA1_3" ForeColor="Red" ValidationGroup="employment_vg">Enter Your Designation</asp:RequiredFieldValidator>

    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="Your Organization" AssociatedControlID="textboxB1_3" ToolTip="Enter Company Name"></asp:Label>
    <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" MaxLength="20" ValidationGroup="employment_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Enter Your Organization" ControlToValidate="textboxB1_3" ForeColor="Red" ValidationGroup="employment_vg">Enter Your Organization</asp:RequiredFieldValidator>

    <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Is this your current Company?" ToolTip="Currently Working in this Company ?"></asp:Label>
    <asp:RadioButton CssClass="radiobuttonA_3" ID="radiobuttonA1_3" runat="server" Text="Yes" GroupName="currentCompany" ValidationGroup="employment_vg" Checked="True" />
    <asp:RadioButton CssClass="radiobuttonB_3" ID="radiobuttonB1_3" runat="server" Text="No" GroupName="currentCompany" ValidationGroup="employment_vg" />


    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Save" ValidationGroup="employment_vg" OnClick="buttonA1_3_Click" />
    <asp:Button CssClass="update_buttonA_3" ID="update_buttonA1_3" runat="server" Text="update" ValidationGroup="employment_vg" OnClick="update_buttonA1_3_Click" />
    <asp:Label CssClass="success_labelA_3" ID="success_labelA1_3" runat="server" Text="Data Saved"></asp:Label>
    <asp:ValidationSummary CssClass="vsA_3" ID="vsA1_3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="employment_vg" />

    <p class="pB_3" id="pB1_3">_______________________________________________________ </p>

    <p class="pC_3" id="pC1_3">Project </p>

    <asp:Label CssClass="labelD_3" ID="labelD_3" runat="server" Text="Project Title" AssociatedControlID="textboxC1_3" ToolTip="Enter Project Title"></asp:Label>
    <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" MaxLength="20" ValidationGroup="project_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvC_3" ID="rfvC1_3" runat="server" ErrorMessage="Enter Project Title" ControlToValidate="textboxC1_3" ForeColor="Red" ValidationGroup="project_vg">Enter Project Title</asp:RequiredFieldValidator>

    <asp:Label CssClass="labelE_3" ID="labelE1_3" runat="server" Text="Tag this project to"></asp:Label>
    <asp:RadioButton CssClass="radiobuttonC_3" ID="radiobuttonC1_3" runat="server" Text="Education" GroupName="tagProject" ValidationGroup="project_vg" Checked="True" />
    <asp:RadioButton CssClass="radiobuttonD_3" ID="radiobuttonD1_3" runat="server" Text="Employment" GroupName="tagProject" ValidationGroup="project_vg" />

    <asp:Label CssClass="labelF_3" ID="labelF_3" runat="server" Text="Project Status"></asp:Label>
    <asp:RadioButton CssClass="radiobuttonE_3" ID="radiobuttonE1_3" runat="server" Text="In Progress" GroupName="projectStatus" ValidationGroup="project_vg" Checked="True" />
    <asp:RadioButton CssClass="radiobuttonF_3" ID="radiobuttonF1_3" runat="server" Text="Finished" GroupName="projectStatus" ValidationGroup="project_vg" />

    <asp:Label CssClass="labelG_3" ID="labelG_3" runat="server" Text="Describe Project" AssociatedControlID="textboxD1_3" ToolTip="Describe Your Project in Breif"></asp:Label>
    <asp:TextBox CssClass="textboxD_3" ID="textboxD1_3" runat="server" MaxLength="500" TextMode="MultiLine" ValidationGroup="project_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvD_3" ID="rfvD1_3" runat="server" ErrorMessage="Project Description Required" ControlToValidate="textboxD1_3" ForeColor="Red" ValidationGroup="project_vg">Project Description Required</asp:RequiredFieldValidator>

    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Save" ValidationGroup="project_vg" OnClick="buttonB1_3_Click" />
    <asp:Button CssClass="update_buttonB_3" ID="update_buttonB1_3" runat="server" Text="update" ValidationGroup="project_vg" OnClick="update_buttonB1_3_Click" />
    <asp:Label CssClass="success_labelB_3" ID="success_labelB1_3" runat="server" Text="Data Saved"></asp:Label>
    <asp:ValidationSummary CssClass="vsB_3" ID="vsB1_3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="project_vg" />

    <p class="pD_3" id="pD1_3">_______________________________________________________ </p>

    <p class="pE_3" id="pE1_3">Online Profile </p>

    <asp:Label CssClass="labelH_3" ID="labelH1_3" runat="server" Text="Social Profile" AssociatedControlID="textboxE1_3" ToolTip="Facebook , Github , . . ."></asp:Label>
    <asp:TextBox CssClass="textboxE_3" ID="textboxE1_3" runat="server" MaxLength="20" ValidationGroup="online_profile_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvE_3" ID="rfvE1_3" runat="server" ErrorMessage="Name of Social Profile Required" ControlToValidate="textboxE1_3" ForeColor="Red" ValidationGroup="online_profile_vg">Name of Social Profile Required</asp:RequiredFieldValidator>

    <asp:Label CssClass="labelI_3" ID="labelI1_3" runat="server" Text="Url" AssociatedControlID="textboxF1_3" ToolTip="Social Profile Link"></asp:Label>
    <asp:TextBox CssClass="textboxF_3" ID="textboxF1_3" runat="server" MaxLength="100" ValidationGroup="online_profile_vg" TextMode="Url"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvF_3" ID="rfvF1_3" runat="server" ErrorMessage="Url Required" ControlToValidate="textboxF1_3" ForeColor="Red" ValidationGroup="online_profile_vg">Url of Social Profile Required</asp:RequiredFieldValidator>

    <asp:Label CssClass="labelJ_3" ID="labelJ1_3" runat="server" Text="Description" AssociatedControlID="textboxG1_3" ToolTip="Profile Description in Brief"></asp:Label>
    <asp:TextBox CssClass="textboxG_3" ID="textboxG1_3" runat="server" MaxLength="500" TextMode="MultiLine" ValidationGroup="online_profile_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvG_3" ID="rfvG1_3" runat="server" ErrorMessage="Social Profile Description Required" ControlToValidate="textboxG1_3" ForeColor="Red" ValidationGroup="online_profile_vg">Social Profile Description Required</asp:RequiredFieldValidator>

    <asp:Button CssClass="buttonC_3" ID="buttonC1_3" runat="server" Text="Save" ValidationGroup="online_profile_vg" OnClick="buttonC1_3_Click" />
    <asp:Button CssClass="update_buttonC_3" ID="update_buttonC1_3" runat="server" Text="update" ValidationGroup="online_profile_vg" OnClick="update_buttonC1_3_Click" />
    <asp:Label CssClass="success_labelC_3" ID="success_labelC1_3" runat="server" Text="Data Saved"></asp:Label>
    <asp:ValidationSummary CssClass="vsC_3" ID="vsC1_3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="online_profile_vg" />

    <p class="pF_3" id="pF1_3">_______________________________________________________ </p>

        <p class="pG_3" id="pG1_3">Certification </p>

    <asp:Label CssClass="labelK_3" ID="labelK1_3" runat="server" Text="Certification Name" AssociatedControlID="textboxH1_3" ToolTip="OCA , MCSD , . . ."></asp:Label>
    <asp:TextBox CssClass="textboxH_3" ID="textboxH1_3" runat="server" MaxLength="10" ValidationGroup="certification_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvH_3" ID="rfvH1_3" runat="server" ErrorMessage="Certification Name Required" ControlToValidate="textboxH1_3" ForeColor="Red" ValidationGroup="certification_vg">Certification Name Required</asp:RequiredFieldValidator>

    <asp:Label CssClass="labelL_3" ID="labelL1_3" runat="server" Text="Certification Body" AssociatedControlID="textboxI1_3" ToolTip="Institute/Center Name"></asp:Label>
    <asp:TextBox CssClass="textboxI_3" ID="textboxI1_3" runat="server" MaxLength="50" ValidationGroup="certification_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvI_3" ID="rfvI1_3" runat="server" ErrorMessage="Certification Body Name Required" ControlToValidate="textboxI1_3" ForeColor="Red" ValidationGroup="certification_vg">Certification Body Name Required</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelM_3" ID="labelM1_3" runat="server" Text="Year"></asp:Label>
    <asp:DropDownList CssClass="ddlA_3" ID="ddlA1_3" runat="server" ValidationGroup="certification_vg">
        <asp:ListItem Value="Select">Select</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfv_ddlA_3" ID="rfv_ddlA1_3" runat="server" ErrorMessage="Select Certification Year" ControlToValidate="ddlA1_3" ForeColor="Red" ValidationGroup="certification_vg" InitialValue="Select">Select Certification Year</asp:RequiredFieldValidator>


    <asp:Button CssClass="buttonD_3" ID="buttonD1_3" runat="server" Text="Save" ValidationGroup="certification_vg" OnClick="buttonD1_3_Click" />
    <asp:Button CssClass="update_buttonD_3" ID="update_buttonD1_3" runat="server" Text="update" ValidationGroup="certification_vg" OnClick="update_buttonD1_3_Click" />
    <asp:Label CssClass="success_labelD_3" ID="success_labelD1_3" runat="server" Text="Data Saved"></asp:Label>
    <asp:ValidationSummary CssClass="vsD_3" ID="vsD1_3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="certification_vg" />

    <p class="pH_3" id="pH1_3">_______________________________________________________ </p>

        <p class="pI_3" id="pI1_3">Personal Details </p>

    <asp:Label CssClass="labelN_3" ID="labelN_3" runat="server" Text="Date of Birth"></asp:Label>
    <asp:DropDownList CssClass="ddlB_3" ID="ddlB1_3" runat="server" ValidationGroup="personal_details_vg">
        <asp:ListItem>Day</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList CssClass="ddlC_3" ID="ddlC1_3" runat="server" ValidationGroup="personal_details_vg">
        <asp:ListItem>Month</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList CssClass="ddlD_3" ID="ddlD1_3" runat="server" ValidationGroup="personal_details_vg">
        <asp:ListItem>Year</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfv_ddlB_3" ID="rfv_ddlB1_3" runat="server" ErrorMessage="Enter Birth_Day" ControlToValidate="ddlB1_3" ForeColor="Red" InitialValue="Day" ValidationGroup="personal_details_vg">*</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator CssClass="rfv_ddlC_3" ID="rfv_ddlC1_3" runat="server" ErrorMessage="Enter Birth_Month" ControlToValidate="ddlC1_3" ForeColor="Red" InitialValue="Month" ValidationGroup="personal_details_vg">*</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator CssClass="rfv_ddlD_3" ID="rfv_ddlD1_3" runat="server" ErrorMessage="Enter Birth_Year" ControlToValidate="ddlD1_3" ForeColor="Red" InitialValue="Year" ValidationGroup="personal_details_vg">*</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelO_3" ID="labelO_3" runat="server" Text="Gender"></asp:Label>
    <asp:RadioButton CssClass="radiobuttonG_3" ID="radiobuttonG1_3" runat="server" Text="Male" GroupName="genderSelect" ValidationGroup="personal_details_vg" Checked="True" />
    <asp:RadioButton CssClass="radiobuttonH_3" ID="radiobuttonH1_3" runat="server" Text="Female" GroupName="genderSelect" ValidationGroup="personal_details_vg" />


    <asp:Label CssClass="labelP_3" ID="labelP1_3" runat="server" Text="State"></asp:Label>
    <asp:DropDownList CssClass="ddlE_3" ID="ddlE1_3" runat="server" ValidationGroup="personal_details_vg" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlE1_3_SelectedIndexChanged">
        <asp:ListItem Value="0">Select State</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfv_ddlE_3" ID="rfv_ddlE1_3" runat="server" ErrorMessage="State Name Required" ControlToValidate="ddlE1_3" ForeColor="Red" InitialValue="0" ValidationGroup="personal_details_vg">State Name Required</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelQ_3" ID="labelQ1_3" runat="server" Text="City"></asp:Label>
    <asp:DropDownList CssClass="ddlF_3" ID="ddlF1_3" runat="server" ValidationGroup="personal_details_vg" AppendDataBoundItems="True">
        <asp:ListItem Value="0">Select City</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfv_ddlF_3" ID="rfv_ddlF1_3" runat="server" ErrorMessage="City Name Required" ControlToValidate="ddlF1_3" ForeColor="Red" InitialValue="0" ValidationGroup="personal_details_vg">City Name Required</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelR_3" ID="labelR1_3" runat="server" Text="Hometown" AssociatedControlID="textboxJ1_3"></asp:Label>
    <asp:TextBox CssClass="textboxJ_3" ID="textboxJ1_3" runat="server" MaxLength="50" ValidationGroup="personal_details_vg"></asp:TextBox>
    <asp:RegularExpressionValidator CssClass="revJ_3" ID="revJ1_3" runat="server" ErrorMessage="HomeTown Name Invalid" ControlToValidate="textboxJ1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z ]{3,50}$" ValidationGroup="personal_details_vg">HomeTown Name Invalid</asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator CssClass="rfvJ_3" ID="rfvJ1_3" runat="server" ErrorMessage="HomeTown Name Required" ControlToValidate="textboxJ1_3" ForeColor="Red" ValidationGroup="personal_details_vg">HomeTown Name Required</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelS_3" ID="labelS_3" runat="server" Text="Pincode" AssociatedControlID="textboxK1_3"></asp:Label>
    <asp:TextBox CssClass="textboxK_3" ID="textboxK1_3" runat="server" MaxLength="6" TextMode="Number" ValidationGroup="personal_details_vg"></asp:TextBox>
    <asp:RegularExpressionValidator CssClass="revK_3" ID="revK1_3" runat="server" ErrorMessage="Pincode Invalid" ControlToValidate="textboxK1_3" ForeColor="Red" ValidationExpression="^([1-9]{1})([0-9]{5,6})$" ValidationGroup="personal_details_vg">Pincode Invalid</asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator CssClass="rfvK_3" ID="rfvK1_3" runat="server" ErrorMessage="Pincode Required" ControlToValidate="textboxK1_3" ForeColor="Red" ValidationGroup="personal_details_vg">Pincode Required</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelT_3" ID="labelT1_3" runat="server" Text="Marital Status"></asp:Label>
    <asp:DropDownList CssClass="ddlG_3" ID="ddlG1_3" runat="server" ValidationGroup="personal_details_vg">
        <asp:ListItem Value="Select ">Select </asp:ListItem>
        <asp:ListItem Value="Unmarried/Single">Unmarried/Single</asp:ListItem>
        <asp:ListItem Value="Married">Married</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfv_ddlG_3" ID="rfv_ddlG1_3" runat="server" ErrorMessage="Marital Status Required" ControlToValidate="ddlG1_3" ForeColor="Red" InitialValue="Select" ValidationGroup="personal_details_vg">Marital Status Required</asp:RequiredFieldValidator>


    <asp:Button CssClass="buttonE_3" ID="buttonE1_3" runat="server" Text="Save" ValidationGroup="personal_details_vg" OnClick="buttonE1_3_Click" />
    <asp:Button CssClass="update_buttonE_3" ID="update_buttonE1_3" runat="server" Text="update" ValidationGroup="personal_details_vg" OnClick="update_buttonE1_3_Click" />
    <asp:Label CssClass="success_labelE_3" ID="success_labelE1_3" runat="server" Text="Data Saved"></asp:Label>
    <asp:ValidationSummary CssClass="vsE_3" ID="vsE1_3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="personal_details_vg" />


    <p class="pJ_3" id="pJ1_3">_______________________________________________________ </p>



    <p class="pK_3" id="pK1_3">Desired Career Profile </p>


    <asp:Label CssClass="labelU_3" ID="labelU_3" runat="server" Text="Industry"></asp:Label>
    <asp:DropDownList CssClass="ddlH_3" ID="ddlH1_3" runat="server" ValidationGroup="dcp_vg" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlH1_3_SelectedIndexChanged">
        <asp:ListItem Value="0">Select Industry</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfv_ddlH_3" ID="rfv_ddlH1_3" runat="server" ErrorMessage="Industry Required" ControlToValidate="ddlH1_3" ForeColor="Red" InitialValue="0" ValidationGroup="dcp_vg">Industry Required</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelV_3" ID="labelV1_3" runat="server" Text="Role"></asp:Label>
    <asp:DropDownList CssClass="ddlI_3" ID="ddlI1_3" runat="server" ValidationGroup="dcp_vg" AppendDataBoundItems="True">
        <asp:ListItem Value="0">Select Role</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfv_ddlI_3" ID="rfv_ddlI1_3" runat="server" ErrorMessage="Role Required" ControlToValidate="ddlI1_3" ForeColor="Red" InitialValue="0" ValidationGroup="dcp_vg">Role Required</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelW_3" ID="labelW1_3" runat="server" Text="Job Type"></asp:Label>
    <asp:CheckBox CssClass="checkboxA_3" ID="checkboxA1_3" runat="server" Text="Permanent" ValidationGroup="dcp_vg" Checked="True" />
    <asp:CheckBox CssClass="checkboxB_3" ID="checkboxB1_3" runat="server" Text="Contract" ValidationGroup="dcp_vg" Checked="False" />


    <asp:Label CssClass="labelX_3" ID="labelX1_3" runat="server" Text="Employment Type"></asp:Label>
    <asp:CheckBox CssClass="checkboxC_3" ID="checkboxC1_3" runat="server" Text="Full Time" ValidationGroup="dcp_vg" Checked="True" />
    <asp:CheckBox CssClass="checkboxD_3" ID="checkboxD1_3" runat="server" Text="Part Time" ValidationGroup="dcp_vg" Checked="False" />


    <asp:Label CssClass="labelY_3" ID="labelY1_3" runat="server" Text="Preferred Shift"></asp:Label>
    <asp:RadioButton CssClass="radiobuttonI_3" ID="radiobuttonI1_3" runat="server" GroupName="preferredShift" Text="Day" ValidationGroup="dcp_vg" Checked="True" />
    <asp:RadioButton CssClass="radiobuttonJ_3" ID="radiobuttonJ1_3" runat="server" GroupName="preferredShift" Text="Night" ValidationGroup="dcp_vg" />
    <asp:RadioButton CssClass="radiobuttonK_3" ID="radiobuttonK1_3" runat="server" GroupName="preferredShift" Text="Flexible" ValidationGroup="dcp_vg" />


    <asp:Label CssClass="labelZ_3" ID="labelZ1_3" runat="server" Text="Expected Salary"></asp:Label>
    <asp:DropDownList CssClass="ddlJ_3" ID="ddlJ1_3" runat="server" ValidationGroup="dcp_vg">
        <asp:ListItem>Lakh</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList CssClass="ddlK_3" ID="ddlK1_3" runat="server" ValidationGroup="dcp_vg">
        <asp:ListItem>Thousand</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfv_ddlJ_3" ID="rfv_ddlJ_3" runat="server" ErrorMessage="Expected Salary Lakh Required" ControlToValidate="ddlJ1_3" ForeColor="Red" InitialValue="Lakh" ValidationGroup="dcp_vg">Expected Salary Required</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator CssClass="rfv_ddlK_3" ID="rfv_ddlK1_3" runat="server" ErrorMessage="Expected Salary Thousand Required" ControlToValidate="ddlK1_3" ForeColor="Red" InitialValue="Thousand" ValidationGroup="dcp_vg">Expected Salary Required</asp:RequiredFieldValidator>


    <asp:Button CssClass="buttonF_3" ID="buttonF1_3" runat="server" Text="Save" ValidationGroup="dcp_vg" OnClick="buttonF1_3_Click" />
    <asp:Button CssClass="update_buttonF_3" ID="update_buttonF1_3" runat="server" Text="update" ValidationGroup="dcp_vg" OnClick="update_buttonF1_3_Click" />
    <asp:Label CssClass="success_labelF_3" ID="success_labelF1_3" runat="server" Text="Data Saved"></asp:Label>
    <asp:ValidationSummary CssClass="vsF_3" ID="vsF1_3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="dcp_vg" />


    <p class="pL_3" id="pL1_3">_______________________________________________________ </p>


    <p class="pM1_3" id="pM1_3">Education </p>


    <asp:Label CssClass="labelZE_3" ID="labelZE_3" runat="server" Text="Highest Qualification"></asp:Label>
    <asp:DropDownList CssClass="ddlL_3" ID="ddlL1_3" runat="server" ValidationGroup="education_vg">
        <asp:ListItem Value="0">Select Qualification</asp:ListItem>
        <asp:ListItem Value="1">Garduate</asp:ListItem>
        <asp:ListItem Value="2">Post Graduate</asp:ListItem>
        <asp:ListItem Value="3">Ph.D</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfv_ddlL_3" ID="rfv_ddlL1_3" runat="server" ErrorMessage="Highest Qualification Required" ControlToValidate="ddlL1_3" ForeColor="Red" InitialValue="0" ValidationGroup="education_vg">Highest Qualification Required</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelZA_3" ID="labelZA1_3" runat="server" Text="Course Name"></asp:Label>
    <asp:TextBox CssClass="textboxL_3" ID="textboxL1_3" runat="server" MaxLength="20" ValidationGroup="education_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvL_3" ID="rfvL1_3" runat="server" ErrorMessage="Course Name Required" ControlToValidate="textboxL1_3" ForeColor="Red" ValidationGroup="education_vg">Course Name Required</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="revL_3" ID="revL1_3" runat="server" ErrorMessage="Course Name Invalid" ControlToValidate="textboxL1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z .]{3,20}$" ValidationGroup="education_vg">Course Name Invalid</asp:RegularExpressionValidator>


    <asp:Label CssClass="labelZB_3" ID="labelZB1_3" runat="server" Text="College Name"></asp:Label>
    <asp:TextBox CssClass="textboxM_3" ID="textboxM1_3" runat="server" MaxLength="50" ValidationGroup="education_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvM_3" ID="rfvM1_3" runat="server" ErrorMessage="College Name Required" ControlToValidate="textboxM1_3" ForeColor="Red" ValidationGroup="education_vg">College Name Required</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="revM_3" ID="revM1_3" runat="server" ErrorMessage="College Name Invalid" ControlToValidate="textboxM1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z ]{3,50}$" ValidationGroup="education_vg">College Name Invalid</asp:RegularExpressionValidator>


    <asp:Label CssClass="labelZC_3" ID="labelZC1_3" runat="server" Text="University Name"></asp:Label>
    <asp:TextBox CssClass="textboxN_3" ID="textboxN1_3" runat="server" MaxLength="50" ValidationGroup="education_vg"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvN_3" ID="rfvN1_3" runat="server" ErrorMessage="University Name Required" ControlToValidate="textboxN1_3" ForeColor="Red" ValidationGroup="education_vg">University Name Required</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="revN_3" ID="revN1_3" runat="server" ErrorMessage="University Name Invalid" ControlToValidate="textboxN1_3" ForeColor="Red" ValidationExpression="^[a-zA-Z]{3,50}$" ValidationGroup="education_vg">University Name Invalid</asp:RegularExpressionValidator>


    <asp:Label CssClass="labelZD_3" ID="labelZD1_3" runat="server" Text="Percentage Acquired"></asp:Label>
    <asp:TextBox CssClass="textboxO_3" ID="textboxO1_3" runat="server" MaxLength="5" ValidationGroup="education_vg" ToolTip="Valid Percentage 89.72"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvO_3" ID="rfvO1_3" runat="server" ErrorMessage="Percentage Required" ControlToValidate="textboxO1_3" ForeColor="Red" ValidationGroup="education_vg">Percentage Required</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator CssClass="revO_3" ID="revO1_3" runat="server" ErrorMessage="Percentage Invalid" ControlToValidate="textboxO1_3" ForeColor="Red" ValidationExpression="^([3-9]{1,1})([0-9]{1,1}).([0-9]{1,2})$" ValidationGroup="education_vg">Percentage Invalid (eg: 89.75)</asp:RegularExpressionValidator>


    <asp:Button CssClass="buttonG_3" ID="buttonG1_3" runat="server" Text="Save" ValidationGroup="education_vg" OnClick="buttonG1_3_Click" />
    <asp:Button CssClass="update_buttonG_3" ID="update_buttonG1_3" runat="server" Text="update" ValidationGroup="education_vg" OnClick="update_buttonG1_3_Click" />
    <asp:Label CssClass="success_labelG_3" ID="success_labelG1_3" runat="server" Text="Data Saved"></asp:Label>
    <asp:ValidationSummary CssClass="vsG_3" ID="vsG1_3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="education_vg" />


    <p class="pN_3" id="pN1_3">_______________________________________________________ </p>

</div>

<!--Markers-->

    <h3 id="h3A1_3">Project</h3>
    <h3 id="h3B1_3">Online Profile</h3>
    <h3 id="h3C1_3">Certification</h3>
    <h3 id="h3D1_3">Per. Details</h3>
    <h3 id="h3E1_3">D.C.Profile</h3>
    <h3 id="h3F1_3">Education</h3>

