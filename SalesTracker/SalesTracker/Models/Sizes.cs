using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesTracker.Models
{
    public class Sizes
    {
        [Key]
        public int Id { get; set; }
        public string JacketSize { get; set; }
        public string PantSize { get; set; }
        public string DressShirtSize { get; set; }
        public string CasualSize { get; set; }
        public string ShoeSize { get; set; }

    }
}