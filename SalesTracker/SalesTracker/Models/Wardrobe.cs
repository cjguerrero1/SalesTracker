using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesTracker.Models
{
    public class Wardrobe
    {
        [Key]
        public int Id { get; set; }
        public List<string> SuitsAndSportCoats { get; set; }
        public List<string> Shoes { get; set; }
        public List<string> CareProducts { get; set; }
        public List<string> DressShirts { get; set; }
        public List<string> DressSlacks { get; set; }
        public List<string> Accessories { get; set; }
    }
}