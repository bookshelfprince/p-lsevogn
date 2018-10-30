using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiProgrammering.Types
{
    public class Customer
    {
        public string Name { get; set; }
        public string TableName { get; set; }
        public Order Order { get; set; }
    }
}
