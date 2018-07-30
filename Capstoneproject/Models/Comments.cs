using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EventName { get; set; }
        public string RestaurantName { get; set; }
        public string BarName { get; set; }
        public string Post { get; set; }
        public DateTime PostDate { get; set; }
    }
}