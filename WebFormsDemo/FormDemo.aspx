<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormDemo.aspx.cs" Inherits="WebFormsDemo.FormDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Details</title>
</head>
<body>
    <form id="form1" runat="server">

        <h3>Select Customer</h3>

        <!-- Dropdown Data Source -->
        <asp:SqlDataSource ID="SqlDataSourceCustomers" runat="server"
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="SELECT CustomerID, CompanyName FROM Customers">
        </asp:SqlDataSource>

        <!-- Dropdown -->
        <asp:DropDownList ID="ddlCustomer" runat="server"
            DataSourceID="SqlDataSourceCustomers"
            DataTextField="CompanyName"
            DataValueField="CustomerID"
            AutoPostBack="True">
        </asp:DropDownList>

        <br /><br />

        <!-- GridView Data Source -->
        <asp:SqlDataSource ID="SqlDataSourceCustomerDetails" runat="server"
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="SELECT * FROM Customers WHERE CustomerID = @CustomerID">

            <SelectParameters>
                <asp:ControlParameter 
                    ControlID="ddlCustomer"
                    Name="CustomerID"
                    PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>

        </asp:SqlDataSource>

        <!-- GridView -->
        <asp:GridView ID="gvCustomer" runat="server"
            AutoGenerateColumns="True"
            DataSourceID="SqlDataSourceCustomerDetails">
        </asp:GridView>

    </form>
</body>
</html>