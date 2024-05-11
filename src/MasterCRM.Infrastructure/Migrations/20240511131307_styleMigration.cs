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
            migrationBuilder.DropForeignKey(
                name: "FK_Style_Templates_TemplateId",
                table: "Style");

            migrationBuilder.DropForeignKey(
                name: "FK_Style_Websites_WebsiteId",
                table: "Style");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Style",
                table: "Style");

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("09bfddc2-b801-41c7-b9e8-77998467dbfb"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("3f48c097-da54-48a2-a89f-d7baeaa2d089"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("471ca963-a2af-42c1-af19-994759e5e3b0"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("6c55e6a5-54f5-494c-aea1-4fe1cfda128f"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("829b768c-fc50-4b12-984a-7519821c0092"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("941161ef-7fb5-4243-a831-7d4bd3cb4613"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("ac76c5e4-ddd9-460b-8103-fe066aa45576"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("bd151027-4699-4ed0-9100-b77c47668ab3"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("d58a0b9d-adb9-464f-a01c-8ce86ae4f1c2"));

            migrationBuilder.DeleteData(
                table: "ConstructorBlocks",
                keyColumn: "Id",
                keyValue: new Guid("e8623584-9927-452b-866a-3b38256c8d49"));

            migrationBuilder.DeleteData(
                table: "Style",
                keyColumn: "Id",
                keyValue: new Guid("60fb00ee-b14f-467a-b249-19db2b29fec3"));

            migrationBuilder.DeleteData(
                table: "Style",
                keyColumn: "Id",
                keyValue: new Guid("7096720c-28f0-419b-98b2-6a5a371169f4"));

            migrationBuilder.DeleteData(
                table: "Style",
                keyColumn: "Id",
                keyValue: new Guid("73a9bf8e-c87c-43c1-b642-8ca79d9569dd"));

            migrationBuilder.DeleteData(
                table: "Style",
                keyColumn: "Id",
                keyValue: new Guid("b651e563-aefd-411a-8fbd-c8e45188390f"));

            migrationBuilder.RenameTable(
                name: "Style",
                newName: "Styles");

            migrationBuilder.RenameIndex(
                name: "IX_Style_WebsiteId",
                table: "Styles",
                newName: "IX_Styles_WebsiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Style_TemplateId",
                table: "Styles",
                newName: "IX_Styles_TemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Styles",
                table: "Styles",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_Templates_TemplateId",
                table: "Styles",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_Websites_WebsiteId",
                table: "Styles",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Styles_Templates_TemplateId",
                table: "Styles");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_Websites_WebsiteId",
                table: "Styles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Styles",
                table: "Styles");

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

            migrationBuilder.RenameTable(
                name: "Styles",
                newName: "Style");

            migrationBuilder.RenameIndex(
                name: "IX_Styles_WebsiteId",
                table: "Style",
                newName: "IX_Style_WebsiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Styles_TemplateId",
                table: "Style",
                newName: "IX_Style_TemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Style",
                table: "Style",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("09bfddc2-b801-41c7-b9e8-77998467dbfb"), "Header", (short)0, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("3f48c097-da54-48a2-a89f-d7baeaa2d089"), "Footer", (short)4, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "WebsiteId" },
                values: new object[] { new Guid("471ca963-a2af-42c1-af19-994759e5e3b0"), "Text", (short)2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "HeaderBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("6c55e6a5-54f5-494c-aea1-4fe1cfda128f"), "Header", (short)0, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Text", "WebsiteId" },
                values: new object[] { new Guid("829b768c-fc50-4b12-984a-7519821c0092"), "Text", (short)2, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Type", "WebsiteId" },
                values: new object[] { new Guid("941161ef-7fb5-4243-a831-7d4bd3cb4613"), "Catalog", (short)3, 2, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "H1Text", "ImageUrl", "Order", "PText", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("ac76c5e4-ddd9-460b-8103-fe066aa45576"), "H1", "H1 text", "http://localhost:8080/uploads/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 1, null },
                    { new Guid("bd151027-4699-4ed0-9100-b77c47668ab3"), "H1", "H1 text", "http://localhost:8080/uploads/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png", (short)1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.", 2, null }
                });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "Type", "WebsiteId" },
                values: new object[] { new Guid("d58a0b9d-adb9-464f-a01c-8ce86ae4f1c2"), "Catalog", (short)3, 1, 0, null });

            migrationBuilder.InsertData(
                table: "ConstructorBlocks",
                columns: new[] { "Id", "BlockType", "Order", "TemplateId", "FooterBlock_Type", "WebsiteId" },
                values: new object[] { new Guid("e8623584-9927-452b-866a-3b38256c8d49"), "Footer", (short)4, 1, 0, null });

            migrationBuilder.InsertData(
                table: "Style",
                columns: new[] { "Id", "Element", "Properties", "TemplateId", "WebsiteId" },
                values: new object[,]
                {
                    { new Guid("60fb00ee-b14f-467a-b249-19db2b29fec3"), "body", new Dictionary<string, string> { ["background-color"] = "#000001", ["color"] = "#110011" }, 2, null },
                    { new Guid("7096720c-28f0-419b-98b2-6a5a371169f4"), "body", new Dictionary<string, string> { ["background-color"] = "#100001", ["color"] = "#000011" }, 1, null },
                    { new Guid("73a9bf8e-c87c-43c1-b642-8ca79d9569dd"), "h1", new Dictionary<string, string> { ["color"] = "#001100" }, 1, null },
                    { new Guid("b651e563-aefd-411a-8fbd-c8e45188390f"), "h1", new Dictionary<string, string> { ["color"] = "#110000" }, 2, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Style_Templates_TemplateId",
                table: "Style",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Style_Websites_WebsiteId",
                table: "Style",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "Id");
        }
    }
}
