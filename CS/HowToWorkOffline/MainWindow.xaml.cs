using System.Data;
using System.Data.OleDb;
using System.Windows;
using DevExpress.Xpf.PivotGrid;
using HowToBindToMDB.NwindDataSetTableAdapters;
using System.IO;
using DevExpress.Xpf.Core;

namespace HowToBindToMDB {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        NwindDataSet.SalesPersonDataTable salesPersonDataTable = new NwindDataSet.SalesPersonDataTable();
        SalesPersonTableAdapter salesPersonDataAdapter = new SalesPersonTableAdapter();

        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = salesPersonDataTable;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            salesPersonDataAdapter.Fill(salesPersonDataTable);
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            pivotGridControl1.SavePivotGridToFile("pivot.dat", true);
            pivotGridControl1.DataSource = null;
            pivotGridControl1.Fields.Clear();
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            if(!File.Exists("pivot.dat")) {
                DXMessageBox.Show("You should save the PivotGrid into a file first");
                return;
            }
            pivotGridControl1.RestorePivotGridFromFile("pivot.dat");
        }
    }
}
