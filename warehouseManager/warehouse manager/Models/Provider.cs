using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse_manager.Models
{
    public class Provider
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(10)]
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }

        [Browsable(false)]
        public virtual ICollection<SupplyingOrder> SupplyingOrders { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
