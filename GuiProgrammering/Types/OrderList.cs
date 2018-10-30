using System.Collections.Generic;

namespace GuiProgrammering.Types
{
    public class Order
    {
        public Order(string tableName, List<string> items)
        {
            TableName = tableName;
            Items = items;
            foreach (string item in items)
                OrderString += item + ", ";
        }
        public int Number { get; set; }
        public string TableName { get; set; }
        public List<string> Items { get; set; }
        public string OrderString { get; set; }
        public bool Delivered { get; set; }
    }
}
