<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="RevenueReportPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.ReportPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <title>Revenue Report</title>
        <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
        <style>
            body {
                font-family: Arial, sans-serif;
            }

            .chart-container {
                width: 70%;
                margin: 50px auto;
            }
        </style>

        <!-- Chart Container -->
        <div class="chart-container">
            <canvas id="revenueChart"></canvas>
        </div>

        <!-- Button Container -->
        <div class="flex justify-center space-x-4 mt-6">
            <asp:Button
                ID="btnLoadDaily"
                runat="server"
                Text="Günlük Gelir"
                OnClick="btnLoadDaily_Click"
                CssClass="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600 transition duration-300" />

            <asp:Button
                ID="btnLoadWeekly"
                runat="server"
                Text="Haftalık Gelir"
                OnClick="btnLoadWeekly_Click"
                CssClass="bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600 transition duration-300" />

            <asp:Button
                ID="btnLoadMonthly"
                runat="server"
                Text="Aylık Gelir"
                OnClick="btnLoadMonthly_Click"
                CssClass="bg-yellow-500 text-white py-2 px-4 rounded hover:bg-yellow-600 transition duration-300" />

            <asp:Button
                ID="btnLoadYearly"
                runat="server"
                Text="Yıllık Gelir"
                OnClick="btnLoadYearly_Click"
                CssClass="bg-red-500 text-white py-2 px-4 rounded hover:bg-red-600 transition duration-300" />
        </div>

        <script>
            const ctx = document.getElementById('revenueChart').getContext('2d');
            let revenueChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: [],
                    datasets: [{
                        label: 'Gelir',
                        data: [],
                        borderColor: 'rgba(75, 192, 192, 1)',
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        borderWidth: 2,
                        pointBackgroundColor: 'rgba(75, 192, 192, 1)',
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: { display: false }
                    },
                    scales: {
                        x: { title: { display: true, text: 'Zaman' } },
                        y: { title: { display: true, text: 'Gelir' } }
                    }
                }
            });

            function updateChart(labels, data) {
                revenueChart.data.labels = labels;
                revenueChart.data.datasets[0].data = data;
                revenueChart.update();
            }
        </script>
    </form>
</asp:Content>

