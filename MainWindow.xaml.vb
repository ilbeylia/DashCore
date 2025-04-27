Imports System.Data

Class MainWindow
    Public Sub New()
        InitializeComponent()
        Dim testData As New Dictionary(Of String, Object) From {
            {"Ocak", 120},
            {"Şubat", 150},
            {"Mart", 180},
            {"Nisan", 90}
        }


        Dim LineChart As DashCore_Card_Chart = New DashCore_Card_Chart(InHeader:="Aylık Satış", InSubtitle:="Test", InValue:="540", InChartMode:="Pie", InChartValues:=testData)
        Dim LineChart1 As DashCore_Card_Chart = New DashCore_Card_Chart(InHeader:="Aylık Satış", InSubtitle:="Test", InValue:="540", InChartMode:="Line", InChartValues:=testData)
        Dim LineChart2 As DashCore_Card_Chart = New DashCore_Card_Chart(InHeader:="Aylık Satış", InSubtitle:="Test", InValue:="540", InChartMode:="Column", InChartValues:=testData)

        Dim LineChart3 As DashCore_Card_Chart = New DashCore_Card_Chart(InHeader:="Aylık Satış", InSubtitle:="Test", InValue:="540", InChartMode:="Doughnut", InChartValues:=testData)
        MainGrid.Children.Add(LineChart)
        MainGrid.Children.Add(LineChart1)
        MainGrid.Children.Add(LineChart2)
        MainGrid.Children.Add(LineChart3)

        Dim dt As New DataTable("MaintenanceData")

        dt.Columns.Add("Date", GetType(String))
        dt.Columns.Add("Type", GetType(String))
        dt.Columns.Add("Status", GetType(String))

        dt.Rows.Add("2025-04-17", "Inspection", "Completed")
        dt.Rows.Add("2025-04-22", "Repair", "Pending")
        dt.Rows.Add("2025-04-25", "Maintenance", "In Progress")
        dt.Rows.Add("2025-04-30", "Inspection", "Completed")

        Dim sTable As DashCore_Card_Table = New DashCore_Card_Table(dt)
        TableContainer.Children.Add(sTable)

    End Sub
End Class
