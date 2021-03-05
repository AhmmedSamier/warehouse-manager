using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse_manager.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string StockKeeper { get; set; }

        [Browsable(false)]
        public virtual ICollection<SupplyingOrder> SupplyingOrders { get; set; }
        
        [Browsable(false)]
        public virtual ICollection<PaymentOrder> PaymentOrders { get; set; }
        
        [Browsable(false)]
        public virtual ICollection<Item> Items { get; set; }

        [Browsable(false)]
        [InverseProperty("SourceWarehouse")]
        public virtual ICollection<ExchangeOrder> ExchangeOrdersSource { get; set; }

        [Browsable(false)]
        [InverseProperty("DestinationWarehouse")]
        public virtual ICollection<ExchangeOrder> ExchangeOrdersDestination { get; set; }


        public override string ToString()
        {
            return this.Name;
        }
    }
}
