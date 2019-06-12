<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WFC_E_ViewJobs.ascx.cs" 
    Inherits="JobSurfer.E_WebFormControl.WFC_E_ViewJobs" %>


<link href="../E_CSS/CSS_WFC_E_ViewJobs.css" rel="stylesheet" />

<div id="divA1_3">

    <asp:GridView CssClass="gvA_3" ID="gvA1_3" runat="server" BackColor="White" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="job_id" DataSourceID="sql_DSA1_3">
        <Columns>
            <asp:BoundField DataField="job_id" HeaderText="Job ID" InsertVisible="False" ReadOnly="True" SortExpression="job_id">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="job_id" />
            </asp:BoundField>
            <asp:BoundField DataField="job_title" HeaderText="Job Title" SortExpression="job_title">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="job_title" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Click To View" SortExpression="job_id">
                <ItemTemplate>
                    <asp:Button ID="buttonA1_3" OnClick="buttonA1_3_Click" runat="server" CausesValidation="false" CommandName="" Text='<%# Eval("job_id") %>' />
                </ItemTemplate>
                <ControlStyle CssClass="button_css"  />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
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

    <asp:SqlDataSource ID="sql_DSA1_3" runat="server" ConnectionString="Data Source=DESKTOP-NKM47LH\SQL_SERVER_TEST;Initial Catalog=TestDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [job_id], [job_title] FROM [Jobs] WHERE ([emp_username] = @emp_username)">
        <SelectParameters>
            <asp:SessionParameter Name="emp_username" SessionField="employer" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:Button CssClass="buttonB_3" ID="buttonB1_3" runat="server" Text="Post Jobs" PostBackUrl="~/Employer/E_PostJobs.aspx" />

</div>
