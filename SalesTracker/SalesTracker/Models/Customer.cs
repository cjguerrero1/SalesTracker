using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalesTracker.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("SalesPerson")]
        public int SalesPersonId { get; set; }
        public SalesPerson SalesPerson { get; set; }

        [ForeignKey("Measurements")]
        public int MeasurementsId { get; set; }
        public Measurements Measurements { get; set; }

        [ForeignKey("Sizes")]
        public int SizesId { get; set; }
        public Sizes Sizes { get; set; }

        [ForeignKey("CustomerInfo")]
        public int CustomerInfoId { get; set; }
        public CustomerInfo CustomerInfo { get; set; }

        [ForeignKey("Wardrobe")]
        public int WardrobeId { get; set; }
        public Wardrobe Wardrobe { get; set; }

    }
}