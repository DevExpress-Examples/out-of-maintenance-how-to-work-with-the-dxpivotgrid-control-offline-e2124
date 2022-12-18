Imports System.Windows
Imports HowToBindToMDB.NwindDataSetTableAdapters
Imports System.IO
Imports DevExpress.Xpf.Core

Namespace HowToBindToMDB

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Private salesPersonDataTable As NwindDataSet.SalesPersonDataTable = New NwindDataSet.SalesPersonDataTable()

        Private salesPersonDataAdapter As SalesPersonTableAdapter = New SalesPersonTableAdapter()

        Public Sub New()
            Me.InitializeComponent()
            Me.pivotGridControl1.DataSource = salesPersonDataTable
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            salesPersonDataAdapter.Fill(salesPersonDataTable)
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.pivotGridControl1.SavePivotGridToFile("pivot.dat", True)
            Me.pivotGridControl1.DataSource = Nothing
            Me.pivotGridControl1.Fields.Clear()
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If Not File.Exists("pivot.dat") Then
                DXMessageBox.Show("You should save the PivotGrid into a file first")
                Return
            End If

            Me.pivotGridControl1.RestorePivotGridFromFile("pivot.dat")
        End Sub
    End Class
End Namespace
