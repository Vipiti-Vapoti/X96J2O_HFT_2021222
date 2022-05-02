using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X96J2O_HFT_2021222.Models
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RentTime { get; set; }
        public int Cost { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string Mail { get; set; }

        [NotMapped]
        public virtual Car Car { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        
    }
}
