﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstoneproject.Models
{
    public class Barcomments
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarName { get; set; }
        public string Comment { get; set; }
        public DateTime PostDate { get; set; }

    }
}