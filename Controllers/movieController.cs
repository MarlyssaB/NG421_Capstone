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
        public ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context){
            _context = context;
        }

        [HttpGet]
        public IEnumerable<movieEntry> Get()
        {
            movieEntry[] movies = null;
            
            movies = _context.MovieEntries.ToArray();
            
            return movies;

        }
        [HttpPost]
        public movieEntry Post([FromBody]movieEntry entry)
        {
         
            _context.MovieEntries.Add(entry);
            _context.SaveChanges();
        
            return entry;
        }
    }
}