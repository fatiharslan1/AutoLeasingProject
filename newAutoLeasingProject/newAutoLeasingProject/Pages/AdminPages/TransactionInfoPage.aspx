<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="TransactionInfoPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.TransactionInfoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" class="space-y-4" runat="server">
        <asp:HiddenField ID="BranchIDHiddenField" runat="server" />

        <table class="min-w-full bg-white border border-gray-300 rounded-lg shadow-lg">
            <thead class="bg-gray-100">
                <tr>
                    <th class="px-6 py-3 text-left font-semibold">Araba Bilgisi</th>
                    <th class="px-6 py-3 text-left font-semibold">Müşteri Adı</th>
                    <th class="px-6 py-3 text-left font-semibold">Alma Tarihi</th>
                    <th class="px-6 py-3 text-left font-semibold">Bırakma Tarihi</th>
                    <th class="px-6 py-3 text-left font-semibold">Toplam Ücret</th>
                    <th class="px-6 py-3 text-left font-semibold">Geç Teslim Ücreti</th>
                    <th class="px-6 py-3 text-left font-semibold">İşlemler</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr class='<%# Container.ItemIndex % 2 == 0 ? "bg-gray-50" : "bg-gray-100" %>'>
                            <!-- Birleştirilmiş Müşteri Adı -->
                            <td class="px-6 py-3"><%# Eval("FullName") %></td>
                            <!-- Birleştirilmiş Araba Bilgisi -->
                            <td class="px-6 py-3"><%# Eval("CarDetails") %></td>
                            <!-- Alma Tarihi -->
                            <td class="px-6 py-3"><%# Eval("PickupDateTime", "{0:yyyy-MM-dd HH:mm}") %></td>
                            <!-- Bırakma Tarihi -->
                            <td class="px-6 py-3"><%# Eval("DropDateTime", "{0:yyyy-MM-dd HH:mm}") %></td>
                            <td class="px-6 py-3"><%# Eval("TotalFee") %></td>
                            <td class="px-6 py-3"><%# Eval("LateFee") %></td>
                            <td class="px-6 py-3" style="display: flex; gap: 0.5rem; justify-content: center; align-items: center;">
                                <asp:Button ID="InfoButton" runat="server" Text="Düzenle" CommandArgument='<%# Eval("TransactionID") %>'
                                    OnClick="InfoButton_Click" CssClass="bg-yellow-500 hover:bg-yellow-600 text-white py-1 px-3 rounded-md transition" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>


    </form>
</asp:Content>
