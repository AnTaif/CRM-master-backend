using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class constructorMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.AlterColumn<ValueTuple<string, string>[]>(
                name: "TextSections",
                table: "ConstructorBlocks",
                type: "record[]",
                nullable: true,
                oldClrType: typeof(Dictionary<string, string>),
                oldType: "hstore",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "Type", "WebsiteId" },
                values: new object[] { new Guid("065c3936-c1cb-4b8a-8ee7-3d3f97fd95be"), "Catalog", (short)2, 1, "Каталог", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "Title", "WebsiteId" },
                values: new object[] { new Guid("0d51c52f-28ab-49db-9120-ace17a18ba9a"), "Text", (short)3, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl.", "Подробнее о нас", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("559911f9-d9ff-473b-9ef4-7c2affaba0bf"), "H1", "H1 text", "http://localhost:8080/uploads/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in.", 2, "", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "Type", "WebsiteId" },
                values: new object[] { new Guid("5a34c90d-84c0-4de2-a27d-3a2eb60e5cd0"), "Catalog", (short)2, 2, "Каталог", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("71dd08bf-d466-424e-8d87-f2595193fafe"), "Footer", (short)4, 1, "Свяжитесь со мной", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "HeaderBlock_Type", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("79c4499e-b187-4309-b193-af46f0044e0d"), "Header", (short)0, 2, "", 0, null },
                    { new Guid("7de9f3f7-3669-49ff-b0e6-cfa79214cddb"), "Header", (short)0, 1, "", 0, null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("ad02f43c-3d1b-4fe5-a35c-c63d045ffdbd"), "Footer", (short)4, 2, "Свяжитесь со мной", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "TextSections", "Title", "WebsiteId" },
                values: new object[] { new Guid("e578179c-2536-42d3-a659-435a4151d46d"), "MultipleTextBlock", (short)0, 1, new[] { ("Уникальность изделий", "Каждое украшение создается вручную, что гарантирует его неповторимость и эксклюзивность."), ("Творческий дизайн", "Наши мастера постоянно разрабатывают новые и оригинальные модели, чтобы вы всегда могли найти что-то свежее и стильное."), ("Высокое качество материалов", "Мы используем только проверенные и высококачественные материалы, обеспечивая долговечность и эстетичность каждого изделия.") }, "Преимущества", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "Title", "WebsiteId" },
                values: new object[] { new Guid("ed9d36c9-4f20-460d-9f72-d8260aecb454"), "Text", (short)3, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl.", "Подробнее о нас", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("f900133a-11e6-4d38-80e2-4ed64e610432"), "H1", "Душевная мастерская", "http://localhost:8080/uploads/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png", (short)1, "Добро пожаловать в нашу handmade мастерскую, где мы создаем уникальные украшения вручную с любовью и вниманием к деталям. Каждый элемент, от колец до ожерелий, сделан из высококачественных материалов, чтобы подчеркнуть вашу индивидуальность и стиль.", 1, "", null });

            migrationBuilder.InsertData(
                table: "GlobalStyles",
                columns: new[] { "Id", "BackgroundColor", "ButtonColor", "FontFamily", "H1Color", "PColor", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("b9d1083e-7f6e-4025-831f-206cdc9cb448"), "#00ff00", "#00000f", "Arial", "#f00000", "#00f000", 1, null },
                    { new Guid("cd084094-fa3d-4390-8eb8-4df36e010dfb"), "#ffffff", "#00000f", "Arial", "#f00000", "#00f000", 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("065c3936-c1cb-4b8a-8ee7-3d3f97fd95be"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("0d51c52f-28ab-49db-9120-ace17a18ba9a"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("559911f9-d9ff-473b-9ef4-7c2affaba0bf"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("5a34c90d-84c0-4de2-a27d-3a2eb60e5cd0"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("71dd08bf-d466-424e-8d87-f2595193fafe"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("79c4499e-b187-4309-b193-af46f0044e0d"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("7de9f3f7-3669-49ff-b0e6-cfa79214cddb"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("ad02f43c-3d1b-4fe5-a35c-c63d045ffdbd"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("e578179c-2536-42d3-a659-435a4151d46d"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("ed9d36c9-4f20-460d-9f72-d8260aecb454"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("f900133a-11e6-4d38-80e2-4ed64e610432"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("b9d1083e-7f6e-4025-831f-206cdc9cb448"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("cd084094-fa3d-4390-8eb8-4df36e010dfb"));

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.AlterColumn<Dictionary<string, string>>(
                name: "TextSections",
                table: "ConstructorBlocks",
                type: "hstore",
                nullable: true,
                oldClrType: typeof(ValueTuple<string, string>[]),
                oldType: "record[]",
                oldNullable: true);

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
        }
    }
}
