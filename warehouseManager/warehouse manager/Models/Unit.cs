using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse_manager.Models
{
    public class Unit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Browsable(false)]
        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
