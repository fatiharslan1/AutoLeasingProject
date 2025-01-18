<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="BranchAddPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.BranchAddPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="AddBranchForm" runat="server" class="max-w-lg mx-auto mt-10 bg-white p-8 shadow-md rounded-lg">
        <h1 class="text-2xl font-bold text-center text-gray-700 mb-6">Şube Kayıt Formu</h1>

        <!-- Branch Name -->
        <div class="mb-4">
              
            <label for="BranchName" class="block text-sm font-medium text-gray-700 mb-1">Şube Adı</label>
            <asp:TextBox
                ID="BranchNameTxt"
                runat="server"
                placeholder="Şube Adını Girin"
                CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none" />
        </div>

        <!-- City -->
        <div class="mb-4">
            <label for="City" class="block text-sm font-medium text-gray-700 mb-1">Şehir</label>
            <asp:TextBox
                ID="CityTxt"
                runat="server"
                placeholder="Şehir Adını Girin"
                CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none" />
        </div>

        <!-- Province -->
        <div class="mb-4">
            <label for="Province" class="block text-sm font-medium text-gray-700 mb-1">İlçe</label>
            <asp:TextBox
                ID="ProvinceTxt"
                runat="server"
                placeholder="İlçe Adını Girin"
                CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none" />
        </div>

        <!-- Country -->
        <div class="mb-4">
            <label for="Country" class="block text-sm font-medium text-gray-700 mb-1">Ülke</label>
            <asp:TextBox
                ID="CountryTxt"
                runat="server"
                placeholder="Ülke Adını Girin"
                CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none" />
        </div>

        <!-- Street Address -->
        <div class="mb-4">
            <label for="StreetAddress" class="block text-sm font-medium text-gray-700 mb-1">Sokak Adresi</label>
            <asp:TextBox
                ID="StreetAddressTxt"
                runat="server"
                placeholder="Sokak Adresini Girin"
                CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none" />
        </div>

        <!-- Phone -->
        <div class="mb-4">
            <label for="Phone" class="block text-sm font-medium text-gray-700 mb-1">Telefon Numarası</label>
            <asp:TextBox
                ID="PhoneTxt"
                runat="server"
                placeholder="Telefon Numarasını Girin"
                CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none" />
        </div>

        <!-- Submit Button -->
        <div class="text-center">
            <asp:Button ID="AddbranchBtn" runat="server" Text="Kaydet" OnClick="AddBranchBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>


    </form>
</asp:Content>
