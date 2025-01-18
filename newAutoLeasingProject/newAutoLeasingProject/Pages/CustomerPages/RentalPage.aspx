<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CustomerPages/CustomerLayout.Master" AutoEventWireup="true" CodeBehind="RentalPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.CustomerPages.RentalPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <!-- Filters Section -->
        <div class="flex gap-6 mb-6">
            <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

            <!-- Filters -->
            <div class="w-1/4 bg-white p-6 rounded-lg shadow-lg border border-gray-200">
                <h3 class="text-xl font-bold mb-4 text-gray-700 border-b pb-2">Özet</h3>
                <div class="space-y-4">
                    <asp:Label ID="lblCity" runat="server" Text=": " CssClass="block text-gray-600"></asp:Label>
                    <asp:Label ID="lblDays" runat="server" Text=": " CssClass="block text-gray-600"></asp:Label>
                    <asp:Label ID="lblPickupDate" runat="server" Text=": " CssClass="block text-gray-600"></asp:Label>
                    <asp:Label ID="lblDropDate" runat="server" Text=": " CssClass="block text-gray-600"></asp:Label>
                    <h3 class="text-xl font-bold mb-4 text-gray-700 border-b pb-2">Filitrele</h3>

                    <div>
                        <label class="block font-medium mb-1 text-gray-700">Transmission</label>
                        <asp:DropDownList ID="TransmissionDropdown" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"></asp:DropDownList>
                    </div>
                    <div>
                        <label class="block font-medium mb-1 text-gray-700">Location</label>
                        <asp:DropDownList ID="LocationDropDown" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"></asp:DropDownList>
                    </div>
                    <div>
                        <label class="block font-medium mb-1 text-gray-700">Brand</label>
                        <asp:DropDownList ID="BrandDropdown" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"></asp:DropDownList>
                    </div>
                    <div>
                        <label class="block font-medium mb-1 text-gray-700">Fuel Type</label>
                        <asp:DropDownList ID="FuelTypeDropDown" runat="server" CssClass="w-full border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"></asp:DropDownList>
                    </div>

                    <!-- Filtrele Butonu -->
                    <div class="text-center mt-4">
                        <asp:Button ID="FilterBtn" runat="server" Text="Filtrele" OnClick="FilterBtn_Click" CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                        <asp:Button ID="ClearBtn" runat="server" Text="Temizle" OnClick="ClearBtn_Click" CssClass="px-6 py-2 bg-gray-400 text-white font-medium rounded-md hover:bg-gray-500 focus:outline-none focus:ring-2 focus:ring-gray-400 ml-2" />
                    </div>
                </div>
            </div>

            <!-- Car Listings -->
            <div class="flex-1 space-y-6">
                <asp:Repeater ID="carRepeater" runat="server">
                    <ItemTemplate>
                        <div class="border p-4 rounded-lg shadow-md bg-white flex items-start gap-4">
                            <img src='<%# Eval("CarImage") %>' alt="Car Image" class="w-40 h-24 object-contain rounded-md" />

                            <div class="flex-1">
                                <h3 class="text-lg font-semibold text-blue-600"><%# Eval("Brand") + " " + Eval("Model") %></h3>
                                <p class="text-sm text-gray-500"><%# Eval("TypeName") %></p>
                                <div class="mt-2 space-y-1 text-sm">
                                    <p><span class="font-semibold">Year:</span> <%# Eval("Year") %></p>
                                    <p><span class="font-semibold">Location:</span> <%# Eval("City") %></p>
                                    <p><span class="font-semibold">Daily Fee:</span> ₺<%# Eval("DailyFee", "{0:N2}") %></p>
                                    <p style="display: none;"><span class="font-semibold">BranchID:</span> <%# Eval("BranchID") %></p>
                                </div>
                            </div>

                            <div class="text-right">
                                <asp:Button ID="RentBtn" runat="server" Text="Kirala" OnClick="RentBtn_Click"
                                    CommandArgument='<%# Eval("CarID") + "," + Eval("BranchID") + "," + Eval("DailyFee") + "," + Eval("Brand") + " " + Eval("Model") %>'
                                    CssClass="px-6 py-2 bg-blue-600 text-white font-medium rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</asp:Content>
