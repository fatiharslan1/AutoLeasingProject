<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/AdminPages/EmployeeLayout.Master" AutoEventWireup="true" CodeBehind="CarReportPage.aspx.cs" Inherits="newAutoLeasingProject.Pages.AdminPages.CarReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <title>Car Report</title>
        <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
        <style>
            body {
                font-family: Arial, sans-serif;
                margin: 20px;
            }

            .container {
                display: flex;
                flex-direction: column;
                align-items: center;
            }

            .chart-container {
                width: 80%;
                margin-bottom: 20px;
            }

            .button-group {
                display: flex;
                justify-content: center;
                gap: 10px;
            }

            button {
                padding: 10px 20px;
                font-size: 16px;
                background-color: #007bff;
                color: white;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                transition: background-color 0.3s ease;
            }

                button:hover {
                    background-color: #0056b3;
                }
        </style>

        <div class="container">
            <div class="chart-container">
                <canvas id="carChart"></canvas>
            </div>

            <div class="button-group">
                <asp:Button ID="btnFilterSituation" runat="server" Text="Araç Durumu" OnClick="btnFilterSituation_Click" CssClass="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600 transition duration-300" />
                <asp:Button ID="btnFilterType" runat="server" Text="Tür" OnClick="btnFilterType_Click" CssClass="bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600 transition duration-300" />
                <asp:Button ID="btnFilterFuel" runat="server" Text="Yakıt" OnClick="btnFilterFuel_Click"  CssClass="bg-yellow-500 text-white py-2 px-4 rounded hover:bg-yellow-600 transition duration-300" />
                <asp:Button ID="btnFilterYear" runat="server" Text="Yıl" OnClick="btnFilterYear_Click" CssClass="bg-red-500 text-white py-2 px-4 rounded hover:bg-red-600 transition duration-300" />
        </div>

        <script>
            const ctx = document.getElementById('carChart').getContext('2d');
            let carChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: [],
                    datasets: [{
                        label: 'Araç Durumu',
                        data: [],
                        backgroundColor: [
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)'
                        ],
                        borderColor: [
                            'rgba(75, 192, 192, 1)',
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: { display: false }
                    },
                    scales: {
                        x: { title: { display: true, text: '' } },
                        y: { title: { display: true, text: 'Araç Sayısı' } }
                    }
                }
            });

            function updateChart(labels, data) {
                carChart.data.labels = labels;
                carChart.data.datasets[0].data = data;
                carChart.update();
            }
        </script>
    </form>
</asp:Content>
