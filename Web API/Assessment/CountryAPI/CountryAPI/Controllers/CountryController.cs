using CountryAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CountryAPI.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "Singapore", Capital = "Singapore" },
            new Country { ID = 2, CountryName = "Malaysia", Capital = "Kuala Lampur" }
        };

        public IEnumerable<Country> GetCountries()
        {
            return countries;
        }

        public IHttpActionResult GetCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        public IHttpActionResult PostCountry(Country country)
        {
            country.ID = countries.Max(c => c.ID) + 1;
            countries.Add(country);
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        public IHttpActionResult PutCountry(int id, Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            countries.Remove(country);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}