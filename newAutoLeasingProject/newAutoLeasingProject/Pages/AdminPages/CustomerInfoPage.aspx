<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="CustomerInfoPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.CustomerInfoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <form id="form1" runat="server">
        <!-- Filters Section -->
        <div class="flex gap-6 mb-6">
           <div>
               <div>

               </div>
                <label class="block font-medium mb-1">Müşteri İsmi</label>
                <asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="w-full border p-2 rounded-md" />          
          
           <!-- Filter Button Section -->     
                <asp:Button ID="FilterBtn" runat="server" Text="Filtrele" OnClick="FilterBtn_Click" CssClass="bg-blue-600 hover:bg-blue-700 text-white py-2 px-4 rounded-lg font-semibold transition" />
           </div>
        </div>

        <!-- Customer Table Section -->
        <div class="flex-1 space-y-6">
           
            <!-- Customer Table -->
            <table class="min-w-full bg-white border border-gray-300 rounded-lg shadow-lg">
                <thead class="bg-gray-100">
                    <tr>
                        <th class="px-6 py-3 text-left font-semibold">ID</th>
                        <th class="px-6 py-3 text-left font-semibold">Ad</th>
                        <th class="px-6 py-3 text-left font-semibold">Soyad</th>
                        <th class="px-6 py-3 text-left font-semibold">Telefon</th>
                        <th class="px-6 py-3 text-left font-semibold">Yaş</th>
                        <th class="px-6 py-3 text-left font-semibold">Sigorta</th>
                        <th class="px-6 py-3 text-left font-semibold">Ehliyet Türü</th>
                        <th class="px-6 py-3 text-left font-semibold">Email</th>
                        <th class="px-6 py-3 text-left font-semibold">Şifre</th>
                        <th class="px-6 py-3 text-left font-semibold">İşlemler</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="CustomerRepeater" runat="server">
                        <ItemTemplate>
                            <tr class='<%# Container.ItemIndex % 2 == 0 ? "bg-gray-50" : "bg-gray-100" %>'>
                                <td class="px-6 py-3"><%# Eval("CustomerID") %></td>
                                <td class="px-6 py-3"><%# Eval("FirstName") %></td>
                                <td class="px-6 py-3"><%# Eval("LastName") %></td>
                                <td class="px-6 py-3"><%# Eval("PhoneNumber") %></td>
                                <td class="px-6 py-3"><%# Eval("Age") %></td>
                                <td class="px-6 py-3"><%# Eval("Insurance") %></td>
                                <td class="px-6 py-3"><%# Eval("DriverLicenseClassType") %></td>
                                <td class="px-6 py-3"><%# Eval("Email") %></td>
                                <td class="px-6 py-3"><%# Eval("Password") %></td>

                                <!-- Action Buttons -->
                                <td class="px-6 py-3 flex gap-2 justify-center">
                                    <asp:Button ID="EditBtn" runat="server" Text="Düzenle" CommandArgument='<%# Eval("CustomerID") %>' OnClick="EditBtn_Click" CssClass="bg-yellow-500 hover:bg-yellow-600 text-white py-1 px-3 rounded-md" />
                                    <asp:Button ID="DeleteBtn" runat="server" Text="Sil" CommandArgument='<%# Eval("CustomerID") %>' OnClick="DeleteBtn_Click" CssClass="bg-red-600 hover:bg-red-700 text-white py-1 px-3 rounded-md" OnClientClick="return confirm('Müşteriyi silmek istediğinize emin misiniz?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </form>
</asp:Content>
