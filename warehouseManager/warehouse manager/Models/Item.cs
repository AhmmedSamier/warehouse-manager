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
    public class Item
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }
        public int SuppliedQuantity { get; set; }

        [Column(TypeName = "Date")] 
        public DateTime ProductionDate { get; set; }

        [DisplayName("Expiry (days)")]
        public int Expiry { get; set; }

        public virtual Unit Unit { get; set; }

        [Browsable(false)]
        public virtual SupplyingOrder SupplyingOrder { get; set; }

        [Browsable(false)]
        public virtual ExchangeOrder ExchangeOrder { get; set; }

        [Browsable(false)]
        public virtual Product Product { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Warehouse Warehouse { get; set; }

    }
}
