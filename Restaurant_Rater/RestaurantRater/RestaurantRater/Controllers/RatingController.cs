using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RatingController : ApiController
    {

        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        //create new ratings
        //post api/Rating
        [HttpPost]
        public async Task<IHttpActionResult> CreateRating([FromBody] Rating model)
        {
            //check the model is null
            if (model is null)
                return BadRequest("Your Request Body cannot be empty");
            //check the model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //find the restau by the model.RestaurantId and see that it exists
            var restaurantEntity = await _context.Restaurants.FindAsync(model.RestaurantId);
            if (restaurantEntity is null)
                return BadRequest($"The target restaurant with the ID of {model.RestaurantId} does not exist.");

            //add to the rating table
            //_context.Ratings.Add(model);
            // OR YOU COULD DO IT THIS WAY
            restaurantEntity.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
                return Ok($"You rated restaurnat {restaurantEntity.Name} sucessfully");
            return InternalServerError();
        }
        //get a rating by its id

        //get all ratings

        //get all ratings for a restaurant by the restaurant id

        //Update a rating

        //delete a rating
    }
}
