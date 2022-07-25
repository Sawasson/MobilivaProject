using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobiliva.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerGSM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedBy", "CreatedDate", "Description", "Status", "Unit", "UnitPrice", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 113309625, "Shoes", "Daisy", new DateTime(2021, 10, 8, 3, 56, 5, 73, DateTimeKind.Local).AddTicks(7705), "Esse natus quae consequatur eos aut dolorem ut minima nihil. Illum est dolor commodi vitae ipsum impedit repudiandae facere ullam. Perspiciatis voluptatibus vel facilis explicabo quis necessitatibus.", "Tools & Beauty", 267m, 38649m, "Daisy", new DateTime(2021, 10, 20, 18, 39, 0, 942, DateTimeKind.Local).AddTicks(6988) },
                    { 120694813, "Books", "Janis", new DateTime(2022, 2, 6, 8, 13, 50, 415, DateTimeKind.Local).AddTicks(6991), "Omnis nostrum accusamus totam aliquid tempore. Temporibus quia nemo fuga sequi quam.", "microchip", 282m, 10337m, "Janis", new DateTime(2021, 9, 4, 4, 42, 54, 430, DateTimeKind.Local).AddTicks(197) },
                    { 127821628, "Grocery", "Cristina", new DateTime(2021, 10, 26, 1, 38, 47, 918, DateTimeKind.Local).AddTicks(7363), "Sit voluptatibus facilis nostrum vero labore ea vel placeat. Facilis reprehenderit expedita a unde. Aspernatur ipsa quam.", "teal", 719m, 24761m, "Cristina", new DateTime(2022, 1, 12, 16, 9, 2, 987, DateTimeKind.Local).AddTicks(493) },
                    { 136709641, "Grocery", "Gregg", new DateTime(2022, 6, 17, 8, 19, 35, 313, DateTimeKind.Local).AddTicks(3403), "Unde delectus sit culpa alias quis numquam molestias et. Deleniti explicabo debitis expedita soluta laudantium est quas.", "port", 796m, 36588m, "Gregg", new DateTime(2022, 5, 10, 2, 20, 37, 235, DateTimeKind.Local).AddTicks(1332) },
                    { 150262248, "Kids", "Terrence", new DateTime(2021, 9, 7, 1, 39, 33, 463, DateTimeKind.Local).AddTicks(5564), "Ut explicabo sint. Accusamus et reprehenderit minus vel et eveniet at. Occaecati maxime ut aut quasi. Inventore et rerum vel omnis.", "back up", 259m, 42082m, "Terrence", new DateTime(2022, 5, 4, 20, 40, 46, 750, DateTimeKind.Local).AddTicks(8713) },
                    { 152170432, "Electronics", "Trevor", new DateTime(2022, 2, 3, 12, 35, 57, 586, DateTimeKind.Local).AddTicks(1063), "Qui a officiis qui eligendi repudiandae eligendi. Qui perferendis doloremque ea sit ratione autem.", "online", 925m, 47773m, "Trevor", new DateTime(2021, 10, 25, 13, 52, 19, 84, DateTimeKind.Local).AddTicks(1939) },
                    { 159198385, "Tools", "Kyle", new DateTime(2021, 9, 3, 9, 25, 2, 655, DateTimeKind.Local).AddTicks(5468), "Et quod nisi. Voluptatem qui explicabo molestiae. Sint sed ad sed qui molestiae. Sint blanditiis omnis nesciunt mollitia placeat voluptate qui voluptatem accusantium.", "Fiji Dollar", 904m, 27497m, "Kyle", new DateTime(2021, 8, 17, 9, 25, 23, 570, DateTimeKind.Local).AddTicks(1041) },
                    { 169057772, "Jewelery", "Louise", new DateTime(2021, 10, 14, 2, 54, 2, 141, DateTimeKind.Local).AddTicks(7027), "Repellendus iusto sequi omnis. Unde qui eligendi necessitatibus quia ut aut non doloribus.", "SDD", 116m, 2727m, "Louise", new DateTime(2021, 8, 21, 15, 41, 24, 231, DateTimeKind.Local).AddTicks(9447) },
                    { 187131789, "Movies", "Jaime", new DateTime(2022, 4, 22, 2, 39, 37, 927, DateTimeKind.Local).AddTicks(614), "Voluptas accusantium unde debitis quas voluptate praesentium consequatur asperiores. Aliquam eveniet sed provident alias quibusdam laboriosam. Aut maiores dolorum qui perspiciatis rem nihil nobis autem sint.", "database", 457m, 10902m, "Jaime", new DateTime(2022, 5, 8, 8, 33, 52, 155, DateTimeKind.Local).AddTicks(2447) },
                    { 192528617, "Electronics", "Velma", new DateTime(2022, 3, 2, 23, 54, 56, 541, DateTimeKind.Local).AddTicks(7193), "Atque minima dolores velit accusantium exercitationem rem.", "Central", 779m, 37499m, "Velma", new DateTime(2021, 11, 19, 15, 20, 41, 407, DateTimeKind.Local).AddTicks(2398) },
                    { 218530037, "Shoes", "Ronald", new DateTime(2022, 6, 25, 3, 37, 41, 137, DateTimeKind.Local).AddTicks(9652), "Architecto vero non tenetur placeat labore. Rerum culpa accusamus eum voluptate atque voluptatem. Expedita inventore dicta et sapiente quia odio aut.", "Legacy", 290m, 26685m, "Ronald", new DateTime(2021, 9, 3, 17, 48, 52, 723, DateTimeKind.Local).AddTicks(131) },
                    { 225841831, "Movies", "Harvey", new DateTime(2022, 5, 1, 11, 1, 14, 405, DateTimeKind.Local).AddTicks(50), "Minima deleniti molestiae dolor provident cum minima nobis. Natus quia eos facilis harum eos aperiam.", "microchip", 211m, 38652m, "Harvey", new DateTime(2022, 6, 30, 4, 12, 22, 532, DateTimeKind.Local).AddTicks(4302) },
                    { 234595683, "Industrial", "Wm", new DateTime(2022, 2, 22, 3, 27, 24, 1, DateTimeKind.Local).AddTicks(1100), "Illo consequatur sunt laborum. Vel maxime optio quia voluptatem asperiores. Totam consequatur quis.", "Rustic Frozen Salad", 373m, 24m, "Wm", new DateTime(2022, 4, 6, 6, 7, 18, 599, DateTimeKind.Local).AddTicks(8206) },
                    { 258415954, "Garden", "Israel", new DateTime(2021, 10, 4, 13, 6, 53, 243, DateTimeKind.Local).AddTicks(5456), "Dolor voluptatum et qui perferendis. Facere eum sit consequatur molestias cupiditate aut suscipit odio ea. Facere doloremque laudantium voluptas nemo. Explicabo et at nemo sunt officia nihil et temporibus.", "Dynamic", 368m, 42793m, "Israel", new DateTime(2022, 1, 2, 7, 35, 4, 999, DateTimeKind.Local).AddTicks(1580) },
                    { 265785763, "Grocery", "Gwen", new DateTime(2021, 10, 29, 8, 2, 8, 340, DateTimeKind.Local).AddTicks(7059), "Quia nihil possimus illum earum sed veniam et. Autem soluta fugiat enim perspiciatis dolorem. Eum molestiae ea sint voluptatem velit nobis rerum ipsum.", "driver", 212m, 47730m, "Gwen", new DateTime(2022, 2, 20, 12, 17, 20, 933, DateTimeKind.Local).AddTicks(7160) },
                    { 267755702, "Movies", "Elsie", new DateTime(2021, 7, 31, 10, 55, 4, 162, DateTimeKind.Local).AddTicks(6301), "Dolor maxime asperiores laudantium molestiae et consequatur. Eum perspiciatis voluptatibus ab aut sunt et ut labore fugiat. Illum sunt nemo est quo qui consectetur veniam explicabo inventore.", "Practical Cotton Keyboard", 565m, 9232m, "Elsie", new DateTime(2022, 2, 22, 21, 24, 23, 592, DateTimeKind.Local).AddTicks(4813) },
                    { 270765875, "Industrial", "Jesse", new DateTime(2022, 7, 4, 4, 51, 16, 948, DateTimeKind.Local).AddTicks(3490), "Voluptatem aut voluptatem atque hic possimus nihil magnam sed voluptas. Necessitatibus rem est rerum veritatis ea tempore commodi distinctio. Aut necessitatibus alias autem.", "local area network", 988m, 12946m, "Jesse", new DateTime(2021, 10, 30, 17, 44, 43, 198, DateTimeKind.Local).AddTicks(9685) },
                    { 292425515, "Tools", "Mae", new DateTime(2022, 1, 9, 3, 0, 41, 62, DateTimeKind.Local).AddTicks(1021), "Vel soluta ex libero aliquid. Ratione iste veritatis impedit. Repudiandae atque esse deleniti adipisci.", "disintermediate", 468m, 11255m, "Mae", new DateTime(2021, 9, 29, 1, 8, 29, 971, DateTimeKind.Local).AddTicks(3798) },
                    { 306806236, "Automotive", "Mike", new DateTime(2022, 5, 4, 20, 50, 28, 961, DateTimeKind.Local).AddTicks(4666), "Culpa ut magni. Cum in corporis delectus odio.", "Tools, Home & Books", 970m, 48632m, "Mike", new DateTime(2022, 5, 4, 8, 39, 32, 739, DateTimeKind.Local).AddTicks(9818) },
                    { 310931031, "Health", "Julie", new DateTime(2021, 8, 6, 15, 8, 47, 639, DateTimeKind.Local).AddTicks(8657), "Aliquam voluptatem iste accusamus beatae sint sed id. Corporis ut exercitationem repudiandae.", "purple", 585m, 2486m, "Julie", new DateTime(2022, 3, 17, 21, 14, 7, 404, DateTimeKind.Local).AddTicks(152) },
                    { 317082575, "Computers", "Blanche", new DateTime(2021, 9, 15, 3, 20, 47, 725, DateTimeKind.Local).AddTicks(7870), "Voluptas enim ut esse voluptatem quae et rerum. Illum rerum et voluptas. Ducimus animi at totam est ad atque placeat quia unde.", "Kwacha", 539m, 19553m, "Blanche", new DateTime(2021, 10, 31, 12, 38, 23, 25, DateTimeKind.Local).AddTicks(6739) },
                    { 318364140, "Automotive", "Kelvin", new DateTime(2021, 11, 5, 2, 0, 1, 751, DateTimeKind.Local).AddTicks(1226), "A ipsam a quia aut deleniti quod error nemo in. Ea velit doloremque unde. Aliquam mollitia sit aut quis vel aut sequi.", "user-facing", 388m, 21093m, "Kelvin", new DateTime(2021, 9, 4, 23, 18, 33, 972, DateTimeKind.Local).AddTicks(8922) },
                    { 321987193, "Books", "Kevin", new DateTime(2021, 9, 13, 0, 8, 50, 433, DateTimeKind.Local).AddTicks(3515), "Incidunt est at dolorem voluptatem. Alias et veniam temporibus.", "Steel", 656m, 14372m, "Kevin", new DateTime(2022, 4, 27, 1, 8, 16, 527, DateTimeKind.Local).AddTicks(3786) },
                    { 326790360, "Home", "Lori", new DateTime(2021, 8, 23, 15, 51, 45, 144, DateTimeKind.Local).AddTicks(7657), "Rerum delectus laborum dolores saepe quia. Aut velit repellat recusandae aut architecto sed expedita. Itaque quos nisi ut aut natus ratione sed sapiente quis.", "Solutions", 457m, 12906m, "Lori", new DateTime(2022, 1, 10, 21, 11, 22, 309, DateTimeKind.Local).AddTicks(7720) },
                    { 335928463, "Grocery", "Marcus", new DateTime(2022, 6, 3, 16, 16, 20, 958, DateTimeKind.Local).AddTicks(1575), "Ea quaerat omnis aut. Et sint et maiores distinctio quidem.", "Infrastructure", 772m, 31263m, "Marcus", new DateTime(2022, 4, 18, 7, 16, 58, 376, DateTimeKind.Local).AddTicks(8179) },
                    { 337323229, "Tools", "Jimmy", new DateTime(2022, 1, 28, 15, 49, 42, 265, DateTimeKind.Local).AddTicks(9876), "Voluptatem repellendus earum.", "bricks-and-clicks", 745m, 37051m, "Jimmy", new DateTime(2022, 4, 15, 7, 2, 0, 189, DateTimeKind.Local).AddTicks(2880) },
                    { 358790566, "Sports", "Diane", new DateTime(2022, 5, 1, 12, 0, 4, 81, DateTimeKind.Local).AddTicks(7410), "Omnis commodi qui aperiam eaque quia aspernatur autem. Architecto quam pariatur libero quibusdam illo non est sequi commodi. Quas ut enim qui suscipit nam non occaecati adipisci. Eum nam eveniet voluptatem occaecati aut possimus.", "indexing", 213m, 5716m, "Diane", new DateTime(2022, 1, 19, 7, 44, 17, 194, DateTimeKind.Local).AddTicks(2490) },
                    { 376958253, "Beauty", "Olivia", new DateTime(2021, 8, 13, 16, 24, 3, 922, DateTimeKind.Local).AddTicks(6682), "Necessitatibus dolorem odio repellendus veniam perspiciatis ea. Beatae aut cumque beatae sit temporibus consectetur. Quaerat odio quae aliquam reprehenderit dolor voluptas consequatur quia tempora.", "adapter", 238m, 35155m, "Olivia", new DateTime(2022, 5, 27, 14, 59, 42, 831, DateTimeKind.Local).AddTicks(1990) },
                    { 381010334, "Health", "Karl", new DateTime(2022, 4, 12, 13, 0, 21, 946, DateTimeKind.Local).AddTicks(9414), "Facilis et sit accusantium amet id. Et quo asperiores dolorum excepturi.", "Afghani", 610m, 1194m, "Karl", new DateTime(2021, 12, 26, 13, 23, 51, 930, DateTimeKind.Local).AddTicks(8597) },
                    { 388594755, "Automotive", "Arnold", new DateTime(2022, 7, 6, 19, 52, 12, 49, DateTimeKind.Local).AddTicks(256), "Beatae id qui quas iste consequuntur. Corporis minus pariatur ipsa quia necessitatibus.", "Marketing", 308m, 3296m, "Arnold", new DateTime(2022, 5, 13, 1, 47, 31, 294, DateTimeKind.Local).AddTicks(142) },
                    { 388856154, "Games", "Cesar", new DateTime(2022, 4, 1, 7, 8, 54, 452, DateTimeKind.Local).AddTicks(2471), "Autem quisquam aut sint et velit amet autem adipisci qui. Placeat sunt deserunt qui veniam vel.", "withdrawal", 449m, 14870m, "Cesar", new DateTime(2022, 6, 18, 8, 7, 18, 767, DateTimeKind.Local).AddTicks(4992) },
                    { 395147740, "Electronics", "Vernon", new DateTime(2021, 10, 29, 19, 51, 3, 883, DateTimeKind.Local).AddTicks(4591), "Culpa itaque placeat voluptatum earum quaerat minus earum voluptatem. Nostrum quia et natus similique. Eveniet eaque qui ipsum blanditiis iure dolores suscipit dolores.", "Jamaican Dollar", 889m, 24988m, "Vernon", new DateTime(2022, 1, 27, 7, 38, 32, 628, DateTimeKind.Local).AddTicks(2873) },
                    { 406400086, "Books", "Don", new DateTime(2022, 4, 8, 8, 41, 12, 166, DateTimeKind.Local).AddTicks(9131), "Harum magni asperiores dolorem id. Corrupti a fugit atque.", "withdrawal", 142m, 48217m, "Don", new DateTime(2021, 8, 9, 5, 38, 48, 613, DateTimeKind.Local).AddTicks(4928) },
                    { 410030369, "Jewelery", "Cynthia", new DateTime(2021, 11, 11, 21, 21, 55, 195, DateTimeKind.Local).AddTicks(6086), "Qui sint omnis est expedita. Ut et velit iure rerum rerum qui laudantium itaque. Inventore qui fugit assumenda ea molestiae. Ipsam placeat ipsum cum.", "Crest", 29m, 20204m, "Cynthia", new DateTime(2021, 12, 20, 4, 38, 28, 287, DateTimeKind.Local).AddTicks(2221) },
                    { 426630575, "Baby", "Christian", new DateTime(2022, 7, 15, 10, 36, 15, 5, DateTimeKind.Local).AddTicks(5158), "Nihil iure nobis ut aut. Omnis temporibus animi quis nam ea nesciunt nulla magni repellendus. Reiciendis necessitatibus repellat mollitia non.", "HTTP", 503m, 40278m, "Christian", new DateTime(2021, 10, 13, 12, 16, 55, 135, DateTimeKind.Local).AddTicks(260) },
                    { 447936620, "Electronics", "Jake", new DateTime(2022, 6, 8, 5, 9, 41, 654, DateTimeKind.Local).AddTicks(1061), "Ut vel impedit sit. Omnis quas et laboriosam possimus consectetur rerum.", "Internal", 868m, 23415m, "Jake", new DateTime(2022, 4, 16, 15, 40, 56, 84, DateTimeKind.Local).AddTicks(4282) },
                    { 447988766, "Health", "Beth", new DateTime(2022, 5, 8, 7, 48, 11, 895, DateTimeKind.Local).AddTicks(4806), "Et officiis voluptatem rem. Et velit nihil quaerat velit sunt doloribus non adipisci. Voluptatem et ratione voluptas vitae earum alias nemo.", "responsive", 243m, 22609m, "Beth", new DateTime(2022, 2, 21, 17, 46, 22, 401, DateTimeKind.Local).AddTicks(5631) },
                    { 456567356, "Music", "Ron", new DateTime(2022, 5, 19, 18, 44, 37, 684, DateTimeKind.Local).AddTicks(2926), "Facere totam modi ipsa optio aut sed totam nihil quos. Voluptas esse eveniet voluptatem modi labore inventore est sit rerum.", "Berkshire", 913m, 32285m, "Ron", new DateTime(2021, 9, 14, 17, 37, 18, 250, DateTimeKind.Local).AddTicks(1101) },
                    { 478357395, "Tools", "Roosevelt", new DateTime(2021, 12, 28, 20, 49, 45, 466, DateTimeKind.Local).AddTicks(6918), "Dolores qui ut in.", "reboot", 824m, 23083m, "Roosevelt", new DateTime(2021, 10, 2, 17, 46, 17, 973, DateTimeKind.Local).AddTicks(1801) },
                    { 489490870, "Automotive", "Grant", new DateTime(2021, 11, 27, 19, 4, 26, 816, DateTimeKind.Local).AddTicks(6313), "Dolore veritatis aut. Quas placeat itaque et voluptas molestiae ut. Aut qui numquam odio odio ipsam nulla harum soluta nemo.", "SCSI", 57m, 7399m, "Grant", new DateTime(2021, 12, 1, 12, 0, 13, 344, DateTimeKind.Local).AddTicks(5274) },
                    { 492279020, "Toys", "Roberto", new DateTime(2022, 6, 20, 14, 18, 33, 835, DateTimeKind.Local).AddTicks(6268), "Asperiores sint magni qui quaerat nisi repudiandae ut quisquam similique.", "Kroon", 592m, 35441m, "Roberto", new DateTime(2021, 10, 20, 17, 14, 40, 630, DateTimeKind.Local).AddTicks(2739) },
                    { 493975761, "Toys", "Cedric", new DateTime(2021, 8, 9, 0, 28, 2, 596, DateTimeKind.Local).AddTicks(1087), "Qui et optio nemo impedit optio perferendis. Dolorum vitae omnis doloremque vero accusamus quaerat consequuntur et tempora. Rerum enim aut at quae provident amet rerum dolores repudiandae. Ea ipsa rerum repellendus commodi expedita repudiandae fugiat illo nesciunt.", "Lempira", 845m, 21069m, "Cedric", new DateTime(2021, 11, 19, 12, 35, 5, 17, DateTimeKind.Local).AddTicks(4422) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedBy", "CreatedDate", "Description", "Status", "Unit", "UnitPrice", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 505094876, "Home", "Kay", new DateTime(2021, 11, 22, 0, 14, 44, 843, DateTimeKind.Local).AddTicks(2257), "Aperiam reprehenderit id.", "maroon", 24m, 3780m, "Kay", new DateTime(2021, 12, 30, 13, 5, 27, 482, DateTimeKind.Local).AddTicks(2061) },
                    { 505556037, "Games", "Jared", new DateTime(2021, 8, 31, 0, 5, 36, 379, DateTimeKind.Local).AddTicks(3830), "Repellat hic optio ea. Non ut incidunt explicabo voluptatibus a magni qui.", "Minnesota", 573m, 33534m, "Jared", new DateTime(2022, 5, 17, 14, 17, 14, 740, DateTimeKind.Local).AddTicks(6429) },
                    { 514454634, "Tools", "Jacob", new DateTime(2022, 2, 20, 9, 20, 30, 406, DateTimeKind.Local).AddTicks(9416), "Odio dolorum officiis consequuntur. Aut non ipsam et officia enim voluptate qui occaecati velit.", "disintermediate", 181m, 16298m, "Jacob", new DateTime(2022, 6, 29, 1, 43, 34, 343, DateTimeKind.Local).AddTicks(4284) },
                    { 516059283, "Sports", "Jerald", new DateTime(2022, 6, 27, 3, 26, 9, 165, DateTimeKind.Local).AddTicks(3692), "Porro rem nisi est fuga expedita doloremque mollitia expedita veniam. Ipsum at nam quis eaque itaque odio.", "grey", 782m, 2576m, "Jerald", new DateTime(2021, 11, 11, 15, 38, 55, 152, DateTimeKind.Local).AddTicks(9619) },
                    { 517982222, "Games", "Barbara", new DateTime(2021, 12, 17, 12, 7, 52, 625, DateTimeKind.Local).AddTicks(2119), "Repellendus ratione voluptas dolor in. Velit autem omnis libero quae et aut. Dicta ea in velit est et modi ea.", "Ville", 697m, 7829m, "Barbara", new DateTime(2021, 11, 15, 15, 54, 15, 97, DateTimeKind.Local).AddTicks(9084) },
                    { 519296789, "Garden", "Devin", new DateTime(2022, 1, 28, 1, 29, 49, 202, DateTimeKind.Local).AddTicks(4393), "Blanditiis vero qui et quibusdam natus ut repudiandae. Est voluptatum sint aut inventore odio sint molestias. Non laborum omnis fugiat impedit aliquid. Quas illo nemo ut recusandae doloremque ex est et.", "auxiliary", 310m, 29936m, "Devin", new DateTime(2022, 3, 22, 19, 27, 45, 301, DateTimeKind.Local).AddTicks(6339) },
                    { 559334795, "Toys", "Kenny", new DateTime(2021, 8, 5, 7, 31, 3, 907, DateTimeKind.Local).AddTicks(5678), "Dolorum cum sed adipisci laudantium aut aperiam.", "Spring", 2m, 33802m, "Kenny", new DateTime(2022, 5, 29, 0, 25, 21, 334, DateTimeKind.Local).AddTicks(6064) },
                    { 560732192, "Games", "Jeffery", new DateTime(2022, 7, 13, 15, 37, 49, 422, DateTimeKind.Local).AddTicks(9615), "Eaque porro sit tenetur et quas delectus eligendi reprehenderit labore. Illum illo eos cum perferendis. Quaerat harum quam sint. Excepturi iure laborum impedit dolores.", "Intelligent", 425m, 2888m, "Jeffery", new DateTime(2021, 11, 17, 22, 9, 7, 935, DateTimeKind.Local).AddTicks(5435) },
                    { 561776885, "Books", "Priscilla", new DateTime(2021, 11, 5, 22, 4, 54, 802, DateTimeKind.Local).AddTicks(4015), "Et nam quisquam rerum rerum.", "Barbados Dollar", 317m, 38693m, "Priscilla", new DateTime(2022, 1, 4, 1, 15, 10, 761, DateTimeKind.Local).AddTicks(833) },
                    { 569920344, "Movies", "Terence", new DateTime(2022, 2, 25, 0, 12, 25, 192, DateTimeKind.Local).AddTicks(8289), "Cumque a eveniet voluptatem dolorum inventore sequi quis excepturi. Perspiciatis a voluptas omnis ut.", "next-generation", 869m, 48677m, "Terence", new DateTime(2022, 3, 18, 20, 15, 49, 126, DateTimeKind.Local).AddTicks(1219) },
                    { 571782413, "Movies", "Geneva", new DateTime(2022, 4, 26, 19, 3, 23, 365, DateTimeKind.Local).AddTicks(5321), "Reprehenderit in quis sit quod ea sit nulla ad. Autem sit omnis id dolor et id.", "Knolls", 427m, 15346m, "Geneva", new DateTime(2021, 12, 7, 22, 53, 44, 80, DateTimeKind.Local).AddTicks(1503) },
                    { 579325015, "Tools", "Milton", new DateTime(2022, 6, 6, 18, 6, 12, 60, DateTimeKind.Local).AddTicks(5336), "Iusto ut animi porro maxime ut rem alias velit. Ut beatae voluptatem inventore quam exercitationem dicta reprehenderit eos.", "Rapid", 402m, 36850m, "Milton", new DateTime(2021, 11, 11, 17, 45, 42, 496, DateTimeKind.Local).AddTicks(4510) },
                    { 587192260, "Books", "Gilbert", new DateTime(2022, 1, 25, 8, 28, 4, 800, DateTimeKind.Local).AddTicks(8738), "Aliquid voluptatibus blanditiis debitis. Quibusdam voluptatum enim excepturi eius vitae autem numquam eum quo. Et modi temporibus dolores incidunt.", "program", 404m, 31991m, "Gilbert", new DateTime(2022, 7, 14, 12, 30, 46, 768, DateTimeKind.Local).AddTicks(2157) },
                    { 599757923, "Movies", "Doreen", new DateTime(2021, 10, 23, 9, 7, 56, 539, DateTimeKind.Local).AddTicks(7807), "Et qui provident. In excepturi officia quisquam nostrum. Sed dolorem sunt totam magnam excepturi.", "Bermudian Dollar (customarily known as Bermuda Dollar)", 77m, 7178m, "Doreen", new DateTime(2022, 1, 21, 14, 13, 41, 528, DateTimeKind.Local).AddTicks(8073) },
                    { 603711021, "Kids", "Sabrina", new DateTime(2022, 4, 29, 16, 28, 57, 619, DateTimeKind.Local).AddTicks(6893), "Quos pariatur quos iste ipsa blanditiis. Esse repellendus ut reprehenderit. Neque eum repudiandae perspiciatis.", "Toys, Grocery & Sports", 299m, 21266m, "Sabrina", new DateTime(2021, 11, 25, 21, 23, 55, 401, DateTimeKind.Local).AddTicks(4907) },
                    { 617230196, "Computers", "Bernard", new DateTime(2021, 10, 25, 18, 30, 26, 258, DateTimeKind.Local).AddTicks(941), "Consectetur aut praesentium sunt et unde nesciunt molestias.", "withdrawal", 647m, 45508m, "Bernard", new DateTime(2021, 12, 5, 5, 11, 10, 498, DateTimeKind.Local).AddTicks(301) },
                    { 621062628, "Jewelery", "Margie", new DateTime(2021, 12, 26, 20, 2, 23, 940, DateTimeKind.Local).AddTicks(5616), "Est nostrum qui molestias omnis sit sunt id fugit nisi. Veniam sequi in. Ut voluptatem expedita sed accusamus necessitatibus et eveniet qui temporibus. Quo quis rerum qui cupiditate omnis odio voluptatem sed.", "payment", 354m, 38158m, "Margie", new DateTime(2021, 7, 28, 13, 8, 13, 573, DateTimeKind.Local).AddTicks(5114) },
                    { 624369253, "Books", "Johnny", new DateTime(2022, 2, 17, 19, 10, 12, 184, DateTimeKind.Local).AddTicks(7617), "Molestiae amet consequatur voluptatum quia et. Enim est aut quo. Neque temporibus libero sit omnis labore nobis explicabo aut voluptatem. Laborum sed sunt est dolorem voluptates.", "Practical Wooden Chair", 880m, 10023m, "Johnny", new DateTime(2022, 2, 21, 11, 41, 16, 681, DateTimeKind.Local).AddTicks(6491) },
                    { 627732911, "Computers", "Derrick", new DateTime(2022, 7, 6, 20, 39, 41, 705, DateTimeKind.Local).AddTicks(9989), "Sint ab et. Labore qui dignissimos distinctio labore tempore ut consequatur provident tempore.", "methodologies", 724m, 13402m, "Derrick", new DateTime(2022, 6, 27, 7, 30, 38, 72, DateTimeKind.Local).AddTicks(9642) },
                    { 640443182, "Industrial", "Winston", new DateTime(2022, 7, 4, 8, 33, 10, 783, DateTimeKind.Local).AddTicks(4166), "Qui dolores qui. Cumque dolores placeat accusamus. Autem dolores fugiat illum.", "Fresh", 386m, 42074m, "Winston", new DateTime(2021, 12, 19, 15, 7, 52, 892, DateTimeKind.Local).AddTicks(4763) },
                    { 650806235, "Sports", "Lula", new DateTime(2021, 8, 3, 5, 36, 40, 832, DateTimeKind.Local).AddTicks(1691), "Nulla ullam eveniet vitae qui itaque quisquam eveniet. Aperiam quia ea ullam enim laboriosam et consequuntur natus. Tenetur fugit omnis. Earum qui distinctio harum quibusdam perferendis quae accusamus sit.", "Manager", 132m, 37751m, "Lula", new DateTime(2022, 3, 25, 19, 47, 19, 407, DateTimeKind.Local).AddTicks(1095) },
                    { 652338878, "Outdoors", "Alison", new DateTime(2021, 9, 12, 10, 22, 42, 376, DateTimeKind.Local).AddTicks(7051), "Non iusto sed impedit sed voluptates ut odio at molestiae. Molestiae consectetur non suscipit ea repellendus quo dolorem enim ratione. Provident harum nesciunt iure asperiores a qui. Odit facere ea omnis qui quam in.", "methodologies", 804m, 45398m, "Alison", new DateTime(2022, 6, 5, 9, 38, 22, 902, DateTimeKind.Local).AddTicks(678) },
                    { 656203612, "Jewelery", "Florence", new DateTime(2022, 7, 22, 1, 49, 11, 483, DateTimeKind.Local).AddTicks(630), "Provident voluptas nesciunt accusantium molestiae enim nulla. Aut mollitia veniam.", "Ergonomic Wooden Chips", 381m, 43161m, "Florence", new DateTime(2022, 5, 11, 0, 5, 32, 135, DateTimeKind.Local).AddTicks(1139) },
                    { 657694277, "Beauty", "Howard", new DateTime(2021, 11, 21, 11, 18, 59, 121, DateTimeKind.Local).AddTicks(5560), "Soluta qui expedita totam consectetur omnis voluptatibus.", "stable", 233m, 14902m, "Howard", new DateTime(2021, 8, 18, 16, 11, 26, 498, DateTimeKind.Local).AddTicks(9235) },
                    { 667300881, "Toys", "Charles", new DateTime(2022, 2, 26, 6, 8, 16, 924, DateTimeKind.Local).AddTicks(2887), "Omnis voluptates omnis nobis voluptate. Non voluptatem officiis iure deserunt sint nihil. Nam sit doloribus magnam necessitatibus ea provident doloremque. Quibusdam et vero rerum cumque repudiandae.", "end-to-end", 641m, 9913m, "Charles", new DateTime(2022, 6, 20, 4, 45, 29, 410, DateTimeKind.Local).AddTicks(8476) },
                    { 670276711, "Jewelery", "Ruben", new DateTime(2022, 5, 18, 8, 41, 41, 589, DateTimeKind.Local).AddTicks(1243), "Est quis dolores quaerat et earum. Incidunt eaque reprehenderit iure natus. Nemo maxime et. Qui sapiente fugit velit eum nemo dolorem accusantium.", "vortals", 561m, 21139m, "Ruben", new DateTime(2021, 8, 8, 17, 1, 51, 901, DateTimeKind.Local).AddTicks(612) },
                    { 683382139, "Movies", "Jeremiah", new DateTime(2021, 9, 3, 21, 27, 16, 938, DateTimeKind.Local).AddTicks(3488), "Repellat amet hic accusamus ipsa a fugiat et exercitationem sequi. Vel est qui reprehenderit totam placeat non non aut nihil. Soluta id maxime voluptas. Repellat alias placeat vel accusantium sapiente magni quos sint.", "homogeneous", 787m, 49141m, "Jeremiah", new DateTime(2022, 4, 2, 0, 50, 55, 986, DateTimeKind.Local).AddTicks(9028) },
                    { 696993844, "Music", "Stephen", new DateTime(2022, 7, 2, 15, 25, 10, 788, DateTimeKind.Local).AddTicks(2307), "Et quaerat reprehenderit explicabo ullam debitis architecto inventore quia totam.", "Guyana Dollar", 970m, 6205m, "Stephen", new DateTime(2022, 4, 18, 7, 13, 9, 250, DateTimeKind.Local).AddTicks(441) },
                    { 704899335, "Outdoors", "Tammy", new DateTime(2021, 11, 22, 21, 1, 30, 344, DateTimeKind.Local).AddTicks(311), "Quos voluptatem error in dolores reprehenderit ratione incidunt nisi. Nulla asperiores earum tenetur blanditiis.", "Liberia", 293m, 1106m, "Tammy", new DateTime(2022, 3, 11, 21, 11, 10, 112, DateTimeKind.Local).AddTicks(8364) },
                    { 707148390, "Electronics", "Pearl", new DateTime(2021, 8, 14, 20, 25, 26, 802, DateTimeKind.Local).AddTicks(8095), "Placeat dolores rerum voluptatem consequatur esse ut est. Hic optio perferendis voluptatem quia iusto eligendi temporibus voluptatem est. Voluptatem repellendus voluptate. Quaerat ut praesentium.", "Berkshire", 312m, 36187m, "Pearl", new DateTime(2022, 2, 26, 7, 23, 4, 915, DateTimeKind.Local).AddTicks(253) },
                    { 707430730, "Baby", "Jesse", new DateTime(2022, 5, 14, 13, 42, 55, 22, DateTimeKind.Local).AddTicks(6250), "Quaerat et dicta aspernatur atque veritatis explicabo. Officiis vitae consequuntur dignissimos non voluptatibus et.", "compelling", 829m, 1185m, "Jesse", new DateTime(2021, 7, 29, 14, 25, 55, 302, DateTimeKind.Local).AddTicks(6663) },
                    { 710730218, "Games", "Myrtle", new DateTime(2021, 10, 29, 21, 38, 38, 940, DateTimeKind.Local).AddTicks(3577), "Nulla ab nostrum architecto eos quo quia. Consectetur sunt accusantium sit praesentium suscipit cum. Optio placeat est dolor. Error beatae molestiae praesentium.", "Fantastic Granite Pizza", 158m, 12050m, "Myrtle", new DateTime(2021, 9, 10, 16, 46, 51, 624, DateTimeKind.Local).AddTicks(8795) },
                    { 721347675, "Sports", "Vicki", new DateTime(2021, 11, 26, 22, 46, 35, 619, DateTimeKind.Local).AddTicks(6774), "Iure iure vel est cumque aut. Nisi maxime expedita. Doloribus eum ipsa officiis debitis consequatur et.", "pink", 610m, 47622m, "Vicki", new DateTime(2022, 3, 8, 10, 18, 42, 72, DateTimeKind.Local).AddTicks(3410) },
                    { 726397805, "Games", "Eloise", new DateTime(2022, 6, 11, 2, 2, 4, 294, DateTimeKind.Local).AddTicks(5644), "Ab corrupti quia aut eveniet et quidem. Non et nihil nostrum. Voluptatem consequuntur nisi beatae eum nemo excepturi dignissimos enim animi.", "Assurance", 193m, 19837m, "Eloise", new DateTime(2021, 10, 13, 9, 46, 28, 938, DateTimeKind.Local).AddTicks(4272) },
                    { 732627090, "Music", "Rebecca", new DateTime(2022, 4, 8, 16, 42, 52, 50, DateTimeKind.Local).AddTicks(6867), "Excepturi in explicabo reiciendis est minima illum unde temporibus. Alias placeat possimus aut est est recusandae quod ab ipsam. Molestiae eum eveniet eligendi nobis. Dolores quia voluptatum itaque.", "efficient", 350m, 42227m, "Rebecca", new DateTime(2021, 12, 15, 11, 6, 15, 305, DateTimeKind.Local).AddTicks(8929) },
                    { 754507475, "Health", "Jessie", new DateTime(2022, 6, 9, 13, 56, 37, 22, DateTimeKind.Local).AddTicks(3343), "Corrupti id labore dolores fuga est error. Labore fugit facilis labore eveniet ipsam.", "collaborative", 988m, 6728m, "Jessie", new DateTime(2022, 5, 25, 11, 54, 20, 2, DateTimeKind.Local).AddTicks(3633) },
                    { 755702070, "Books", "Georgia", new DateTime(2022, 2, 1, 0, 45, 17, 15, DateTimeKind.Local).AddTicks(5864), "Asperiores quibusdam neque a ut ut ut. Error quibusdam doloremque autem. Soluta delectus doloremque.", "engineer", 11m, 34030m, "Georgia", new DateTime(2022, 6, 6, 5, 42, 18, 985, DateTimeKind.Local).AddTicks(134) },
                    { 756253178, "Beauty", "Irving", new DateTime(2022, 6, 22, 13, 53, 12, 860, DateTimeKind.Local).AddTicks(1879), "Ex quis harum sed exercitationem quos ab. Dolor atque labore facilis tempore ipsam aut consequatur. Aut quos sit.", "Venezuela", 772m, 38486m, "Irving", new DateTime(2022, 6, 15, 19, 23, 12, 730, DateTimeKind.Local).AddTicks(3547) },
                    { 765395644, "Computers", "Van", new DateTime(2021, 10, 20, 3, 10, 47, 51, DateTimeKind.Local).AddTicks(2525), "Illo delectus aut molestias provident. Ad fugiat veniam iure eos ratione reiciendis. Suscipit eaque sint nam quisquam in aut repellat.", "Soft", 367m, 16465m, "Van", new DateTime(2021, 11, 10, 8, 36, 50, 988, DateTimeKind.Local).AddTicks(5065) },
                    { 769782974, "Sports", "Maxine", new DateTime(2022, 4, 3, 5, 47, 25, 50, DateTimeKind.Local).AddTicks(6912), "Est reiciendis eveniet dolor autem fugiat corporis itaque. Eius fugit odit ea eveniet vitae ea eveniet nostrum qui. Dolore natus officiis dolore enim quia ipsa voluptate.", "RSS", 418m, 36947m, "Maxine", new DateTime(2022, 4, 8, 19, 30, 48, 615, DateTimeKind.Local).AddTicks(2534) },
                    { 790602956, "Garden", "Russell", new DateTime(2022, 1, 18, 19, 23, 2, 565, DateTimeKind.Local).AddTicks(7128), "Magnam ea a culpa corporis soluta est. Eos distinctio eos aut et minima assumenda dolorum.", "back-end", 211m, 5298m, "Russell", new DateTime(2021, 11, 8, 11, 29, 11, 219, DateTimeKind.Local).AddTicks(6591) },
                    { 790985800, "Tools", "Gregory", new DateTime(2022, 4, 25, 19, 19, 48, 869, DateTimeKind.Local).AddTicks(4914), "Adipisci et laudantium ab ut consectetur. Sit deleniti ab quam incidunt illo est ut. Omnis repellat vitae molestias cupiditate quibusdam quia unde.", "Bedfordshire", 359m, 32982m, "Gregory", new DateTime(2021, 12, 22, 15, 54, 39, 77, DateTimeKind.Local).AddTicks(7766) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedBy", "CreatedDate", "Description", "Status", "Unit", "UnitPrice", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 791974913, "Industrial", "Sophie", new DateTime(2021, 7, 27, 9, 46, 49, 714, DateTimeKind.Local).AddTicks(5656), "Placeat quam enim ut ut autem eum est quia ut. Exercitationem at aut suscipit qui est ipsa. Velit quis ex. Cum voluptas non.", "efficient", 360m, 48914m, "Sophie", new DateTime(2021, 8, 1, 10, 59, 37, 359, DateTimeKind.Local).AddTicks(8711) },
                    { 793808743, "Tools", "Darrin", new DateTime(2022, 4, 11, 8, 0, 45, 477, DateTimeKind.Local).AddTicks(9751), "Asperiores similique fuga consectetur veritatis et qui illum dicta. Vel voluptatem dolorum libero aliquid nihil qui et. Et ipsa dicta dicta.", "open-source", 271m, 28324m, "Darrin", new DateTime(2021, 11, 22, 21, 46, 26, 532, DateTimeKind.Local).AddTicks(5420) },
                    { 803284427, "Industrial", "Ian", new DateTime(2022, 3, 3, 10, 21, 37, 916, DateTimeKind.Local).AddTicks(5072), "Reiciendis incidunt numquam laudantium placeat aspernatur quia ut. Commodi porro unde qui aspernatur expedita repellat quia eum aspernatur.", "white", 663m, 5537m, "Ian", new DateTime(2022, 6, 24, 12, 12, 23, 95, DateTimeKind.Local).AddTicks(2397) },
                    { 807237170, "Jewelery", "Ricky", new DateTime(2022, 5, 12, 20, 0, 32, 557, DateTimeKind.Local).AddTicks(4939), "Sunt eveniet dolore suscipit autem laborum numquam laboriosam.", "Metrics", 751m, 18214m, "Ricky", new DateTime(2022, 6, 2, 23, 29, 33, 411, DateTimeKind.Local).AddTicks(3368) },
                    { 828758638, "Sports", "Kristin", new DateTime(2022, 4, 5, 11, 29, 54, 667, DateTimeKind.Local).AddTicks(1768), "Aliquid velit officiis. Quod possimus ut totam ut sapiente. Et nostrum ut qui eum atque nihil blanditiis magnam vitae.", "Research", 694m, 16996m, "Kristin", new DateTime(2022, 7, 23, 19, 55, 1, 692, DateTimeKind.Local).AddTicks(4118) },
                    { 837133020, "Clothing", "Henrietta", new DateTime(2021, 11, 18, 18, 40, 3, 535, DateTimeKind.Local).AddTicks(8815), "Quod dolorem non. Aspernatur ad nam doloremque et harum illum sint rem.", "knowledge base", 866m, 38676m, "Henrietta", new DateTime(2022, 3, 20, 9, 24, 43, 281, DateTimeKind.Local).AddTicks(9174) },
                    { 842157751, "Games", "Edmond", new DateTime(2021, 10, 19, 12, 32, 7, 232, DateTimeKind.Local).AddTicks(3383), "Saepe aut dolor ut voluptate. Et assumenda fugit omnis eius.", "Bedfordshire", 549m, 45487m, "Edmond", new DateTime(2022, 4, 23, 10, 25, 43, 707, DateTimeKind.Local).AddTicks(6314) },
                    { 842461372, "Music", "Edward", new DateTime(2022, 3, 2, 10, 37, 48, 489, DateTimeKind.Local).AddTicks(515), "Dolorem dicta cum voluptatem cum impedit odio ipsa.", "cross-platform", 445m, 38838m, "Edward", new DateTime(2022, 1, 4, 12, 56, 48, 748, DateTimeKind.Local).AddTicks(3659) },
                    { 844317218, "Jewelery", "Erma", new DateTime(2022, 4, 29, 7, 27, 35, 431, DateTimeKind.Local).AddTicks(2569), "Consequatur iure ipsam occaecati qui est.", "Engineer", 960m, 20664m, "Erma", new DateTime(2021, 8, 18, 12, 26, 44, 414, DateTimeKind.Local).AddTicks(2292) },
                    { 862023818, "Beauty", "Francis", new DateTime(2021, 12, 11, 7, 45, 9, 376, DateTimeKind.Local).AddTicks(3447), "Unde explicabo aut ab iste itaque sit iure quis et. Voluptas ea a esse sed debitis.", "Savings Account", 826m, 35039m, "Francis", new DateTime(2021, 11, 25, 0, 20, 52, 807, DateTimeKind.Local).AddTicks(6301) },
                    { 867619000, "Baby", "Mandy", new DateTime(2021, 8, 5, 2, 27, 40, 346, DateTimeKind.Local).AddTicks(7760), "Dolorum quos culpa reiciendis consectetur id sit minima.", "Berkshire", 40m, 14538m, "Mandy", new DateTime(2021, 8, 9, 17, 41, 2, 301, DateTimeKind.Local).AddTicks(3624) },
                    { 913042727, "Shoes", "Lynn", new DateTime(2021, 10, 3, 13, 2, 37, 668, DateTimeKind.Local).AddTicks(9615), "Aut sed voluptatem tempore non nam iste et mollitia. Quos libero voluptatem natus quae. Numquam quaerat reprehenderit iste nulla iste libero soluta sequi voluptatem. Incidunt est et ut.", "array", 769m, 18961m, "Lynn", new DateTime(2022, 5, 23, 12, 43, 35, 332, DateTimeKind.Local).AddTicks(1704) },
                    { 922457951, "Automotive", "Robert", new DateTime(2022, 1, 23, 23, 29, 49, 847, DateTimeKind.Local).AddTicks(9338), "Voluptatem sapiente vel nihil omnis. Natus fugiat culpa unde qui voluptatem dolor. Ut est similique. Numquam voluptatem accusantium magni voluptas.", "infrastructures", 104m, 23004m, "Robert", new DateTime(2022, 3, 6, 7, 15, 46, 980, DateTimeKind.Local).AddTicks(4942) },
                    { 923518155, "Automotive", "Sonya", new DateTime(2022, 7, 12, 20, 3, 34, 367, DateTimeKind.Local).AddTicks(3173), "Architecto dolor aut ut ut est odit. Debitis qui consectetur aut rem. Recusandae sunt reprehenderit nobis tenetur possimus quia aspernatur.", "Fort", 33m, 42444m, "Sonya", new DateTime(2022, 2, 8, 16, 59, 23, 908, DateTimeKind.Local).AddTicks(4265) },
                    { 950548104, "Sports", "Rosa", new DateTime(2022, 5, 19, 9, 7, 44, 592, DateTimeKind.Local).AddTicks(5344), "Facere et consequuntur reiciendis quia nemo natus deserunt asperiores. Dolores ratione unde omnis temporibus. Iure velit necessitatibus sed ut nobis omnis. Assumenda reprehenderit dolorum qui dolores atque quo.", "Clothing", 264m, 30733m, "Rosa", new DateTime(2022, 1, 17, 4, 58, 40, 155, DateTimeKind.Local).AddTicks(1279) },
                    { 993942461, "Garden", "Frederick", new DateTime(2022, 6, 26, 10, 46, 58, 675, DateTimeKind.Local).AddTicks(7506), "Voluptatem quam autem repellat. Molestiae debitis consequatur odio nam corrupti illum voluptas provident voluptatem. Nihil est quam nemo deserunt ullam molestias rerum et. Est mollitia consequatur.", "Product", 673m, 32625m, "Frederick", new DateTime(2022, 5, 21, 14, 1, 53, 100, DateTimeKind.Local).AddTicks(2642) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
