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
    /// Interaction logic for Scan.xaml
    /// </summary>
    public partial class Scan : UserControl
    {
        public Scan()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Application.Current.Properties[String.Format("Item_{0}", element)] = null;
                Application.Current.Properties[String.Format("Addon_{0}", element)] = null;
                Application.Current.Properties["Total"] = "0.00";
            }
            Switcher.Switch(new ThankYou());
        }
    }
}
