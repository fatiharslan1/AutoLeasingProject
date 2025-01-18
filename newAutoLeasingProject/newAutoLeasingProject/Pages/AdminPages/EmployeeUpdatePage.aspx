<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="EmployeeUpdatePage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.EmployeeUpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex items-center justify-center min-h-screen bg-gray-100">
        <form method="post" class="space-y-4" runat="server">
            <div class="p-4 md:p-8 bg-white rounded-lg shadow-lg w-full max-w-4xl">
                <!-- Başlık -->
                <h1 class="text-2xl font-bold mb-6 text-center">Çalışan Detay Sayfası</h1>

                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                    <!-- Update Form -->
                    <div class="bg-gray-50 shadow-md rounded-lg p-6">
                        <h2 class="text-xl font-bold mb-4 text-center">Çalışan Bilgisi</h2>
                        <input type="hidden" id="EmployeeID" runat="server" />

                        <div>
                            <asp:Label ID="BranchIDLabel" runat="server" Text="Şube" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="BranchIDTxt" runat="server" CssClass="mt-1 block w-full p-3 text-center text-lg border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="FirstNameLabel" runat="server" Text="Ad" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="FirstNameTxt" runat="server" CssClass="mt-1 block w-full p-3 text-center text-lg border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="LastNameLabel" runat="server" Text="Soyad" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="LastNameTxt" runat="server" CssClass="mt-1 block w-full p-3 text-center text-lg border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="PhoneNumberLabel" runat="server" Text="Telefon Numarası" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="PhoneNumberTxt" runat="server" TextMode="Phone" CssClass="mt-1 block w-full p-3 text-center text-lg border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="EmailLabel" runat="server" Text="Email" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="EmailTxt" runat="server" TextMode="Email" CssClass="mt-1 block w-full p-3 text-center text-lg border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="SalaryLabel" runat="server" Text="Maaş" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="SalaryTxt" runat="server" TextMode="Number" CssClass="mt-1 block w-full p-3 text-center text-lg border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="PositionLabel" runat="server" Text="Pozisyon" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="PositionTxt" runat="server" CssClass="mt-1 block w-full p-3 text-center text-lg border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="StatusLabel" runat="server" Text="Durum" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="StatusTxt" runat="server" CssClass="mt-1 block w-full p-3 text-center text-lg border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                        </div>                      
                        <div class="text-right">
                            <asp:Button ID="UpdateEmployeeBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" CssClass="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>

