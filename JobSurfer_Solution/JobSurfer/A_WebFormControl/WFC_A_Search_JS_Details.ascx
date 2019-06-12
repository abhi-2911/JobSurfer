<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_Search_JS_Details.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_Search_JS_Details" %>

<link href="../A_CSS/CSS_WFC_A_Search_JS_Details.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:Image CssClass="imageA_3" ID="imageA1_3"  runat="server" />     <!--jobseeker profile image-->
    <asp:Button CssClass="buttonResumeA_3" ID="buttonResumeA1_3" runat="server" Text="Resume"  OnClick="buttonResumeA1_3_Click" />
    <asp:Button CssClass="buttonVideoResumeA_3" ID="buttonVideoResumeA1_3" runat="server" Text="Video Resume"  OnClick="buttonVideoResumeA1_3_Click" />


    <p id="pA1_3">Jobseeker Details</p>

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="First Name "></asp:Label>
    <asp:Label CssClass="valuelabelA_3" ID="valuelabelA1_3" runat="server" ></asp:Label>

     <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text="Last Name "></asp:Label>
    <asp:Label CssClass="valuelabelB_3" ID="valuelabelB1_3" runat="server" ></asp:Label>

     <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="Email ID"></asp:Label>
    <asp:Label CssClass="valuelabelC_3" ID="valuelabelC1_3" runat="server" ></asp:Label>

     <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" Text="Contact Detail "></asp:Label>
    <asp:Label CssClass="valuelabelD_3" ID="valuelabelD1_3" runat="server" ></asp:Label>

    <hr id="hrA1_3" />

    <p id="pB1_3">Employment Details</p>

    <asp:Label CssClass="labelE_3" ID="labelE1_3" runat="server" Text="Designation "></asp:Label>
    <asp:Label CssClass="valuelabelE_3" ID="valuelabelE1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelF_3" ID="labelF1_3" runat="server" Text="Organization "></asp:Label>
    <asp:Label CssClass="valuelabelF_3" ID="valuelabelF1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelG_3" ID="labelG1_3" runat="server" Text="Working "></asp:Label>
    <asp:Label CssClass="valuelabelG_3" ID="valuelabelG1_3" runat="server" ></asp:Label>

     <hr id="hrB1_3" />

     <p id="pC1_3">Project</p>

    <asp:Label CssClass="labelH_3" ID="labelH1_3" runat="server" Text="Title "></asp:Label>
    <asp:Label CssClass="valuelabelH_3" ID="valuelabelH_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelI_3" ID="labelI1_3" runat="server" Text="Project of "></asp:Label>
    <asp:Label CssClass="valuelabelI_3" ID="valuelabelI_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelJ_3" ID="labelJ1_3" runat="server" Text="Status "></asp:Label>
    <asp:Label CssClass="valuelabelJ_3" ID="valuelabelJ_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelK_3" ID="labelK1_3" runat="server" Text="Description "></asp:Label>
    <asp:TextBox CssClass="textboxK_3" ID="textboxK1_3" runat="server" ReadOnly="True" TextMode="MultiLine" ></asp:TextBox>

    <hr id="hrC1_3" />


    <p id="pD1_3">Online Profile</p>

    <asp:Label CssClass="labelL_3" ID="labelL1_3" runat="server" Text="Social Profile "></asp:Label>
    <asp:Label CssClass="valuelabelL_3" ID="valuelabelL1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelM_3" ID="labelM1_3" runat="server" Text="URL "></asp:Label>
    <asp:Button CssClass="buttonM_3" ID="buttonM1_3" runat="server" Text="View"/>

    <asp:Label CssClass="labelN_3" ID="labelN1_3" runat="server" Text="Description "></asp:Label>
    <asp:TextBox CssClass="textboxN_3" ID="textboxN1_3" runat="server" ReadOnly="True" TextMode="MultiLine" ></asp:TextBox>

      <hr id="hrD1_3" />


    <p id="pE1_3">Certification</p>

    <asp:Label CssClass="labelO_3" ID="labelO1_3" runat="server" Text=" Name "></asp:Label>
    <asp:Label CssClass="valuelabelO_3" ID="valuelabelO1_3" runat="server" ></asp:Label>
    
    <asp:Label CssClass="labelP_3" ID="labelP1_3" runat="server" Text=" Institute "></asp:Label>
    <asp:Label CssClass="valuelabelP_3" ID="valuelabelP1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelQ_3" ID="labelQ1_3" runat="server" Text="Year "></asp:Label>
    <asp:Label CssClass="valuelabelQ_3" ID="valuelabelQ1_3" runat="server" ></asp:Label>

     <hr id="hrE1_3" />


    <p id="pF1_3">Personal Details</p>

    <asp:Label CssClass="labelR_3" ID="labelR1_3" runat="server" Text="DOB "></asp:Label>
    <asp:Label CssClass="valuedayR_3" ID="valuedayR1_3" runat="server" ></asp:Label>
    <asp:Label CssClass="valuemonthR_3" ID="valuemonthR1_3" runat="server" ></asp:Label>
    <asp:Label CssClass="valueyearR_3" ID="valueyearR1_3" runat="server" ></asp:Label>

     <asp:Label CssClass="labelS_3" ID="labelS1_3" runat="server" Text="Gender "></asp:Label>
    <asp:Label CssClass="valuelabelS_3" ID="valuelabelS1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelT_3" ID="labelT1_3" runat="server" Text="State "></asp:Label>
    <asp:Label CssClass="valuelabelT_3" ID="valuelabelT1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelU_3" ID="labelU1_3" runat="server" Text="City "></asp:Label>
    <asp:Label CssClass="valuelabelU_3" ID="valuelabelU1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelV_3" ID="labelV1_3" runat="server" Text="HomeTown "></asp:Label>
    <asp:Label CssClass="valuelabelV_3" ID="valuelabelV1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelW_3" ID="labelW1_3" runat="server" Text="Pincode "></asp:Label>
    <asp:Label CssClass="valuelabelW_3" ID="valuelabelW1_3" runat="server" ></asp:Label>

     <asp:Label CssClass="labelX_3" ID="labelX1_3" runat="server" Text="Marital Status "></asp:Label>
    <asp:Label CssClass="valuelabelX_3" ID="valuelabelX1_3" runat="server" ></asp:Label>

    <hr id="hrF1_3" />


    <p id="pG1_3">Education</p>

    <asp:Label CssClass="labelY_3" ID="labelY1_3" runat="server" Text="Qualification "></asp:Label>
    <asp:Label CssClass="valuelabelY_3" ID="valuelabelY1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelZ_3" ID="labelZ1_3" runat="server" Text="Course Name "></asp:Label>
    <asp:Label CssClass="valuelabelZ_3" ID="valuelabelZ1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelAA_3" ID="labelAA1_3" runat="server" Text="College Name "></asp:Label>
    <asp:Label CssClass="valuelabelAA_3" ID="valuelabelAA1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelAB_3" ID="labelAB1_3" runat="server" Text="University "></asp:Label>
    <asp:Label CssClass="valuelabelAB_3" ID="valuelabelAB1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelAC_3" ID="labelAC1_3" runat="server" Text="Percentage "></asp:Label>
    <asp:Label CssClass="valuelabelAC_3" ID="valuelabelAC1_3" runat="server" ></asp:Label>

    <hr id="hrG1_3" />

    <hr id="hrH1_3" />

</div>
