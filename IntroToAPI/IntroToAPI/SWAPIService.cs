using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI
{
    class SWAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Person> GetPersonAsync(string url)
        {
            /*   HttpResponseMessage response = await _httpClient.GetAsync(url);
               if (response.IsSuccessStatusCode)
               {
                   Person person = await response.Content.ReadAsAsync<Person>();
                   return person;
               }

               return null;*/

            return await GetAsync<Person>(url);
        }

        public async Task<Vehicle> GetVehicleAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<Vehicle>() : null;

        }

        public async Task<T> GetAsync<T>(string url) where T: class   //this to make null work, because a class is nullable
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                T content = await response.Content.ReadAsAsync<T>();
                return content;
            }
            //return default; this is if you don't want this to be nullable.
            return null;
        }

        public async Task<SearchResult<Person>> GetPersonSearchAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://swapi.dev/api/people/?search=" + query);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<Person>>();
            }
            return null;
        }

        public async Task<SearchResult<T>>GetSearchAsynch<T>(string query,string category)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://swapi.dev/api/{category}?search={query}");
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<SearchResult<T>>() : default;
        }

        public async Task<SearchResult<Vehicle>> GetVehicleSearchAsync(string query)
        {
            return await GetSearchAsynch<Vehicle>(query, "vehicles");
        }

    }
}
