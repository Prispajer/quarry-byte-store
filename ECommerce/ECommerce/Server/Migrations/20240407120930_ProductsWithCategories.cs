using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Server.Migrations
{
    public partial class ProductsWithCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 4, 2, "Is a 2023 new adult fantasy novel by American author Rebecca Yarros. It is the first book in the Empyrean series. Released on May 2, 2023, the novel achieved viral success on TikTok's reader community BookTok, which propelled it to reach No. 1 on The New York Times bestseller list.", "https://upload.wikimedia.org/wikipedia/en/d/dd/Fourth_Wing_Cover_Art.jpeg", 9.99m, "Fourth Wing" },
                    { 5, 2, "Is a Sherlock Holmes short story by Arthur Conan Doyle collected in The Case-Book of Sherlock Holmes (1927). It was first published in 1922 in The Strand Magazine (UK) and Hearst's International (US).", "https://upload.wikimedia.org/wikipedia/commons/6/60/The_Problem_of_Thor_Bridge_07.jpg", 9.99m, "The Problem of Thor Bridge" },
                    { 6, 2, "Is the first book in the series. It follows Jude Duarte, a mortal girl living in Elfhame, a faerie world. Swept against her will to Elfhame, Jude must adapt to living alongside powerful creatures with a deep disdain for humans and a penchant for violent delights while also figuring out her feelings for faerie prince Cardan Greenbriar.", "https://upload.wikimedia.org/wikipedia/en/2/20/The_Cruel_Prince.jpg", 9.99m, "The Cruel Prince" },
                    { 7, 3, "Is a 2022 action role-playing game developed by FromSoftware. It was directed by Hidetaka Miyazaki with worldbuilding provided by fantasy writer George R. R. Martin. It was published for PlayStation 4, PlayStation 5, Windows, Xbox One, and Xbox Series X/S on February 25 by FromSoftware in Japan and Bandai Namco Entertainment internationally. Players control a customizable player character who is on a quest to repair the Elden Ring and become the new Elden Lord.", "https://upload.wikimedia.org/wikipedia/en/b/b9/Elden_Ring_Box_art.jpg", 9.99m, "Elden Ring" },
                    { 8, 3, "Is a 2022 action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment. A remake of the 2013 game The Last of Us, it features revised gameplay, including enhanced combat and exploration, and expanded accessibility options.", "https://upload.wikimedia.org/wikipedia/en/8/86/The_Last_of_Us_Part_I_cover.jpg", 9.99m, "The Last of Us Part I" },
                    { 9, 3, "Is an action role-playing game in which the player takes control of Commander Shepard from a third-person perspective.Shepard's gender, appearance, military background, combat training, and first name are determined by the player before the game begins.", "https://upload.wikimedia.org/wikipedia/en/b/b0/Mass_Effect_3_Game_Cover.jpg", 9.99m, "Mass Effect 3" },
                    { 10, 4, "Is a Euro-style board game created by Uwe Rosenberg. It is a worker placement game with a focus on resource management. In Agricola, players are farmers who sow, plow the fields, collect wood, build stables, buy animals, expand their farms and feed their families. After 14 rounds players calculate their score based on the size and prosperity of the household.", "https://upload.wikimedia.org/wikipedia/en/f/f6/Agricola_game.jpg", 9.99m, "Agricola" },
                    { 11, 4, "s a board game for 1 to 5 players designed by Jacob Fryxelius and published by FryxGames in 2016, and thereafter by 12 others, including Stronghold Games. In Terraforming Mars, players take the role of corporations working together to terraform the planet Mars by raising the temperature, adding oxygen to the atmosphere, covering the planet's surface with water and creating plant and animal life.", "https://upload.wikimedia.org/wikipedia/en/f/f0/Terraforming_Mars_board_game_box_cover.jpg", 9.99m, "Terraforming Mars" },
                    { 12, 4, "Is a strategy board game of German origin that can be played by two, three, four, or six people, playing individually or with partners.The game is a modern and simplified variation of the game Halma.", "https://upload.wikimedia.org/wikipedia/commons/3/3e/ChineseCheckersboard.jpeg", 9.99m, "Chinese checkers" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
