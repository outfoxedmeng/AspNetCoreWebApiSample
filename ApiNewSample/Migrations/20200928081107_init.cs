using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiNewSample.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Industry = table.Column<string>(maxLength: 50, nullable: true),
                    Product = table.Column<string>(maxLength: 100, nullable: true),
                    Introduction = table.Column<string>(maxLength: 500, nullable: true),
                    BankruptTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNo = table.Column<string>(maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "BankruptTime", "Country", "Industry", "Introduction", "Name", "Product" },
                values: new object[,]
                {
                    { 1, null, "USA", "Software", "Great Company", "Microsoft", "Software" },
                    { 16, null, "USA", "Internet", "Not Exists?", "AOL", "Website" },
                    { 15, null, "USA", "ECommerce", "Store", "Amazon", "Books" },
                    { 14, null, "China", "Internet", "Music?", "NetEase", "Songs" },
                    { 13, null, "China", "ECommerce", "Brothers", "Jingdong", "Goods" },
                    { 12, null, "China", "Security", "- -", "360", "Security Product" },
                    { 11, null, "USA", "Internet", "Blocked", "Youtube", "Videos" },
                    { 10, null, "USA", "Internet", "Blocked", "Twitter", "Tweets" },
                    { 9, null, "China", "ECommerce", "From Jiangsu", "Suning", "Goods" },
                    { 8, null, "Italy", "Football", "Football Club", "AC Milan", "Football Match" },
                    { 7, null, "USA", "Technology", "Wow", "SpaceX", "Rocket" },
                    { 6, null, "USA", "Software", "Photoshop?", "Adobe", "Software" },
                    { 5, null, "China", "Internet", "From Beijing", "Baidu", "Software" },
                    { 4, null, "China", "ECommerce", "From Shenzhen", "Tencent", "Software" },
                    { 3, null, "China", "Internet", "Fubao Company", "Alipapa", "Software" },
                    { 2, null, "USA", "Internet", "Don't be evil", "Google", "Software" },
                    { 17, null, "USA", "Internet", "Who?", "Yahoo", "Mail" },
                    { 18, null, "USA", "Internet", "Is it a company?", "Firefox", "Browser" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1976, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "MSFT231", "Nick", 0, "Carter" },
                    { 2, 1, new DateTime(1981, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "MSFT245", "Vince", 0, "Carter" },
                    { 3, 2, new DateTime(1986, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "G003", "Mary", 1, "King" },
                    { 4, 2, new DateTime(1977, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "G097", "Kevin", 0, "Richardson" },
                    { 5, 3, new DateTime(1967, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "A009", "卡", 1, "里" },
                    { 6, 3, new DateTime(1957, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "A404", "Not", 0, "Man" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
