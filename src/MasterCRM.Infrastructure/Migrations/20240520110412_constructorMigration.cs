using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class constructorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("163f9e6c-7f8f-4587-83b0-d954c016e450"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("36b3d58e-043d-401c-9c6f-b0c299bac0c6"));

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "TextSections",
                table: "ConstructorBlocks",
                type: "hstore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ConstructorBlocks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("17621eae-9a44-445f-9291-242963ea2c43"), "H1", "Душевная мастерская", "http://localhost:8080/uploads/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png", (short)1, "Добро пожаловать в нашу handmade мастерскую, где мы создаем уникальные украшения вручную с любовью и вниманием к деталям. Каждый элемент, от колец до ожерелий, сделан из высококачественных материалов, чтобы подчеркнуть вашу индивидуальность и стиль.", 1, "", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("18789cc0-d802-4d03-b417-402f68a89a22"), "Footer", (short)4, 1, "Свяжитесь со мной", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("3341e14b-9100-439f-b702-6eb4009caeb8"), "Header", (short)0, 2, "", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "Title", "WebsiteId" },
                values: new object[] { new Guid("4cb17338-2a1b-4865-8a53-0ef33e210a0b"), "Text", (short)3, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl.", "Подробнее о нас", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("53a69db3-10ff-49f8-8d7e-1273069ad537"), "H1", "H1 text", "http://localhost:8080/uploads/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in.", 2, "", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("9a338b21-4100-4fc7-9c36-8fb945b2b7e4"), "Footer", (short)4, 2, "Свяжитесь со мной", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "TextSections", "Title", "WebsiteId" },
                values: new object[] { new Guid("9c439d81-c4a1-4941-af99-f97189d5a468"), "MultipleTextBlock", (short)0, 1, new Dictionary<string, string> { ["Уникальность изделий"] = "Каждое украшение создается вручную, что гарантирует его неповторимость и эксклюзивность.", ["Творческий дизайн"] = "Наши мастера постоянно разрабатывают новые и оригинальные модели, чтобы вы всегда могли найти что-то свежее и стильное.", ["Высокое качество материалов"] = "Мы используем только проверенные и высококачественные материалы, обеспечивая долговечность и эстетичность каждого изделия." }, "Преимущества", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "Type", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("a8e0d7e5-9078-449b-a464-00c17c001087"), "Catalog", (short)2, 1, "Каталог", 0, null },
                    { new Guid("b9561491-0a2c-4216-98ef-477d63022ee3"), "Catalog", (short)2, 2, "Каталог", 0, null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("c9478867-bab6-4ab7-be7e-b34fdfc001b3"), "Header", (short)0, 1, "", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "Title", "WebsiteId" },
                values: new object[] { new Guid("d0e256bd-fa13-4abf-b3d3-f93933494dcb"), "Text", (short)3, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl.", "Подробнее о нас", null });

            migrationBuilder.InsertData(
                table: "GlobalStyles",
                columns: new[] { "Id", "BackgroundColor", "ButtonColor", "FontFamily", "H1Color", "PColor", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("a740ed6f-e8d9-4ea1-a286-b86cf7c95cda"), "#00ff00", "#00000f", "Arial", "#f00000", "#00f000", 1, null },
                    { new Guid("bdcf848a-65b1-47e4-9e11-ac1a9d03b46e"), "#ffffff", "#00000f", "Arial", "#f00000", "#00f000", 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MasterId",
                table: "Orders",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_MasterId",
                table: "Orders",
                column: "MasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_MasterId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MasterId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("17621eae-9a44-445f-9291-242963ea2c43"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("18789cc0-d802-4d03-b417-402f68a89a22"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("3341e14b-9100-439f-b702-6eb4009caeb8"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("4cb17338-2a1b-4865-8a53-0ef33e210a0b"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("53a69db3-10ff-49f8-8d7e-1273069ad537"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("9a338b21-4100-4fc7-9c36-8fb945b2b7e4"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("9c439d81-c4a1-4941-af99-f97189d5a468"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("a8e0d7e5-9078-449b-a464-00c17c001087"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("b9561491-0a2c-4216-98ef-477d63022ee3"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c9478867-bab6-4ab7-be7e-b34fdfc001b3"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("d0e256bd-fa13-4abf-b3d3-f93933494dcb"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("a740ed6f-e8d9-4ea1-a286-b86cf7c95cda"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("bdcf848a-65b1-47e4-9e11-ac1a9d03b46e"));

            migrationBuilder.DropColumn(
                name: "TextSections",
                table: "ConstructorBlocks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ConstructorBlocks");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:hstore", ",,");

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
        }
    }
}
