<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="CustomerUpdatePage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.CustomerUpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form method="post" class="space-y-4" runat="server">
        <div class="p-4 md:p-8">
            <!-- Başlık -->
            <h1 class="text-2xl font-bold mb-6"> Müşteri Detay</h1>

            <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                <!-- Update Form -->
                <div class="bg-white shadow-md rounded-lg p-6">
                    <h2 class="text-xl font-bold mb-4">Müşteri Bilgisi</h2>
                    <form method="post" asp-action="UpdateCustomer" asp-controller="Customer">
                        <input type="hidden" asp-for="Customer.CustomerID" />

                        <div>
                            <asp:Label ID="FirstNameLabel" runat="server" Text="Ad" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="FirstNameTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="LastNameLabel" runat="server" Text="Soyad" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="LastNameTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="PhoneNumberLabel" runat="server" Text="Telefon Numarası" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="PhoneNumberTxt" runat="server" TextMode="Phone" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div class="mb-4">
                            <label for="Email" class="block text-sm font-medium text-gray-700 mb-1">Email</label>
                            <asp:TextBox type="Email" ID="EmailTxt" runat="server" placeholder="Emailiniz" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="AgeLabel" runat="server" Text="Yaş" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="AgeTxt" runat="server" TextMode="Number" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="InsuranceLabel" runat="server" Text="Sigorta" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="InsuranceTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="DriverLicenseLabel" runat="server" Text="Ehliyet" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="DriverLicenseTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="UpdateBtn" runat="server" Text="Güncelle" CssClass="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600" OnClick="UpdateBtn_Click"></asp:Button>
                        </div>


                    </form>
                </div>

 
            </div>
        </div>
    </form>
</asp:Content>
