﻿// <auto-generated />
using ECommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ECommerce.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Books",
                            Url = "books"
                        },
                        new
                        {
                            Id = 2,
                            Name = "eBooks",
                            Url = "e-books"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Video Games",
                            Url = "video-games"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Board Games",
                            Url = "board-games"
                        });
                });

            modelBuilder.Entity("ECommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "The Lord of the Rings is an epic high fantasy novel by the English author and scholar J. R. R. Tolkien. Set in Middle-earth, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif",
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                            Title = "Ready Player One"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Owers of Midnight is a fantasy novel by Robert Jordan and Brandon Sanderson. It is the sequel to the novel The Gathering Storm,[4] and the 13th book in the Wheel of Time series.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3f/WoT13_TowersOfMidnight.jpg",
                            Title = "Towers of Midnight"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Is a 2023 new adult fantasy novel by American author Rebecca Yarros. It is the first book in the Empyrean series. Released on May 2, 2023, the novel achieved viral success on TikTok's reader community BookTok, which propelled it to reach No. 1 on The New York Times bestseller list.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/dd/Fourth_Wing_Cover_Art.jpeg",
                            Title = "Fourth Wing"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Is a Sherlock Holmes short story by Arthur Conan Doyle collected in The Case-Book of Sherlock Holmes (1927). It was first published in 1922 in The Strand Magazine (UK) and Hearst's International (US).",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/60/The_Problem_of_Thor_Bridge_07.jpg",
                            Title = "The Problem of Thor Bridge"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Is the first book in the series. It follows Jude Duarte, a mortal girl living in Elfhame, a faerie world. Swept against her will to Elfhame, Jude must adapt to living alongside powerful creatures with a deep disdain for humans and a penchant for violent delights while also figuring out her feelings for faerie prince Cardan Greenbriar.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/20/The_Cruel_Prince.jpg",
                            Title = "The Cruel Prince"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "Is a 2022 action role-playing game developed by FromSoftware. It was directed by Hidetaka Miyazaki with worldbuilding provided by fantasy writer George R. R. Martin. It was published for PlayStation 4, PlayStation 5, Windows, Xbox One, and Xbox Series X/S on February 25 by FromSoftware in Japan and Bandai Namco Entertainment internationally. Players control a customizable player character who is on a quest to repair the Elden Ring and become the new Elden Lord.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b9/Elden_Ring_Box_art.jpg",
                            Title = "Elden Ring"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "Is a 2022 action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment. A remake of the 2013 game The Last of Us, it features revised gameplay, including enhanced combat and exploration, and expanded accessibility options.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/86/The_Last_of_Us_Part_I_cover.jpg",
                            Title = "The Last of Us Part I"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Is an action role-playing game in which the player takes control of Commander Shepard from a third-person perspective.Shepard's gender, appearance, military background, combat training, and first name are determined by the player before the game begins.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b0/Mass_Effect_3_Game_Cover.jpg",
                            Title = "Mass Effect 3"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            Description = "Is a Euro-style board game created by Uwe Rosenberg. It is a worker placement game with a focus on resource management. In Agricola, players are farmers who sow, plow the fields, collect wood, build stables, buy animals, expand their farms and feed their families. After 14 rounds players calculate their score based on the size and prosperity of the household.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/f6/Agricola_game.jpg",
                            Title = "Agricola"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 4,
                            Description = "s a board game for 1 to 5 players designed by Jacob Fryxelius and published by FryxGames in 2016, and thereafter by 12 others, including Stronghold Games. In Terraforming Mars, players take the role of corporations working together to terraform the planet Mars by raising the temperature, adding oxygen to the atmosphere, covering the planet's surface with water and creating plant and animal life.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/f0/Terraforming_Mars_board_game_box_cover.jpg",
                            Title = "Terraforming Mars"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 4,
                            Description = "Is a strategy board game of German origin that can be played by two, three, four, or six people, playing individually or with partners.The game is a modern and simplified variation of the game Halma.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3e/ChineseCheckersboard.jpeg",
                            Title = "Chinese checkers"
                        });
                });

            modelBuilder.Entity("ECommerce.Shared.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Paperback"
                        },
                        new
                        {
                            Id = 3,
                            Name = "HardCover"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Audiobook"
                        },
                        new
                        {
                            Id = 5,
                            Name = "PC"
                        },
                        new
                        {
                            Id = 6,
                            Name = "PlayStation"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Xbox"
                        },
                        new
                        {
                            Id = 8,
                            Name = "CollectorsEdition"
                        },
                        new
                        {
                            Id = 9,
                            Name = "PDF"
                        });
                });

            modelBuilder.Entity("ECommerce.Shared.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 2,
                            OriginalPrice = 19.99m,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 3,
                            OriginalPrice = 0m,
                            Price = 10.99m
                        },
                        new
                        {
                            ProductId = 2,
                            ProductTypeId = 2,
                            OriginalPrice = 14.99m,
                            Price = 8.99m
                        },
                        new
                        {
                            ProductId = 2,
                            ProductTypeId = 3,
                            OriginalPrice = 0m,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 3,
                            ProductTypeId = 2,
                            OriginalPrice = 0m,
                            Price = 8.99m
                        },
                        new
                        {
                            ProductId = 3,
                            ProductTypeId = 3,
                            OriginalPrice = 0m,
                            Price = 10.99m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 4,
                            OriginalPrice = 0m,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 9,
                            OriginalPrice = 0m,
                            Price = 6.99m
                        },
                        new
                        {
                            ProductId = 5,
                            ProductTypeId = 4,
                            OriginalPrice = 0m,
                            Price = 8.99m
                        },
                        new
                        {
                            ProductId = 5,
                            ProductTypeId = 9,
                            OriginalPrice = 4.99m,
                            Price = 6.99m
                        },
                        new
                        {
                            ProductId = 6,
                            ProductTypeId = 4,
                            OriginalPrice = 0m,
                            Price = 6.99m
                        },
                        new
                        {
                            ProductId = 6,
                            ProductTypeId = 9,
                            OriginalPrice = 12.99m,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 5,
                            OriginalPrice = 40.99m,
                            Price = 29.99m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 6,
                            OriginalPrice = 0m,
                            Price = 39.99m
                        },
                        new
                        {
                            ProductId = 8,
                            ProductTypeId = 5,
                            OriginalPrice = 180m,
                            Price = 139.99m
                        },
                        new
                        {
                            ProductId = 8,
                            ProductTypeId = 6,
                            OriginalPrice = 125m,
                            Price = 79.99m
                        },
                        new
                        {
                            ProductId = 8,
                            ProductTypeId = 9,
                            OriginalPrice = 120m,
                            Price = 79.99m
                        },
                        new
                        {
                            ProductId = 9,
                            ProductTypeId = 6,
                            OriginalPrice = 199m,
                            Price = 79.99m
                        },
                        new
                        {
                            ProductId = 10,
                            ProductTypeId = 8,
                            OriginalPrice = 100m,
                            Price = 69.99m
                        },
                        new
                        {
                            ProductId = 11,
                            ProductTypeId = 1,
                            OriginalPrice = 0m,
                            Price = 39.99m
                        },
                        new
                        {
                            ProductId = 12,
                            ProductTypeId = 1,
                            OriginalPrice = 0m,
                            Price = 19.99m
                        });
                });

            modelBuilder.Entity("ECommerce.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "gotomordor@gmail.com",
                            Name = "Frodo",
                            Password = "Gandalf!"
                        },
                        new
                        {
                            Id = 2,
                            Email = "youshallnotpass@gmail.com",
                            Name = "Gandalf",
                            Password = "Mellon"
                        });
                });

            modelBuilder.Entity("ECommerce.Shared.Product", b =>
                {
                    b.HasOne("ECommerce.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ECommerce.Shared.ProductVariant", b =>
                {
                    b.HasOne("ECommerce.Shared.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Shared.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("ECommerce.Shared.Product", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
