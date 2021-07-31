using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("DefaultConnection")
        {
                
        }

        public DbSet<Restaurant> Restaurants { get; set; } //we are creating a DB "table" called restaurants
        public DbSet<Rating> Ratings { get; set; } //creating the table for the ratings.
    }
}