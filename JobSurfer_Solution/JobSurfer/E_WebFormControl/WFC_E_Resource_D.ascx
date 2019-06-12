<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_E_Resource_D.ascx.cs" 
    Inherits="JobSurfer.E_WebFormControl.WFC_E_Resource_D" %>

<link href="../E_CSS/CSS_WFC_E_Resource_D.css" rel="stylesheet" />


<div id="divA1_3">

    <asp:GridView CssClass="gvA_3" ID="gvA1_3" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id" DataSourceID="sql_DS_A1_3" OnSelectedIndexChanged="gvA1_3_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="ID" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="labelA1_3" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="labelB1_3" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle CssClass="title_css" />
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


    <asp:SqlDataSource ID="sql_DS_A1_3" runat="server" ConnectionString="Data Source=DESKTOP-NKM47LH\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="list_emp_doc_res" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

</div>