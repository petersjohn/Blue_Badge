using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{   //Left off at https://elevenfifty.instructure.com/courses/749/pages/rr-api-2-dot-03-delete-functionality?module_item_id=65350
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
        //GET ALL
        //api/Restaurant

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {   
            
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        //GET BY ID
        //api/Restaurant/{id}
        [HttpGet]

        public async Task<IHttpActionResult> GetByID([FromUri] int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if(restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        //PUT (update)
        // api/Restaurant/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri]int id, [FromBody] Restaurant updatedRestaurant)
        {
            //Check the IDs to see if the match
            if(id != updatedRestaurant?.Id) //? this prevents an exception if the model returned is null; you can't access the id of a null object!(duh)
            {
                return BadRequest("Ids do not match");
            }
            //Check the model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Find the restaurant in the db
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            //if not found, then do a thing
            if (restaurant is null)
                return NotFound();

            //update the properties
            restaurant.Name = updatedRestaurant.Name;
            restaurant.Address = updatedRestaurant.Address;
            restaurant.Rating = updatedRestaurant.Rating;

            //Save the changes
            await _context.SaveChangesAsync();
            return Ok("Update successful!");
        }
    }
}
