<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLogInLayout.Master" AutoEventWireup="true" CodeBehind="EmployeeLogInPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.EmployeeLogInPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="SignUp" runat="server">
        <!-- Giriş Formu Başlangıcı -->
        <div class="bg-white p-8 rounded-lg shadow-lg w-full max-w-sm mx-auto mt-20">
            <h2 class="text-2xl font-bold text-center mb-6 text-gray-800">Giriş Yap</h2>

            <!-- Hata Mesajı -->
            <div id="error-message" class="hidden bg-red-500 text-white text-center py-2 rounded mb-4">
                <span>Geçersiz kullanıcı adı veya şifre.</span>
            </div>

            <!-- Form Başlangıcı -->
            <div>
                <div class="mb-4">
                    <label for="email" class="block text-sm font-semibold text-gray-600">E-posta</label>
                    <asp:TextBox Type="email" ID="EmailTxt" runat="server" CssClass="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500" Placeholder="E-posta adresinizi girin" Required="true" />
                </div>

                <div class="mb-4">
                    <label for="password" class="block text-sm font-semibold text-gray-600">Şifre</label>
                    <asp:TextBox type="password" ID="PasswordTxt" runat="server" TextMode="Password" CssClass="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500" Placeholder="Şifrenizi girin" Required="true" />
                </div>


                <!-- Giriş Yap Butonu -->
                <asp:Button ID="EmployeeLoginBtn" runat="server" Text="Giriş Yap" OnClick="EmployeeLoginBtn_Click" CssClass="w-full bg-blue-600 hover:bg-blue-700 text-white py-2 px-4 rounded-lg font-semibold transition" />
            </div>



            <!-- Dinamik Hata Mesajı -->
            <asp:Label ID="lblMessage" runat="server" Visible="false" CssClass="block mt-4 text-sm text-center text-red-500"></asp:Label>
        </div>
        <!-- Giriş Formu Bitişi -->
    </form>
</asp:Content>

