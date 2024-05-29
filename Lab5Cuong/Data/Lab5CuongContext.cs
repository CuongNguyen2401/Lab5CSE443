using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Lab5Cuong.Models;

namespace Lab5Cuong.Data
{
    public class Lab5CuongContext : DbContext
    {
        public Lab5CuongContext(DbContextOptions<Lab5CuongContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().HasKey(sc => new { sc.PersonId, sc.MovieId, sc.Role });

            // Seed movie data
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Action Movie",
                    ReleaseDate = new DateTime(2020, 1, 1),
                    Price = 19.99,
                    Rating = 4.5,
                    ProducerId = 1
                },
                new Movie
                {
                    Id = 2,
                    Title = "Comedy Movie",
                    ReleaseDate = new DateTime(2021, 5, 20),
                    Price = 14.99,
                    Rating = 4.0,
                    ProducerId = 2
                },
                new Movie
                {
                    Id = 3,
                    Title = "Drama Movie",
                    ReleaseDate = new DateTime(2022, 3, 15),
                    Price = 9.99,
                    Rating = 3.8,
                    ProducerId = 3
                }
            );
        }
    }
}
