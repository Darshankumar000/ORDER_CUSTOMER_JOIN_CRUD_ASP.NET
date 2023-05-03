<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Joincrud.aspx.cs" Inherits="JOIN_CRUD.Joincrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
       <center>
           <h1>Order Entry</h1>
            <table>
                <tr>
                    <td>Enter Order Id :</td>
                    <td>
                        <asp:TextBox ID="txtorderid" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td>Customer Id :</td>
                    <td>
                        <%--<asp:TextBox ID="txtcustid" runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddcustid" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Customer Name :</td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Order Date :</td>
                    <td>
                        <asp:TextBox ID="txtorderdate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Ship Date :</td>
                    <td>
                        <asp:TextBox ID="txtshipdate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Order Amount :</td>
                    <td>
                        <asp:TextBox ID="txtorderamt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Payment Mode :</td>
                    <td>
                        <asp:DropDownList ID="ddpaymentmode" runat="server">
                            <asp:ListItem>Gpay</asp:ListItem>
                            <asp:ListItem>Upi</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Remarks :</td>
                    <td>
                        <asp:TextBox ID="txtremark" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btninsert" runat="server" Text="Insert" OnClick="btninsert_Click" />
                        <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                    </td>
                    
                    <td>
                        <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
                        <asp:Button ID="btnview" runat="server" Text="View" OnClick="btnview_Click"  />
                    </td>
                    
                </tr>
            </table>
           <br />
           <br />
           <table>
               <tr>
                   <td>
                       <asp:GridView ID="GridView1" runat="server">
                       </asp:GridView>
                   </td>
               </tr>
           </table>

           <br />
           <br />
           <br />
           <table>
               <tr>
                   <td>
                       <asp:DropDownList ID="ddsearch" runat="server">
                           <asp:ListItem>--Select Query--</asp:ListItem>
                           <asp:ListItem>Query1</asp:ListItem>
                           <asp:ListItem>Query2</asp:ListItem>
                           <asp:ListItem>Query3</asp:ListItem>
                           <asp:ListItem>Query4</asp:ListItem>
                           <asp:ListItem>Query5</asp:ListItem>
                           <asp:ListItem>Query6</asp:ListItem>
                           <asp:ListItem>Query7</asp:ListItem>
                           <asp:ListItem>Query8</asp:ListItem>
                           <asp:ListItem>Query9</asp:ListItem>
                           <asp:ListItem>Query10</asp:ListItem>
                       </asp:DropDownList>
                   </td>
                   <td>
                       <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                   </td>
               </tr>
               <br />
               <br />
               <br />
               <br />
               <tr>
                   <td>
                    <asp:GridView ID="GridView2" runat="server"></asp:GridView>

                   </td>
               </tr>
           </table>
       </center>
        </div>
    </form>
</body>
</html>
