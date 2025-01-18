<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="EmployeeInfoPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.EmployeeInfoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <!-- Filters Section -->
        <div class="flex gap-6 mb-6">
            <!-- Filters -->
            <div class="w-1/4 bg-gray-50 p-4 rounded-lg shadow-md">
                <h3 class="text-lg font-semibold mb-4">Filtreler</h3>
                <div class="space-y-4">

                    <div class="mb-4">
                        <label for="FirstName" class="block text-sm font-medium text-gray-700 mb-1">Ad</label>
                        <asp:TextBox ID="FirstNameTextBox" runat="server" placeholder="Ad" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
                    </div>


                    <div>
                        <asp:Label ID="StatusLabel" runat="server" Text="Durum" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:DropDownList ID="StatusDropDown" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                            <asp:ListItem Text="Tümü" Value="" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="Aktif" Value="Aktif"></asp:ListItem>
                            <asp:ListItem Text="Pasif" Value="Pasif"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtrele ve Temizle Butonları -->
                    <div class="text-center">
                        <asp:Button ID="FilterBtn" runat="server" Text="Filitrele" OnClick="FilterBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                        <asp:Button ID="ClearBtn" runat="server" Text="Temizle" OnClick="ClearBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                    </div>
                </div>
            </div>


            <!-- Employee Listings -->
            <div class="flex-1 space-y-6">
                <div>
                    <asp:Button ID="BtnAdd" runat="server" Text="Yeni Çalışan" OnClick="AddBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />

                </div>
                <!-- Employee Table -->
                <table class="min-w-full bg-white border border-gray-300 rounded-lg shadow-lg">
                    <thead class="bg-gray-100">
                        <tr>
                            <th class="px-6 py-3 text-left font-semibold">Çalışan ID</th>
                            <th class="px-6 py-3 text-left font-semibold">Ad</th>
                            <th class="px-6 py-3 text-left font-semibold">Soyad</th>
                            <th class="px-6 py-3 text-left font-semibold">Telefon</th>
                            <th class="px-6 py-3 text-left font-semibold">E-posta</th>
                            <th class="px-6 py-3 text-left font-semibold">Pozisyon</th>
                            <th class="px-6 py-3 text-left font-semibold">Durum</th>
                            <th class="px-6 py-3 text-left font-semibold">Şube ID</th>
                            <th class="px-6 py-3 text-left font-semibold">Yaş</th>
                            <th class="px-6 py-3 text-center font-semibold">Aksiyonlar</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="EmployeeRepeater" runat="server">
                            <ItemTemplate>
                                <tr class='<%# Container.ItemIndex % 2 == 0 ? "bg-gray-50" : "bg-gray-100" %>'>
                                    <td class="px-6 py-3"><%# Eval("EmployeeID") %></td>
                                    <td class="px-6 py-3"><%# Eval("FirstName") %></td>
                                    <td class="px-6 py-3"><%# Eval("LastName") %></td>
                                    <td class="px-6 py-3"><%# Eval("PhoneNumber") %></td>
                                    <td class="px-6 py-3"><%# Eval("Email") %></td>
                                    <td class="px-6 py-3"><%# Eval("Position") %></td>
                                    <td class="px-6 py-3"><%# Eval("Status") %></td>
                                    <td class="px-6 py-3"><%# Eval("BranchName") %></td>
                                    <td class="px-6 py-3"><%# Eval("BirthDate") %></td>
                                    <td class="px-6 py-3 text-center" style="display: flex; gap: 0.5rem; justify-content: center; align-items: center;">
                                        <asp:Button ID="InfoBtn" runat="server" Text="Güncelle" CommandArgument='<%# Eval("EmployeeID") %>'
                                            OnClick="InfoBtn_Click" CssClass="bg-yellow-500 hover:bg-yellow-600 text-white py-1 px-3 rounded-md transition" />
                                        <asp:Button ID="DeleteBtn" runat="server" Text="Sil" CommandArgument='<%# Eval("EmployeeID") %>'
                                            OnClick="DeleteBtn_Click" CssClass="bg-red-600 hover:bg-red-700 text-white py-1 px-3 rounded-md" OnClientClick="return confirm('Çalışanı silmek istediğinize emin misiniz?');" />
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
