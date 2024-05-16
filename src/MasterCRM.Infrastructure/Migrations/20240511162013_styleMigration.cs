using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class styleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("1dcdcee7-01bc-4ebf-8019-b012bab9e5ba"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("2818bf0f-d9ee-43a0-9b51-b981a700c83b"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("54f100fb-0801-4c38-b7a3-17ca79363564"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("61bb87f5-3eac-42bc-9d93-b03c172149cd"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("8e98c811-3a57-4363-8d03-37e747907490"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("9b0acd79-a221-4c68-a9de-733b14a464fd"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("a852e545-3e00-4abe-abd7-6daecd872504"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("bf2c5576-087c-447e-8ab1-75177dd3f66e"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("d554759a-a7bd-40b8-9ae9-7117a6763fcf"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("d9d04eeb-791d-4c47-929b-6300b8633435"));

            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("3288a688-b44f-4cbf-a003-be5b102a79f8"));

            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("3fd7692e-90ed-453f-9e48-66731b7b3902"));

            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("8eab627e-4eec-41d8-a95c-dd0de04467f3"));

            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("909a4afc-8e79-4712-a60e-abcd5854b4f9"));

            migrationBuilder.RenameColumn(
                name: "Element",
                table: "Styles",
                newName: "Selector");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("27d65cb7-6f81-4cca-aa88-e1a1e3c59417"));

            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("4f8cea0e-326f-4fac-a987-1e87a91141ea"));

            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("841aa1f5-3fb1-45d5-a4a3-1995e64ce6c2"));

            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("97d14ebc-cd02-4996-8636-87de5ef35dc3"));

            migrationBuilder.RenameColumn(
                name: "Selector",
                table: "Styles",
                newName: "Element");

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Type", "WebsiteId" },
                values: new object[] { new Guid("1dcdcee7-01bc-4ebf-8019-b012bab9e5ba"), "Catalog", (short)3, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("2818bf0f-d9ee-43a0-9b51-b981a700c83b"), "Text", (short)2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null },
                    { new Guid("54f100fb-0801-4c38-b7a3-17ca79363564"), "Text", (short)2, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("61bb87f5-3eac-42bc-9d93-b03c172149cd"), "Footer", (short)4, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "WebsiteId" },
                values: new object[] { new Guid("8e98c811-3a57-4363-8d03-37e747907490"), "H1", "H1 text", "http://localhost:8080/uploads/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 1, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("9b0acd79-a221-4c68-a9de-733b14a464fd"), "Header", (short)0, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Type", "WebsiteId" },
                values: new object[] { new Guid("a852e545-3e00-4abe-abd7-6daecd872504"), "Catalog", (short)3, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("bf2c5576-087c-447e-8ab1-75177dd3f66e"), "Footer", (short)4, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "WebsiteId" },
                values: new object[] { new Guid("d554759a-a7bd-40b8-9ae9-7117a6763fcf"), "H1", "H1 text", "http://localhost:8080/uploads/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 2, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("d9d04eeb-791d-4c47-929b-6300b8633435"), "Header", (short)0, 1, 0, null });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "Element", "Properties", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("3288a688-b44f-4cbf-a003-be5b102a79f8"), "body", new Dictionary<string, string> { ["background-color"] = "#100001", ["color"] = "#000011" }, 1, null },
                    { new Guid("3fd7692e-90ed-453f-9e48-66731b7b3902"), "h1", new Dictionary<string, string> { ["color"] = "#110000" }, 2, null },
                    { new Guid("8eab627e-4eec-41d8-a95c-dd0de04467f3"), "h1", new Dictionary<string, string> { ["color"] = "#001100" }, 1, null },
                    { new Guid("909a4afc-8e79-4712-a60e-abcd5854b4f9"), "body", new Dictionary<string, string> { ["background-color"] = "#000001", ["color"] = "#110011" }, 2, null }
                });
        }
    }
}
