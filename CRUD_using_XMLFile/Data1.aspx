<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data1.aspx.cs" Inherits="CRUD_using_XMLFile.Data1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <table>
                <tr>
                    <td>
                        ID <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Name <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td>
                        Designation <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Salary <asp:TextBox ID="txtSal" runat="server"></asp:TextBox>
                    </td>
                </tr>               
                <tr>
                    <td>
                        <asp:Button ID="btnSUbmit" runat="server" OnClick="btnSUbmit_Click" Text="Submit" />
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
                    </td>
                </tr>
            </table>
            <hr/>
            <br/>
            <hr/>
                <asp:GridView ID="grv" runat="server" Width="80%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>Action</HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEdit" CommandName='<%# Bind("Id") %>' OnCommand="lbtnEdit_Command" runat="server">Edit</asp:LinkButton>
                                <asp:LinkButton ID="LbtnDelete" CommandArgument='<%# Bind("Id") %>' OnCommand="LbtnDelete_Command" runat="server">Delete</asp:LinkButton>
                            </ItemTemplate>   

                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />

                </asp:GridView>

            </center>
        </div>
    </form>

</body>
</html>
