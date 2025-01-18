<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="BranchUpdatePage.aspx.cs" Inherits="newAutoLeasingProject.Pages.BranchUpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" class="space-y-4" runat="server">
        <div class="p-4 md:p-8">
            <!-- Başlık -->
            <h1 class="text-2xl font-bold mb-6">Şube Detay</h1>

            <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                <!-- Update Form -->
                <div class="bg-white shadow-md rounded-lg p-6">
                    <h2 class="text-xl font-bold mb-4">Şube Bilgisi</h2>
                    <input type="hidden" id="BranchIDHidden" runat="server" value="<%= BranchID %>" />
                    
                    <div>
                        <asp:Label ID="NameLabel" runat="server" Text="Şube İsmi" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:TextBox ID="NameTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="CityLabel" runat="server" Text="İl" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:TextBox ID="CityTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="ProvinceLabel" runat="server" Text="İlçe" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:TextBox ID="ProvinceTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="CountryLabel" runat="server" Text="Ülke" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:TextBox ID="CountryTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="AddressLabel" runat="server" Text="Sokak" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:TextBox ID="AddressTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="PhoneLabel" runat="server" Text="Telefon Numarası" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:TextBox ID="PhoneTxt" runat="server" TextMode="Phone" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="BranchInfoUpdateBtn" runat="server" Text="Güncelle" CssClass="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600" OnClick="BranchInfoUpdateBtn_Click"></asp:Button>
                    </div>
                </div>

                <!-- Employee Table -->
                <div class="bg-gray-50 shadow-md rounded-lg p-6">
                    <h2 class="text-xl font-bold mb-4">Şube Çalışanları</h2>
                    <div class="overflow-x-auto">
                        <asp:GridView ID="EmployeeGridView" runat="server" AutoGenerateColumns="false" CssClass="min-w-full table-auto border-collapse border border-gray-300 text-sm">
                            <Columns>
                                <asp:BoundField DataField="EmployeeID" HeaderText="Çalışan ID" />
                                <asp:BoundField DataField="FirstName" HeaderText="Ad" />
                                <asp:BoundField DataField="LastName" HeaderText="SoyAd" />
                                <asp:BoundField DataField="Position" HeaderText="Pozisyon" />
                                <asp:BoundField DataField="PhoneNumber" HeaderText="Telefon Numarası" />
                            </Columns>
                            <HeaderStyle CssClass="bg-gray-100" />
                            <RowStyle CssClass="hover:bg-gray-50" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
