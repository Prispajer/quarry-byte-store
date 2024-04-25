

namespace ECommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>()
                .HasKey(p => new { p.ProductId, p.ProductTypeId });

            modelBuilder.Entity<ProductType>().HasData(
                    new ProductType { Id = 1, Name = "Default" },
                    new ProductType { Id = 2, Name = "Paperback" },
                    new ProductType { Id = 3, Name = "HardCover" },
                    new ProductType { Id = 4, Name = "Audiobook" },                                       
                    new ProductType { Id = 5, Name = "PC" },
                    new ProductType { Id = 6, Name = "PlayStation" },
                    new ProductType { Id = 7, Name = "Xbox" },
                    new ProductType { Id = 8, Name = "CollectorsEdition" },
                    new ProductType { Id = 9, Name = "PDF" }
                );


            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Books",
                    Url = "books"
                },
                new Category
                {
                    Id = 2,
                    Name = "eBooks",
                    Url = "e-books"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "video-games"
                },
                new Category
                {
                    Id = 4,
                    Name = "Board Games",
                    Url = "board-games"
                }
                );

            modelBuilder.Entity<Product>().HasData(

                        new Product
                        {
                            Id = 1,
                            Title = "The Lord of the Rings",
                            Description = "The Lord of the Rings is an epic high fantasy novel by the English author and scholar J. R. R. Tolkien. Set in Middle-earth, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif",
                            
                            CategoryId = 1,
                        },
                        new Product
                        {
                            Id = 2,
                            Title = "Ready Player One",
                            Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                            
                            CategoryId = 1,
                        },
                        new Product
                        {
                            Id = 3,
                            Title = "Towers of Midnight",
                            Description = "Owers of Midnight is a fantasy novel by Robert Jordan and Brandon Sanderson. It is the sequel to the novel The Gathering Storm,[4] and the 13th book in the Wheel of Time series.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3f/WoT13_TowersOfMidnight.jpg",
                            
                            CategoryId = 1,
                        }
                        , new Product
                        {
                            Id = 4,
                            Title = "Fourth Wing",
                            Description = "Is a 2023 new adult fantasy novel by American author Rebecca Yarros. It is the first book in the Empyrean series. Released on May 2, 2023, the novel achieved viral success on TikTok's reader community BookTok, which propelled it to reach No. 1 on The New York Times bestseller list.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/dd/Fourth_Wing_Cover_Art.jpeg",
                            
                            CategoryId = 2,
                        },
                        new Product
                        {
                            Id = 5,
                            Title = "The Problem of Thor Bridge",
                            Description = "Is a Sherlock Holmes short story by Arthur Conan Doyle collected in The Case-Book of Sherlock Holmes (1927). It was first published in 1922 in The Strand Magazine (UK) and Hearst's International (US).",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/60/The_Problem_of_Thor_Bridge_07.jpg",
                            
                            CategoryId = 2,
                        },
                        new Product
                        {
                            Id = 6,
                            Title = "The Cruel Prince",
                            Description = "Is the first book in the series. It follows Jude Duarte, a mortal girl living in Elfhame, a faerie world. Swept against her will to Elfhame, Jude must adapt to living alongside powerful creatures with a deep disdain for humans and a penchant for violent delights while also figuring out her feelings for faerie prince Cardan Greenbriar.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/20/The_Cruel_Prince.jpg",
                            
                            CategoryId = 2,
                        },
                        new Product
                        {
                            Id = 7,
                            Title = "Elden Ring",
                            Description = "Is a 2022 action role-playing game developed by FromSoftware. It was directed by Hidetaka Miyazaki with worldbuilding provided by fantasy writer George R. R. Martin. It was published for PlayStation 4, PlayStation 5, Windows, Xbox One, and Xbox Series X/S on February 25 by FromSoftware in Japan and Bandai Namco Entertainment internationally. Players control a customizable player character who is on a quest to repair the Elden Ring and become the new Elden Lord.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b9/Elden_Ring_Box_art.jpg",
                            
                            CategoryId = 3,
                        },
                         new Product
                         {
                             Id = 8,
                             Title = "The Last of Us Part I",
                             Description = "Is a 2022 action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment. A remake of the 2013 game The Last of Us, it features revised gameplay, including enhanced combat and exploration, and expanded accessibility options.",
                             ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/86/The_Last_of_Us_Part_I_cover.jpg",
                             
                             CategoryId = 3,
                         },
                          new Product
                          {
                              Id = 9,
                              Title = "Mass Effect 3",
                              Description = "Is an action role-playing game in which the player takes control of Commander Shepard from a third-person perspective.Shepard's gender, appearance, military background, combat training, and first name are determined by the player before the game begins.",
                              ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b0/Mass_Effect_3_Game_Cover.jpg",
                              
                              CategoryId = 3,
                          },
                           new Product
                           {
                               Id = 10,
                               Title = "Agricola",
                               Description = "Is a Euro-style board game created by Uwe Rosenberg. It is a worker placement game with a focus on resource management. In Agricola, players are farmers who sow, plow the fields, collect wood, build stables, buy animals, expand their farms and feed their families. After 14 rounds players calculate their score based on the size and prosperity of the household.",
                               ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/f6/Agricola_game.jpg",
                               
                               CategoryId = 4,
                           },
                           new Product
                           {
                               Id = 11,
                               Title = "Terraforming Mars",
                               Description = "s a board game for 1 to 5 players designed by Jacob Fryxelius and published by FryxGames in 2016, and thereafter by 12 others, including Stronghold Games. In Terraforming Mars, players take the role of corporations working together to terraform the planet Mars by raising the temperature, adding oxygen to the atmosphere, covering the planet's surface with water and creating plant and animal life.",
                               ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/f0/Terraforming_Mars_board_game_box_cover.jpg",
                               
                               CategoryId = 4,
                           },
                           new Product
                           {
                               Id = 12,
                               Title = "Chinese checkers",
                               Description = "Is a strategy board game of German origin that can be played by two, three, four, or six people, playing individually or with partners.The game is a modern and simplified variation of the game Halma.",
                               ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3e/ChineseCheckersboard.jpeg",
                               
                               CategoryId = 4,
                           }
                );

            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 2,
                    Price = 9.99m,
                    OriginalPrice = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 3,
                    Price = 10.99m
                },
                
                new ProductVariant
                {
                    ProductId = 2,
                    ProductTypeId = 2,
                    Price = 8.99m,
                    OriginalPrice = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 2,
                    ProductTypeId = 3,
                    Price = 9.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    ProductTypeId = 2,
                    Price = 8.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    ProductTypeId = 3,
                    Price = 10.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 4,
                    Price = 9.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 9,
                    Price = 6.99m,
                },
                new ProductVariant
                {
                    ProductId = 5,
                    ProductTypeId = 4,
                    Price = 8.99m
                },
                new ProductVariant
                {
                    ProductId = 5,
                    ProductTypeId = 9,
                    Price = 6.99m,
                    OriginalPrice = 4.99m
                },
                new ProductVariant
                {
                    ProductId = 6,
                    ProductTypeId = 4,
                    Price = 6.99m
                },
                new ProductVariant
                {
                    ProductId = 6,
                    ProductTypeId = 9,
                    Price = 9.99m,
                    OriginalPrice = 12.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 5,
                    Price = 29.99m,
                    OriginalPrice = 40.99m,
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 6,
                    Price = 39.99m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    ProductTypeId = 5,
                    Price = 139.99m,
                    OriginalPrice = 180m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    ProductTypeId = 6,
                    Price = 79.99m,
                    OriginalPrice = 125m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    ProductTypeId = 9,
                    Price = 79.99m,
                    OriginalPrice = 120m
                },
                new ProductVariant
                {
                    ProductId = 9,
                    ProductTypeId = 6,
                    Price = 79.99m,
                    OriginalPrice = 199m
                },
                new ProductVariant
                {
                    ProductId = 10,
                    ProductTypeId = 8,
                    Price = 69.99m,
                    OriginalPrice = 100m
                },
                new ProductVariant
                {
                    ProductId = 11,
                    ProductTypeId = 1,
                    Price = 39.99m,
                },
                new ProductVariant
                {
                    ProductId = 12,
                    ProductTypeId = 1,
                    Price = 19.99m
                }
            );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
    }
}
