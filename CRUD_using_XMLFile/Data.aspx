<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="CRUD_using_XMLFile.Data" %>

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
                        City <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                       Gender <asp:DropDownList ID="ddlGen" runat="server">
                           <asp:ListItem>Male</asp:ListItem>
                           <asp:ListItem>Female</asp:ListItem>
                              </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address <asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Salary <asp:TextBox ID="txtSal" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
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
            
        <asp:GridView Width="80%" ID="grv" runat="server" BackColor="White" AutoGenerateColumns="false" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDeleting="grv_RowDeleting" OnSelectedIndexChanged="grv_SelectedIndexChanged">
            <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblname" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>            
            
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="lblcity" runat="server" Text='<%# Bind("City")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>            
                            
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <asp:Label ID="lblgender" runat="server" Text='<%# Bind("Gender")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>            
                            
                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:Label ID="lbladdress" runat="server" Text='<%# Bind("Address")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>     
                
                            <asp:TemplateField HeaderText="Salary">
                                <ItemTemplate>
                                    <asp:Label ID="lblsalary" runat="server" Text='<%# Bind("salary")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>        
                
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblemail" runat="server" Text='<%# Bind("Email")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                
                       
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Select" ID="lnkSelect" runat="server" CommandName="Select" />
                                     <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete">Delete</asp:LinkButton>
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
