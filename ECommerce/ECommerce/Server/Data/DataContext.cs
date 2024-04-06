

namespace ECommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasData(

        //                new Product
        //                {
        //                    Id = 1,
        //                    Title = "The Lord of the Rings",
        //                    Description = "The Lord of the Rings is an epic high fantasy novel by the English author and scholar J. R. R. Tolkien. Set in Middle-earth, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.",
        //                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif",
        //                    Price = 9.99m
        //                },
        //                new Product
        //                {
        //                    Id = 2,
        //                    Title = "Ready Player One",
        //                    Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
        //                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
        //                    Price = 7.99m
        //                },
        //                new Product
        //                {
        //                    Id = 3,
        //                    Title = "Towers of Midnight",
        //                    Description = "owers of Midnight is a fantasy novel by Robert Jordan and Brandon Sanderson. It is the sequel to the novel The Gathering Storm,[4] and the 13th book in the Wheel of Time series.",
        //                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3f/WoT13_TowersOfMidnight.jpg",
        //                    Price = 6.99m
        //                }
        //        );
        //}
        public DbSet<Product> Products { get; set; }
    }
}
