using GuiProgrammering.Types;
using System.Windows;

namespace GuiProgrammering.Popups
{
    /// <summary>
    /// Interaction logic for AdvancedOrder.xaml
    /// </summary>
    public partial class AdvancedOrder : Window
    {
        private OrderPage orderPage;
        public AdvancedOrder(OrderPage page)
        {
            InitializeComponent();
            orderPage = page;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            string sausage = null;
            string sennep = null;
            string ketchup = null;
            string remoulade = null;
            string ristedeloeg = null;
            string raaloeg = null;
            string syltedeloeg = null;
            string agurkesalat = null;

            if ((bool)sennepCheckBox.IsChecked)
                sennep = "sennep";
            if ((bool)ketchupCheckBox.IsChecked)
                ketchup = "ketchup";
            if ((bool)remouladeCheckBox.IsChecked)
                remoulade = "remoulade";
            if ((bool)ristedeLoegCheckBox.IsChecked)
                ristedeloeg = "ristede løg";
            if ((bool)raaLoegCheckBox.IsChecked)
                raaloeg = "rå løg";
            if ((bool)syltedeLoegCheckBox.IsChecked)
                syltedeloeg = "syltede løg";
            if ((bool)agurkesalatCheckBox.IsChecked)
                agurkesalat = "agurkesalat";
            if ((bool)kogtRadioButton.IsChecked)
                sausage = "Kogt pølse";
            if ((bool)stegtRadioButton.IsChecked)
                sausage = "Stegt pølse";
            if ((bool)stegtXLRadioButton.IsChecked)
                sausage = "Stegt XL pølse";

            if (sausage != null)
            {
                Order order = new Order(orderPage.customer.TableName, orderPage.ItemlistCreate(sausage, sennep, ketchup, remoulade, ristedeloeg, raaloeg, syltedeloeg, agurkesalat));
                orderPage.customer.Order = order;
                Close();
            }
        }
    }
}
