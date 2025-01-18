<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CustomerPages/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerSignUpPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.CustomerPages.CustomerSignUpPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form id="SignUp" runat="server" class="max-w-lg mx-auto mt-10 bg-white p-8 shadow-md rounded-lg">
        <h1 class="text-2xl font-bold text-center text-gray-700 mb-6">Kayıt Ol</h1>

        <!-- Ad -->
        <div class="mb-4">
            <label for="ad" class="block text-sm font-medium text-gray-700 mb-1">Ad</label>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Adınız" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Soyad -->
        <div class="mb-4">
            <label for="soyad" class="block text-sm font-medium text-gray-700 mb-1">Soyad</label>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Soyadınız" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Email -->
        <div class="mb-4">
            <label for="Email" class="block text-sm font-medium text-gray-700 mb-1">Email</label>
            <asp:TextBox type="email" ID="TextBox5" runat="server" placeholder="Emailiniz" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>
        <!-- Telefon Numarası -->
        <div class="mb-4">
            <label for="telefon" class="block text-sm font-medium text-gray-700 mb-1">Telefon Numarası</label>
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Telefon numaranız" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Yaş -->
        <div class="mb-4">
            <label for="yas" class="block text-sm font-medium text-gray-700 mb-1">Yaş</label>
            <asp:TextBox ID="TextBox4" runat="server" placeholder="Yaşınız" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Sigorta -->
        <div class="mb-4">
            <label for="Insurance" class="block text-sm font-medium text-gray-700 mb-1">Sigorta</label>
            <asp:DropDownList ID="Insurance" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none">
                <asp:ListItem Text="Sigorta durumunu seçiniz" Value="" Disabled="True" Selected="True" />
                <asp:ListItem Text="Evet" Value="Evet" />
                <asp:ListItem Text="Hayır" Value="Hayır" />
            </asp:DropDownList>
        </div>

        <!-- Ehliyet Sınıfı -->
        <div class="mb-6">
            <label for="DriverLicenseClassType" class="block text-sm font-medium text-gray-700 mb-1">Ehliyet Sınıfı</label>
            <asp:DropDownList ID="DriverLicenseClassType" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none">
                <asp:ListItem Text="Ehliyet sınıfınızı seçiniz" Value="" Disabled="True" Selected="True" />
                <asp:ListItem Text="A1" Value="A1" />
                <asp:ListItem Text="A2" Value="A2" />
                <asp:ListItem Text="A" Value="A" />
                <asp:ListItem Text="B" Value="B" />
                <asp:ListItem Text="C" Value="C" />
                <asp:ListItem Text="D" Value="D" />
                <asp:ListItem Text="F" Value="F" />
                <asp:ListItem Text="G" Value="G" />
            </asp:DropDownList>
        </div>

        <!-- Şifre -->
        <div class="mb-4">
            <label for="Password" class="block text-sm font-medium text-gray-700 mb-1">Şifre</label>
            <asp:TextBox type="password" ID="TextBox6" runat="server" placeholder="Şifreniz" CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none"></asp:TextBox>
        </div>

        <!-- Gönder Butonu -->
        <div>
            <asp:Button ID="CustomerRegisterBtn" runat="server" Text="Kaydol" OnClick="CustomerRegisterBtn_Click"
                CssClass="w-full bg-blue-600 hover:bg-blue-700 text-white py-2 px-4 rounded-lg font-semibold transition" />
        </div>
          <!-- Dinamik Hata Mesajı -->
            <asp:Label ID="lblMessage" runat="server" Visible="false" CssClass="block mt-4 text-sm text-center text-red-500"></asp:Label>
    </form>
</asp:Content>
