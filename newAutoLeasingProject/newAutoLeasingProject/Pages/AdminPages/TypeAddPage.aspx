<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="TypeAddPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.TypeAddPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="AddTypeForm" runat="server" class="max-w-lg mx-auto mt-10 bg-white p-8 shadow-md rounded-lg">
        <h1 class="text-2xl font-bold text-center text-gray-700 mb-6">Araç Tipi Kayıt Formu</h1>

        <!-- Type Name -->
        <div class="mb-4">
            <label for="TypeName" class="block text-sm font-medium text-gray-700 mb-1">Araç Tipi Adı</label>
            <asp:TextBox
                ID="TypeNameTxt"
                runat="server"
                placeholder="Araç Tipi Adını Girin"
                CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none" />
        </div>

        <!-- Daily Fee -->
        <div class="mb-4">
            <label for="DailyFee" class="block text-sm font-medium text-gray-700 mb-1">Günlük Ücret</label>
            <asp:TextBox
                ID="DailyFeeTxt"
                runat="server"
                placeholder="Günlük Ücreti Girin"
                TextMode="Number"
                CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none" />
        </div>

        <div>
            <asp:Button ID="AddTypeBtn" runat="server" Text="Ekle" OnClick="AddTypeBtn_Click" CssClass="w-full bg-blue-600 hover:bg-blue-700 text-white py-2 px-4 rounded-lg font-semibold transition" />
        </div>


    </form>
</asp:Content>
