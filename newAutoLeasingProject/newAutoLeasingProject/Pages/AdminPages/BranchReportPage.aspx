<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="BranchReportPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.BranchReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 900px; margin: 0 auto;">
        <canvas id="polarChart"></canvas>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        // Backend'den gelen veriler JavaScript'e gömüldü
        const branchNames = [<%= BranchNames %>];
        const revenues = [<%= BranchRevenues %>];

        // Renkleri dinamik olarak oluştur
        const colors = branchNames.map((_, index) => {
            const hue = (index * 360 / branchNames.length) % 360;
            return `hsl(${hue}, 70%, 50%)`;
        });

        const ctx = document.getElementById('polarChart').getContext('2d');
        const polarChart = new Chart(ctx, {
            type: 'polarArea',
            data: {
                labels: branchNames, // Şube isimleri
                datasets: [{
                    label: 'Branch Revenues',
                    data: revenues, // Gelirler
                    backgroundColor: colors, // Dinamik renkler
                    borderColor: colors.map(color => color.replace('50%', '40%')), // Daha koyu renk sınır
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: true, // Grafik boyutunu sayfa boyutuna uygun hale getirir
                plugins: {
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'Branch Revenue Polar Chart'
                    }
                },
                layout: {
                    padding: 10 // Grafik çevresine biraz boşluk ekler
                }
            }
        });
    </script>
</asp:Content>
