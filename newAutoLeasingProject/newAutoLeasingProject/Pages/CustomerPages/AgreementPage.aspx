<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgreementPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.CustomerPages.AgreementPage" %>

<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <title>Araba Kiralama Sözleşmesi</title>
    <link rel="stylesheet" href="/Styles/styles.css" />
</head>
<body class="bg-gray-100">
    <!-- Form etiketi ile tüm içerik sarılıyor -->
    <form id="form1" runat="server">
        <div class="container mx-auto mt-10">
            <div class="bg-white p-8 rounded-lg shadow-md">
                <h1 class="text-2xl font-bold mb-6 text-center text-blue-600">Araba Kiralama Sözleşmesi</h1>

                <div class="overflow-y-auto h-96 border p-4 bg-gray-50 rounded-md text-justify">
                    <p>
                        İşbu sözleşme, araba kiralama hizmeti sunan <strong>[Şirket Adı]</strong> (bundan sonra "Kiralayan" olarak anılacaktır) ile 
                        aracı kiralayan kişi (bundan sonra "Kiracı" olarak anılacaktır) arasında yapılmıştır.
                    </p>
                    <p>
                        <strong>1. Tarafların Hak ve Yükümlülükleri</strong>
                    </p>
                    <ul class="list-disc ml-6">
                        <li>Kiralayan, kiralanan aracın çalışır durumda ve temiz olduğunu garanti eder.</li>
                        <li>Kiracı, aracı belirtilen süre boyunca iyi bir şekilde kullanmayı ve belirtilen süre sonunda teslim etmeyi kabul eder.</li>
                    </ul>
                    <p>
                        <strong>2. Kiralama Süresi ve Ücret</strong>
                    </p>
                    <ul class="list-disc ml-6">
                        <li>Kiralama süresi, başlangıç ve bitiş tarihleri arasında geçerlidir.</li>
                        <li>Kiralama ücreti günlük olarak belirlenmiştir ve toplam ücret teslim sırasında ödenir.</li>
                    </ul>
                    <p>
                        <strong>3. Araç Kullanımı</strong>
                    </p>
                    <ul class="list-disc ml-6">
                        <li>Araç yalnızca Kiracı ve sözleşmede belirtilen sürücüler tarafından kullanılabilir.</li>
                        <li>Kiracı, aracı yasalara uygun şekilde kullanmayı taahhüt eder.</li>
                    </ul>
                    <p>
                        <strong>4. Cezalar ve Zararlar</strong>
                    </p>
                    <ul class="list-disc ml-6">
                        <li>Herhangi bir trafik cezası, Kiracı tarafından karşılanır.</li>
                        <li>Aracın zarar görmesi durumunda masraflar Kiracıya aittir.</li>
                    </ul>
                    <p>
                        <strong>5. Diğer Hükümler</strong>
                    </p>
                    <ul class="list-disc ml-6">
                        <li>İhtilaf durumunda [Şehir Adı] mahkemeleri yetkilidir.</li>
                    </ul>
                    <p class="mt-4">
                        Bu sözleşme, tarafların özgür iradeleriyle kabul edilmiş ve imzalanmıştır.
                    </p>
                </div>

                <!-- Onay Kutusu ve Butonlar -->
                <div class="mt-6 text-center">
                    <asp:CheckBox ID="AgreementCheckBox" runat="server" Text="Sözleşmeyi okudum ve kabul ediyorum." CssClass="text-sm" />
                    <br />
                    <asp:Label ID="ErrorLabel" runat="server" Text="" CssClass="text-red-500 text-sm mt-2" Visible="false"></asp:Label>
                </div>
                <div class="mt-4 text-center flex justify-center gap-4">
                    <asp:Button ID="CancelButton" runat="server" Text="İptal" CssClass="bg-gray-600 text-white px-6 py-2 rounded-lg" OnClick="CancelButton_Click" />
                    <asp:Button ID="AcceptButton" runat="server" Text="Kabul Et" CssClass="bg-blue-600 text-white px-6 py-2 rounded-lg" OnClick="AcceptButton_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>