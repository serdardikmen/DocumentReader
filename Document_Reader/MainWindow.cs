using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Document_Reader
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      //ReadCsv(@"C:\Users\serda\Desktop\Analizör CSV verileri\Analizör CSV verileri\XX.XX.XX-XX.XX-TemelveHarmonik.csv");

    }
    
    private string[] lines;
    public void ReadCsv(string file)
    {
      lines = File.ReadAllLines(file);
      ReadColumns();
      ReadRows();

    }

    private void btn_start(object sender, RoutedEventArgs e)
    {
      OpenFileDialog file = new OpenFileDialog();
      file.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
      file.FilterIndex = 1;
      file.RestoreDirectory = true;
      file.CheckFileExists = false;
      file.Title = "Aktarım Yapılacak csv Dosyası Seçiniz..";
      file.Multiselect = false;
      file.ShowDialog();
      ReadCsv(file.FileName);
      DataTable dt = new DataTable();
      dt.Columns.Add();

    }
    public void ReadColumns()
    {
      string[] columnlines = lines[0].Split(";");
      for (int i = 0; i < columnlines.Length; i++)
      {
        DG.Columns.Add(new DataGridTextColumn()
        {
          Header = columnlines[i],
          Binding = new Binding(String.Format("[{0}]", i))

        });
      }
    }
    private void ReadRows()
    {
      DataTable dt = new DataTable();
      for (int i = 1; i < lines.Length; i++)
      {
        DG.Items.Add(lines[i].Split(";"));
        //foreach (var l in line.Split(";"))
        //{
        //  //DG.Items.Add(l);
        //  dt.Rows.Add("abc");
        //}
      }
    }
  }
}
//DG.ItemsSource = dt.;

