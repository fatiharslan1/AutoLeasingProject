<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/CustomerPages/CustomerLayout.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.CustomerPages.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="MainPage" runat="server">

        <!-- Başlık Bölümü -->
        <div class="header__container" id="home">
            <div class="header__image">
                <img src="assets/header.png" alt="başlık" />
            </div>
            <div class="header__content text-center">
                <h1 class="text-4xl font-bold mt-4">HIZLI VE KOLAY ARAÇ KİRALAMA</h1>
                <p class="text-lg text-gray-600 mt-2">
                    Bizimle sorunsuz bir araç kiralama deneyimi yaşayın. Tarzınıza ve ihtiyaçlarınıza uygun premium araç seçeneklerinden birini seçin ve güvenle yola çıkın. Hızlı, kolay ve güvenilir - Bugün aracınızı kiralayın!
                </p>
            </div>
        </div>

        <!-- Form Bölümü -->
        <div class="max-w-6xl mx-auto p-8 bg-gray-100 rounded-lg shadow-lg mt-8">
            <div class="grid grid-cols-2 gap-8">
                <!-- Teslim Alma Konumu -->
                <div class="col-span-1">
                    <label for="Branch" class="text-lg font-medium text-gray-700">Teslim Alma Şubesi Seçin</label>
                    <asp:DropDownList ID="CityDropDown" CssClass="mt-2 w-full p-4 text-lg border border-gray-400 rounded-lg" runat="server">
                    </asp:DropDownList>
                </div>
                <div></div>
                <!-- Teslim Tarihi -->
                <div class="col-span-1">
                    <label for="pickupDate" class="text-lg font-medium text-gray-700">Başlangıç Tarihi</label>
                    <asp:TextBox ID="TextBoxPickupDate" TextMode="Date" CssClass="mt-2 w-full p-4 text-lg border border-gray-400 rounded-lg" runat="server" placeholder="gg.aa.yyyy" />
                </div>

                <!-- Alış Tarihi -->
                <div class="col-span-1">
                    <label for="dropofDate" class="text-lg font-medium text-gray-700">Bitiş Tarihi</label>
                    <asp:TextBox ID="TextBoxDropOffDate" TextMode="Date" CssClass="mt-2 w-full p-4 text-lg border border-gray-400 rounded-lg" runat="server" placeholder="gg.aa.yyyy" />
                </div>

                <!-- Arama Butonu -->
                <div class="col-span-2 flex justify-center">
                    <asp:Button ID="ButtonSearch" runat="server" Text="Araç Ara" CssClass="btn bg-yellow-500 text-white py-2 px-4 rounded-md" OnClick="SearchCarBtn_Click" />
                </div>

                <asp:Label ID="lblMessage" runat="server" Visible="false" CssClass="block mt-4 text-sm text-center text-red-500"></asp:Label>
            </div>
        </div>

        <!-- Nasıl Çalışır Bölümü -->
        <section class="section__container about__container" id="about">
            <h2 class="section__header">Nasıl Çalışır?</h2>
            <p class="section__description">
                Bizimle araç kiralamak çok kolay! Aracınızı seçin, tarihler belirleyin ve rezervasyonunuzu tamamlayın. Yolculuğunuzun sorunsuz başlamasını sağlayacağız.
            </p>
            <div class="about__grid">
                <div class="about__card">
                    <span><i class="ri-map-pin-2-fill"></i></span>
                    <h4>Konum Seçin</h4>
                    <p>
                        Ev, iş yeri veya havaalanına yakın çeşitli teslim alma konumları arasından seçim yapın.
                    </p>
                </div>
                <div class="about__card">
                    <span><i class="ri-calendar-event-fill"></i></span>
                    <h4>Tarih Belirleyin</h4>
                    <p>
                        Aracınızı alacağınız tarih ve saati seçin.
                    </p>
                </div>
                <div class="about__card">
                    <span><i class="ri-roadster-fill"></i></span>
                    <h4>Aracınızı Ayırtın</h4>
                    <p>
                        Rezervasyonunuzu tamamlayın ve aracınızı sorunsuz bir şekilde teslim alın.
                    </p>
                </div>
            </div>
        </section>

      
    </form>
</asp:Content>
