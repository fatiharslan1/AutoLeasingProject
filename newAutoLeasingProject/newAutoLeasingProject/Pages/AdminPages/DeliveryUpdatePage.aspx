<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="DeliveryUpdatePage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.DeliveryUpdatePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex items-center justify-center min-h-screen bg-gray-100">
        <form method="post" class="space-y-4 bg-white shadow-md rounded-lg p-8 w-full max-w-lg" runat="server">
            <!-- Başlık -->
            <h1 class="text-2xl font-bold mb-6 text-center">Car Details</h1>



            <!-- Update Form -->
            <div>
                <h2 class="text-xl font-bold mb-4">Teslim Alma Ekranı </h2>
                <div class="mb-4">
                    <h3 class="text-xl font-bold mb-4 text-gray-700 border-b pb-2">Özet</h3>
                    <div class="space-y-4">
                        <asp:HiddenField ID="deliveryID" runat="server" />


                        <asp:TextBox ID="DeliveryIDTextBox" runat="server" ReadOnly="true" CssClass="form-control hidden" />
                        <asp:TextBox ID="CarIDTextBox" runat="server" ReadOnly="true" CssClass="form-control hidden" />
                        <asp:TextBox ID="BranchIDTextBox" runat="server" ReadOnly="true" CssClass="form-control hidden" />
                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" CssClass="form-control hidden" />

                    </div>
                    <!-- Gecikme ücreti Label -->
                    <div class="mb-4">
                        <asp:Label ID="FeeLabel" runat="server" Text="Gecikme Ücreti" CssClass="block text-sm font-medium text-gray-700 mb-2"></asp:Label>
                        <asp:TextBox ID="FeeTextBox" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" ReadOnly="true" />
                    </div>

                    <!-- Kullanılan KM Label -->
                    <div class="mb-4">
                        <asp:Label ID="KMLabel" runat="server" Text="Kullanılan KM" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
                        <asp:TextBox ID="KMTxt" runat="server" CssClass="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500" Required="true"></asp:TextBox>
                    </div>

                    <div>
                        <asp:Button ID="UpdateBtn" runat="server" Text="Aracı Teslim Al" OnClick="UpdateBtn_Click" CssClass="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600"></asp:Button>
                    </div>
                </div>
        </form>
    </div>
</asp:Content>
