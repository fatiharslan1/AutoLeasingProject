<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="BranchInfoPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.BranchInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <!-- Filters Section -->
        <div class="flex gap-6 mb-6">
            <!-- Filters -->
            <div class="w-1/4 bg-gray-50 p-4 rounded-lg shadow-md">
                <h3 class="text-lg font-semibold mb-4">Filitreler</h3>
                <div class="space-y-4">

                    <div>
                        <label class="block font-medium mb-1">Ülke</label>
                        <asp:DropDownList ID="CountryDropDown" runat="server" CssClass="w-full border p-2 rounded-md"></asp:DropDownList>
                    </div>

                    <div>
                        <label class="block font-medium mb-1">Şehir</label>
                        <asp:DropDownList ID="CityDropdown" runat="server" CssClass="w-full border p-2 rounded-md"
                            AutoPostBack="true" OnSelectedIndexChanged="CityDropdown_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div>
                        <label class="block font-medium mb-1">İlçe</label>
                        <asp:DropDownList ID="ProvinceDropdown" runat="server" CssClass="w-full border p-2 rounded-md"
                            AutoPostBack="true" OnSelectedIndexChanged="ProvinceDropdown_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>



                    <!-- Filitrele Butonu -->
                    <div class="text-center">
                        <asp:Button ID="FilterBtn" runat="server" Text="Filitrele" OnClick="FilterBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                        <asp:Button ID="ClearBtn" runat="server" Text="Temizle" OnClick="ClearBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                    </div>
                </div>
            </div>

            <!-- Branch Listings -->
            <div class="flex-1 space-y-6">
                <!-- Add New branch Button -->
                <div></div>

                <!-- Branch Table -->
                <table class="min-w-full bg-white border border-gray-300 rounded-lg shadow-lg">
                    <thead class="bg-gray-100">
                        <tr>
                            <th class="px-6 py-3 text-left font-semibold">Şube ID</th>
                            <th class="px-6 py-3 text-left font-semibold">Şube İsmi</th>
                            <th class="px-6 py-3 text-left font-semibold">Şehir</th>
                            <th class="px-6 py-3 text-left font-semibold">İlçe</th>
                            <th class="px-6 py-3 text-left font-semibold">Ülke</th>
                            <th class="px-6 py-3 text-left font-semibold">Açık Adres</th>
                            <th class="px-6 py-3 text-left font-semibold">Telefon Numarası</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <tr class='<%# Container.ItemIndex % 2 == 0 ? "bg-gray-50" : "bg-gray-100" %>'>
                                    <td class="px-6 py-3"><%# Eval("BranchID") %></td>
                                    <td class="px-6 py-3"><%# Eval("Name") %></td>
                                    <td class="px-6 py-3"><%# Eval("Country") %></td>
                                    <td class="px-6 py-3"><%# Eval("City") %></td>
                                    <td class="px-6 py-3"><%# Eval("Province") %></td>
                                    <td class="px-6 py-3"><%# Eval("StreetAddress") %></td>
                                    <td class="px-6 py-3"><%# Eval("Phone") %></td>


                                    <!-- Butonların olduğu hücre -->
                                    <td class="px-6 py-3" style="display: flex; gap: 0.5rem; justify-content: center; align-items: center;">
                                        <asp:Button ID="InfoButton" runat="server" Text="Düzenle" CommandArgument='<%# Eval("BranchID") %>'
                                            OnClick="InfoButton_Click" CssClass="bg-yellow-500 hover:bg-yellow-600 text-white py-1 px-3 rounded-md transition" />
                                        <asp:Button ID="DeleteBtn" runat="server" Text="Sil" CommandArgument='<%# Eval("BranchID") %>'
                                            OnClick="DeleteBtn_Click" CssClass="bg-red-600 hover:bg-red-700 text-white py-1 px-3 rounded-md transition"
                                            OnClientClick="return confirm('Şubeyi silmek istediğinize emin misiniz?');" />
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
