using CoreSTSolutionApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreSTSolutionApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Java"});
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "ASP.NET" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "PHP" });
            
            // Seed Tags
            modelBuilder.Entity<Tag>().HasData(new Tag {TagId = 1, Name = "Programming"});
            modelBuilder.Entity<Tag>().HasData(new Tag {TagId = 2, Name = "Traveling"});
            modelBuilder.Entity<Tag>().HasData(new Tag {TagId = 3, Name = "Software"});

            // Seed Blogs
            modelBuilder.Entity<Blog>().HasData(new Blog
            {
                BlogId = 1,
                Name = "Java Fundamentals",
                ShortDescription = "Lorem Ipsum",
                LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                ImageUrl = "https://via.placeholder.com/500",
                ImageThumbnailUrl = "https://via.placeholder.com/200",
            });
            
            modelBuilder.Entity<Blog>().HasData(new Blog
            {
                BlogId = 2,
                Name = "ASP.NET Fundamentals",
                ShortDescription = "Lorem Ipsum",
                LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 2,
                ImageUrl = "https://via.placeholder.com/500",
                ImageThumbnailUrl = "https://via.placeholder.com/200",
            });
            
            modelBuilder.Entity<Blog>().HasData(new Blog
            {
                BlogId = 3,
                Name = "PHP Fundamentals",
                ShortDescription = "Lorem Ipsum",
                LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 3,
                ImageUrl = "https://via.placeholder.com/500",
                ImageThumbnailUrl = "https://via.placeholder.com/200",
            });
        }
    }
}