using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KJ.Tourify.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class TourifyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AboutHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutGuideTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutGuideDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutGuideButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookFormTittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookFormDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookFormButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactLocationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactLocationIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhoneTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhoneIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmailTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmailIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreateTestimonialPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTestimonialHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialIcon1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialIcon2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialIcon3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTestimonialButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateTestimonialPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GalleryHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuideHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideName4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideDescription4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutServicesTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutServicesButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutService1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutService2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutService3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAboutService4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageDestinationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeDestinationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeDestinationButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service1Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service2Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service3Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service3Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service4Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service4Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePageButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourCities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryCategories_GalleryPages_GalleryPageId",
                        column: x => x.GalleryPageId,
                        principalTable: "GalleryPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TourItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HowMuchMoney = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TourCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTestimonialPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourItems_CreateTestimonialPages_CreateTestimonialPageId",
                        column: x => x.CreateTestimonialPageId,
                        principalTable: "CreateTestimonialPages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TourItems_TourCities_TourCityId",
                        column: x => x.TourCityId,
                        principalTable: "TourCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourItems_TourPages_TourPageId",
                        column: x => x.TourPageId,
                        principalTable: "TourPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GalleryItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GalleryPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryItems_GalleryCategories_GalleryCategoryId",
                        column: x => x.GalleryCategoryId,
                        principalTable: "GalleryCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryItems_GalleryPages_GalleryPageId",
                        column: x => x.GalleryPageId,
                        principalTable: "GalleryPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TourTestimonialItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourTestimonialItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourTestimonialItems_TourItems_TourItemId",
                        column: x => x.TourItemId,
                        principalTable: "TourItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryCategories_GalleryPageId",
                table: "GalleryCategories",
                column: "GalleryPageId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryItems_GalleryCategoryId",
                table: "GalleryItems",
                column: "GalleryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryItems_GalleryPageId",
                table: "GalleryItems",
                column: "GalleryPageId");

            migrationBuilder.CreateIndex(
                name: "IX_TourItems_CreateTestimonialPageId",
                table: "TourItems",
                column: "CreateTestimonialPageId");

            migrationBuilder.CreateIndex(
                name: "IX_TourItems_TourCityId",
                table: "TourItems",
                column: "TourCityId");

            migrationBuilder.CreateIndex(
                name: "IX_TourItems_TourPageId",
                table: "TourItems",
                column: "TourPageId");

            migrationBuilder.CreateIndex(
                name: "IX_TourTestimonialItems_TourItemId",
                table: "TourTestimonialItems",
                column: "TourItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPages");

            migrationBuilder.DropTable(
                name: "BookPages");

            migrationBuilder.DropTable(
                name: "ContactPages");

            migrationBuilder.DropTable(
                name: "GalleryItems");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Subscribe");

            migrationBuilder.DropTable(
                name: "TourTestimonialItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GalleryCategories");

            migrationBuilder.DropTable(
                name: "TourItems");

            migrationBuilder.DropTable(
                name: "GalleryPages");

            migrationBuilder.DropTable(
                name: "CreateTestimonialPages");

            migrationBuilder.DropTable(
                name: "TourCities");

            migrationBuilder.DropTable(
                name: "TourPages");
        }
    }
}
