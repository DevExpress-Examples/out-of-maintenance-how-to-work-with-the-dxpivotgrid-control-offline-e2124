Imports System.Data
Imports System.Data.OleDb
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports HowToBindToMDB.NwindDataSetTableAdapters
Imports System.IO
Imports DevExpress.Xpf.Core

Namespace HowToBindToMDB
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

'INSTANT VB NOTE: The variable salesPersonDataTable was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Private salesPersonDataTable_Conflict As New NwindDataSet.SalesPersonDataTable()
		Private salesPersonDataAdapter As New SalesPersonTableAdapter()

		Public Sub New()
			InitializeComponent()
			pivotGridControl1.DataSource = salesPersonDataTable_Conflict
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			salesPersonDataAdapter.Fill(salesPersonDataTable_Conflict)
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			pivotGridControl1.SavePivotGridToFile("pivot.dat", True)
			pivotGridControl1.DataSource = Nothing
			pivotGridControl1.Fields.Clear()
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If Not File.Exists("pivot.dat") Then
				DXMessageBox.Show("You should save the PivotGrid into a file first")
				Return
			End If
			pivotGridControl1.RestorePivotGridFromFile("pivot.dat")
		End Sub
	End Class
End Namespace
