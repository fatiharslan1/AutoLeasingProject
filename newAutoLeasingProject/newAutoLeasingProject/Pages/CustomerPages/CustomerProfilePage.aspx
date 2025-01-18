<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CustomerPages/CustomerLayout.Master" AutoEventWireup="true" CodeBehind="CustomerProfilePage.aspx.cs" Inherits="newAutoLeasingProject.Pages.CustomerPages.CustomerProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" class="space-y-8 bg-gray-100 p-6 rounded-lg shadow-lg" runat="server">
        <!-- Başlık -->
        <h1 class="text-3xl font-extrabold text-gray-800 mb-8">Müşteri Detay</h1>

        <div class="grid grid-cols-1 md:grid-cols-2 gap-8">
            <!-- Update Form -->
            <div class="bg-white p-6 rounded-lg shadow">
                <h2 class="text-xl font-bold text-gray-700 mb-6">Müşteri Bilgisi</h2>
                <form method="post" asp-action="UpdateCustomer" asp-controller="Customer" class="space-y-4">
                    <input type="hidden" asp-for="Customer.CustomerID" />

                    <div>
                        <asp:Label ID="FirstNameLabel" runat="server" Text="Ad" CssClass="block text-sm font-medium text-gray-600"></asp:Label>
                        <asp:TextBox ID="FirstNameTxt" runat="server" CssClass="w-full mt-1 p-3 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="LastNameLabel" runat="server" Text="Soyad" CssClass="block text-sm font-medium text-gray-600"></asp:Label>
                        <asp:TextBox ID="LastNameTxt" runat="server" CssClass="w-full mt-1 p-3 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="PhoneNumberLabel" runat="server" Text="Telefon Numarası" CssClass="block text-sm font-medium text-gray-600"></asp:Label>
                        <asp:TextBox ID="PhoneNumberTxt" runat="server" TextMode="Phone" CssClass="w-full mt-1 p-3 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="EmailLabel" runat="server" Text="Email" CssClass="block text-sm font-medium text-gray-600"></asp:Label>
                        <asp:TextBox ID="EmailTxt" runat="server" CssClass="w-full mt-1 p-3 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="AgeLabel" runat="server" Text="Yaş" CssClass="block text-sm font-medium text-gray-600"></asp:Label>
                        <asp:TextBox ID="AgeTxt" runat="server" TextMode="Number" CssClass="w-full mt-1 p-3 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="InsuranceLabel" runat="server" Text="Sigorta" CssClass="block text-sm font-medium text-gray-600"></asp:Label>
                        <asp:TextBox ID="InsuranceTxt" runat="server" CssClass="w-full mt-1 p-3 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="DriverLicenseLabel" runat="server" Text="Ehliyet" CssClass="block text-sm font-medium text-gray-600"></asp:Label>
                        <asp:TextBox ID="DriverLicenseTxt" runat="server" CssClass="w-full mt-1 p-3 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="UpdateBtn" runat="server" Text="Güncelle" CssClass="w-full bg-blue-600 text-white py-3 px-4 rounded-lg hover:bg-blue-700"></asp:Button>
                    </div>
                </form>
            </div>

            <!-- Transaction Table -->
            <div class="bg-white p-6 rounded-lg shadow">
                <h2 class="text-xl font-bold text-gray-700 mb-6">Şube Çalışanları</h2>
                <div class="overflow-x-auto">
                    <asp:GridView ID="EmployeeGridView" runat="server" AutoGenerateColumns="false" CssClass="w-full border-collapse border border-gray-300 text-sm">
                        <Columns>
                            <asp:BoundField DataField="TransactionID" HeaderText="İşlem ID" />
                            <asp:BoundField DataField="PickupDateTime" HeaderText="Başlangıç Tarihi" />
                            <asp:BoundField DataField="DropDateTime" HeaderText="Bitiş Tarihi" />
                            <asp:BoundField DataField="TotalFee" HeaderText="Toplam Ücret" />
                            <asp:BoundField DataField="CarInfo" HeaderText="Araç (Marka ve Model)" />
                            <asp:BoundField DataField="Name" HeaderText="Şube Adı" />
                        </Columns>
                        <HeaderStyle CssClass="bg-gray-200 text-gray-800" />
                        <RowStyle CssClass="hover:bg-gray-50" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
