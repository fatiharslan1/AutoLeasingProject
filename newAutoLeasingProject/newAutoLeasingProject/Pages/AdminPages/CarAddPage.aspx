<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="CarAddPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.AddCarPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="SignUp" runat="server" class="max-w-lg mx-auto mt-10 bg-white p-8 shadow-md rounded-lg">
        <h1 class="text-2xl font-bold text-center text-gray-700 mb-6">Araç Kayıt Formu</h1>

        <asp:HiddenField ID="BranchIDHiddenField" runat="server" />

        <!-- Marka -->
        <div class="mb-4">
            <label for="Brand" class="block text-sm font-medium text-gray-700 mb-1">Marka</label>
            <asp:TextBox ID="BrandTxt" runat="server" placeholder="Marka" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Model -->
        <div class="mb-4">
            <label for="Model" class="block text-sm font-medium text-gray-700 mb-1">Model</label>
            <asp:TextBox ID="ModelTxt" runat="server" placeholder="Model" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>
        <!-- Vites Seçimi (Transmission) -->
        <div class="mb-4">
            <label for="Transmission" class="block text-sm font-medium text-gray-700 mb-1">Vites Tipi</label>
            <asp:DropDownList ID="TransmissionDropDown" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none">
                <asp:ListItem Text="Vites Tipi Seçiniz" Value="" Disabled="True" Selected="True" />
                <asp:ListItem Text="Otomatik" Value="True" />
                <asp:ListItem Text="Manuel" Value="False" />
            </asp:DropDownList>
        </div>

        <!-- Yıl -->
        <div class="mb-4">
            <label for="Year" class="block text-sm font-medium text-gray-700 mb-1">Yıl</label>
            <asp:TextBox ID="YearTxt" runat="server" placeholder="Yıl" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- VIN Numarası -->
        <div class="mb-4">
            <label for="VINNumber" class="block text-sm font-medium text-gray-700 mb-1">VIN Numarası</label>
            <asp:TextBox ID="VINNumberTxt" runat="server" placeholder="VIN Numarası" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Plaka -->
        <div class="mb-4">
            <label for="LicensePlate" class="block text-sm font-medium text-gray-700 mb-1">Plaka</label>
            <asp:TextBox ID="LicensePlateTxt" runat="server" placeholder="Plaka" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Kayıt Tarihi -->
        <div class="mb-4">
            <label for="Registration" class="block text-sm font-medium text-gray-700 mb-1">Kayıt Tarihi</label>
            <asp:TextBox ID="RegistrationTxt" TextMode="Date" runat="server" placeholder="Kayıt Tarihi" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Sigorta -->
        <div class="mb-4">
            <label for="Insurance" class="block text-sm font-medium text-gray-700 mb-1">Sigorta Durumu</label>
            <asp:DropDownList ID="InsuranceDropdown" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none">
                <asp:ListItem Text="Sigorta Durumu" Value="" Disabled="True" Selected="True" />
                <asp:ListItem Text="Var" Value="True" />
                <asp:ListItem Text="Yok" Value="False" />
            </asp:DropDownList>
        </div>


        <!-- Hizmete Giriş -->
        <div>
            <asp:Label ID="InSituation" runat="server" Text="Servis Durumu" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
            <asp:DropDownList ID="InSituationDropdown" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                <asp:ListItem Text="Herhangi Biri" Value="" Selected="false"></asp:ListItem>
                <asp:ListItem Text="Servis" Value="Servis"></asp:ListItem>
                <asp:ListItem Text="Müsait" Value="Müsait"></asp:ListItem>
                <asp:ListItem Text="Kirada" Value="Kirada"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <!-- Araç Tipi -->
        <div class="mb-4">
            <label for="TypeName" class="block text-sm font-medium text-gray-700 mb-1">Araç Tipi</label>
            <asp:DropDownList ID="TypeNameTxt" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none">
                <asp:ListItem Text="Araç Tipi seçiniz" Value="" Disabled="True" Selected="True" />
            </asp:DropDownList>
        </div>

        <!-- Yakıt Türü -->
        <div>
            <asp:Label ID="FuelType" runat="server" Text="Yakıt Türü" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
            <asp:DropDownList ID="FuelTypeDropDown" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                <asp:ListItem Text="Herhangi Biri" Value="" Selected="Null"></asp:ListItem>
                <asp:ListItem Text="Benzin" Value="Benzin"></asp:ListItem>
                <asp:ListItem Text="Dizel" Value="Dizel"></asp:ListItem>
                <asp:ListItem Text="Hybrid" Value="Hybrid"></asp:ListItem>
                <asp:ListItem Text="Elektrik" Value="Elektrik"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <!-- Araç KM -->
        <div class="mb-4">
            <label for="CarKM" class="block text-sm font-medium text-gray-700 mb-1">Araç Kilometresi</label>
            <asp:TextBox ID="CarKMTxt" runat="server" Text="0" placeholder="0" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Araç Görseli -->
        <div class="mb-4">
            <label for="CarImage" class="block text-sm font-medium text-gray-700 mb-1">Araç Görseli</label>
            <asp:TextBox ID="CarImageTxt" runat="server" placeholder="Araç görselinin URL'sini girin" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>


        <!-- Gönder Butonu -->
        <div class="text-center">
            <asp:Button ID="AddCarBtn" runat="server" Text="Ekle" OnClick="AddCarBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>
    </form>

</asp:Content>

