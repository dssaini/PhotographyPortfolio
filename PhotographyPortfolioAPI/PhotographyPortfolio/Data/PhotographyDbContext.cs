using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class PhotographyDbContext: DbContext
    {
        public PhotographyDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Carousel> carousels { get; set; }
        public DbSet<Index_description> index_Descriptions { get; set; }
        public DbSet<AboutTheArtist> aboutTheArtists { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Tags> tags { get; set; }
        public DbSet<Portfolio> portfolios { get; set; }
        
    }
}
