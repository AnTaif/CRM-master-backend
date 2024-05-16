using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class globalStylesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("13843ce7-213c-4321-a09d-83ff80d363f4"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("2232004c-fac2-43b0-b90f-bf7b39df43d3"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("44d4e4eb-9135-4803-8e18-3400d660fd5b"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("7351f985-64c9-40d4-9967-a908a1e7ac4e"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("7c72fc93-75e5-41fa-8aad-878038e88b4d"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("886d3254-3d72-4c18-aece-56e2b39fa765"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("b0939fdd-9cef-4e39-90f2-8f908deab4c2"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("b17b3641-50df-4c68-ba65-7b5c85ccf833"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("cd7e39af-881e-402d-a76d-057dd262e715"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("e78bf589-1262-4a0f-b8f4-c5359d5ca1ae"));

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.AddColumn<string>(
                name: "AddressName",
                table: "Websites",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GlobalStyles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: true),
                    WebsiteId = table.Column<Guid>(type: "uuid", nullable: true),
                    FontFamily = table.Column<string>(type: "text", nullable: false),
                    BackgroundColor = table.Column<string>(type: "text", nullable: false),
                    H1Color = table.Column<string>(type: "text", nullable: false),
                    PColor = table.Column<string>(type: "text", nullable: false),
                    ButtonColor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalStyles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalStyles_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GlobalStyles_Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Websites",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Type", "WebsiteId" },
                values: new object[] { new Guid("32f629ac-0f9c-4923-bcb1-29b3f386e810"), "Catalog", (short)3, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("3b79e44a-8945-4582-b110-724aecf6cc42"), "Footer", (short)4, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("a4e9e167-4fe0-4401-bb18-03658cf80840"), "Text", (short)2, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null },
                    { new Guid("aa499910-7a6d-4413-a8a1-442a17758766"), "Text", (short)2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("b671aed6-7b93-4faa-8bcf-1de44d983485"), "H1", "H1 text", "http://localhost:8080/uploads/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 1, null },
                    { new Guid("bfee1f82-b5c4-4b93-9f5c-4d7da64a714d"), "H1", "H1 text", "http://localhost:8080/uploads/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 2, null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "HeaderBlock_Type", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("c0f7971c-0ba3-4b74-8f88-f44da8448171"), "Header", (short)0, 2, 0, null },
                    { new Guid("c343fbc1-63d6-4fa4-b3dc-d5520bcaa10d"), "Header", (short)0, 1, 0, null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Type", "WebsiteId" },
                values: new object[] { new Guid("c6643412-e90a-4586-81e7-16a20354b2c8"), "Catalog", (short)3, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("da68a473-a320-4f52-82d8-c68dcb1a3de6"), "Footer", (short)4, 2, 0, null });

            migrationBuilder.InsertData(
                table: "GlobalStyles",
                columns: new[] { "Id", "BackgroundColor", "ButtonColor", "FontFamily", "H1Color", "PColor", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("163f9e6c-7f8f-4587-83b0-d954c016e450"), "#ffffff", "#00000f", "Arial", "#f00000", "#00f000", 2, null },
                    { new Guid("36b3d58e-043d-401c-9c6f-b0c299bac0c6"), "#00ff00", "#00000f", "Arial", "#f00000", "#00f000", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlobalStyles_TemplateId",
                table: "GlobalStyles",
                column: "TemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GlobalStyles_WebsiteId",
                table: "GlobalStyles",
                column: "WebsiteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalStyles");

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("32f629ac-0f9c-4923-bcb1-29b3f386e810"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("3b79e44a-8945-4582-b110-724aecf6cc42"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("a4e9e167-4fe0-4401-bb18-03658cf80840"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("aa499910-7a6d-4413-a8a1-442a17758766"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("b671aed6-7b93-4faa-8bcf-1de44d983485"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("bfee1f82-b5c4-4b93-9f5c-4d7da64a714d"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c0f7971c-0ba3-4b74-8f88-f44da8448171"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c343fbc1-63d6-4fa4-b3dc-d5520bcaa10d"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c6643412-e90a-4586-81e7-16a20354b2c8"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("da68a473-a320-4f52-82d8-c68dcb1a3de6"));

            migrationBuilder.DropColumn(
                name: "AddressName",
                table: "Websites");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Properties = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false),
                    Selector = table.Column<string>(type: "text", nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: true),
                    WebsiteId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Styles_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Styles_Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Websites",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("13843ce7-213c-4321-a09d-83ff80d363f4"), "Footer", (short)4, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Type", "WebsiteId" },
                values: new object[] { new Guid("2232004c-fac2-43b0-b90f-bf7b39df43d3"), "Catalog", (short)3, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "WebsiteId" },
                values: new object[] { new Guid("44d4e4eb-9135-4803-8e18-3400d660fd5b"), "Text", (short)2, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("7351f985-64c9-40d4-9967-a908a1e7ac4e"), "Footer", (short)4, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "WebsiteId" },
                values: new object[] { new Guid("7c72fc93-75e5-41fa-8aad-878038e88b4d"), "Text", (short)2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "WebsiteId" },
                values: new object[] { new Guid("886d3254-3d72-4c18-aece-56e2b39fa765"), "H1", "H1 text", "http://localhost:8080/uploads/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 2, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("b0939fdd-9cef-4e39-90f2-8f908deab4c2"), "Header", (short)0, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Type", "WebsiteId" },
                values: new object[] { new Guid("b17b3641-50df-4c68-ba65-7b5c85ccf833"), "Catalog", (short)3, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "WebsiteId" },
                values: new object[] { new Guid("cd7e39af-881e-402d-a76d-057dd262e715"), "H1", "H1 text", "http://localhost:8080/uploads/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 1, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("e78bf589-1262-4a0f-b8f4-c5359d5ca1ae"), "Header", (short)0, 2, 0, null });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "Properties", "Selector", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("27d65cb7-6f81-4cca-aa88-e1a1e3c59417"), new Dictionary<string, string> { ["color"] = "#001100" }, "h1", 1, null },
                    { new Guid("4f8cea0e-326f-4fac-a987-1e87a91141ea"), new Dictionary<string, string> { ["color"] = "#110000" }, "h1", 2, null },
                    { new Guid("841aa1f5-3fb1-45d5-a4a3-1995e64ce6c2"), new Dictionary<string, string> { ["background-color"] = "#100001", ["color"] = "#000011" }, "body", 1, null },
                    { new Guid("97d14ebc-cd02-4996-8636-87de5ef35dc3"), new Dictionary<string, string> { ["background-color"] = "#000001", ["color"] = "#110011" }, "body", 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Styles_TemplateId",
                table: "Styles",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_WebsiteId",
                table: "Styles",
                column: "WebsiteId");
        }
    }
}
