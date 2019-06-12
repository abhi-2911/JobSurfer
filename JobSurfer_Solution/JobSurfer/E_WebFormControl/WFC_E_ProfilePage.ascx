<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_E_ProfilePage.ascx.cs" 
    Inherits="JobSurfer.E_WebFormControl.WFC_E_ProfilePage" %>

<link href="../E_CSS/CSS_WFC_E_ProfilePage.css" rel="stylesheet" />

<asp:Image CssClass="imageA_3" ID="imageA1_3"  runat="server" /><!--profile picture-->

<asp:Button CssClass="buttonMessage" ID="buttonMessageA1_3" runat="server" Text="Messages" PostBackUrl="~/Employer/E_Messages.aspx" />
<asp:Button CssClass="buttonNotification" ID="buttonNotificationA1_3" runat="server" Text="Notifications" PostBackUrl="~/Employer/E_Notifications.aspx" />

<div id="divA_3">   <!--empname box-->    
       <p runat="server" class="pA_3" id="pA1_3"><asp:Literal runat="server" ID="literalA_1" ></asp:Literal></p>
</div>


<div id="divB_3"><!--emp info box-->

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="User Name "></asp:Label>
    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" Text=""></asp:Label>

     <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="First Name "></asp:Label>
    <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" Text=""></asp:Label>

     <asp:Label CssClass="labelE_3" ID="labelE1_3" runat="server" Text="Last Name "></asp:Label>
    <asp:Label CssClass="labelF_3" ID="labelF1_3" runat="server" Text=""></asp:Label>

     <asp:Label CssClass="labelG_3" ID="labelG1_3" runat="server" Text="Designation "></asp:Label>
    <asp:Label CssClass="labelH_3" ID="labelH1_3" runat="server" Text=""></asp:Label>

       <asp:Label CssClass="labelI_3" ID="labelI1_3" runat="server" Text="Company Name "></asp:Label>
    <asp:Label CssClass="labelJ_3" ID="labelJ1_3" runat="server" Text=""></asp:Label>

    <asp:Label CssClass="labelK_3" ID="labelK1_3" runat="server" Text="Email ID "></asp:Label>
    <asp:Label CssClass="labelL_3" ID="labelL1_3" runat="server" Text=" "></asp:Label>

        <asp:Label CssClass="labelM_3" ID="labelM1_3" runat="server" Text="State "></asp:Label>
    <asp:Label CssClass="labelN_3" ID="labelN1_3" runat="server" Text=" "></asp:Label>

        <asp:Label CssClass="labelO_3" ID="labelO1_3" runat="server" Text="City "></asp:Label>
    <asp:Label CssClass="labelP_3" ID="labelP1_3" runat="server" Text=" "></asp:Label>

        <asp:Label CssClass="labelQ_3" ID="labelQ1_3" runat="server" Text="Industry "></asp:Label>
    <asp:Label CssClass="labelR_3" ID="labelR1_3" runat="server" Text=" "></asp:Label>

        <asp:Label CssClass="labelS_3" ID="labelS1_3" runat="server" Text="Contact Number"></asp:Label>
    <asp:Label CssClass="labelT_3" ID="labelT1_3" runat="server" Text=" "></asp:Label>

        <asp:Label CssClass="labelU_3" ID="labelU1_3" runat="server" Text="Member Since "></asp:Label>
    <asp:Label CssClass="labelV_3" ID="labelV1_3" runat="server" Text=" "></asp:Label>

    <hr /> <!--horizontal rule at the end-->


</div>

