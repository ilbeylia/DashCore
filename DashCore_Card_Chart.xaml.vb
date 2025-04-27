Imports LiveCharts
Imports LiveCharts.Wpf

Public Class DashCore_Card_Chart
    Private ReadOnly _chartMode As String
    Private ReadOnly _values As Dictionary(Of String, Object)
    Private _showLegend As Boolean

    Public Sub New(Optional InHeader As String = Nothing, Optional InSubtitle As String = Nothing, Optional InValue As String = Nothing, Optional ButtonVisible As Boolean = True, Optional InChartMode As String = Nothing, Optional InChartValues As Dictionary(Of String, Object) = Nothing, Optional InShowLegend As Boolean = True)

        InitializeComponent()
        _chartMode = InChartMode
        _values = InChartValues
        _showLegend = InShowLegend

        Header_Label.Content = InHeader
        Subtitle_Label.Content = InSubtitle
        Value_Label.Content = InValue

        If ButtonVisible = True Then
            ThreeDot_Button.Visibility = Windows.Visibility.Visible
        Else
            ThreeDot_Button.Visibility = Windows.Visibility.Collapsed
        End If

    End Sub

    Private Sub DashCore_Chart_Card_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If _values Is Nothing OrElse _values.Count = 0 Then
            ' Not found data/Value
            'MessageBox.Show("Not Found Values.")
            Return
        End If
        Select Case _chartMode
            Case "Line"
                CreateLineChart()
            Case "Column"
                CreateColumnChart()
            Case "Pie"
                CreatePieChart()
            Case "Doughnut"
                'CreateDoughnutChart()
            Case "PolarArea"

            Case "Row"
                CreateRowChart()
            Case Else
                ' Handle unknown chart mode
                End
        End Select

    End Sub

    Private Sub CreateLineChart()
        Dim chart As New CartesianChart()

        Dim lineSeries As New LineSeries() With {
            .Title = "Veriler",
            .Values = New ChartValues(Of Double)(_values.Values.Select(Function(v) CDbl(v)))
        }

        chart.Series = New SeriesCollection() From {lineSeries}

        chart.AxisX.Add(New Axis With {
            .Labels = _values.Keys.ToList()
        })

        chart.AxisY.Add(New Axis)

        ChartContainer.Children.Add(chart)
    End Sub

    Private Sub CreateColumnChart()
        Dim chart As New CartesianChart()

        Dim columnSeries As New ColumnSeries() With {
            .Title = "Veriler",
            .Values = New ChartValues(Of Double)(_values.Values.Select(Function(v) CDbl(v)))
        }

        chart.Series = New SeriesCollection() From {columnSeries}

        chart.AxisX.Add(New Axis With {
            .Labels = _values.Keys.ToList()
        })

        chart.AxisY.Add(New Axis)

        ChartContainer.Children.Add(chart)
    End Sub



    Private Sub CreatePieChart()
        Dim chart As New PieChart() With {
            .LegendLocation = LegendLocation.Bottom
        }

        For Each kvp In _values
            chart.Series.Add(New PieSeries With {
                .Title = kvp.Key,
                .Values = New ChartValues(Of Double)({CDbl(kvp.Value)}),
                .DataLabels = True
            })
        Next

        ChartContainer.Children.Add(chart)
    End Sub

    ''EDIT 
    'Private Sub CreateDoughnutChart()
    '    Dim chart As New PieChart()

    '    For Each kvp In _values
    '        Dim doughnutSeries As New PieSeries With {
    '            .Title = kvp.Key,
    '            .Values = New ChartValues(Of Double)({CDbl(kvp.Value)}),
    '            .DataLabels = True
    '        }

    '        chart.Series.Add(doughnutSeries)
    '    Next


    '    ChartContainer.Children.Add(chart)
    'End Sub


    Private Sub CreateRowChart()
        Dim chart As New CartesianChart()

        Dim columnSeries As New ColumnSeries() With {
            .Title = "Veriler",
            .Values = New ChartValues(Of Double)(_values.Values.Select(Function(v) CDbl(v)))
        }

        chart.Series = New SeriesCollection() From {columnSeries}

        chart.AxisY.Add(New Axis With {
            .Labels = _values.Keys.ToList()
        })

        chart.AxisX.Add(New Axis)

        ChartContainer.Children.Add(chart)
    End Sub
End Class
