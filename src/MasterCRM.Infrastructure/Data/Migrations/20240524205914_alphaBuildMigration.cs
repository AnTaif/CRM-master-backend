using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alphaBuildMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("1477c345-c7e4-4787-bfcf-c3de11ccfd5c"), "Footer", (short)5, 2, "Свяжитесь со мной", 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("2d4e3b18-eb9e-4af4-af60-4bbe8f0b9d29"), "H1", "Душевная мастерская", "http://localhost:8080/uploads//templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png", (short)1, "Добро пожаловать в нашу handmade мастерскую, где мы создаем уникальные украшения вручную с любовью и вниманием к деталям. Каждый элемент, от колец до ожерелий, сделан из высококачественных материалов, чтобы подчеркнуть вашу индивидуальность и стиль.", 1, "", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "Type", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("460d3c0a-45d0-4774-b278-09185fe82185"), "Catalog", (short)2, 2, "Каталог", 0, null },
                    { new Guid("8eacd1c0-cbb8-4fc8-b217-925e9229febb"), "Catalog", (short)2, 1, "Каталог", 0, null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "Title", "WebsiteId" },
                values: new object[] { new Guid("987a6515-69e3-48ed-beda-52c227bfe965"), "Text", (short)4, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl.", "Подробнее о нас", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("aa47b955-7737-475a-89db-74607753176c"), "H1", "H1 text", "http://localhost:8080/uploads//templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in.", 2, "", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "WebsiteId" },
                values: new object[] { new Guid("b50cc534-2ffc-40e9-84b6-8cb9756a8cce"), "MultipleTextBlock", (short)3, 1, "Преимущества", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "HeaderBlock_Type", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("c1cf4f5a-8981-4866-8d86-1552e0139970"), "Header", (short)0, 2, "", 0, null },
                    { new Guid("d9873b20-54f0-4ada-bd5e-2aa2b77625ff"), "Header", (short)0, 1, "", 0, null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Title", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("eab9cdd0-c2ae-4441-b99d-3caf4da61b64"), "Footer", (short)5, 1, "Свяжитесь со мной", 0, null });

            migrationBuilder.InsertData(
                table: "GlobalStyles",
                columns: new[] { "Id", "BackgroundColor", "ButtonColor", "FontFamily", "H1Color", "PColor", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("2302ab52-6d61-4313-8967-a4616e6ffeac"), "#ffffff", "#00000f", "Arial", "#f00000", "#00f000", 2, null },
                    { new Guid("cc19ec4a-5494-4cc9-afc1-0a4c56fb6831"), "#00ff00", "#00000f", "Arial", "#f00000", "#00f000", 1, null }
                });

            migrationBuilder.InsertData(
                table: "TextSection",
                columns: new[] { "Id", "MultipleTextBlockId", "Text", "Title" },
                values: new object[,]
                {
                    { new Guid("620e7468-edfc-4c17-8229-1d99ca711c1d"), new Guid("b50cc534-2ffc-40e9-84b6-8cb9756a8cce"), "Каждое украшение создается вручную, что гарантирует его неповторимость и эксклюзивность.", "Уникальность изделий" },
                    { new Guid("992d10c7-8ba4-4618-ad5d-77698333acea"), new Guid("b50cc534-2ffc-40e9-84b6-8cb9756a8cce"), "Мы используем только проверенные и высококачественные материалы, обеспечивая долговечность и эстетичность каждого изделия.", "Высокое качество материалов" },
                    { new Guid("bf962c65-bd64-46a7-ac84-c4b7ad298188"), new Guid("b50cc534-2ffc-40e9-84b6-8cb9756a8cce"), "Наши мастера постоянно разрабатывают новые и оригинальные модели, чтобы вы всегда могли найти что-то свежее и стильное.", "Творческий дизайн" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Websites_AddressName",
                table: "Websites",
                column: "AddressName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Websites_AddressName",
                table: "Websites");

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("1477c345-c7e4-4787-bfcf-c3de11ccfd5c"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("2d4e3b18-eb9e-4af4-af60-4bbe8f0b9d29"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("460d3c0a-45d0-4774-b278-09185fe82185"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("8eacd1c0-cbb8-4fc8-b217-925e9229febb"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("987a6515-69e3-48ed-beda-52c227bfe965"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("aa47b955-7737-475a-89db-74607753176c"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("c1cf4f5a-8981-4866-8d86-1552e0139970"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("d9873b20-54f0-4ada-bd5e-2aa2b77625ff"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("eab9cdd0-c2ae-4441-b99d-3caf4da61b64"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("2302ab52-6d61-4313-8967-a4616e6ffeac"));

            migrationBuilder.DeleteData(
                table: "GlobalStyles",
                keyColumn: "Id",
                keyValue: new Guid("cc19ec4a-5494-4cc9-afc1-0a4c56fb6831"));

            migrationBuilder.DeleteData(
                table: "TextSection",
                keyColumn: "Id",
                keyValue: new Guid("620e7468-edfc-4c17-8229-1d99ca711c1d"));

            migrationBuilder.DeleteData(
                table: "TextSection",
                keyColumn: "Id",
                keyValue: new Guid("992d10c7-8ba4-4618-ad5d-77698333acea"));

            migrationBuilder.DeleteData(
                table: "TextSection",
                keyColumn: "Id",
                keyValue: new Guid("bf962c65-bd64-46a7-ac84-c4b7ad298188"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("b50cc534-2ffc-40e9-84b6-8cb9756a8cce"));

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
    }
}
