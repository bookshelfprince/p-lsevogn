using GuiProgrammering.Types;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GuiProgrammering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Order> allOrders;
        private OrderPage orderPage;
        private OrderList orderList;
        public MainWindow()
        {
            InitializeComponent();
            allOrders = new List<Order>();
            orderPage = new OrderPage(this, new Customer(), allOrders);
            orderList = new OrderList(this, new Customer(), allOrders);
            grid.Children.Add(orderPage);
        }

        internal void SwitchGrid(string windowType)
        {
            switch (windowType)
            {
                case "Orderlist":
                    grid.Children.Remove(orderPage);
                    orderPage = null;
                    orderList = new OrderList(this, new Customer(), allOrders);
                    grid.Children.Add(orderList);
                    break;
                case "Orderpage":
                    grid.Children.Remove(orderList);
                    orderList = null;
                    orderPage = new OrderPage(this, new Customer(), allOrders);
                    grid.Children.Add(orderPage);
                    break;
            }
        }
    }
}
