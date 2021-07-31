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

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
        public double Rating
        {
            get
            {
                double totalAvgRating = 0;

                foreach(var rating in Ratings)
                {
                    totalAvgRating += rating.AvgRating;
                }

                return Ratings.Count > 0 ? Math.Round(totalAvgRating / Ratings.Count,2) : 0;


            }
        }
        
        public bool IsRecommended
        {
            get
            {
                return Rating >= 8;
            }
        }

    }
}