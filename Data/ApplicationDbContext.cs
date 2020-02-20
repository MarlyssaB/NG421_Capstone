using AutoMapper.Configuration;
using capstone.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Data
{

    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public IConfiguration Configuration { get; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<movieEntry> MovieEntries { get; set;}
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }
        public ApplicationDbContext() : base(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite("Data Source=app.db").Options,null)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

           builder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Jon", LastName = "Smith"},
                new Student { Id = 2, FirstName = "Bobby", LastName = "Miller"},
                new Student { Id = 3, FirstName = "Sarah", LastName = "Brooks"}
            );

            // builder.Entity<Teacher>().HasData(
            //     new Teacher { Id = 1, FirstName = "Sam", LastName = "Smith" },
            //     new Teacher { Id = 2, FirstName = "Tom", LastName = "Miller" },
            //     new Teacher { Id = 1, FirstName = "Mary", LastName = "Brooks" }
            // );

            builder.Entity<movieEntry>().HasData(
                new movieEntry { id = 1, title = "The Silence of the Lambs", genre = "Thriller, Horror", stars = 5, review = "Edge of your seat thriller, amazing performance by Anthony Hopkins"},
                new movieEntry { id = 2, title = "Chicago", genre = "Muscial, Drama", stars = 3, review = "Some memorable songs, decent date night movie"},
                new movieEntry { id = 3, title = "The Room", genre = "Drama", stars = 2, review = "Awful movie that's fun it its own way. Best seen at a midnight showing"},
                new movieEntry { id = 4, title = "Animal Crackers", genre = "Musical, Comedy", stars = 4, review = "One of the Marx Brothers' best works"}


            );

        }
    }
}
