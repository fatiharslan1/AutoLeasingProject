<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="EmployeeAddPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.EmployeeAddPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="SignUp" runat="server" class="max-w-lg mx-auto mt-10 bg-white p-8 shadow-md rounded-lg">
        <h1 class="text-2xl font-bold text-center text-gray-700 mb-6">Çalışan Kayıt Formu</h1>

        <!-- Branch ID (Şube) -->
        <div class="mb-4">
            <label for="BranchID" class="block text-sm font-medium text-gray-700 mb-1">Şube</label>
            <asp:DropDownList ID="BranchIDTxt" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none">
                <asp:ListItem Text="Şube seçiniz" Value="" Disabled="True" Selected="True" />

            </asp:DropDownList>
        </div>

        <!-- Ad -->
        <div class="mb-4">
            <label for="FirstName" class="block text-sm font-medium text-gray-700 mb-1">Ad</label>
            <asp:TextBox ID="FirstNameTxt" runat="server" placeholder="Adınız" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Soyad -->
        <div class="mb-4">
            <label for="LastName" class="block text-sm font-medium text-gray-700 mb-1">Soyad</label>
            <asp:TextBox ID="LastNameTxt" runat="server" placeholder="Soyadınız" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Telefon Numarası -->
        <div class="mb-4">
            <label for="PhoneNumber" class="block text-sm font-medium text-gray-700 mb-1">Telefon Numarası</label>
            <asp:TextBox ID="PhoneNumberTxt" runat="server" placeholder="Telefon numaranız" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Email -->
        <div class="mb-4">
            <label for="Email" class="block text-sm font-medium text-gray-700 mb-1">Email</label>
            <asp:TextBox type="email" ID="EmailTxt" runat="server" placeholder="Emailiniz" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Maaş -->
        <div class="mb-4">
            <label for="Salary" class="block text-sm font-medium text-gray-700 mb-1">Maaş</label>
            <asp:TextBox ID="SalaryTxt" runat="server" placeholder="Maaş" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Pozisyon -->
        <div class="mb-4">
            <label for="Position" class="block text-sm font-medium text-gray-700 mb-1">Pozisyon</label>
            <asp:TextBox ID="PositionTxt" runat="server" placeholder="Pozisyonunuz" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Statü -->
        <div class="mb-4">
            <label for="Status" class="block text-sm font-medium text-gray-700 mb-1">Statü</label>
            <asp:DropDownList ID="StatusTxt" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none">
                <asp:ListItem Text="Statü seçiniz" Value="" Disabled="True" Selected="True" />
                <asp:ListItem Text="Aktif" Value="Aktif" />
                <asp:ListItem Text="Pasif" Value="Pasif" />
            </asp:DropDownList>
        </div>

        <!-- Password -->
        <div class="mb-4">
            <label for="Password" class="block text-sm font-medium text-gray-700 mb-1">Password</label>
            <asp:TextBox ID="PasswordTxt" runat="server" placeholder="Password" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Doğum Tarihi -->
        <div class="mb-4">
            <label for="Age" class="block text-sm font-medium text-gray-700 mb-1">Age</label>
            <asp:TextBox ID="AgeTxt" runat="server" placeholder=" Doğum Tarihini Giriniz" TextMode="DateTime" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Sosyal Sigorta Numarası (SIN) -->
        <div class="mb-4">
            <label for="SIN" class="block text-sm font-medium text-gray-700 mb-1">Sosyal Sigorta Numarası (SIN)</label>
            <asp:TextBox ID="SINTxt" runat="server" placeholder="SIN numaranızı girin" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Gönder Butonu -->
        <div class="text-center">
            <asp:Button ID="AddEmployeeBtn" runat="server" Text="Kaydet" OnClick="AddEmployeeBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>
    </form>
</asp:Content>
