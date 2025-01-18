<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="CarUpdatePage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.CarUpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <form method="post" class="space-y-4" runat="server">
        <div class="p-4 md:p-8">
            <!-- Başlık -->
            <h1 class="text-2xl font-bold mb-6">Araba Detayları</h1>

            <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                <!-- Update Form -->
                <div class="bg-white shadow-md rounded-lg p-6">
                    <h2 class="text-xl font-bold mb-4">Araba Bilgisi</h2>
                    <form method="post" asp-action="UpdateCar" asp-controller="Customer">
                        <input type="hidden" asp-for="Car.CarID" />

                        <div>
                            <asp:Label ID="Brand" runat="server" Text="Marka" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="BrandTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="Model" runat="server" Text="Model" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="ModelTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="Year" runat="server" Text="Yıl" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="YearTxt" runat="server" TextMode="Number" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div class="mb-4">
                            <asp:Label ID="VINNumber" runat="server" Text="Şase Numarası" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="VINNumberTxt" runat="server" TextMode="Number" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="LicensePlate" runat="server" Text="Plaka" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="LicensePlateTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="Registration" runat="server" Text="Araç Kayıt Tarihi" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="RegistrationTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="Insurance" runat="server" Text="Sigorta Durumu" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="InsuranceTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="InSituation" runat="server" Text="Servis Durumu" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:DropDownList ID="InSituationDropdown" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                                <asp:ListItem Text="Herhangi Biri" Value="" Selected="false"></asp:ListItem>
                                <asp:ListItem Text="Servis" Value="Servis"></asp:ListItem>
                                <asp:ListItem Text="Müsait" Value="Müsait"></asp:ListItem>
                                <asp:ListItem Text="Kirada" Value="Kirada"></asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <div>
                            <asp:Label ID="BranchName" runat="server" Text="Şube" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="BranchNameTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="TypeName" runat="server" Text="Araç Türü" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="TypeNameTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                         <div>
                            <asp:Label ID="CarImage" runat="server" Text="Araç Görsel Linki" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="CarImageTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                         <div>
                            <asp:Label ID="Transmission" runat="server" Text="Vites Tipi" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="TransmissionTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label ID="FuelType" runat="server" Text="Yakıt Türü" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="FuelTypeTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                         <div>
                            <asp:Label ID="CarKM" runat="server" Text="KiloMetre" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="CarKMTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
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
