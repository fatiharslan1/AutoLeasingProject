<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="EmployeeProfilePage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.EmployeeProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form method="post" class="space-y-4" runat="server">
        <div class="p-4 md:p-8">
            <!-- Başlık -->
            <h1 class="text-2xl font-bold mb-6">Çalışan Detay</h1>

            <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
                <!-- Update Form -->
                <div class="bg-white shadow-md rounded-lg p-6">
                    <h2 class="text-xl font-bold mb-4">Çalışan Biilgisi</h2>
                    <form method="post">
                        <input type="hidden" id="EmployeeID" runat="server" />

                        <div>
                            <asp:Label ID="BranchIDLabel" runat="server" Text="Şube ID" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="BranchIDTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="FirstNameLabel" runat="server" Text="İsim" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="FirstNameTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="LastNameLabel" runat="server" Text="Soyad" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="LastNameTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="PhoneNumberLabel" runat="server" Text="Telefo Numarası" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="PhoneNumberTxt" runat="server" TextMode="Phone" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="EmailLabel" runat="server" Text="Email" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="EmailTxt" runat="server" TextMode="Email" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="SalaryLabel" runat="server" Text="Maaş" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="SalaryTxt" runat="server" TextMode="Number" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="PositionLabel" runat="server" Text="Pozisyon" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="PositionTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="StatusLabel" runat="server" Text="Durum" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="StatusTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                        </div>
                     
                        <div>
                            <asp:Label ID="BirthDateLabel" runat="server" Text="Birth Date" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                            <asp:TextBox ID="BirthDateTxt" runat="server" TextMode="DateTime" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></asp:TextBox>
                        </div>
                     
                        <div class="text-right">
                            <asp:Button ID="UpdateEmployeeBtn" runat="server" Text="Güncelle" CssClass="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700" />
                        </div>
                    </form>
                </div>
               
            </div>
        </div>
    </form>
</asp:Content>