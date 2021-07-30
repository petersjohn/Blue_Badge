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
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        //post
        //api/Restaurant
        [HttpPost] //this eliminates the need for naming conventions on post, since .NET doesn't have to assume
        public async Task<IHttpActionResult> CreateRestaurant([FromBody]Restaurant model)
        {
            if(model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }
            if (ModelState.IsValid)
            {
                //store the model in the db
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync(); //this returns an int count of all the changes that were made
                                                   //so in theory you could do "int changeCnt = await _context.SaveC....
                                                   //and use this later for validation if you care.
                return Ok("Your restaurant was saved!");
            }
            //if the model is not valid, reject it
            return BadRequest(ModelState);
        }

    }
}
