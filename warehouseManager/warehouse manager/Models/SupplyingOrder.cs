using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse_manager.Models
{
    public class SupplyingOrder
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Number { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public virtual Warehouse Warehouse { get; set; }
        public virtual Provider Provider { get; set; }

        [Browsable(false)]
        public virtual ICollection<Item> Items { get; set; }
    }
}
