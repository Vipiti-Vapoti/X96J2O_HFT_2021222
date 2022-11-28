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
using System.Windows.Shapes;

namespace X96J2O_HFT_2021222.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Rent(object sender, RoutedEventArgs e)
        {
            RentEditor rentEditor = new RentEditor();
            rentEditor.Show();
        }

        private void Button_Click_Car(object sender, RoutedEventArgs e)
        {
            CarEditor carEditor = new CarEditor();
            carEditor.Show();
        }

        private void Button_Click_Brand(object sender, RoutedEventArgs e)
        {
            BrandEditor brandEditor = new BrandEditor();
            brandEditor.Show();
        }
    }
}
