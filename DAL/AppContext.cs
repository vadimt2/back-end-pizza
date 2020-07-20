using Common;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Catrgories { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<CategoryItems> CategoryItems { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<Order> Orders { get; set; }


        //public DbSet<ImagesItem> ImagesItem { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ImageThumbnail>().HasBaseType<Image>();


            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleType = "Admin" },
                new Role { Id = 2, RoleType = "User" },
                new Role { Id = 3, RoleType = "Guset" });

            // Add Categories
            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Title = "Pizza", Description = "All Pizza" },
             new Category { Id = 2, Title = "Toopings", Description = "All Toopings" },
             new Category { Id = 3, Title = "PizzaCrust", Description = "All Pizza Crust" },
             new Category { Id = 4, Title = "PizzaSize", Description = "All Pizza Size" },
             new Category { Id = 5, Title = "Drinks", Description = "All drinks" });

            //Add Items
            modelBuilder.Entity<Item>().HasData(
             new Item { Id = 1, Title = "Great Pizza", Description = "Try our the great pizza", Price = 20, Available = true, Total = 15, 
                 
             },
             new Item { Id = 2, Title = "Spinach & Feta pizza", Description = "This spinach and feta pizza comes together really quickly, it’s a great veggie pizza option. It comes with homemade pizza sauce and homemade dough. Topped with lots of spinach, feta, red onions and sundried tomatoes this pizza is not short on flavour. I like to add some toasted pine nuts to this too just to add a little more crunch to my pizza.", Price = 17.99m, Available = true, Total = 17.99m, 
 
             },
             new Item { Id = 3, Title = "Honolulu Hawaiian pizza", Description = " Features traditional ham and pineapple as well as smoked bacon, roasted red peppers, mozzarella, and provolone cheese.", Price = 14.99m, Available = true, Total = 14.99m, 
             },
             new Item { Id = 4, Title = "Philly Cheese Steak pizza", Description = "This Philly Cheese Steak Pizza is cheesy, meaty, comfort food at it’s most addicting.  It starts by layering pizza dough with Alfredo Sauce followed by mozzarella cheese, juicy steak, bell peppers, mushrooms.", Price = 11.99m, Available = true, Total = 11.99m
             ,
             },
             new Item { Id = 5, Title = "Pacific Veggie pizza", Description = "It has (almost) everything: roasted red peppers, baby spinach, onions, mushrooms, tomatoes, and black olives. It's also topped with three kinds of cheese — feta, provolone, and mozzarella — and sprinkled with garlic herb seasoning.", Price = 10, Available = true, Total = 10 , 
             },
             new Item { Id = 6, Title = "Buffalo Chicken pizza", Description = "Pizza with a little kick of buffalo wing flavor! Have your pizza and wings together!", Price = 20, Available = true, Total = 20, 
             },
             new Item { Id = 7, Title = "Deluxe Feast pizza", Description = "Try our great pizza", Price = 11.99m, Available = true , Total = 11.99m, 
             },
             new Item { Id = 8, Title = "Private Pizza", Description = "Beef pepperoni, Italian sausage, green peppers, mushrooms.", Price = 20, Available = true, Total = 20, 
             },
             new Item { Id = 9, Title = "Coke", Description = "Soda drink.", Price = 1, Available = true, Total = 1, 
             }
             );



            modelBuilder.Entity<Image>().HasData(
            new Image { Id = 1, ImageData = "http://st1.foodsd.co.il/Images/Recipes/xxl/Recipe-5968-7g0fXYdnVNi1LZ7N.jpg", ItemId = 1, IsUrl = true },
            new Image { Id = 2, ImageData = "https://media.metrolatam.com/2020/04/23/pizza14429461280-26168c22f83af34d20770970db28bb7b-1200x0.jpg", ItemId = 2, IsUrl = true },
            new Image { Id = 3, ImageData = "https://www.dominos.com.au/ManagedAssets/AU/product/P005/AU_P005_en_hero_4055.jpg", ItemId = 3, IsUrl = true },
            new Image { Id = 4, ImageData = "https://www.dominos.com.au/ManagedAssets/AU/product/P356/AU_P356_en_hero_4055.jpg", ItemId = 4, IsUrl = true },
            new Image { Id = 5, ImageData = "https://i.insider.com/5cf6d1ef11e2054bb76400b4?width=1100&format=jpeg&auto=webp", ItemId = 5, IsUrl = true },
            new Image { Id = 6, ImageData = "https://d1725r39asqzt3.cloudfront.net/9858a18d-613d-4d14-ad4d-bc87e000df9e/orig.jpg", ItemId = 6, IsUrl = true },
            new Image { Id = 7, ImageData = "https://www.sirpizzatn.com/wp-content/uploads/2017/09/RoyalFeast.jpg", ItemId = 7, IsUrl = true },
            new Image { Id = 8, ImageData = "https://images.squarespace-cdn.com/content/v1/53816030e4b0135aba1a2100/1454031327479-S1VJTYG878E9W09KM9DM/ke17ZwdGBToddI8pDm48kGdXwE-vebEpgb33VwdtsTxZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZUJFbgE-7XRK3dMEBRBhUpyFXBTrd8RtdLuD2xTt52BcbibHP9HAWTuiNyjdIhZkDRmM2LuhCrpPu_cqK6msTYI/PizzaHut_TargetMenuBoards_MR-002.jpg", ItemId = 8, IsUrl = true },
            new Image { Id = 9, ImageData = "https://cdn.shopify.com/s/files/1/1335/2603/products/Coca-cola_regular_1024x1024.jpg", ItemId = 9, IsUrl = true });


            //Merge Images and Items
            //modelBuilder.Entity<ImagesItem>().HasData(
            //new ImagesItem { Id = 1, ImageId = 1, ItemId = 1 },
            // new ImagesItem { Id = 2, ImageId = 1, ItemId = 5 });

            //Merge Categories and Items
            modelBuilder.Entity<CategoryItems>().HasData(
             new CategoryItems { Id = 1, ItemId = 1, CategoryId = 1 },
             new CategoryItems { Id = 2, ItemId = 2, CategoryId = 1 },
             new CategoryItems { Id = 3, ItemId = 3, CategoryId = 1 },
             new CategoryItems { Id = 4, ItemId = 4, CategoryId = 1 },
             new CategoryItems { Id = 5, ItemId = 5, CategoryId = 1 },
             new CategoryItems { Id = 6, ItemId = 6, CategoryId = 1 },
             new CategoryItems { Id = 7, ItemId = 7, CategoryId = 1 },
             new CategoryItems { Id = 8, ItemId = 8, CategoryId = 1 },
             new CategoryItems { Id = 9, ItemId = 9, CategoryId = 5 });



            //Shipping Options
            modelBuilder.Entity<Shipping>().HasData(
            new Shipping { Id = 1, Title = "Delivery", Price = 5, Available = true },
            new Shipping { Id = 2, Title = "Pickup", Price = 0 , Available = true });

        }
    }
}
