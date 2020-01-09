using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

namespace BasicApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ObservableCollection<Person> listData;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listData = new ObservableCollection<Person>();
            listPerson.ItemsSource = listData;
        }
        private void BtnPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new CommonOpenFileDialog();
                dlg.Filters.Add(new CommonFileDialogFilter("xml", "xml"));
                if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    tbPath.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred from {MethodBase.GetCurrentMethod().Name}");
                Console.WriteLine(ex.ToString());
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = tbName.Text;
                var age = int.Parse(tbAge.Text);

                listData.Add(new Person(name, age));

                tbName.Text = "";
                tbAge.Text = "";
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An exception occurred from {MethodBase.GetCurrentMethod().Name}");
                Console.WriteLine(ex.ToString());
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if(listPerson.SelectedItem is Person person)
            {
                listData.Remove(person);
            }
        }
    }
}
