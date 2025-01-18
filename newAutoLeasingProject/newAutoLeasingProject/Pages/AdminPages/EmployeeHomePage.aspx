<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="EmployeeHomePage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.EmployeeHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
    <html lang="en">
    <head runat="server">
        <meta charset="UTF-8">
        <title>Ana Sayfa</title>
        <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet">
    </head>
    <body class="bg-gray-100 text-gray-900">
        <form id="form1" runat="server" class="container mx-auto p-4">
            <!-- Başlık -->
            <h1 class="text-3xl font-bold mb-6">Ana Sayfa</h1>

            <!-- Navigasyon Butonları -->
            <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4 mb-8">
                <asp:Button ID="btnAddCarPage" runat="server" Text="Yeni Araç" OnClick="btnAddCarPage_Click" CssClass="btn bg-blue-500 text-white py-2 px-4 rounded-md" />
                <asp:Button ID="btnTransactionPage" runat="server" Text="İşlem Bilgisi" OnClick="btnTransactionPage_Click" CssClass="btn bg-green-500 text-white py-2 px-4 rounded-md" />
                <asp:Button ID="btnCarTypePage" runat="server" Text="Yeni Araba Türü " OnClick="btnCarTypePage_Click" CssClass="btn bg-yellow-500 text-white py-2 px-4 rounded-md" />
                <asp:Button ID="btnBranchAddPage" runat="server" Text="Yeni Şube" OnClick="btnBranchAddPage_Click" CssClass="btn bg-purple-500 text-white py-2 px-4 rounded-md" />
                <asp:Button ID="btnServiceInfo" runat="server" Text="Araç Servis" OnClick="btnServisInfo_Click" CssClass="btn bg-red-500 text-white py-2 px-4 rounded-md" />
                <asp:Button ID="btnEmployeePage" runat="server" Text="Çalışan Bilgisi" OnClick="btnEmployeePage_Click" CssClass="btn bg-indigo-500 text-white py-2 px-4 rounded-md" />
                <asp:Button ID="btnBranchReportPage" runat="server" Text="Şube Raporu" OnClick="btnBranchReportPage_Click" CssClass="btn bg-orange-500 text-white py-2 px-4 rounded-md" />
                <asp:Button ID="btnProfilePage" runat="server" Text="Profilim" OnClick="btnProfilePage_Click" CssClass="btn bg-pink-500 text-white py-2 px-4 rounded-md" />
                <asp:Button ID="btnExit" runat="server" Text="Çıkış Yap" OnClick="btnExitPage_Click" CssClass="btn bg-orange-500 text-white py-2 px-4 rounded-md" />
            </div>

        </form>
    </body>
    </html>

</asp:Content>
