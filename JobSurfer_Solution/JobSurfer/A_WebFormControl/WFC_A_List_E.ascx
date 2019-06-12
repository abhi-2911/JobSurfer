<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_A_List_E.ascx.cs" 
    Inherits="JobSurfer.A_WebFormControl.WFC_A_List_E" %>

<link href="../A_CSS/CSS_WFC_A_List_E.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:GridView CssClass="gvA_3" ID="gvA1_3" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="sql_DS_A1_3" OnSelectedIndexChanged="gvA1_3_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="User Name">
                <ItemTemplate>
                    <asp:Label ID="labelA1_3" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle CssClass="emp_username_css" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="labelB1_3" runat="server" Text='<%# Eval("firstName") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle CssClass="emp_name_css" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="View" Text="open">
            <ControlStyle CssClass="button_css" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:ButtonField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle CssClass="gv_header" BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

    <asp:SqlDataSource ID="sql_DS_A1_3" runat="server" ConnectionString="Data Source=DESKTOP-NKM47LH\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="pull_empInfo_A_p" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

</div>
