<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="ServiceInfo.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.ServiceInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Ana Form -->
    <form id="ServiceForm" runat="server" class="container mx-auto p-6 bg-white shadow-md rounded-lg mt-8">
        <!-- Sayfa Başlığı -->
        <h1 class="text-3xl font-bold text-center mb-6 text-gray-800">Araç Servis Durumu</h1>
                <asp:HiddenField ID="BranchIDHiddenField" runat="server" />

        <!-- Buton Bölgesi -->
        <div class="mb-4 flex justify-end">
            <asp:Button ID="UpdateBTN" runat="server" Text="Güncelle"
                OnClick="UpdateBTN_Click"
                CssClass="px-4 py-2 bg-blue-600 text-white font-semibold rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

        <!-- Araç Listesi -->
        <div class="overflow-x-auto">
            <table class="w-full border-collapse bg-white rounded-md shadow-lg">
                <thead class="bg-gray-200 text-gray-700">
                    <tr>
                        <th class="py-2 px-4 border-b text-left">CarID</th>
                        <th class="py-2 px-4 border-b text-left">Marka</th>
                        <th class="py-2 px-4 border-b text-left">Model</th>
                        <th class="py-2 px-4 border-b text-left">Yıl</th>
                        <th class="py-2 px-4 border-b text-left">Plaka</th>
                        <th class="py-2 px-4 border-b text-left">Tip</th>
                        <th class="py-2 px-4 border-b text-left">Durum</th>
                        <th class="py-2 px-4 border-b text-left">Şube</th>
                        <th class="py-2 px-4 border-b text-center">İşlemler</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="hover:bg-gray-100">
                                <td class="py-2 px-4 border-b"><%# Eval("CarID") %></td>
                                <td class="py-2 px-4 border-b"><%# Eval("Brand") %></td>
                                <td class="py-2 px-4 border-b"><%# Eval("Model") %></td>
                                <td class="py-2 px-4 border-b"><%# Eval("Year") %></td>
                                <td class="py-2 px-4 border-b"><%# Eval("LicensePlate") %></td>
                                <td class="py-2 px-4 border-b"><%# Eval("TypeName") %></td>
                                <td class="py-2 px-4 border-b"><%# Eval("InSituation") %></td>
                                <td class="py-2 px-4 border-b"><%# Eval("BranchID") %></td>
                                <td class="py-2 px-4 border-b text-center">
                                    <!-- Teslim Al Butonu -->
                                    <asp:Button ID="InfoButton" runat="server" Text="Teslim Al"
                                        CommandArgument='<%# Eval("CarID") %>'
                                        OnClick="InfoButton_Click"
                                        CssClass="px-4 py-2 bg-blue-600 text-white font-semibold rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </form>
</asp:Content>