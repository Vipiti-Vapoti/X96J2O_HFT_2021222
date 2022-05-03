using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace X96J2O_HFT_2021222.Models
{
    public class Car
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int carId { get; set; }

        public string Model { get; set; }

        public int RentPrice { get; set; }

        [NotMapped]
        public virtual Brand Brand { get; set; }

        
        [NotMapped]
        public virtual ICollection<Rent> Rents { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public Car()
        {
            
        }
    }
}
