using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace X96J2O_HFT_2021222.Models
{
    public class Brand
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int brandId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }

        public Brand()
        {
            Cars = new HashSet<Car>();
        }

    }
}
