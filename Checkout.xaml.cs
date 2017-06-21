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
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : UserControl
    {
        public Checkout()
        {
            InitializeComponent();
            Make_Grid();
        }


        private void Make_Grid()
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                string item = (string)Application.Current.Properties[String.Format("Item_{0}", element)];
                string price = (string)Application.Current.Properties[String.Format("Price_{0}", element)];
                string addons = (string)Application.Current.Properties[String.Format("Item_Add_{0}", element)];
                if (item != null)
                {
                    string curr_item = String.Format("Item_{0}", element);
                    Label curr_label = (Label) Items_Grid.FindName(curr_item);
                    curr_label.Content = item;

                    string curr_Add = String.Format("Item_Add_{0}", element);
                    Label current_Add = (Label)Items_Grid.FindName(curr_Add);
                    current_Add.Content = addons;

                    string curr_price = String.Format("Price_{0}", element);
                    Label curr_labelP = (Label)Items_Grid.FindName(curr_price);
                    curr_labelP.Content = price;
                    string curr_delete = String.Format("delete_{0}", element);
                    Button current_delete = (Button)Items_Grid.FindName(curr_delete);
                    current_delete.Visibility = System.Windows.Visibility.Visible;
                }
            


            }
            Final.Content = (string)Application.Current.Properties["Total"];
        }

        private void Update_Total(Decimal add)
        {
            Decimal final = Convert.ToDecimal(Final.Content);
            final = final + add;

            Final.Content = Convert.ToString(final);

        }


        //Delete button
        private void delete_all_Click(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label current = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
                Label nextitem = (Label)Items_Grid.FindName(String.Format("Item_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                Label nextitemPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentAddon = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));


                Decimal anInteger = Convert.ToDecimal(currentPrice.Content);
                Update_Total(-anInteger);
                current.Content = null;
                currentPrice.Content = null;
                currentAddon.Content = null;
                Application.Current.Properties[String.Format("Item_{0}", element)] = null;
                Application.Current.Properties[String.Format("Addon_{0}", element)] = null;
                string curr_delete = String.Format("delete_{0}", element);
                Button current_delete = (Button)Items_Grid.FindName(curr_delete);
                current_delete.Visibility = System.Windows.Visibility.Hidden;

            }
        }
        private void delete_0_Click(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label current = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
                Label nextitem = (Label)Items_Grid.FindName(String.Format("Item_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                Label nextitemPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                
                Button currentDelete = (Button)Items_Grid.FindName(String.Format("delete_{0}", element));

                Label currentAdd = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                Label nextitemAdd = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                String currentAddons = (String)Application.Current.Properties[String.Format("Addon_{0}", element)];
                String nextAddons = (String)Application.Current.Properties[String.Format("Addon_{0}", element)];

               
                String nextaddon = (String)Application.Current.Properties[String.Format("Addon_{0}", Convert.ToString(Convert.ToInt32(element) + 1))];


                if (nextitem.Content == null)
                {

                    Decimal anInteger = Convert.ToDecimal(currentPrice.Content);
                    Update_Total(-anInteger);

                    current.Content = null;
                    currentPrice.Content = null;
                    currentAdd.Content = null;
                    Application.Current.Properties[String.Format("Item_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Price_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Item_Add_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Addon_{0}", element)] = null;
                     
                    currentDelete.Visibility = System.Windows.Visibility.Hidden;

                }
                else
                {
                    Decimal anInteger = Convert.ToDecimal(currentPrice.Content);
                    Update_Total(-anInteger);


                    Application.Current.Properties[String.Format("Item_{0}", element)] = nextitem.Content;
                    current.Content = nextitem.Content;

                    Application.Current.Properties[String.Format("Price_{0}", element)] = nextitemPrice.Content; 
                    currentPrice.Content = nextitemPrice.Content;

                    Application.Current.Properties[String.Format("Item_Add_{0}", element)] = nextitemAdd.Content;

                    Application.Current.Properties[String.Format("Addon_{0}", element)] = nextaddon;
                    currentAdd.Content = nextitemAdd.Content;


                    nextitemAdd.Content = null;
                    nextitem.Content = null;
                    nextitemPrice.Content = null;
         
                }
            }
        }

        private void delete_1_Click(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "1", "2", "3"};
            foreach (String element in list10)
            {
                Label current = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
                Label nextitem = (Label)Items_Grid.FindName(String.Format("Item_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                Label nextitemPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Button currentDelete = (Button)Items_Grid.FindName(String.Format("delete_{0}", element));

                Label currentAdd = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                Label nextitemAdd = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                String nextaddon = (String)Application.Current.Properties[String.Format("Addon_{0}", Convert.ToString(Convert.ToInt32(element) + 1))];

                if (!(nextitem.HasContent))
                {
                    Decimal anInteger = Convert.ToDecimal(currentPrice.Content);
                    Update_Total(-anInteger);
                    current.Content = null;
                    currentPrice.Content = null;
                    currentAdd.Content = null;
                    Application.Current.Properties[String.Format("Item_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Price_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Item_Add_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Addon_{0}", element)] = null;
                    currentDelete.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    Decimal anInteger = Convert.ToDecimal(currentPrice.Content);
                    Update_Total(-anInteger);
                    current.Content = nextitem.Content;
                    Application.Current.Properties[String.Format("Item_{0}", element)] = nextitem.Content;
                    Application.Current.Properties[String.Format("Item_Add_{0}", element)] = nextitemAdd.Content;
                    Application.Current.Properties[String.Format("Price_{0}", element)] = nextitemPrice.Content;
                    Application.Current.Properties[String.Format("Addon_{0}", element)] = nextaddon;

                    currentPrice.Content = nextitemPrice.Content;
                   
                    currentAdd.Content = nextitemAdd.Content;
                    nextitemAdd.Content = null;
                    nextitem.Content = null;
                    nextitemPrice.Content = null;
                }
            }
        }

        private void delete_2_Click(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "2", "3" };
            foreach (String element in list10)
            {
                Label current = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
                Label nextitem = (Label)Items_Grid.FindName(String.Format("Item_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                Label nextitemPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                Button currentDelete = (Button)Items_Grid.FindName(String.Format("delete_{0}", element));

                Button nextDelete = (Button)Items_Grid.FindName(String.Format("delete_{0}", element));
                Label currentAdd = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                Label nextitemAdd = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                String nextaddon = (String)Application.Current.Properties[String.Format("Addon_{0}", Convert.ToString(Convert.ToInt32(element) + 1))];
                if (!(nextitem.HasContent))
                {
                    Decimal anInteger = Convert.ToDecimal(currentPrice.Content);
                    Update_Total(-anInteger);
                    current.Content = null;
                    currentPrice.Content = null;
                    currentAdd.Content = null;
                    Application.Current.Properties[String.Format("Item_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Price_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Item_Add_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Addon_{0}", element)] = null;
                    currentDelete.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    Decimal anInteger = Convert.ToDecimal(currentPrice.Content);
                    Update_Total(-anInteger);

                    current.Content = nextitem.Content;
                    Application.Current.Properties[String.Format("Item_{0}", element)] = nextitem.Content;

                    currentPrice.Content = nextitemPrice.Content;
                    Application.Current.Properties[String.Format("Price_{0}", element)] = nextitemPrice.Content;
                    Application.Current.Properties[String.Format("Item_Add_{0}", element)] = nextitemAdd.Content;
                    Application.Current.Properties[String.Format("Addon_{0}", element)] = nextaddon;
                    nextitem.Content = null;
                    nextitemPrice.Content = null;
                    currentAdd.Content = nextitemAdd.Content;
                    nextitemAdd.Content = null;
                }
            }
        }

        private void delete_3_Click(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "3" };
            foreach (String element in list10)
            {
                Label current = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
                Label nextitem = (Label)Items_Grid.FindName(String.Format("Item_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                Label nextitemPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                Button currentDelete = (Button)Items_Grid.FindName(String.Format("delete_{0}", element));

                Label currentAdd = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                Label nextitemAdd = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                String nextaddon = (String)Application.Current.Properties[String.Format("Addon_{0}", Convert.ToString(Convert.ToInt32(element) + 1))];
                if (!(nextitem.HasContent))
                {
                    Decimal anInteger = Convert.ToDecimal(currentPrice.Content);
                    Update_Total(-anInteger);
                    current.Content = null;
                    currentPrice.Content = null;
                    Application.Current.Properties[String.Format("Item_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Price_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Item_Add_{0}", element)] = null;
                    Application.Current.Properties[String.Format("Addon_{0}", element)] = null;
                    currentDelete.Visibility = System.Windows.Visibility.Hidden;
                    currentAdd.Content = null;
                }
                else
                {
                    Decimal anInteger = Convert.ToDecimal(currentPrice.Content);
                    Update_Total(-anInteger);
                    current.Content = nextitem.Content;
                    Application.Current.Properties[String.Format("Item_{0}", element)] = nextitem.Content;

                    currentPrice.Content = nextitemPrice.Content;
                    Application.Current.Properties[String.Format("Price_{0}", element)] = nextitemPrice.Content;

                    Application.Current.Properties[String.Format("Item_Add_{0}", element)] = nextitemAdd.Content;
                    Application.Current.Properties[String.Format("Addon_{0}", element)] = nextaddon;
                    nextitem.Content = null;
                    nextitemPrice.Content = null;
                }
            }
        }


        private void Menu_Click(object sender, RoutedEventArgs e)   //menu button
        {
            Application.Current.Properties["Total"] = Final.Content;
            Switcher.Switch(new Menu());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)   //ucid
        {
            Switcher.Switch(new Scan());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)   //debit
        {
            Switcher.Switch(new Scan());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)   //credit    
        {
            Switcher.Switch(new Scan());
        }

        private void Button_Click_bell(object sender, RoutedEventArgs e)    //bell button
        {
            MessageBox.Show("An employee is on their way to help.");
        }
    }
}
