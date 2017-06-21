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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public int counter;
        public Menu()
        {
            InitializeComponent();
            counter = 0;
            String[] list10 = new String[] { "0", "1", "2", "3"};
            foreach (String element in list10)
            {
                string item = (string)Application.Current.Properties[String.Format("Item_{0}", element)];
                string price = (string)Application.Current.Properties[String.Format("Price_{0}", element)];
                string addon = (string)Application.Current.Properties[String.Format("Addon_{0}", element)];
                string add = (string)Application.Current.Properties[String.Format("Item_Add_{0}", element)];
                if (item != null)
                {
                    string curr_item = String.Format("Item_{0}", element);
                    Label curr_label = (Label)Items_Grid.FindName(curr_item);
                    curr_label.Content = item;

               
                   

                    string curr_price = String.Format("Price_{0}", element);
                    Label curr_labelP = (Label)Items_Grid.FindName(curr_price);
                    curr_labelP.Content = price;
                    Button delete = (Button)Items_Grid.FindName(String.Format("Delete_{0}", element));
                    delete.Visibility = System.Windows.Visibility.Visible;

                    Label CurrentPrice = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                    Double anInteger;


                    if (addon.Contains("B"))
                    {
                        ComboBox Boost = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", element));
                        CheckBox Whey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", element));
                        CheckBox Smart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", element));
                        CheckBox Trim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", element));
                        Boost.Visibility = System.Windows.Visibility.Visible;
                        if (addon.Contains("W"))
                        {

                            anInteger = Convert.ToDouble(CurrentPrice.Content);
                            anInteger = anInteger - .71;
                            CurrentPrice.Content = Convert.ToString(anInteger);
                            Whey.IsChecked = true;
                            
                        }
                        if (addon.Contains("R"))
                        {
                            anInteger = Convert.ToDouble(CurrentPrice.Content);
                            anInteger = anInteger - .71;
                            CurrentPrice.Content = Convert.ToString(anInteger);
                            Smart.IsChecked = true;
                        }

                        if (addon.Contains("T"))
                        {
                            anInteger = Convert.ToDouble(CurrentPrice.Content);
                            anInteger = anInteger - .71;
                            CurrentPrice.Content = Convert.ToString(anInteger);
                            Trim.IsChecked = true;
                        }


                    }
                    else if (addon.Contains("Z"))
                    {
                        ComboBox Size = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));
                        RadioButton Small = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", element));

                        RadioButton Medium = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", element));
                        RadioButton Large = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", element));

                        Size.Visibility = System.Windows.Visibility.Visible;

                        string curr_add = String.Format("Item_Add_{0}", element);
                        Label curr_addon = (Label)Items_Grid.FindName(curr_add);
                        curr_addon.Content = add;


                        if (addon.Contains("S"))
                        {
                            Small.IsChecked = true;
                        }
                        else if (addon.Contains("M"))
                        {
                            Medium.IsChecked = true;
                            anInteger = Convert.ToDouble(CurrentPrice.Content);
                            anInteger = anInteger - .24;
                            CurrentPrice.Content = Convert.ToString(anInteger);
                        }
                        else
                        {
                            Large.IsChecked = true;
                            anInteger = Convert.ToDouble(CurrentPrice.Content);
                            anInteger = anInteger - .58;
                            CurrentPrice.Content = Convert.ToString(anInteger);
                        }

                    }
                    else
                    {

                    }


                }



            }
            FinalPrice.Content = (string)Application.Current.Properties["Total"];
        }

        private void Checkout_Click(object sender, RoutedEventArgs e) //checkout button
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
            
                if (items != null)
                {
                    Label Price = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                    Label items_add = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));

                    Application.Current.Properties[String.Format("Item_{0}", element)] = items.Content;
                    Application.Current.Properties[String.Format("Item_Add_{0}", element)] = items_add.Content;
                    Application.Current.Properties[String.Format("Price_{0}", element)] = Price.Content;


                    ComboBox Boost = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", element));
                    ComboBox Size = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));

                    if (Boost.Visibility == System.Windows.Visibility.Visible)
                    {
                        CheckBox Whey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", element));
                        CheckBox Smart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", element));
                        CheckBox Trim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", element));

                       

                        String Build = "B";

                        if (Whey.IsChecked == true)
                        {
                            Build = String.Concat(Build, "W");
                        }
                        if (Smart.IsChecked == true)
                        {
                            Build = String.Concat(Build, "R");
                        }
                        if (Trim.IsChecked == true)
                        {
                            Build = String.Concat(Build, "T");
                        }

                        Application.Current.Properties[String.Format("Addon_{0}", element)] = Build;

                    }
                    else if (Size.Visibility == System.Windows.Visibility.Visible)
                    {
                        String Build = "Z";

                        RadioButton Small = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", element));

                        RadioButton Medium = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", element));
                        RadioButton Large = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", element));

                        if (Small.IsChecked == true)
                        {
                            Build = String.Concat(Build, "S");
                        }
                        else if (Medium.IsChecked == true)
                        {
                            Build = String.Concat(Build, "M");
                        }
                        else
                        {
                            Build = String.Concat(Build, "L");
                        }
                        Application.Current.Properties[String.Format("Addon_{0}", element)] = Build;


                    }
                    else
                    {
                        Application.Current.Properties[String.Format("Addon_{0}", element)] = "N";
                    }







                }

                
            }
            Application.Current.Properties["Total"] = FinalPrice.Content;
            Switcher.Switch(new Checkout());
        }


        private void Button_Click(object sender, RoutedEventArgs e)   //cancel button
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Application.Current.Properties[String.Format("Item_{0}", element)] = null;
                Application.Current.Properties[String.Format("Addon_{0}", element)] = null;
                Application.Current.Properties["Total"] = "0.00";
            }
            Switcher.Switch(new Start());
        }

        private void Update_Total(Decimal add)
        {
            Decimal final = Convert.ToDecimal(FinalPrice.Content);
            final = final + add;

            FinalPrice.Content = Convert.ToString(final);

        }



        private void Delete_0_Click(object sender, RoutedEventArgs e)
        {
            String[] list5 = new String[] { "0", "1", "2", "3"};
            foreach (String element in list5)
            {
                Label current = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
                Label nextitem = (Label)Items_Grid.FindName(String.Format("Item_{0}", Convert.ToString(Convert.ToInt32(element)+1)));

                Label currentP = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                Label nextitemP = (Label)Items_Grid.FindName(String.Format("Price_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Button currentB = (Button)Items_Grid.FindName(String.Format("Delete_{0}", element));
                Button nextB = (Button)Items_Grid.FindName(String.Format("Delete_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                ComboBox currentBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));
                ComboBox nextBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                ComboBox currentBoost = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", element));
                ComboBox nextBoostBox = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
          

                CheckBox currentWhey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", element));
                CheckBox nextWhey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                CheckBox currentSmart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", element));
                CheckBox nextSmart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                CheckBox currentTrim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", element));
                CheckBox nextTrim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                 ComboBox currentSize = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));
                ComboBox nextSizeBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                RadioButton currentRadioS = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", element));
                RadioButton nextRadioS = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                RadioButton currentRadioM = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", element));
                RadioButton nextRadioM = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                RadioButton currentRadioL = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", element));
                RadioButton nextRadioL = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                String currentAddons = (String)Application.Current.Properties[String.Format("Addon_{0}", element)];

                Label currentLabel = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                Label nextLabel = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                if (nextitem.Content == null )
                {
                    

                    currentWhey.IsChecked = false;
                    currentSmart.IsChecked = false;
                    currentTrim.IsChecked = false;
                    currentRadioS.IsChecked = true;
                    currentRadioM.IsChecked = false;
                    currentRadioL.IsChecked = false;
                    Decimal anInteger = Convert.ToDecimal(currentP.Content);
                    Update_Total(-anInteger);
                    current.Content = null;
                    currentP.Content = null;

                    currentLabel.Content = null;


                    currentB.Visibility = System.Windows.Visibility.Hidden;
                    currentBox.Visibility = System.Windows.Visibility.Hidden;
                    currentBoost.Visibility = System.Windows.Visibility.Hidden;
                    currentSize.Visibility = System.Windows.Visibility.Hidden;
                   
                 
                 

                }
                else
                {
                   

                  
                    current.Content = nextitem.Content;
                   

                    currentWhey.IsChecked = nextWhey.IsChecked;
                    currentSmart.IsChecked = nextSmart.IsChecked;
                    currentTrim.IsChecked = nextTrim.IsChecked;

                    currentRadioS.IsChecked = nextRadioS.IsChecked;
                    currentRadioM.IsChecked = nextRadioM.IsChecked;
                    currentRadioL.IsChecked = nextRadioL.IsChecked;

                    if (nextSizeBox.Visibility == System.Windows.Visibility.Visible)
                    {
                        currentSize.Visibility = System.Windows.Visibility.Visible;
                        currentBoost.Visibility = System.Windows.Visibility.Hidden;
                        currentLabel.Content = nextLabel.Content;
                    }
                    else if (nextBoostBox.Visibility == System.Windows.Visibility.Visible)
                    {
                        currentSize.Visibility = System.Windows.Visibility.Hidden;
                        currentBoost.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        currentSize.Visibility = System.Windows.Visibility.Hidden;
                        currentBoost.Visibility = System.Windows.Visibility.Hidden;
                    }
                   
                    Decimal anInteger = Convert.ToDecimal(currentP.Content);
                    Update_Total(-anInteger);

                    currentP.Content = nextitemP.Content;

                 
                    nextitem.Content = null;
                    nextitemP.Content = null;

            
                   
                    
                }
                
            }
        }
        private void Delete_1_Click(object sender, RoutedEventArgs e)
        {
            String[] list5 = new String[] {"1", "2", "3" };
            foreach (String element in list5)
            {
                Label current = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
                Label nextitem = (Label)Items_Grid.FindName(String.Format("Item_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentP = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                Label nextitemP = (Label)Items_Grid.FindName(String.Format("Price_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Button currentB = (Button)Items_Grid.FindName(String.Format("Delete_{0}", element));
                Button nextB = (Button)Items_Grid.FindName(String.Format("Delete_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                ComboBox currentBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));
                ComboBox nextBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                ComboBox currentBoost = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", element));
                ComboBox nextBoostBox = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                CheckBox currentWhey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", element));
                CheckBox nextWhey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                CheckBox currentSmart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", element));
                CheckBox nextSmart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                CheckBox currentTrim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", element));
                CheckBox nextTrim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                ComboBox currentSize = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));
                ComboBox nextSizeBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                RadioButton currentRadioS = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", element));
                RadioButton nextRadioS = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                RadioButton currentRadioM = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", element));
                RadioButton nextRadioM = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                RadioButton currentRadioL = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", element));
                RadioButton nextRadioL = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                Label currentLabel = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                Label nextLabel = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                if (nextitem.Content == null)
                {


                    currentWhey.IsChecked = false;
                    currentSmart.IsChecked = false;
                    currentTrim.IsChecked = false;
                    currentRadioS.IsChecked = true;
                    currentRadioM.IsChecked = false;
                    currentRadioL.IsChecked = false;
                    currentLabel.Content = null;
                    Decimal anInteger = Convert.ToDecimal(currentP.Content);
                    Update_Total(-anInteger);
                    current.Content = null;
                    currentP.Content = null;
                    currentB.Visibility = System.Windows.Visibility.Hidden;
                    currentBox.Visibility = System.Windows.Visibility.Hidden;
                    currentBoost.Visibility = System.Windows.Visibility.Hidden;
                    currentSize.Visibility = System.Windows.Visibility.Hidden;




                }
                else
                {


        

                    current.Content = nextitem.Content;
                    currentWhey.IsChecked = nextWhey.IsChecked;
                    currentSmart.IsChecked = nextSmart.IsChecked;
                    currentTrim.IsChecked = nextTrim.IsChecked;

                    currentRadioS.IsChecked = nextRadioS.IsChecked;
                    currentRadioM.IsChecked = nextRadioM.IsChecked;
                    currentRadioL.IsChecked = nextRadioL.IsChecked;

                    if (nextSizeBox.Visibility == System.Windows.Visibility.Visible)
                    {
                        currentSize.Visibility = System.Windows.Visibility.Visible;
                        currentBoost.Visibility = System.Windows.Visibility.Hidden;
                        currentLabel.Content = nextLabel.Content;

                    }else if(nextBoostBox.Visibility == System.Windows.Visibility.Visible){
                        currentSize.Visibility = System.Windows.Visibility.Hidden;
                        currentBoost.Visibility = System.Windows.Visibility.Visible;
                    }else{
                        currentSize.Visibility = System.Windows.Visibility.Hidden;
                        currentBoost.Visibility = System.Windows.Visibility.Hidden;
                    }
                   


                    Decimal anInteger = Convert.ToDecimal(currentP.Content);
                    Update_Total(-anInteger);

                    currentP.Content = nextitemP.Content;


                    nextitem.Content = null;
                    nextitemP.Content = null;




                }

            }
        }

        private void Delete_2_Click(object sender, RoutedEventArgs e)
        {
            String[] list5 = new String[] {"2", "3" };
            foreach (String element in list5)
            {
                Label current = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
                Label nextitem = (Label)Items_Grid.FindName(String.Format("Item_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentP = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                Label nextitemP = (Label)Items_Grid.FindName(String.Format("Price_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Button currentB = (Button)Items_Grid.FindName(String.Format("Delete_{0}", element));
                Button nextB = (Button)Items_Grid.FindName(String.Format("Delete_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                ComboBox currentBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));
                ComboBox nextBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                ComboBox currentBoost = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", element));
                ComboBox nextBoostBox = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                CheckBox currentWhey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", element));
                CheckBox nextWhey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                CheckBox currentSmart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", element));
                CheckBox nextSmart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                CheckBox currentTrim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", element));
                CheckBox nextTrim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                ComboBox currentSize = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));
                ComboBox nextSizeBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                RadioButton currentRadioS = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", element));
                RadioButton nextRadioS = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                RadioButton currentRadioM = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", element));
                RadioButton nextRadioM = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                RadioButton currentRadioL = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", element));
                RadioButton nextRadioL = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentLabel = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                Label nextLabel = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                if (nextitem.Content == null)
                {

                    currentLabel.Content = null;
                    currentWhey.IsChecked = false;
                    currentSmart.IsChecked = false;
                    currentTrim.IsChecked = false;
                    currentRadioS.IsChecked = true;
                    currentRadioM.IsChecked = false;
                    currentRadioL.IsChecked = false;
                    Decimal anInteger = Convert.ToDecimal(currentP.Content);
                    Update_Total(-anInteger);
                    current.Content = null;
                    currentP.Content = null;
                    currentB.Visibility = System.Windows.Visibility.Hidden;
                    currentBox.Visibility = System.Windows.Visibility.Hidden;
                    currentBoost.Visibility = System.Windows.Visibility.Hidden;
                    currentSize.Visibility = System.Windows.Visibility.Hidden;




                }
                else
                {
               


                    current.Content = nextitem.Content;
                    currentWhey.IsChecked = nextWhey.IsChecked;
                    currentSmart.IsChecked = nextSmart.IsChecked;
                    currentTrim.IsChecked = nextTrim.IsChecked;

                    currentRadioS.IsChecked = nextRadioS.IsChecked;
                    currentRadioM.IsChecked = nextRadioM.IsChecked;
                    currentRadioL.IsChecked = nextRadioL.IsChecked;

                    if (nextSizeBox.Visibility == System.Windows.Visibility.Visible)
                    {
                        currentSize.Visibility = System.Windows.Visibility.Visible;
                        currentBoost.Visibility = System.Windows.Visibility.Hidden;
                        currentLabel.Content = nextLabel.Content;
                    }
                    else if (nextBoostBox.Visibility == System.Windows.Visibility.Visible)
                    {
                        currentSize.Visibility = System.Windows.Visibility.Hidden;
                        currentBoost.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        currentSize.Visibility = System.Windows.Visibility.Hidden;
                        currentBoost.Visibility = System.Windows.Visibility.Hidden;
                    }
                   

                    Decimal anInteger = Convert.ToDecimal(currentP.Content);
                    Update_Total(-anInteger);

                    currentP.Content = nextitemP.Content;


                    nextitem.Content = null;
                    nextitemP.Content = null;




                }

            }
        }
        private void Delete_3_Click(object sender, RoutedEventArgs e)
        {
            String[] list5 = new String[] { "3" };
            foreach (String element in list5)
            {
                Label current = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
                Label nextitem = (Label)Items_Grid.FindName(String.Format("Item_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentP = (Label)Items_Grid.FindName(String.Format("Price_{0}", element));
                Label nextitemP = (Label)Items_Grid.FindName(String.Format("Price_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Button currentB = (Button)Items_Grid.FindName(String.Format("Delete_{0}", element));
                Button nextB = (Button)Items_Grid.FindName(String.Format("Delete_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                ComboBox currentBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));
                ComboBox nextBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                ComboBox currentBoost = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", element));
                ComboBox nextBoostBox = (ComboBox)Items_Grid.FindName(String.Format("Boost_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                CheckBox currentWhey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", element));
                CheckBox nextWhey = (CheckBox)Items_Grid.FindName(String.Format("Whey_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                CheckBox currentSmart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", element));
                CheckBox nextSmart = (CheckBox)Items_Grid.FindName(String.Format("Smart_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                CheckBox currentTrim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", element));
                CheckBox nextTrim = (CheckBox)Items_Grid.FindName(String.Format("Trim_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));


                ComboBox currentSize = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", element));
                ComboBox nextSizeBox = (ComboBox)Items_Grid.FindName(String.Format("Size_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                RadioButton currentRadioS = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", element));
                RadioButton nextRadioS = (RadioButton)Items_Grid.FindName(String.Format("Small_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                RadioButton currentRadioM = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", element));
                RadioButton nextRadioM = (RadioButton)Items_Grid.FindName(String.Format("Medium_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));
                RadioButton currentRadioL = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", element));
                RadioButton nextRadioL = (RadioButton)Items_Grid.FindName(String.Format("Large_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                Label currentLabel = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                Label nextLabel = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", Convert.ToString(Convert.ToInt32(element) + 1)));

                if (nextitem.Content == null)
                {

                    currentLabel.Content = null;
                    currentWhey.IsChecked = false;
                    currentSmart.IsChecked = false;
                    currentTrim.IsChecked = false;
                    currentRadioS.IsChecked = true;
                    currentRadioM.IsChecked = false;
                    currentRadioL.IsChecked = false;
                    Decimal anInteger = Convert.ToDecimal(currentP.Content);
                    Update_Total(-anInteger);
                    current.Content = null;
                    currentP.Content = null;
                    currentB.Visibility = System.Windows.Visibility.Hidden;
                    currentBox.Visibility = System.Windows.Visibility.Hidden;
                    currentBoost.Visibility = System.Windows.Visibility.Hidden;
                    currentSize.Visibility = System.Windows.Visibility.Hidden;




                }
                else
                {


                    currentLabel.Content = nextLabel.Content;
                    current.Content = nextitem.Content;
                    currentWhey.IsChecked = nextWhey.IsChecked;
                    currentSmart.IsChecked = nextSmart.IsChecked;
                    currentTrim.IsChecked = nextTrim.IsChecked;

                    currentRadioS.IsChecked = nextRadioS.IsChecked;
                    currentRadioM.IsChecked = nextRadioM.IsChecked;
                    currentRadioL.IsChecked = nextRadioL.IsChecked;

                    Decimal anInteger = Convert.ToDecimal(currentP.Content);
                    Update_Total(-anInteger);

                    currentP.Content = nextitemP.Content;


                    nextitem.Content = null;
                    nextitemP.Content = null;




                }

            }
        }

        private void Special_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Candy Coca";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "3.38";
                    String boost = String.Concat("Size_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label size = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    size.Content = "Small";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }

        private void Coffee_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));
               
                if (items.Content == null)
                {
                    items.Content = "Coffee";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "1.90";
                    String boost = String.Concat("Size_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label size = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    size.Content = "Small";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Tea_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Tea";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "2.38";
                    String boost = String.Concat("Size_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label size = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    size.Content = "Small";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Mocha_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Mocha Coffee";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "2.14";
                    String boost = String.Concat("Size_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label size = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    size.Content = "Small";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                   
                    break;
                }



            }

        }
        private void Latte_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Latte";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "3.33";
                    String boost = String.Concat("Size_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label size = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    size.Content = "Small";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    
                    break;
                }



            }

        }
        private void Vanilla_Bean_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Vanilla Bean Latte";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "3.76";
                    String boost = String.Concat("Size_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label size = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    size.Content = "Small";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Mochanccino_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Mochaccino";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "3.90";
                    String boost = String.Concat("Size_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label size = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    size.Content = "Small";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
              
                    break;
                }



            }

        }
        private void Jamocha_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Ja'Mocha";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "4.85";
                   
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    
                    break;
                }



            }

        }
        private void Extreme_Toffee_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Extreme Toffee";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "4.85";
               
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                   
                    break;
                }



            }

        }
        private void Matcha_Green_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Matcha Green Tea";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "4.85";

                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                  
                    break;
                }



            }

        }
        private void Vanilla_Bean_C_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Vanilla Bean";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "4.85";

                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    
                    break;
                }



            }

        }
        private void Iced_Chocolate_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Iced Chocolate Coffee";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "3.95";

                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    
                    break;
                }



            }

        }
        private void Iced_Caramel_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Iced Chocolate Coffee";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "3.95";

                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                   
                    break;
                }



            }

        }
        private void Strawberry_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Strawberry Lemonade";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "4.10";

                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                
                    break;
                }



            }

        }
        private void Raspberry_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Raspberry Lemonade";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "4.10";

                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
              
                    break;
                }



            }

        }
        private void BLT_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "BTL Bagel";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "4.52";

                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
              
                    break;
                }



            }

        }
        private void Breakfast_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Breakfast Bagel";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "4.52";

                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Breakfast_Wrap_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Breakfast Wrap";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "3.99";

                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Caribbean_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Caribbean Sunrise";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.71";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label boosts = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    boosts.Content = "";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }

        private void Dreamscile_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Dreamsicle";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.71";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label boosts = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    boosts.Content = "";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }

        private void Pina_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Pina Colada Paradise";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.48";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label boosts = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    boosts.Content = "";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }

        private void Passionate_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Passionate Peach";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.48";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label boosts = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    boosts.Content = "";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }

        private void Chocolate_Banana_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Chocolate Banana Blitz";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.95";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Label boosts = (Label)Items_Grid.FindName(String.Format("Item_Add_{0}", element));
                    boosts.Content = "";
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Chocolate_Raspberry_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Choclate Raspberry Rush";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.95";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Tropical_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Tropical Green Tea";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.95";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Strawberry_Green_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Strawberry Green Tea Twister";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.95";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Berry_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Berry Explosion";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.71";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Tropical_Tango_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Tropical Tango";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "5.71";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Mango_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Mango Vegetable";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "6.48";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }
        private void Berry_Veg_Add(object sender, RoutedEventArgs e)
        {
            String[] list10 = new String[] { "0", "1", "2", "3" };
            foreach (String element in list10)
            {
                Label items = (Label)Items_Grid.FindName(String.Format("Item_{0}", element));

                if (items.Content == null)
                {
                    items.Content = "Berry Vegetable";
                    String prices = String.Concat("Price_", element);
                    Label price = (Label)Items_Grid.FindName(prices);
                    price.Content = "6.48";
                    String boost = String.Concat("Boost_", element);
                    ComboBox itemboost = (ComboBox)Items_Grid.FindName(boost);
                    itemboost.Visibility = System.Windows.Visibility.Visible;
                    Update_Total(Convert.ToDecimal(price.Content));
                    String delete = String.Concat("Delete_", element);
                    Button delets = (Button)Items_Grid.FindName(delete);
                    delets.Visibility = System.Windows.Visibility.Visible;
                    break;
                }



            }

        }

        private void CheckHandler(object obj, EventArgs e)
        {


            //String count = Convert.ToString(counter);
            //String con = String.Concat("PP", count);


            //Label hi = (Label)ItemPrice.FindName("PP0");
            //CheckBox current = (CheckBox)obj;
            //Decimal anInteger;


            //    anInteger = Convert.ToDecimal(hi.Content);
            //    anInteger = anInteger + 1;



            //hi.Content = Convert.ToString(anInteger);



        }

        private void Whey_0_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_0.Content);
            anInteger = anInteger + .71;
            Price_0.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));


            Item_Add_0.Content = String.Concat(Item_Add_0.Content, " + Whey");


        }
        private void Whey_0_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_0.Content);
            anInteger = anInteger - .71;
            Price_0.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));

            Item_Add_0.Content = "";
            if (Smart_0.IsChecked == true)
            {
                Item_Add_0.Content = String.Concat(Item_Add_0.Content, " + Smart");
            }
            if (Trim_0.IsChecked == true)
            {
                Item_Add_0.Content = String.Concat(Item_Add_0.Content, " + Trim");
            }
            

        }
        private void Smart_0_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_0.Content);
            anInteger = anInteger + .71;
            Price_0.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_0.Content = String.Concat(Item_Add_0.Content, " + Smart");
        }
        private void Smart_0_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_0.Content);
            anInteger = anInteger - .71;
            Price_0.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));

            Item_Add_0.Content = "";
            if (Whey_0.IsChecked == true)
            {
                Item_Add_0.Content = String.Concat(Item_Add_0.Content, " + Whey");
            }
            if (Trim_0.IsChecked == true)
            {
                Item_Add_0.Content = String.Concat(Item_Add_0.Content, " + Trim");
            }
        }
        private void Trim_0_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_0.Content);
            anInteger = anInteger + .71;
            Price_0.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_0.Content = String.Concat(Item_Add_0.Content, " + Trim");
            
        }
        private void Trim_0_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_0.Content);
            anInteger = anInteger - .71;
            Price_0.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));
            Item_Add_0.Content = "";
            if (Whey_0.IsChecked == true)
            {
                Item_Add_0.Content = String.Concat(Item_Add_0.Content, " + Whey");
            }
            if (Smart_0.IsChecked == true)
            {
                Item_Add_0.Content = String.Concat(Item_Add_0.Content, " + Smart");
            }



            
        }

        private void Small_0_UnCheck(object sender, RoutedEventArgs e)
        {

            Double anInteger;
            anInteger = Convert.ToDouble(Price_0.Content);

            if (Medium_0.IsChecked == true)
            {
                anInteger = anInteger + .24;
                Price_0.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.24));
                Item_Add_0.Content = "Medium";
            }
            if (Large_0.IsChecked == true)
            {
                anInteger = anInteger + .58;
                Price_0.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.58));
                Item_Add_0.Content = "Large";
            }
       

        }
   
 
        private void Medium_0_UnCheck(object sender, RoutedEventArgs e)
        {

            Double anInteger;
            anInteger = Convert.ToDouble(Price_0.Content);

            if (Small_0.IsChecked == true)
            {
                anInteger = anInteger - .24;
                Price_0.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.24));
                Item_Add_0.Content = "Small";
            }
            if (Large_0.IsChecked == true)
            {
                anInteger = anInteger + .34;
                Price_0.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.34));
                Item_Add_0.Content = "Large";
            }

        }

        private void Large_0_UnCheck(object sender, RoutedEventArgs e)
        {


            Double anInteger;
            anInteger = Convert.ToDouble(Price_0.Content);

            if (Small_0.IsChecked == true)
            {
                anInteger = anInteger - .58;
                Price_0.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.58));
                Item_Add_0.Content = "Small";
            }
            if (Medium_0.IsChecked == true)
            {
                anInteger = anInteger - .34;
                Price_0.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.34));
                Item_Add_0.Content = "Medium";
            }
        }

        private void Whey_1_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_1.Content);
            anInteger = anInteger + .71;
            Price_1.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_1.Content = String.Concat(Item_Add_1.Content, " + Whey");
        }
        private void Whey_1_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_1.Content);
            anInteger = anInteger - .71;
            Price_1.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));

            Item_Add_1.Content = "";
            if (Smart_1.IsChecked == true)
            {
                Item_Add_1.Content = String.Concat(Item_Add_1.Content, " + Smart");
            }
            if (Trim_1.IsChecked == true)
            {
                Item_Add_1.Content = String.Concat(Item_Add_1.Content, " + Trim");
            }
            
        }
        private void Smart_1_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_1.Content);
            anInteger = anInteger + .71;
            Price_1.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_1.Content = String.Concat(Item_Add_1.Content, " + Smart");

        }
        private void Smart_1_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_1.Content);
            anInteger = anInteger - .71;
            Price_1.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));

            Item_Add_1.Content = "";
            if (Whey_1.IsChecked == true)
            {
                Item_Add_1.Content = String.Concat(Item_Add_1.Content, " + Whey");
            }
            if (Trim_1.IsChecked == true)
            {
                Item_Add_0.Content = String.Concat(Item_Add_1.Content, " + Trim");
            }
        }
        private void Trim_1_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_1.Content);
            anInteger = anInteger + .71;
            Price_1.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_1.Content = String.Concat(Item_Add_1.Content, " + Trim");

        }
        private void Trim_1_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_1.Content);
            anInteger = anInteger - .71;
            Price_1.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));
            Item_Add_1.Content = "";
            if (Whey_1.IsChecked == true)
            {
                Item_Add_1.Content = String.Concat(Item_Add_1.Content, " + Whey");
            }
            if (Smart_1.IsChecked == true)
            {
                Item_Add_1.Content = String.Concat(Item_Add_1.Content, " + Smart");
            }
        }

        private void Small_1_UnCheck(object sender, RoutedEventArgs e)
        {

            Double anInteger;
            anInteger = Convert.ToDouble(Price_1.Content);

            if (Medium_1.IsChecked == true)
            {
                anInteger = anInteger + .24;
                Price_1.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.24));
                Item_Add_1.Content = "Medium";
            }
            if (Large_1.IsChecked == true)
            {
                anInteger = anInteger + .58;
                Price_1.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.58));
                Item_Add_1.Content = "Large";
            }


        }


        private void Medium_1_UnCheck(object sender, RoutedEventArgs e)
        {

            Double anInteger;
            anInteger = Convert.ToDouble(Price_1.Content);

            if (Small_1.IsChecked == true)
            {
                anInteger = anInteger - .24;
                Price_1.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.24));
                Item_Add_1.Content = "Small";
            }
            if (Large_1.IsChecked == true)
            {
                anInteger = anInteger + .34;
                Price_1.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.34));
                Item_Add_1.Content = "Large";
            }

        }

        private void Large_1_UnCheck(object sender, RoutedEventArgs e)
        {


            Double anInteger;
            anInteger = Convert.ToDouble(Price_1.Content);

            if (Small_1.IsChecked == true)
            {
                anInteger = anInteger - .58;
                Price_1.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.58));
                Item_Add_1.Content = "Small";
            }
            if (Medium_1.IsChecked == true)
            {
                anInteger = anInteger - .34;
                Price_1.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.34));
                Item_Add_1.Content = "Medium";
            }
        }



        private void Whey_2_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_2.Content);
            anInteger = anInteger + .71;
            Price_2.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_2.Content = String.Concat(Item_Add_2.Content, " + Whey");

        }
        private void Whey_2_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_2.Content);
            anInteger = anInteger - .71;
            Price_2.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));
            Item_Add_2.Content = "";
            if (Smart_2.IsChecked == true)
            {
                Item_Add_2.Content = String.Concat(Item_Add_2.Content, " + Smart");
            }
            if (Trim_2.IsChecked == true)
            {
                Item_Add_2.Content = String.Concat(Item_Add_2.Content, " + Trim");
            }
        }
        private void Smart_2_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_2.Content);
            anInteger = anInteger + .71;
            Price_2.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_2.Content = String.Concat(Item_Add_2.Content, " + Smart");
        }
        private void Smart_2_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_2.Content);
            anInteger = anInteger - .71;
            Price_2.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));
            Item_Add_2.Content = "";
            if (Whey_2.IsChecked == true)
            {
                Item_Add_2.Content = String.Concat(Item_Add_2.Content, " + Whey");
            }
            if (Trim_2.IsChecked == true)
            {
                Item_Add_2.Content = String.Concat(Item_Add_2.Content, " + Trim");
            }
        }

        private void Trim_2_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_2.Content);
            anInteger = anInteger + .71;
            Price_2.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_2.Content = String.Concat(Item_Add_2.Content, " + Trim");

        }
        private void Trim_2_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_2.Content);
            anInteger = anInteger - .71;
            Price_2.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));

            Item_Add_2.Content = "";
            if (Whey_2.IsChecked == true)
            {
                Item_Add_2.Content = String.Concat(Item_Add_2.Content, " + Whey");
            }
            if (Smart_2.IsChecked == true)
            {
                Item_Add_2.Content = String.Concat(Item_Add_2.Content, " + Smart");
            }
        }


        private void Small_2_UnCheck(object sender, RoutedEventArgs e)
        {

            Double anInteger;
            anInteger = Convert.ToDouble(Price_2.Content);

            if (Medium_2.IsChecked == true)
            {
                anInteger = anInteger + .24;
                Price_2.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.24));
                Item_Add_2.Content = "Medium";
            }
            if (Large_2.IsChecked == true)
            {
                anInteger = anInteger + .58;
                Price_2.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.58));
                Item_Add_2.Content = "Large";
            }


        }


        private void Medium_2_UnCheck(object sender, RoutedEventArgs e)
        {

            Double anInteger;
            anInteger = Convert.ToDouble(Price_2.Content);

            if (Small_2.IsChecked == true)
            {
                anInteger = anInteger - .24;
                Price_2.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.24));
                Item_Add_2.Content = "Small";
            }
            if (Large_2.IsChecked == true)
            {
                anInteger = anInteger + .34;
                Price_2.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.34));
                Item_Add_2.Content = "Large";
            }

        }

        private void Large_2_UnCheck(object sender, RoutedEventArgs e)
        {


            Double anInteger;
            anInteger = Convert.ToDouble(Price_2.Content);

            if (Small_2.IsChecked == true)
            {
                anInteger = anInteger - .58;
                Price_2.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.58));
                Item_Add_2.Content = "Small";
            }
            if (Medium_2.IsChecked == true)
            {
                anInteger = anInteger - .34;
                Price_2.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.34));
                Item_Add_2.Content = "Medium";
            }
        }


        private void Whey_3_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_3.Content);
            anInteger = anInteger + .71;
            Price_3.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_3.Content = String.Concat(Item_Add_3.Content, " + Whey");
        }
        private void Whey_3_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_3.Content);
            anInteger = anInteger - .71;
            Price_3.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));


            Item_Add_3.Content = "";
            if (Smart_3.IsChecked == true)
            {
                Item_Add_3.Content = String.Concat(Item_Add_3.Content, " + Smart");
            }
            if (Trim_3.IsChecked == true)
            {
                Item_Add_3.Content = String.Concat(Item_Add_3.Content, " + Trim");
            }
        }
        private void Smart_3_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_3.Content);
            anInteger = anInteger + .71;
            Price_3.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_3.Content = String.Concat(Item_Add_3.Content, " + Smart");
        }
        private void Smart_3_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_3.Content);
            anInteger = anInteger - .71;
            Price_3.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));
            Item_Add_3.Content = "";
            if (Whey_3.IsChecked == true)
            {
                Item_Add_3.Content = String.Concat(Item_Add_3.Content, " + Whey");
            }
            if (Trim_3.IsChecked == true)
            {
                Item_Add_3.Content = String.Concat(Item_Add_3.Content, " + Trim");
            }
        }
        private void Trim_3_Check(object sender, RoutedEventArgs e)
        {

            Double anInteger;

            anInteger = Convert.ToDouble(Price_3.Content);
            anInteger = anInteger + .71;
            Price_3.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(.71));
            Item_Add_3.Content = String.Concat(Item_Add_3.Content, " + Trim");

        }
        private void Trim_3_UnCheck(object sender, RoutedEventArgs e)
        {
            Double anInteger;

            anInteger = Convert.ToDouble(Price_3.Content);
            anInteger = anInteger - .71;
            Price_3.Content = Convert.ToString(anInteger);
            Update_Total(Convert.ToDecimal(-.71));
            Item_Add_3.Content = "";
            if (Whey_3.IsChecked == true)
            {
                Item_Add_3.Content = String.Concat(Item_Add_3.Content, " + Whey");
            }
            if (Smart_3.IsChecked == true)
            {
                Item_Add_3.Content = String.Concat(Item_Add_3.Content, " + Smart");
            }
        }


        private void Small_3_UnCheck(object sender, RoutedEventArgs e)
        {

            Double anInteger;
            anInteger = Convert.ToDouble(Price_3.Content);

            if (Medium_3.IsChecked == true)
            {
                anInteger = anInteger + .24;
                Price_3.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.24));
                Item_Add_3.Content = "Medium";
            }
            if (Large_3.IsChecked == true)
            {
                anInteger = anInteger + .58;
                Price_3.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.58));
                Item_Add_3.Content = "Large";
            }

           


        }


        private void Medium_3_UnCheck(object sender, RoutedEventArgs e)
        {

            Double anInteger;
            anInteger = Convert.ToDouble(Price_3.Content);

            if (Small_3.IsChecked == true)
            {
                anInteger = anInteger - .24;
                Price_3.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.24));
                Item_Add_3.Content = "Small";
            }
            if (Large_3.IsChecked == true)
            {
                anInteger = anInteger + .34;
                Price_3.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(.34));
                Item_Add_3.Content = "Large";
            }

        }

        private void Large_3_UnCheck(object sender, RoutedEventArgs e)
        {


            Double anInteger;
            anInteger = Convert.ToDouble(Price_3.Content);

            if (Small_3.IsChecked == true)
            {
                anInteger = anInteger - .58;
                Price_3.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.58));
                Item_Add_3.Content = "Small";
            }
            if (Medium_3.IsChecked == true)
            {
                anInteger = anInteger - .34;
                Price_3.Content = Convert.ToString(anInteger);
                Update_Total(Convert.ToDecimal(-.34));
                Item_Add_3.Content = "Medium";
            }
        }

        private void Button_Click_bell(object sender, RoutedEventArgs e)    //bell button
        {
            MessageBox.Show("An employee is on their way to help.");
        }

    }

}
