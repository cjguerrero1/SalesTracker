using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesTracker.Models
{
    public class CustomerInfo
    {
        [Key]
        public int Id { get; set; }
        public string Occupation { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Hobbies { get; set; }

    }
}