using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse_manager.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public virtual  PaymentOrder PaymentOrder { get; set; }
        public virtual Item Item { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
