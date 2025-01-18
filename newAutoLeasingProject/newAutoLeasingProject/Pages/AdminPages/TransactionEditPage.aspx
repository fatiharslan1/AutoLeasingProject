<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="TransactionEditPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.TransactionEditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex justify-center items-center min-h-screen bg-gray-100">
        <form id="form1" runat="server" class="space-y-4 bg-white p-8 shadow-md rounded-lg w-full max-w-lg">
            <h1 class="text-2xl font-bold text-center text-gray-700 mb-6">Teslim Alma Tarihi Güncelleme Formu</h1>

            <!-- Hidden Field for Transaction ID -->
            <asp:HiddenField ID="TransactionIDHiddenField" runat="server" />
            <asp:HiddenField ID="PickupDateTimeHiddenField" runat="server" />
            <asp:HiddenField ID="CarIDHiddenField" runat="server" />
            <asp:HiddenField ID="DailyFeeHiddenField" runat="server" />
            <asp:HiddenField ID="TotalFeeHiddenField" runat="server" />
            <asp:Label ID="ErrorMessage" runat="server" CssClass="text-red-500" />

            <!-- Drop Date Time -->
            <div class="mb-4">
                <label for="DropDateTime" class="block text-sm font-medium text-gray-700 mb-1">Bırakma Tarihi</label>
                <asp:TextBox
                    ID="DropDateTimeTextBox"
                    runat="server"
                    TextMode="Date"
                    placeholder="Yeni Tarih Seçiniz"
                    CssClass="w-full border border-gray-300 p-2 rounded-lg focus:ring-2 focus:ring-blue-500 focus:outline-none" />
            </div>

            <!-- Total Fee -->
            <div class="mb-4">
                <label for="TotalFee" class="block text-sm font-medium text-gray-700 mb-1">Yeni Ücret</label>
                <asp:TextBox
                    ID="TotalFeeLabel"
                    runat="server"
                    placeholder="Yeni Ücret Otomatik Hesaplanır"
                    TextMode="Number"
                    ReadOnly="true"
                    CssClass="w-full border border-gray-300 bg-gray-100 p-2 rounded-lg focus:outline-none cursor-not-allowed" />
            </div>

            <!-- Update Button -->
            <div class="flex justify-center">
                <asp:Button
                    ID="UpdateButton"
                    runat="server"
                    Text="Güncelle"
                    CssClass="bg-blue-500 hover:bg-blue-600 text-white py-2 px-4 rounded-md"
                    OnClick="UpdateButton_Click" />
            </div>
        </form>
    </div>
</asp:Content>
