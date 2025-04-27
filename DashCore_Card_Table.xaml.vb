Imports System.Data
Imports System.Windows.Controls
Imports System.Windows.Data

Public Class DashCore_Card_Table
    Private ReadOnly _dataTable As DataTable
    Private Const DefaultSearchText As String = "Search in table ... "
    Private _isLoaded As Boolean = False
    Public Sub New(InDataTable As DataTable, Optional ButtonVisible As Boolean = True, Optional SearchVisible As Boolean = True)
        InitializeComponent()
        _dataTable = InDataTable

        If ButtonVisible = True Then
            ThreeDot_Button.Visibility = Windows.Visibility.Visible
        Else
            ThreeDot_Button.Visibility = Windows.Visibility.Collapsed
        End If
        If SearchVisible = True Then
            Search_TextBox.Visibility = Visibility.Visible
        Else
            Search_TextBox.Visibility = Visibility.Collapsed
        End If
    End Sub


    Private Sub DashCore_Table_Card_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If _dataTable Is Nothing Then
            Throw New ArgumentNullException(NameOf(_dataTable), "DataTable cannot be null.")
        End If
        DynamicDataGrid.ItemsSource = _dataTable.DefaultView

        DynamicDataGrid.Columns.Clear()

        For Each column As DataColumn In _dataTable.Columns
            Dim gridColumn As New DataGridTextColumn With {
                .Header = column.ColumnName,
                .Binding = New Binding(column.ColumnName),
                .Width = New DataGridLength(1, DataGridLengthUnitType.Star),
                .IsReadOnly = True
            }
            DynamicDataGrid.Columns.Add(gridColumn)
        Next
        _isLoaded = True
    End Sub

    Private Sub Search_TextBox_GotFocus(sender As Object, e As RoutedEventArgs)
        Dim textBox As TextBox = DirectCast(sender, TextBox)
        If textBox.Text = DefaultSearchText Then
            textBox.Text = ""
            textBox.Foreground = New SolidColorBrush(Colors.Black)
        End If
    End Sub


    Private Sub Search_TextBox_LostFocus(sender As Object, e As RoutedEventArgs)
        Dim textBox As TextBox = DirectCast(sender, TextBox)
        If String.IsNullOrWhiteSpace(textBox.Text) Then
            textBox.Text = DefaultSearchText
            textBox.Foreground = New SolidColorBrush(Colors.Gray)
        End If
    End Sub


    Private Sub Search_TextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        If Not _isLoaded OrElse _dataTable Is Nothing Then
            Return
        End If

        Dim textBox As TextBox = DirectCast(sender, TextBox) ' default search text !! Not filters 
        If textBox Is Nothing Then
            Return
        End If

        Dim searchText As String = textBox.Text.Trim()

        If searchText = DefaultSearchText OrElse String.IsNullOrEmpty(searchText) Then
            _dataTable.DefaultView.RowFilter = String.Empty
            Return
        End If

        Dim filter As String = String.Empty
        For Each column As DataColumn In _dataTable.Columns
            If Not String.IsNullOrEmpty(filter) Then
                filter &= " OR "
            End If
            Dim escapedSearchText As String = searchText.Replace("'", "''")
            filter &= $"Convert([{column.ColumnName}], 'System.String') LIKE '%{escapedSearchText}%'"
        Next

        Try
            _dataTable.DefaultView.RowFilter = filter
        Catch ex As Exception

            _dataTable.DefaultView.RowFilter = String.Empty
            Console.WriteLine("Search filter error: " & ex.Message)
        End Try
    End Sub
End Class
