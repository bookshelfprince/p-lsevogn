using GuiProgrammering.Popups;
using GuiProgrammering.Types;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GuiProgrammering
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : UserControl
    {
        internal Customer customer;
        internal List<Order> allOrders;
        private MainWindow main;
        public OrderPage(MainWindow Main, Customer Customer, List<Order> AllOrders)
        {
            InitializeComponent();
            customer = Customer;
            main = Main;
            allOrders = AllOrders;
            orderButton.IsEnabled = false;
            Tables tables = new Tables();
            customerNameTableCombo.ItemsSource = tables;
            customer.Name = customerNameTextBox.Text;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(customerNameTextBox.Text))
            {
                if (customerNameTableCombo.SelectedItem != null)
                {
                    allOrders.Add(customer.Order);
                    main.SwitchGrid("Orderlist");
                }
            }
        }

        private void OrderType_Click(object sender, RoutedEventArgs e)
        {
            Button temp = (Button)sender;
            switch (temp.Name)
            {
                case "standardHotDogButton":
                    Order order = new Order(customer.TableName, ItemlistCreate());
                    customer.Order = order;
                    standardHotDogButton.IsEnabled = false;
                    advancedOrderButton.IsEnabled = false;
                    orderButton.IsEnabled = true;
                    break;
                case "advancedOrderButton":
                    AdvancedOrder advancedOrderPopup = new AdvancedOrder(this);
                    advancedOrderPopup.ShowDialog();
                    advancedOrderButton.IsEnabled = false;
                    standardHotDogButton.IsEnabled = false;
                    orderButton.IsEnabled = true;
                    break;
                default:
                    break;
            }
        }

        internal List<string> ItemlistCreate(string sausage = "Kogt pølse", string sennep = "sennep", string ketchup = "ketchup", string remoulade = null, string ristedeloeg = "ristede løg", string raaloeg = null, string syltedeloeg = null, string agurkesalat = "agurkesalat")
        {
            List<string> items = new List<string>();
            if (sausage != null)
                items.Add(sausage);
            if (sennep != null)
                items.Add(ketchup);
            if (remoulade != null)
                items.Add(remoulade);
            if (ristedeloeg != null)
                items.Add(ristedeloeg);
            if (raaloeg != null)
                items.Add(raaloeg);
            if (syltedeloeg != null)
                items.Add(syltedeloeg);
            if (agurkesalat != null)
                items.Add(agurkesalat);

            return items;
        }

        private void CustomerNameTableCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) => customer.TableName = customerNameTableCombo.SelectedItem.ToString();
    }
}
