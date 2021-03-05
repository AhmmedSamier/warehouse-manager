using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse_manager.Models
{
    public class Product
    {
        [Browsable(false)]
        public int Id { get; set; }

        [StringLength(150)]
        public string Code { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Browsable(false)]
        public virtual ICollection<Unit> Units { get; set; }
        [Browsable(false)]
        public virtual ICollection<Item> Items { get; set; }

    }
}
