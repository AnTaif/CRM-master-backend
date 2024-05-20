using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class masterWebsiteIdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "TextSection",
                keyColumn: "Id",
                keyValue: new Guid("4bad308e-b4c8-4f74-85be-3ebd50f558ae"));

            migrationBuilder.DeleteData(
                table: "TextSection",
                keyColumn: "Id",
                keyValue: new Guid("77abed1d-c9ba-4457-ba53-3451b8180e39"));

            migrationBuilder.DeleteData(
                table: "TextSection",
                keyColumn: "Id",
                keyValue: new Guid("c0ffbf33-15dd-44a0-90e3-d39d2ea60d5c"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"));

            migrationBuilder.AddColumn<Guid>(
                name: "WebsiteId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "Title", "WebsiteId" },
                values: new object[] { new Guid("08c19f07-a221-4b3b-bef8-2886c5a56c1e"), "Text", (short)4, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl.", "Подробнее о нас", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("08e4e0b0-f7bb-4e30-a2ca-15565935c924"), "Footer", (short)5, 2, "Свяжитесь со мной", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "Type", "WebsiteId" },
                values: new object[] { new Guid("44a5d0c2-14e1-4e3d-8d08-21e39db986f4"), "Catalog", (short)2, 1, "Каталог", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("4e941457-d36a-47dc-bc0c-52a5f102d2f0"), "Header", (short)0, 1, "", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "Title", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("54b3cb5a-0f27-4357-aae8-20d3cf8f17ac"), "H1", "H1 text", "http://localhost:8080/uploads//templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in.", 2, "", null },
                    { new Guid("58c78097-e864-452b-b1c1-b9254b599f3c"), "H1", "Душевная мастерская", "http://localhost:8080/uploads//templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png", (short)1, "Добро пожаловать в нашу handmade мастерскую, где мы создаем уникальные украшения вручную с любовью и вниманием к деталям. Каждый элемент, от колец до ожерелий, сделан из высококачественных материалов, чтобы подчеркнуть вашу индивидуальность и стиль.", 1, "", null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("75a39645-afac-4bb1-b40c-72a2a865871c"), "Footer", (short)5, 1, "Свяжитесь со мной", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "Title", "WebsiteId" },
                values: new object[] { new Guid("a2a89fda-b1b5-4c7a-b9ad-52057d23a463"), "Text", (short)4, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl.", "Подробнее о нас", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("d642ce5c-d843-410a-9d6b-3db4f7852582"), "MultipleTextBlock", (short)3, 1, "Преимущества", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("e3d55138-cd7a-4d06-b180-d1f347f09aec"), "Header", (short)0, 2, "", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "Type", "WebsiteId" },
                values: new object[] { new Guid("e9d14bfb-f9d2-478d-9f60-6b232ab374de"), "Catalog", (short)2, 2, "Каталог", 0, null });

            migrationBuilder.InsertData(
                table: "GlobalStyles",
                columns: new[] { "Id", "BackgroundColor", "ButtonColor", "FontFamily", "H1Color", "PColor", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("0eef5af1-9f84-4136-9e49-ed79ffa58150"), "#00ff00", "#00000f", "Arial", "#f00000", "#00f000", 1, null },
                    { new Guid("4144875a-17c1-4f6f-86ed-499ca9772933"), "#ffffff", "#00000f", "Arial", "#f00000", "#00f000", 2, null }
                });

            migrationBuilder.InsertData(
                table: "TextSection",
                columns: new[] { "Id", "MultipleTextBlockId", "Text", "Title" },
                values: new object[,]
                {
                    { new Guid("0e8613ad-c2e4-42a7-aee5-9a2058f1d6e8"), new Guid("d642ce5c-d843-410a-9d6b-3db4f7852582"), "Наши мастера постоянно разрабатывают новые и оригинальные модели, чтобы вы всегда могли найти что-то свежее и стильное.", "Творческий дизайн" },
                    { new Guid("6732c234-967d-4040-86e3-114cea433c20"), new Guid("d642ce5c-d843-410a-9d6b-3db4f7852582"), "Мы используем только проверенные и высококачественные материалы, обеспечивая долговечность и эстетичность каждого изделия.", "Высокое качество материалов" },
                    { new Guid("f6fd1a75-1496-4288-a349-f38784f6370e"), new Guid("d642ce5c-d843-410a-9d6b-3db4f7852582"), "Каждое украшение создается вручную, что гарантирует его неповторимость и эксклюзивность.", "Уникальность изделий" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("08c19f07-a221-4b3b-bef8-2886c5a56c1e"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("08e4e0b0-f7bb-4e30-a2ca-15565935c924"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("44a5d0c2-14e1-4e3d-8d08-21e39db986f4"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("4e941457-d36a-47dc-bc0c-52a5f102d2f0"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("54b3cb5a-0f27-4357-aae8-20d3cf8f17ac"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("58c78097-e864-452b-b1c1-b9254b599f3c"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("75a39645-afac-4bb1-b40c-72a2a865871c"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("a2a89fda-b1b5-4c7a-b9ad-52057d23a463"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("e3d55138-cd7a-4d06-b180-d1f347f09aec"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("e9d14bfb-f9d2-478d-9f60-6b232ab374de"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("0eef5af1-9f84-4136-9e49-ed79ffa58150"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("4144875a-17c1-4f6f-86ed-499ca9772933"));

            migrationBuilder.DeleteData(
                table: "TextSection",
                keyColumn: "Id",
                keyValue: new Guid("0e8613ad-c2e4-42a7-aee5-9a2058f1d6e8"));

            migrationBuilder.DeleteData(
                table: "TextSection",
                keyColumn: "Id",
                keyValue: new Guid("6732c234-967d-4040-86e3-114cea433c20"));

            migrationBuilder.DeleteData(
                table: "TextSection",
                keyColumn: "Id",
                keyValue: new Guid("f6fd1a75-1496-4288-a349-f38784f6370e"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("d642ce5c-d843-410a-9d6b-3db4f7852582"));

            migrationBuilder.DropColumn(
                name: "WebsiteId",
                table: "AspNetUsers");

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
        }
    }
}
