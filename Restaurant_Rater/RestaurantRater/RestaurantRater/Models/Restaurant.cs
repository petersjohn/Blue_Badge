using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        //this is what the db table we set up in teh RestaurantDbContext.cs for restaurant is going to look like
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double Rating { get; set; }

    }
}