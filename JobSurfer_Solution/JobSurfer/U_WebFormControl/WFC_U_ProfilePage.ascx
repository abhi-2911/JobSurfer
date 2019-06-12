<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_U_ProfilePage.ascx.cs" 
    Inherits="JobSurfer.U_WebFormControl.WFC_U_ProfilePage" %>

<link href="../U_CSS/CSS_WFC_U_ProfilePage.css" rel="stylesheet" />

<asp:Image CssClass="imageA_3" ID="imageA1_3"  runat="server" /><!--profile image-->

<asp:Button CssClass="buttonMessage" ID="buttonMessageA1_3" runat="server" Text="Messages" PostBackUrl="~/User/U_Messages.aspx" />
<asp:Button CssClass="buttonNotification" ID="buttonNotificationA1_3" runat="server" Text="Notifications" PostBackUrl="~/User/U_Notifications.aspx" />

<div id="divA_3">   <!--username box-->    
       <p runat="server" class="pA_3" id="pA1_3"><asp:Literal runat="server" ID="literalA_1" ></asp:Literal></p>
</div>
<div id="divB_3"><!--user info box-->

    <asp:Label CssClass="labelA_3" ID="labelA1_3" runat="server" Text="User Name "></asp:Label>
    <asp:Label CssClass="labelB_3" ID="labelB1_3" runat="server" ></asp:Label>

     <asp:Label CssClass="labelC_3" ID="labelC1_3" runat="server" Text="First Name "></asp:Label>
    <asp:Label CssClass="labelD_3" ID="labelD1_3" runat="server" ></asp:Label>

     <asp:Label CssClass="labelE_3" ID="labelE1_3" runat="server" Text="Last Name "></asp:Label>
    <asp:Label CssClass="labelF_3" ID="labelF1_3" runat="server" ></asp:Label>

     <asp:Label CssClass="labelG_3" ID="labelG1_3" runat="server" Text="Email Id "></asp:Label>
    <asp:Label CssClass="labelH_3" ID="labelH1_3" runat="server" ></asp:Label>

       <asp:Label CssClass="labelI_3" ID="labelI1_3" runat="server" Text="Contact Detail "></asp:Label>
    <asp:Label CssClass="labelJ_3" ID="labelJ1_3" runat="server" ></asp:Label>

    <asp:Label CssClass="labelK_3" ID="labelK1_3" runat="server" Text="Member Since "></asp:Label>
    <asp:Label CssClass="labelL_3" ID="labelL1_3" runat="server" ></asp:Label>


</div>
