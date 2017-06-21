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

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for ThankYou.xaml
    /// </summary>
    public partial class ThankYou : UserControl
    {
        public ThankYou()
        {
            InitializeComponent();
        }

        int timer = 10;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Start());
        }

    }
}
