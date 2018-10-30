using GuiProgrammering.Types;
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

namespace GuiProgrammering
{
    /// <summary>
    /// Interaction logic for OrderList.xaml
    /// </summary>
    public partial class OrderList : UserControl
    {
        private readonly MainWindow main;
        public OrderList(MainWindow Main, Customer Customer, List<Order> AllOrders)
        {
            InitializeComponent();
            main = Main;
            foreach (Order item in AllOrders)
                item.Number = AllOrders.IndexOf(item);
            orderList.ItemsSource = AllOrders;
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Order order = (Order)btn.DataContext;
            List<Order> tempList = (List<Order>)orderList.ItemsSource;
            tempList.Remove(order);
            orderList.ItemsSource = tempList;
            orderList.Items.Refresh();
        }

        private void BtnDelivered_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Order order = (Order)btn.DataContext;
            order.Delivered = !order.Delivered;
            List<Order> tempList = (List<Order>)orderList.ItemsSource;
            tempList.Remove(order);
            tempList.Add(order);
            orderList.ItemsSource = tempList;
            orderList.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e) => main.SwitchGrid("Orderpage");
    }
}
