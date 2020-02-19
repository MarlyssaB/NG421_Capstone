using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capstone.Data;
using capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace capstone.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<movieEntry> Get()
        {
            movieEntry[] movies = null;
            using (var context = new ApplicationDbContext())
            {
                movies = context.MovieEntries.ToArray();
            }
            return movies;

        }
        [HttpPost]
        public movieEntry Post([FromBody]movieEntry entry)
        {
            using (var context = new ApplicationDbContext())
            {
                context.MovieEntries.Add(entry);
                context.SaveChanges();
            }
            return entry;
        }
    }
}