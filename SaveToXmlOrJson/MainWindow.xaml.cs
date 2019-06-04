using System;
using System.Collections.Generic;
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

namespace SaveToXmlOrJson
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Utility MyUtility { get; set; }
        public Repository MyRepository { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MyRepository = new Repository();
            MyUtility = new Utility(MyRepository);
            DataContext = MyUtility;
        }

        private void BtnSaveXml_Click(object sender, RoutedEventArgs e)
        {
            MyUtility.SaveAsXML();
        }

        private void BtnSaveJson_Click(object sender, RoutedEventArgs e)
        {
            MyUtility.SaveAsJson();
        }

        private void BtnLoadXml_Click(object sender, RoutedEventArgs e)
        {
            MyUtility.LoadFromXml();
           
        }

        private void BtnLoadJson_Click(object sender, RoutedEventArgs e)
        {
            MyUtility.LoadFromJson();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            MyUtility.GenerateRandomCat();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MyUtility.AddEnteredData();
        }
    }
}
