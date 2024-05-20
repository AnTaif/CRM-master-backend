﻿// <auto-generated />
using System;
using MasterCRM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MasterCRM.Infrastructure.Migrations
{
    [DbContext(typeof(CrmDbContext))]
    [Migration("20240520145241_constructorMigration3")]
    partial class constructorMigration3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MasterCRM.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MasterId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Master", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("TelegramLink")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int?>("VkId")
                        .HasColumnType("integer");

                    b.Property<string>("VkLink")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCalculationAutomated")
                        .HasColumnType("boolean");

                    b.Property<string>("MasterId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("StageId")
                        .HasColumnType("uuid");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("MasterId");

                    b.HasIndex("StageId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Orders.OrderHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Change")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderHistories");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Orders.OrderProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Orders.Stage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("MasterId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Order")
                        .HasColumnType("smallint");

                    b.Property<int>("StageType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Dimensions")
                        .HasColumnType("text");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("boolean");

                    b.Property<string>("MasterId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Material")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Products.ProductPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Extension")
                        .HasColumnType("text");

                    b.Property<short>("Order")
                        .HasColumnType("smallint");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.ConstructorBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BlockType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<short>("Order")
                        .HasColumnType("smallint");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("WebsiteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("ConstructorBlocks");

                    b.HasDiscriminator<string>("BlockType").HasValue("ConstructorBlock");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.GlobalStyles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BackgroundColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ButtonColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FontFamily")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("H1Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("WebsiteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId")
                        .IsUnique();

                    b.HasIndex("WebsiteId")
                        .IsUnique();

                    b.ToTable("GlobalStyles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c15e72e9-9c27-41b5-be5e-cd5203daf7d4"),
                            BackgroundColor = "#00ff00",
                            ButtonColor = "#00000f",
                            FontFamily = "Arial",
                            H1Color = "#f00000",
                            PColor = "#00f000",
                            TemplateId = 1
                        },
                        new
                        {
                            Id = new Guid("2a4385be-5839-4bf9-a7cf-987f14c2c2e1"),
                            BackgroundColor = "#ffffff",
                            ButtonColor = "#00000f",
                            FontFamily = "Arial",
                            H1Color = "#f00000",
                            PColor = "#00f000",
                            TemplateId = 2
                        });
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Templates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Первый шаблон"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Второй шаблон"
                        });
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.TextSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("MultipleTextBlockId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MultipleTextBlockId");

                    b.ToTable("TextSection");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4bad308e-b4c8-4f74-85be-3ebd50f558ae"),
                            MultipleTextBlockId = new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"),
                            Text = "Каждое украшение создается вручную, что гарантирует его неповторимость и эксклюзивность.",
                            Title = "Уникальность изделий"
                        },
                        new
                        {
                            Id = new Guid("c0ffbf33-15dd-44a0-90e3-d39d2ea60d5c"),
                            MultipleTextBlockId = new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"),
                            Text = "Наши мастера постоянно разрабатывают новые и оригинальные модели, чтобы вы всегда могли найти что-то свежее и стильное.",
                            Title = "Творческий дизайн"
                        },
                        new
                        {
                            Id = new Guid("77abed1d-c9ba-4457-ba53-3451b8180e39"),
                            MultipleTextBlockId = new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"),
                            Text = "Мы используем только проверенные и высококачественные материалы, обеспечивая долговечность и эстетичность каждого изделия.",
                            Title = "Высокое качество материалов"
                        });
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.Website", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Websites");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.CatalogBlock", b =>
                {
                    b.HasBaseType("MasterCRM.Domain.Entities.Websites.ConstructorBlock");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Catalog");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77606987-1940-416a-b89f-ff12ff64ed35"),
                            Order = (short)2,
                            TemplateId = 1,
                            Title = "Каталог",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("bcf86cbb-15ef-46e1-ad63-45461587b1d0"),
                            Order = (short)2,
                            TemplateId = 2,
                            Title = "Каталог",
                            Type = 0
                        });
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.FooterBlock", b =>
                {
                    b.HasBaseType("MasterCRM.Domain.Entities.Websites.ConstructorBlock");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.ToTable("ConstructorBlocks", t =>
                        {
                            t.Property("Type")
                                .HasColumnName("FooterBlock_Type");
                        });

                    b.HasDiscriminator().HasValue("Footer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4fc0253-1b3e-4df8-9e33-4493808b9cb3"),
                            Order = (short)4,
                            TemplateId = 1,
                            Title = "Свяжитесь со мной",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("f439ac9b-381b-4c34-a95d-af38620f8687"),
                            Order = (short)4,
                            TemplateId = 2,
                            Title = "Свяжитесь со мной",
                            Type = 0
                        });
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.H1Block", b =>
                {
                    b.HasBaseType("MasterCRM.Domain.Entities.Websites.ConstructorBlock");

                    b.Property<string>("H1Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PText")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("H1");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b6efc0d1-885c-4c68-aa11-8e03bd8e61e4"),
                            Order = (short)1,
                            TemplateId = 1,
                            Title = "",
                            H1Text = "Душевная мастерская",
                            ImageUrl = "http://localhost:8080/uploads/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png",
                            PText = "Добро пожаловать в нашу handmade мастерскую, где мы создаем уникальные украшения вручную с любовью и вниманием к деталям. Каждый элемент, от колец до ожерелий, сделан из высококачественных материалов, чтобы подчеркнуть вашу индивидуальность и стиль."
                        },
                        new
                        {
                            Id = new Guid("1e5439bc-040e-4085-acef-93b2bd60192f"),
                            Order = (short)1,
                            TemplateId = 2,
                            Title = "",
                            H1Text = "H1 text",
                            ImageUrl = "http://localhost:8080/uploads/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png",
                            PText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in."
                        });
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.HeaderBlock", b =>
                {
                    b.HasBaseType("MasterCRM.Domain.Entities.Websites.ConstructorBlock");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.ToTable("ConstructorBlocks", t =>
                        {
                            t.Property("Type")
                                .HasColumnName("HeaderBlock_Type");
                        });

                    b.HasDiscriminator().HasValue("Header");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3d431cc1-e8fc-4aea-b20d-6b629a9e1be1"),
                            Order = (short)0,
                            TemplateId = 1,
                            Title = "",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("80775f01-dfcd-4ba8-9f68-7e6d2e2b4989"),
                            Order = (short)0,
                            TemplateId = 2,
                            Title = "",
                            Type = 0
                        });
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.MultipleTextBlock", b =>
                {
                    b.HasBaseType("MasterCRM.Domain.Entities.Websites.ConstructorBlock");

                    b.HasDiscriminator().HasValue("MultipleTextBlock");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1deb6106-9542-457b-af0d-2d53c9dcbe52"),
                            Order = (short)0,
                            TemplateId = 1,
                            Title = "Преимущества"
                        });
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.TextBlock", b =>
                {
                    b.HasBaseType("MasterCRM.Domain.Entities.Websites.ConstructorBlock");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Text");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a16d40f2-93d9-4ff8-8b49-80604d257288"),
                            Order = (short)3,
                            TemplateId = 1,
                            Title = "Подробнее о нас",
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl."
                        },
                        new
                        {
                            Id = new Guid("c99d0f65-bd32-4730-b858-b2ed9a1fab42"),
                            Order = (short)3,
                            TemplateId = 2,
                            Title = "Подробнее о нас",
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl."
                        });
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Orders.Order", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterCRM.Domain.Entities.Master", "Master")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterCRM.Domain.Entities.Orders.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Master");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Orders.OrderHistory", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Orders.Order", null)
                        .WithMany("History")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Orders.OrderProduct", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Orders.Order", null)
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterCRM.Domain.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Products.ProductPhoto", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Products.Product", null)
                        .WithMany("Photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.ConstructorBlock", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Websites.Template", null)
                        .WithMany("Components")
                        .HasForeignKey("TemplateId");

                    b.HasOne("MasterCRM.Domain.Entities.Websites.Website", null)
                        .WithMany("Components")
                        .HasForeignKey("WebsiteId");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.GlobalStyles", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Websites.Template", null)
                        .WithOne("GlobalStyles")
                        .HasForeignKey("MasterCRM.Domain.Entities.Websites.GlobalStyles", "TemplateId");

                    b.HasOne("MasterCRM.Domain.Entities.Websites.Website", null)
                        .WithOne("GlobalStyles")
                        .HasForeignKey("MasterCRM.Domain.Entities.Websites.GlobalStyles", "WebsiteId");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.TextSection", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Websites.MultipleTextBlock", null)
                        .WithMany("TextSections")
                        .HasForeignKey("MultipleTextBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.Website", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Master", "Master")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Master");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Master", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Master", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterCRM.Domain.Entities.Master", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MasterCRM.Domain.Entities.Master", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Orders.Order", b =>
                {
                    b.Navigation("History");

                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Products.Product", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.Template", b =>
                {
                    b.Navigation("Components");

                    b.Navigation("GlobalStyles")
                        .IsRequired();
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.Website", b =>
                {
                    b.Navigation("Components");

                    b.Navigation("GlobalStyles")
                        .IsRequired();
                });

            modelBuilder.Entity("MasterCRM.Domain.Entities.Websites.MultipleTextBlock", b =>
                {
                    b.Navigation("TextSections");
                });
#pragma warning restore 612, 618
        }
    }
}