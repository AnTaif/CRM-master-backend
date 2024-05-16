using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class templateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Websites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Element",
                table: "Style",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Первый шаблон" },
                    { 2, "Второй шаблон" }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlock",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "WebsiteId" },
                values: new object[] { new Guid("034f99f5-c05b-46e9-b8f0-df6eca82d681"), "Text", (short)1, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlock",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Type", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("113a9aca-29b5-4709-a3ea-1d72d3c58666"), "Catalog", (short)3, 2, 0, null },
                    { new Guid("365e4e09-3fbb-4b42-a228-573ea8fe216e"), "Catalog", (short)3, 1, 0, null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlock",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("3d441fac-2266-47b2-945e-2ad2c496dc86"), "Footer", (short)4, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlock",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "HeaderBlock_Type", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("6a2df32f-1d6f-4ce3-88f6-0928b9656f35"), "Header", (short)0, 1, 0, null },
                    { new Guid("7112b8b3-a55c-48a1-abf7-13a760e002bc"), "Header", (short)0, 2, 0, null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlock",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "WebsiteId" },
                values: new object[] { new Guid("747ed919-c58c-4287-968b-3f0238262b9a"), "H1", "H1 text", "", (short)2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 1, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlock",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "WebsiteId" },
                values: new object[] { new Guid("7f3f860d-336a-48d0-a2b6-a18793863dcc"), "Text", (short)1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlock",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("df6bd25d-c382-4f9a-aa9a-3d71e0f6c937"), "Footer", (short)4, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlock",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "WebsiteId" },
                values: new object[] { new Guid("f24d5424-41d1-4a5f-8ecd-a21e9e941753"), "H1", "H1 text", "", (short)2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 2, null });

            migrationBuilder.InsertData(
                table: "Style",
                columns: new[] { "Id", "Element", "Properties", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("0cb94caa-6581-4033-96cb-cb566af06e7b"), "body", new Dictionary<string, string> { ["background-color"] = "#000001", ["color"] = "#110011" }, 2, null },
                    { new Guid("4cac9363-71a8-44f2-8bcf-ee825caf69a4"), "h1", new Dictionary<string, string> { ["color"] = "#001100" }, 1, null },
                    { new Guid("9ea44fa0-c19e-4316-a173-8158391a5b13"), "body", new Dictionary<string, string> { ["background-color"] = "#100001", ["color"] = "#000011" }, 1, null },
                    { new Guid("ab550937-8e42-456c-9d91-f32ae13917ac"), "h1", new Dictionary<string, string> { ["color"] = "#110000" }, 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("034f99f5-c05b-46e9-b8f0-df6eca82d681"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("113a9aca-29b5-4709-a3ea-1d72d3c58666"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("365e4e09-3fbb-4b42-a228-573ea8fe216e"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("3d441fac-2266-47b2-945e-2ad2c496dc86"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("6a2df32f-1d6f-4ce3-88f6-0928b9656f35"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("7112b8b3-a55c-48a1-abf7-13a760e002bc"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("747ed919-c58c-4287-968b-3f0238262b9a"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("7f3f860d-336a-48d0-a2b6-a18793863dcc"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("df6bd25d-c382-4f9a-aa9a-3d71e0f6c937"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlock",
                keyColumn: "Id",
                keyValue: new Guid("f24d5424-41d1-4a5f-8ecd-a21e9e941753"));

            migrationBuilder.DeleteData(
                table: "Style",
                keyColumn: "Id",
                keyValue: new Guid("0cb94caa-6581-4033-96cb-cb566af06e7b"));

            migrationBuilder.DeleteData(
                table: "Style",
                keyColumn: "Id",
                keyValue: new Guid("4cac9363-71a8-44f2-8bcf-ee825caf69a4"));

            migrationBuilder.DeleteData(
                table: "Style",
                keyColumn: "Id",
                keyValue: new Guid("9ea44fa0-c19e-4316-a173-8158391a5b13"));

            migrationBuilder.DeleteData(
                table: "Style",
                keyColumn: "Id",
                keyValue: new Guid("ab550937-8e42-456c-9d91-f32ae13917ac"));

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Websites");

            migrationBuilder.DropColumn(
                name: "Element",
                table: "Style");
        }
    }
}
