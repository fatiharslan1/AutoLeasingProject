<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="CarInfoPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.CarInfoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <!-- Filters Section -->
        <div class="flex gap-6 mb-6">
            <!-- Filters -->
            <div class="w-1/4 bg-gray-50 p-4 rounded-lg shadow-md">
                <h3 class="text-lg font-semibold mb-4">Filitreler</h3>
                <div class="space-y-4">
                    <div>
                        <label class="block font-medium mb-1">Marka</label>
                        <asp:DropDownList ID="BrandDropdown" runat="server" CssClass="w-full border p-2 rounded-md"
                            AutoPostBack="true" OnSelectedIndexChanged="BrandDropdown_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div>
                        <label class="block font-medium mb-1">Model</label>
                        <asp:DropDownList ID="ModelDropdown" runat="server" CssClass="w-full border p-2 rounded-md">
                        </asp:DropDownList>
                    </div>

                    <div>
                        <label class="block font-medium mb-1">Yıl</label>
                        <asp:DropDownList ID="YearDropDown" runat="server" CssClass="w-full border p-2 rounded-md"></asp:DropDownList>
                    </div>
                    <div>
                        <label class="block font-medium mb-1">Sigorta</label>
                        <asp:DropDownList ID="InsuranceDropDown" runat="server" CssClass="w-full border p-2 rounded-md"></asp:DropDownList>
                    </div>


                    <div>
                        <label class="block font-medium mb-1">Araba Sınıfı</label>
                        <asp:DropDownList ID="TypeNameDropDown" runat="server" CssClass="w-full border p-2 rounded-md"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label ID="InSituation" runat="server" Text="Servis Durumu" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:DropDownList ID="InSituationDropDown" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                            <asp:ListItem Text="Herhangi Biri" Value="" Selected="false"></asp:ListItem>
                            <asp:ListItem Text="Servis" Value="Servis"></asp:ListItem>
                            <asp:ListItem Text="Müsait" Value="Müsait"></asp:ListItem>
                            <asp:ListItem Text="Kirada" Value="Kirada"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div>
                        <label class="block font-medium mb-1">Vites Türü</label>
                        <asp:DropDownList ID="TransmissionDropdown" runat="server" CssClass="w-full border p-2 rounded-md">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <label class="block font-medium mb-1">Şube</label>
                        <asp:DropDownList ID="BranchNameDropDown" runat="server" CssClass="w-full border p-2 rounded-md"></asp:DropDownList>
                    </div>

                    <div>
                        <label class="block font-medium mb-1">Yakıt Türü</label>
                        <asp:DropDownList ID="FuelTypeDropDown" runat="server" CssClass="w-full border p-2 rounded-md">
                            <asp:ListItem Text="Any" Value="" />
                            <asp:ListItem Text="Petrol" Value="Petrol" />
                            <asp:ListItem Text="Diesel" Value="Diesel" />
                            <asp:ListItem Text="Hybrid" Value="Hybrid" />
                            <asp:ListItem Text="Electric" Value="Electric" />
                        </asp:DropDownList>
                    </div>


                    <!-- Filitrele Butonu -->
                    <div class="text-center">
                        <asp:Button ID="FilterBtn" runat="server" Text="Filitrele" OnClick="FilterBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                        <asp:Button ID="ClearBtn" runat="server" Text="Temizle" OnClick="ClearBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                    </div>
                </div>
            </div>

            <!-- Car Listings -->
            <div class="flex-1 space-y-6">
                <!-- Add New car Button -->
                <div></div>
                <div class="mb-4">
                    <asp:Button ID="CarAddBtn" runat="server" Text="Yeni Araba" OnClick="CarAddBtn_Click"
                        CssClass="w-full sm:w-auto bg-blue-600 hover:bg-blue-700 text-white py-2 px-4 rounded-lg font-semibold transition" />
                </div>
                <!-- Customer Table -->
                <table class="min-w-full bg-white border border-gray-300 rounded-lg shadow-lg">
                    <thead class="bg-gray-100">
                        <tr>
                            <th class="px-6 py-3 text-left font-semibold">Araba ID</th>
                            <th class="px-6 py-3 text-left font-semibold">Marka</th>
                            <th class="px-6 py-3 text-left font-semibold">Model</th>
                            <th class="px-6 py-3 text-left font-semibold">Yıl</th>
                            <th class="px-6 py-3 text-left font-semibold">Vites Türü</th>
                            <th class="px-6 py-3 text-left font-semibold">Plaka</th>
                            <th class="px-6 py-3 text-left font-semibold">Sigorta</th>
                            <th class="px-6 py-3 text-left font-semibold">Şase Numarası</th>
                            <th class="px-6 py-3 text-left font-semibold">Araba Sınıfı</th>
                            <th class="px-6 py-3 text-left font-semibold">Şube</th>
                            <th class="px-6 py-3 text-left font-semibold">Araç Durumu</th>
                            <th class="px-6 py-3 text-left font-semibold">İşlemler</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr class='<%# Container.ItemIndex % 2 == 0 ? "bg-gray-50" : "bg-gray-100" %>'>
                                    <td class="px-6 py-3"><%# Eval("CarID") %></td>
                                    <td class="px-6 py-3"><%# Eval("Brand") %></td>
                                    <td class="px-6 py-3"><%# Eval("Model") %></td>
                                    <td class="px-6 py-3"><%# Eval("Year") %></td>
                                    <td class="px-6 py-3"><%# Eval("Transmission") %></td>
                                    <td class="px-6 py-3"><%# Eval("LicensePlate") %></td>
                                    <td class="px-6 py-3"><%# Eval("Insurance") %></td>
                                    <td class="px-6 py-3"><%# Eval("VINNumber") %></td>
                                    <td class="px-6 py-3"><%# Eval("TypeName") %></td>
                                    <td class="px-6 py-3"><%# Eval("BranchName") %></td>
                                    <td class="px-6 py-3"><%# Eval("InSituation") %></td>




                                    <!-- Butonların olduğu hücre -->
                                    <td class="px-6 py-3" style="display: flex; gap: 0.5rem; justify-content: center; align-items: center;">
                                        <asp:Button ID="InfoButton" runat="server" Text="Düzenle" CommandArgument='<%# Eval("CarId") %>'
                                            OnClick="InfoButton_Click" CssClass="bg-yellow-500 hover:bg-yellow-600 text-white py-1 px-3 rounded-md transition" />
                                        <asp:Button ID="DeleteBtn" runat="server" Text="Sil" CommandArgument='<%# Eval("CarId") %>'
                                            OnClick="DeleteBtn_Click" CssClass="bg-red-600 hover:bg-red-700 text-white py-1 px-3 rounded-md transition"
                                            OnClientClick="return confirm('Arabayı silmek istediğinize emin misiniz?');" />
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
