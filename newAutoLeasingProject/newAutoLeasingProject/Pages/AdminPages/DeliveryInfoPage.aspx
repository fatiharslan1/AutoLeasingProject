<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="DeliveryInfoPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.DeliveryInfoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <!-- Filters Section -->
        <div class="flex gap-6 mb-6">
            <!-- Filters -->
            <div class="w-1/4 bg-gray-50 p-4 rounded-lg shadow-md">
                <h3 class="text-lg font-semibold mb-4">Filitreler</h3>
                <div class="space-y-4">


                    <div class="mb-4">
                        <label for="CustomerName" class="block text-sm font-medium text-gray-700 mb-1">Müşteri İsmi</label>
                        <asp:TextBox ID="CustomerNameTxt" runat="server" placeholder="Müşteri İsmi"
                            CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none">
                        </asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="DeliveryStatus" runat="server" Text="Teslim Durumu" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:DropDownList ID="DeliveryStatusDropDown" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                        </asp:DropDownList>
                    </div>



                    <!-- Filitrele Butonu -->
                    <div class="text-center">
                        <asp:Button ID="FilterBtn" runat="server" Text="Filitrele" OnClick="FilterBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                        <asp:Button ID="ClearBtn" runat="server" Text="Temizle" OnClick="ClearBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                    </div>
                </div>

            </div>

            <!-- Delivery Listings -->
            <div class="flex-1 space-y-6">
                <div></div>
                <asp:Button ID="UpdateBTN" runat="server" Text="Güncelle" OnClick="UpdateBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                <!-- DeliveryTable -->
                <table class="min-w-full bg-white border border-gray-300 rounded-lg shadow-lg">
                    <thead class="bg-gray-100">
                        <tr>
                            <th class="px-6 py-3 text-left font-semibold">Sipariş ID</th>
                            <th class="px-6 py-3 text-left font-semibold">Müşteri</th>
                            <th class="px-6 py-3 text-left font-semibold">Araba </th>
                            <th class="px-6 py-3 text-left font-semibold">Çalışan </th>
                            <th class="px-6 py-3 text-left font-semibold">KM</th>
                            <th class="px-6 py-3 text-left font-semibold">Araç Durumu</th>
                            <th class="px-6 py-3 text-left font-semibold">Teslimat Tarihi</th>
                            <th class="px-6 py-3 text-left font-semibold">İşlem ID</th>
                            <th class="px-6 py-3 text-left font-semibold">   İşlemler</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr class='<%# GetRowClass(Eval("DeliveryStatus").ToString()) %>'>
                                    <td class="px-6 py-3"><%# Eval("DeliveryID") %></td>
                                    <td class="px-6 py-3"><%# Eval("FirstName") + " " + Eval("LastName") %></td>
                                    <td class="px-6 py-3"><%# Eval("Brand") + " " + Eval("Model") %></td>
                                    <td class="px-6 py-3"><%# Eval("EmployeeFirstName") + " " + Eval("EmployeeLastName") %></td>
                                    <td class="px-6 py-3">
                                        <%# 
                Eval("OdometerReading") != DBNull.Value && !string.IsNullOrEmpty(Eval("OdometerReading").ToString()) 
                ? Eval("OdometerReading").ToString() 
                : "N/A" 
                %>
            </td>
                                    <td class="px-6 py-3"><%# Eval("DeliveryStatus") %></td>
                                    <td class="px-6 py-3"><%# Eval("DeliveryDate") %></td>
                                    <td class="px-6 py-3"><%# Eval("TransactionID") %></td>

                                    <!-- Butonların olduğu hücre -->
                                    <td class="px-6 py-3" style="display: flex; gap: 0.5rem; justify-content: center; align-items: center;">
                                        <asp:Button ID="InfoButton" runat="server" Text="Teslim Al" CommandArgument='<%# Eval("DeliveryID") %>'
                                            OnClick="InfoButton_Click" CssClass="bg-yellow-500 hover:bg-yellow-600 text-white py-1 px-3 rounded-md transition" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>

                </table>

            </div>
        </div>
    </form>

</asp:Content>
