using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Discar.Models
{
    public class DiscContext : DbContext
    {
        public DiscContext(DbContextOptions<DiscContext> options)
            : base(options)
        { }

        public DbSet<Disc> Discs { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
    public class Disc
    {
        public int DiscId { get; set; }
        public string Plastic { get; set; }

        public float Speed { get; set; }
        public float Glide { get; set; }
        public float Stability { get; set; }
        public float Fade { get; set; }

        public float Price { get; set; }
        
        public string Url { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }

    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        

        public List<Disc> Discs { get; set; }
    }
}
