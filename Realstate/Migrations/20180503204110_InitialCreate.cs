using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Realstate.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RentingCommon");

            migrationBuilder.EnsureSchema(
                name: "RentingCore");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    StatusRegister = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    StatusRegister = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nchar(500)", nullable: true),
                    StatusRegister = table.Column<string>(type: "nchar(10)", nullable: true),
                    usercreation = table.Column<string>(type: "nchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parish",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    IdDistrict = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    StatusRegister = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "propietario",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cedula = table.Column<string>(type: "nchar(10)", nullable: true),
                    email = table.Column<string>(type: "nchar(10)", nullable: true),
                    movil = table.Column<string>(type: "nchar(10)", nullable: true),
                    name = table.Column<string>(type: "nchar(10)", nullable: true),
                    phone = table.Column<string>(type: "nchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTask",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    StatusRegister = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTask",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    StatusRegister = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "nchar(500)", nullable: true),
                    name = table.Column<string>(type: "nchar(500)", nullable: true),
                    StatusRegister = table.Column<string>(type: "nchar(10)", nullable: true),
                    usercreation = table.Column<string>(type: "nchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    IdCountry = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_Country",
                        column: x => x.IdCountry,
                        principalSchema: "RentingCommon",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Management",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    IdRegion = table.Column<long>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Management_Region",
                        column: x => x.IdRegion,
                        principalSchema: "RentingCommon",
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    IdManagement = table.Column<long>(nullable: true),
                    IdProvince = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    StatusRegister = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Management",
                        column: x => x.IdManagement,
                        principalSchema: "RentingCommon",
                        principalTable: "Management",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_District_Province",
                        column: x => x.IdProvince,
                        principalSchema: "RentingCommon",
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                schema: "RentingCommon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    IdDistrict = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    StatusRegister = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sector_District",
                        column: x => x.IdDistrict,
                        principalSchema: "RentingCommon",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "RentingCore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdAccount = table.Column<int>(nullable: false),
                    IdContry = table.Column<int>(nullable: false),
                    IdDistrict = table.Column<int>(nullable: false),
                    IdLink = table.Column<int>(nullable: false),
                    IdParish = table.Column<int>(nullable: false),
                    IdProvince = table.Column<int>(nullable: false),
                    IdSector = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    StatusRegister = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    usercreation = table.Column<string>(type: "nchar(50)", nullable: true),
                    ZonaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Account",
                        column: x => x.IdAccount,
                        principalSchema: "RentingCommon",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Country",
                        column: x => x.IdContry,
                        principalSchema: "RentingCommon",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_District",
                        column: x => x.IdDistrict,
                        principalSchema: "RentingCommon",
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Link",
                        column: x => x.IdLink,
                        principalSchema: "RentingCommon",
                        principalTable: "Link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Parish",
                        column: x => x.IdParish,
                        principalSchema: "RentingCommon",
                        principalTable: "Parish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Province",
                        column: x => x.IdProvince,
                        principalSchema: "RentingCommon",
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Sector",
                        column: x => x.IdSector,
                        principalSchema: "RentingCommon",
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Zona",
                        column: x => x.ZonaId,
                        principalSchema: "RentingCommon",
                        principalTable: "Zona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZonaProspectada",
                schema: "RentingCore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "nchar(10)", nullable: true),
                    commentary = table.Column<string>(type: "nchar(500)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdProyecto = table.Column<int>(nullable: true),
                    name = table.Column<string>(type: "nchar(100)", nullable: true),
                    reference = table.Column<string>(maxLength: 500, nullable: true),
                    StatusRegister = table.Column<string>(type: "nchar(10)", nullable: true),
                    StreetMain = table.Column<string>(type: "nchar(500)", nullable: true),
                    StreetSecundary = table.Column<string>(type: "nchar(500)", nullable: true),
                    Streetfour = table.Column<string>(type: "nchar(500)", nullable: true),
                    Streetthree = table.Column<string>(type: "nchar(500)", nullable: true),
                    usercreation = table.Column<string>(type: "nchar(50)", nullable: true),
                    zona = table.Column<string>(type: "nchar(50)", nullable: true),
                    imagen = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaProspectada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZonaProspectada_Project",
                        column: x => x.IdProyecto,
                        principalSchema: "RentingCore",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Predio",
                schema: "RentingCore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    idPropietario = table.Column<int>(nullable: true),
                    idZonaProspectada = table.Column<int>(nullable: true),
                    image = table.Column<byte[]>(type: "image", nullable: true),
                    latitude = table.Column<string>(type: "nchar(20)", nullable: true),
                    length = table.Column<string>(type: "nchar(20)", nullable: true),
                    name = table.Column<string>(type: "nchar(500)", nullable: true),
                    StatusRegister = table.Column<string>(type: "nchar(10)", nullable: true),
                    usercreation = table.Column<string>(type: "nchar(50)", nullable: true),
                    value = table.Column<string>(type: "nchar(20)", nullable: true),
                    zona = table.Column<string>(type: "nchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predio_ZonaProspectada",
                        column: x => x.idZonaProspectada,
                        principalSchema: "RentingCore",
                        principalTable: "ZonaProspectada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                schema: "RentingCore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AggregateUri = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Code = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DateCreation = table.Column<DateTime>(type: "date", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    ExternalCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IdAccount = table.Column<int>(nullable: false),
                    IdPredio = table.Column<int>(nullable: true),
                    IdProject = table.Column<int>(nullable: false),
                    IdProspectoAreas = table.Column<int>(nullable: false),
                    IdStatusTask = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTypeTask = table.Column<int>(nullable: true),
                    Route = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusRegister = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    usercreation = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Predio",
                        column: x => x.IdPredio,
                        principalSchema: "RentingCore",
                        principalTable: "Predio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_StatusTask",
                        column: x => x.IdStatusTask,
                        principalSchema: "RentingCommon",
                        principalTable: "StatusTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_TypeTask",
                        column: x => x.IdTypeTask,
                        principalSchema: "RentingCommon",
                        principalTable: "TypeTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_District_IdManagement",
                schema: "RentingCommon",
                table: "District",
                column: "IdManagement");

            migrationBuilder.CreateIndex(
                name: "IX_District_IdProvince",
                schema: "RentingCommon",
                table: "District",
                column: "IdProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Management_IdRegion",
                schema: "RentingCommon",
                table: "Management",
                column: "IdRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Province_IdCountry",
                schema: "RentingCommon",
                table: "Province",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_IdDistrict",
                schema: "RentingCommon",
                table: "Sector",
                column: "IdDistrict");

            migrationBuilder.CreateIndex(
                name: "IX_Predio_idZonaProspectada",
                schema: "RentingCore",
                table: "Predio",
                column: "idZonaProspectada");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdAccount",
                schema: "RentingCore",
                table: "Project",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdContry",
                schema: "RentingCore",
                table: "Project",
                column: "IdContry");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdDistrict",
                schema: "RentingCore",
                table: "Project",
                column: "IdDistrict");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdLink",
                schema: "RentingCore",
                table: "Project",
                column: "IdLink");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdParish",
                schema: "RentingCore",
                table: "Project",
                column: "IdParish");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdProvince",
                schema: "RentingCore",
                table: "Project",
                column: "IdProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdSector",
                schema: "RentingCore",
                table: "Project",
                column: "IdSector");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ZonaId",
                schema: "RentingCore",
                table: "Project",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_IdPredio",
                schema: "RentingCore",
                table: "Task",
                column: "IdPredio");

            migrationBuilder.CreateIndex(
                name: "IX_Task_IdStatusTask",
                schema: "RentingCore",
                table: "Task",
                column: "IdStatusTask");

            migrationBuilder.CreateIndex(
                name: "IX_Task_IdTypeTask",
                schema: "RentingCore",
                table: "Task",
                column: "IdTypeTask");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaProspectada_IdProyecto",
                schema: "RentingCore",
                table: "ZonaProspectada",
                column: "IdProyecto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "propietario",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "Task",
                schema: "RentingCore");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Predio",
                schema: "RentingCore");

            migrationBuilder.DropTable(
                name: "StatusTask",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "TypeTask",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "ZonaProspectada",
                schema: "RentingCore");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "RentingCore");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "Link",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "Parish",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "Sector",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "Zona",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "District",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "Management",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "Province",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "RentingCommon");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "RentingCommon");
        }
    }
}
