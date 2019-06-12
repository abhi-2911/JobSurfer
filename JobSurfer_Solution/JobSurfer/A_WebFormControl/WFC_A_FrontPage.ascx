<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_FrontPage.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_FrontPage" %>


<link href="../A_CSS/CSS_WFC_A_FrontPage.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:Button CssClass="buttonA_3" ID="buttonA1_3" runat="server" Text="Resources" PostBackUrl="~/Admin/A_Resources_Add_View_Del.aspx" />
    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="List" PostBackUrl="~/Admin/A_List_JS_E_J.aspx" />
    <asp:Button CssClass="buttonC_3" ID="buttonC1_3" runat="server" Text="Search" PostBackUrl="~/Admin/A_Search_JS_E_J.aspx" />
    <asp:Button CssClass="buttonD_3" ID="buttonD1_3" runat="server" Text="Remove" PostBackUrl="~/Admin/A_Remove_JS_E_J.aspx" />
    <asp:Button CssClass="buttonE_3" ID="buttonE1_3" runat="server" Text="Message" PostBackUrl="~/Admin/A_Message_V_S_R.aspx"  />
    <asp:Button CssClass="buttonF_3" ID="buttonF1_3" runat="server" Text="Notification" PostBackUrl="~/Admin/A_Notification_V_S_R.aspx"  />
    <asp:Button CssClass="buttonG_3" ID="buttonG1_3" runat="server" Text="Update Password" PostBackUrl="~/Admin/A_ChangePassword.aspx" />
    <asp:Button CssClass="buttonH_3" ID="buttonH1_3" runat="server" Text="Logout" OnClick="buttonH1_3_Click" />

    <hr id="hrA1_3" />
    <hr id="hrB1_3" />
    <hr id="hrC1_3" />
    <hr id="hrD1_3" />
    <hr id="hrE1_3" />
    <hr id="hrF1_3" />
    <hr id="hrG1_3" />
    <hr id="hrH1_3" />

</div>
