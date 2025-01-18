<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CustomerPages/CustomerLayout.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.CustomerPages.PaymentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="max-w-4xl mx-auto bg-white p-6 rounded-lg shadow-md">
        <h2 class="text-2xl font-semibold mb-4">Ödeme Ekranı</h2>
            <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

        <!-- Payment Summary -->
        <div class="mb-6">
            <h3 class="text-lg font-semibold mb-4">Kiralama Özeti</h3>
            <div class="space-y-2 text-sm">
                <!-- Araba ve Şehir Bilgisi -->
                <p><span class="font-medium">Araba:</span> <%: Session["CarName"] %></p>
                <!-- Kiralama Süresi -->
                <p><span class="font-medium">Kiralama Süresi :</span> <%: Session["RentalDays"] %> Gün</p>
                <!-- Günlük Ücret -->
                <p><span class="font-medium">Günlük Fiyat :</span> ₺<%: Session["DailyFee"] %></p>
                <!-- Toplam Fiyat -->
                <p><span class="font-medium">KDV :</span> ₺<%: (Convert.ToDecimal(Session["DailyFee"]) * Convert.ToDecimal(1.20 )) %></p>
                <!-- Toplam Fiyat -->
                <p><span class="font-medium">Toplam Fiyat :</span> ₺<%: (Convert.ToDecimal(Session["DailyFee"]) * Convert.ToInt32(Session["RentalDays"])).ToString("N2") %></p>
            </div>
        </div>

        <!-- Payment Form -->
        <div class="mb-6">
            <h3 class="text-lg font-semibold mb-4">Payment Details</h3>
            <form runat="server">
                <div class="space-y-4">
                    <div>
                        <asp:Label ID="lblCardName" runat="server" Text="Kart Sahibi Adı" CssClass="block font-medium mb-1"></asp:Label>
                        <asp:TextBox ID="txtCardName" runat="server" CssClass="w-full border p-2 rounded-md" Placeholder="John Doe"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblCardNumber" runat="server" Text="Kart Numarası" CssClass="block font-medium mb-1"></asp:Label>
                        <asp:TextBox ID="txtCardNumber" runat="server" CssClass="w-full border p-2 rounded-md"
                            Placeholder="1234 5678 9012 3456" MaxLength="16"
                            TextMode="SingleLine" ToolTip="Only 16 digits are allowed"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revCardNumber" runat="server"
                            ControlToValidate="txtCardNumber"
                            ValidationExpression="^\d{16}$"
                            ErrorMessage="Card Number must be 16 digits"
                            CssClass="text-red-500"></asp:RegularExpressionValidator>
                    </div>
                    <div class="flex gap-4">
                        <div class="flex-1">
                            <asp:Label ID="lblExpiryDate" runat="server" Text="Kart Son Kullanma Tarihi" CssClass="block font-medium mb-1"></asp:Label>
                            <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="w-full border p-2 rounded-md" Placeholder="MM/YY"></asp:TextBox>
                        </div>
                        <div class="flex-1">
                            <asp:Label ID="lblCVV" runat="server" Text="CVV" CssClass="block font-medium mb-1"></asp:Label>
                            <asp:TextBox ID="txtCVV" runat="server" CssClass="w-full border p-2 rounded-md"
                                Placeholder="123" MaxLength="3" TextMode="SingleLine"
                                ToolTip="Only 3 digits are allowed"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revCVV" runat="server"
                                ControlToValidate="txtCVV"
                                ValidationExpression="^\d{3}$"
                                ErrorMessage="CVV must be 3 digits"
                                CssClass="text-red-500"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="lblBillingAddress" runat="server" Text="Billing Address" CssClass="block font-medium mb-1"></asp:Label>
                        <asp:TextBox ID="txtBillingAddress" runat="server" CssClass="w-full border p-2 rounded-md" Placeholder="123 Main St, City, Country"></asp:TextBox>
                    </div>

                    <!-- Actions -->
                    <div class="text-center flex flex-col items-end space-y-4 mt-6">
                        <!-- Sözleşme Checkbox -->
                        <div class="flex items-center">
                            <asp:CheckBox ID="AgreementCheckBox" runat="server" CssClass="mr-2" />
                            <label for="AgreementCheckBox" class="text-sm text-gray-700">
                                <a href="\Pages\CustomerPages\AgreementPage.aspx" target="_blank" class="text-blue-600 underline">Şartlar ve Koşullar'ı kabul ediyorum</a>.
       
                            </label>
                        </div>

                        <!-- Butonlar -->
                        <div class="flex justify-end space-x-4">
                            <!-- Cancel Button (Gri Renk) -->
                            <asp:Button ID="CancelBtn" runat="server" Text="İptal" OnClick="CancelBtn_Click"
                                CssClass="px-6 py-2 bg-gray-600 text-white font-medium rounded-lg hover:bg-gray-700 focus:outline-none focus:ring-2 focus:ring-gray-500" />

                            <!-- Payment Button (Yeşil Renk) -->
                            <asp:Button ID="PaymentBtn" runat="server" Text="Öde" OnClick="PaymentBtn_Click"
                                CssClass="px-6 py-2 bg-green-600 text-white font-medium rounded-lg hover:bg-green-700 focus:outline-none focus:ring-2 focus:ring-green-500" />
                        </div>

                        <!-- Hata Mesajı -->
                        <asp:Label ID="lblAgreementError" runat="server" CssClass="text-sm text-red-600 mt-2" Visible="false"></asp:Label>
                    </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>
