using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse_manager.Models
{
    public class ExchangeOrder
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Browsable(false)]
        public virtual ICollection<Item> Items { get; set; }
        public virtual Warehouse SourceWarehouse { get; set; }
        public virtual Warehouse DestinationWarehouse { get; set; }
    }
}
