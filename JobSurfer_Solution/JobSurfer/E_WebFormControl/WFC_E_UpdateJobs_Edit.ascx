<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_E_UpdateJobs_Edit.ascx.cs" 
    Inherits="JobSurfer.E_WebFormControl.WFC_E_UpdateJobs_Edit" %>

<link href="../E_CSS/CSS_WFC_E_UpdateJobs_Edit.css" rel="stylesheet" />

<div id="divA1_3">

     <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="Role"></asp:Label>
    <asp:DropDownList CssClass="ddlA_3" ID="ddlA1_3" runat="server" AppendDataBoundItems="True">
        <asp:ListItem >Select Role</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfvA_3" ID="rfvA1_3" runat="server" ErrorMessage="Role Required" ControlToValidate="ddlA1_3" ForeColor="Red" InitialValue="Select Role">*</asp:RequiredFieldValidator>
    

    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="Job Title"></asp:Label>
    <asp:TextBox CssClass="textboxA_3" ID="textboxA1_3" runat="server" MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvB_3" ID="rfvB1_3" runat="server" ErrorMessage="Job Title Required" ControlToValidate="textboxA1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Job Description"></asp:Label>
    <asp:TextBox CssClass="textboxB_3" ID="textboxB1_3" runat="server" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvC_3" ID="rfvC1_3" runat="server" ErrorMessage="Job Description Required" ControlToValidate="textboxB1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" Text="Education"></asp:Label>
    <asp:DropDownList CssClass="ddlB_3" ID="ddlB1_3" runat="server" >
        <asp:ListItem >Select Qualification</asp:ListItem>
        <asp:ListItem >Garduate</asp:ListItem>
        <asp:ListItem >Post Graduate</asp:ListItem>
        <asp:ListItem >Ph.D</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfvD_3" ID="rfvD1_3" runat="server" ErrorMessage="Education Required" ControlToValidate="ddlB1_3" ForeColor="Red" InitialValue="Select Qualification">*</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelE_3" ID="labelE1_3" runat="server" Text="Salary"></asp:Label>
    <asp:DropDownList CssClass="ddlC_3" ID="ddlC1_3" runat="server">
        <asp:ListItem>Lakh</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList CssClass="ddlD_3" ID="ddlD1_3" runat="server">
        <asp:ListItem>Thousand</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfvE_3" ID="rfvE1_3" runat="server" ErrorMessage="Salary in Lakh Required" ControlToValidate="ddlC1_3" ForeColor="Red" InitialValue="Lakh">*</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator CssClass="rfvF_3" ID="rfvF1_3" runat="server" ErrorMessage="Salary in Thousand Required" ControlToValidate="ddlD1_3" ForeColor="Red" InitialValue="Thousand">*</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelF_3" ID="labelF1_3" runat="server" Text="Vacancy"></asp:Label>
    <asp:TextBox CssClass="textboxC_3" ID="textboxC1_3" runat="server" TextMode="Number" ></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="rfvG_3" ID="rfvG1_3" runat="server" ErrorMessage="Vacancy Required" ControlToValidate="textboxC1_3" ForeColor="Red">*</asp:RequiredFieldValidator>


    <asp:Label CssClass="labelG_3" ID="labelG1_3" runat="server" Text="Interview Dates"></asp:Label>

    <asp:Label CssClass="labelH_3" ID="labelH1_3" runat="server" Text="From"></asp:Label>
    <asp:DropDownList CssClass="ddlE_3" ID="ddlE1_3" runat="server" >
        <asp:ListItem>Day</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList CssClass="ddlF_3" ID="ddlF1_3" runat="server" >
        <asp:ListItem>Month</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList CssClass="ddlG_3" ID="ddlG1_3" runat="server" >
        <asp:ListItem>Year</asp:ListItem>
        <asp:ListItem>2018</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfvH_3" ID="rfvH1_3" runat="server" ErrorMessage="From_Day Required" ControlToValidate="ddlE1_3" ForeColor="Red" InitialValue="Day">*</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator CssClass="rfvI_3" ID="rfvI1_3" runat="server" ErrorMessage="From_Month Required" ControlToValidate="ddlF1_3" ForeColor="Red" InitialValue="Month">*</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator CssClass="rfvJ_3" ID="rfvJ1_3" runat="server" ErrorMessage="From_Year Required" ControlToValidate="ddlG1_3" ForeColor="Red" InitialValue="Year">*</asp:RequiredFieldValidator>

    <asp:Label CssClass="labelI_3" ID="labelI1_3" runat="server" Text="To"></asp:Label>
        <asp:DropDownList CssClass="ddlH_3" ID="ddlH1_3" runat="server" >
        <asp:ListItem>Day</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList CssClass="ddlI_3" ID="ddlI1_3" runat="server" >
        <asp:ListItem>Month</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList CssClass="ddlJ_3" ID="ddlJ1_3" runat="server" >
        <asp:ListItem>Year</asp:ListItem>
        <asp:ListItem>2018</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="rfvK_3" ID="rfvK1_3" runat="server" ErrorMessage="To_Day Required" ControlToValidate="ddlH1_3" ForeColor="Red" InitialValue="Day">*</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator CssClass="rfvL_3" ID="rfvL1_3" runat="server" ErrorMessage="To_Month Required" ControlToValidate="ddlI1_3" ForeColor="Red" InitialValue="Month">*</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator CssClass="rfvM_3" ID="rfvM1_3" runat="server" ErrorMessage="To_Year Required" ControlToValidate="ddlJ1_3" ForeColor="Red" InitialValue="Year">*</asp:RequiredFieldValidator>

    <hr class="hrA_3" id="hrA1_3" />

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Update Job" OnClick="buttonA1_3_Click"  />
    <asp:Label CssClass="labelJ_3" ID="labelJ1_3" runat="server" Text="Job Posted"></asp:Label> <!--Success Label-->

    <asp:ValidationSummary CssClass="vsumA_3" ID="vsumA1_3" runat="server" HeaderText="Resolve The Following :" ShowMessageBox="True" ShowSummary="False" />

    <hr class="hrB_3" id="hrB1_3" />

</div>
