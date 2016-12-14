using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesTracker.Models
{
    public class Measurements
    {
        [Key]
        public int Id { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Chest { get; set; }
        public int OverArm { get; set; }
        public int Waist { get; set; }
        public int Hip { get; set; }
        public int Outseam { get; set; }
        public int Neck { get; set; }
        public int ShirtSleeve { get; set; }
    }
}