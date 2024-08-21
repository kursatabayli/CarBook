using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Context
{
	public class CarBookContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=HP\\SQLEXPRESS;initial Catalog=CarBookDb;integrated Security=true;TrustServerCertificate=True");
		}
		public DbSet<About> Abouts { get; set; }
		public DbSet<Banner> Banners { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<CarDescription> CarDescriptions { get; set; }
		public DbSet<CarFeature> CarFeatures { get; set; }
		public DbSet<CarPricing> CarPricings { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<FooterAddress> FooterAddresses { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Pricing> Pricings { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<SocialMedia> SocialMedias { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<TagCloud> TagClouds { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<CarFuel> CarFuels { get; set; }
		public DbSet<CarLuggage> CarLuggages { get; set; }
		public DbSet<CarTransmission> CarTransmissions  { get; set; }
		public DbSet<RentACar> RentACars { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Reservation>()
				.HasOne(x => x.PickUpLocation)
				.WithMany(y => y.PickUpReservation)
				.HasForeignKey(z => z.PickUpLocationID)
				.OnDelete(DeleteBehavior.ClientSetNull);
			
			modelBuilder.Entity<Reservation>()
				.HasOne(x => x.DropOffLocation)
				.WithMany(y => y.DropOffReservation)
				.HasForeignKey(z => z.DropOffLocationID)
				.OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Feature>()
                .ToTable(tb => tb.HasTrigger("trg_InsertCarFeature"));
			
			modelBuilder.Entity<Car>()
                .ToTable(tb => tb.HasTrigger("trg_InsertCarFeature"));

        }

    }
}
