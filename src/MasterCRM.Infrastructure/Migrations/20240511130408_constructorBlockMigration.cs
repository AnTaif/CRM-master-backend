using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class constructorBlockMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorBlock_Templates_TemplateId",
                table: "ConstructorBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorBlock_Websites_WebsiteId",
                table: "ConstructorBlock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConstructorBlock",
                table: "ConstructorBlock");

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

            migrationBuilder.RenameTable(
                name: "ConstructorBlock",
                newName: "ConstructorBlocks");

            migrationBuilder.RenameIndex(
                name: "IX_ConstructorBlock_WebsiteId",
                table: "ConstructorBlocks",
                newName: "IX_ConstructorBlocks_WebsiteId");

            migrationBuilder.RenameIndex(
                name: "IX_ConstructorBlock_TemplateId",
                table: "ConstructorBlocks",
                newName: "IX_ConstructorBlocks_TemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConstructorBlocks",
                table: "ConstructorBlocks",
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
                name: "FK_ConstructorBlocks_Templates_TemplateId",
                table: "ConstructorBlocks",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructorBlocks_Websites_WebsiteId",
                table: "ConstructorBlocks",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorBlocks_Templates_TemplateId",
                table: "ConstructorBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorBlocks_Websites_WebsiteId",
                table: "ConstructorBlocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConstructorBlocks",
                table: "ConstructorBlocks");

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
                name: "ConstructorBlocks",
                newName: "ConstructorBlock");

            migrationBuilder.RenameIndex(
                name: "IX_ConstructorBlocks_WebsiteId",
                table: "ConstructorBlock",
                newName: "IX_ConstructorBlock_WebsiteId");

            migrationBuilder.RenameIndex(
                name: "IX_ConstructorBlocks_TemplateId",
                table: "ConstructorBlock",
                newName: "IX_ConstructorBlock_TemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConstructorBlock",
                table: "ConstructorBlock",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructorBlock_Templates_TemplateId",
                table: "ConstructorBlock",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructorBlock_Websites_WebsiteId",
                table: "ConstructorBlock",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "Id");
        }
    }
}
