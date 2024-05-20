using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class constructorMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TextSections",
                table: "ConstructorBlocks");

            migrationBuilder.CreateTable(
                name: "TextSection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    MultipleTextBlockId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextSection_ConstructorBlocks_MultipleTextBlockId",
                        column: x => x.MultipleTextBlockId,
                        principalTable: "ConstructorBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"), "MultipleTextBlock", (short)0, 1, "Преимущества", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("1e5439bc-040e-4085-acef-93b2bd60192f"), "H1", "H1 text", "http://localhost:8080/uploads/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in.", 2, "", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("3d431cc1-e8fc-4aea-b20d-6b629a9e1be1"), "Header", (short)0, 1, "", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "Type", "WebsiteId" },
                values: new object[] { new Guid("77606987-1940-416a-b89f-ff12ff64ed35"), "Catalog", (short)2, 1, "Каталог", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("80775f01-dfcd-4ba8-9f68-7e6d2e2b4989"), "Header", (short)0, 2, "", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "Title", "WebsiteId" },
                values: new object[] { new Guid("a16d40f2-93d9-4ff8-8b49-80604d257288"), "Text", (short)3, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl.", "Подробнее о нас", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("b6efc0d1-885c-4c68-aa11-8e03bd8e61e4"), "H1", "Душевная мастерская", "http://localhost:8080/uploads/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png", (short)1, "Добро пожаловать в нашу handmade мастерскую, где мы создаем уникальные украшения вручную с любовью и вниманием к деталям. Каждый элемент, от колец до ожерелий, сделан из высококачественных материалов, чтобы подчеркнуть вашу индивидуальность и стиль.", 1, "", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "Type", "WebsiteId" },
                values: new object[] { new Guid("bcf86cbb-15ef-46e1-ad63-45461587b1d0"), "Catalog", (short)2, 2, "Каталог", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "Title", "WebsiteId" },
                values: new object[] { new Guid("c99d0f65-bd32-4730-b858-b2ed9a1fab42"), "Text", (short)3, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl.", "Подробнее о нас", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "FooterBlock_Type", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("d4fc0253-1b3e-4df8-9e33-4493808b9cb3"), "Footer", (short)4, 1, "Свяжитесь со мной", 0, null },
                    { new Guid("f439ac9b-381b-4c34-a95d-af38620f8687"), "Footer", (short)4, 2, "Свяжитесь со мной", 0, null }
                });

            migrationBuilder.InsertData(
                table: "GlobalStyles",
                columns: new[] { "Id", "BackgroundColor", "ButtonColor", "FontFamily", "H1Color", "PColor", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("2a4385be-5839-4bf9-a7cf-987f14c2c2e1"), "#ffffff", "#00000f", "Arial", "#f00000", "#00f000", 2, null },
                    { new Guid("c15e72e9-9c27-41b5-be5e-cd5203daf7d4"), "#00ff00", "#00000f", "Arial", "#f00000", "#00f000", 1, null }
                });

            migrationBuilder.InsertData(
                table: "TextSection",
                columns: new[] { "Id", "MultipleTextBlockId", "Text", "Title" },
                values: new object[,]
                {
                    { new Guid("4bad308e-b4c8-4f74-85be-3ebd50f558ae"), new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"), "Каждое украшение создается вручную, что гарантирует его неповторимость и эксклюзивность.", "Уникальность изделий" },
                    { new Guid("77abed1d-c9ba-4457-ba53-3451b8180e39"), new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"), "Мы используем только проверенные и высококачественные материалы, обеспечивая долговечность и эстетичность каждого изделия.", "Высокое качество материалов" },
                    { new Guid("c0ffbf33-15dd-44a0-90e3-d39d2ea60d5c"), new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"), "Наши мастера постоянно разрабатывают новые и оригинальные модели, чтобы вы всегда могли найти что-то свежее и стильное.", "Творческий дизайн" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextSection_MultipleTextBlockId",
                table: "TextSection",
                column: "MultipleTextBlockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextSection");

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("1e5439bc-040e-4085-acef-93b2bd60192f"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("3d431cc1-e8fc-4aea-b20d-6b629a9e1be1"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("77606987-1940-416a-b89f-ff12ff64ed35"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("80775f01-dfcd-4ba8-9f68-7e6d2e2b4989"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("a16d40f2-93d9-4ff8-8b49-80604d257288"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("b6efc0d1-885c-4c68-aa11-8e03bd8e61e4"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("bcf86cbb-15ef-46e1-ad63-45461587b1d0"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c99d0f65-bd32-4730-b858-b2ed9a1fab42"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("d4fc0253-1b3e-4df8-9e33-4493808b9cb3"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("f439ac9b-381b-4c34-a95d-af38620f8687"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("2a4385be-5839-4bf9-a7cf-987f14c2c2e1"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("c15e72e9-9c27-41b5-be5e-cd5203daf7d4"));

            migrationBuilder.AddColumn<ValueTuple<string, string>[]>(
                name: "TextSections",
                table: "ConstructorBlocks",
                type: "record[]",
                nullable: true);

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
    }
}
