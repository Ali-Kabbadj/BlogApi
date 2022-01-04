﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Blog.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220104140321_AddedRolesToDb")]
    partial class AddedRolesToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ArticleId");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ab52df6b-5881-4e09-a4f6-959200b54376"),
                            CategoryId = new Guid("0e18c37c-2a15-44fc-ace9-73e15d2a5d03"),
                            CreatedDate = new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2720),
                            Summary = "SummaryArticleOne",
                            Title = "TitleArticleOne"
                        },
                        new
                        {
                            Id = new Guid("1f16a542-b836-4152-893c-a0884baf210c"),
                            CategoryId = new Guid("0e18c37c-2a15-44fc-ace9-73e15d2a5d03"),
                            CreatedDate = new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2803),
                            Summary = "SummaryArticleOne",
                            Title = "TitleArticleOne"
                        },
                        new
                        {
                            Id = new Guid("eea19341-1122-4ba8-b94c-404348adcc00"),
                            CategoryId = new Guid("02a95519-a82b-4b57-8c51-05d261e27c05"),
                            CreatedDate = new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2808),
                            Summary = "SummaryArticleOne",
                            Title = "TitleArticleOne"
                        },
                        new
                        {
                            Id = new Guid("d6bbcf6b-a935-46cc-9359-f52b6f2f11f1"),
                            CategoryId = new Guid("02a95519-a82b-4b57-8c51-05d261e27c05"),
                            CreatedDate = new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2811),
                            Summary = "SummaryArticleOne",
                            Title = "TitleArticleOne"
                        },
                        new
                        {
                            Id = new Guid("bb296082-a5e4-4b5c-99e3-4595144be332"),
                            CategoryId = new Guid("02a95519-a82b-4b57-8c51-05d261e27c05"),
                            CreatedDate = new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2815),
                            Summary = "SummaryArticleOne",
                            Title = "TitleArticleOne"
                        });
                });

            modelBuilder.Entity("Entities.Models.ArticleTag", b =>
                {
                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TagId");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ArticleId");

                    b.HasKey("TagId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleTag");

                    b.HasData(
                        new
                        {
                            TagId = new Guid("eee4a769-de0c-4e4d-9b4e-8f50406a5fac"),
                            ArticleId = new Guid("ab52df6b-5881-4e09-a4f6-959200b54376")
                        },
                        new
                        {
                            TagId = new Guid("0e617317-64c7-4e53-bf27-396d93c87c82"),
                            ArticleId = new Guid("ab52df6b-5881-4e09-a4f6-959200b54376")
                        },
                        new
                        {
                            TagId = new Guid("ce9f0204-8ded-4e5b-b044-328455f0c3f0"),
                            ArticleId = new Guid("ab52df6b-5881-4e09-a4f6-959200b54376")
                        },
                        new
                        {
                            TagId = new Guid("0eea77a8-e163-4b52-b0dc-d67fd7eec682"),
                            ArticleId = new Guid("1f16a542-b836-4152-893c-a0884baf210c")
                        },
                        new
                        {
                            TagId = new Guid("61191da9-4363-47ef-9745-996b9410dce4"),
                            ArticleId = new Guid("1f16a542-b836-4152-893c-a0884baf210c")
                        },
                        new
                        {
                            TagId = new Guid("e7a6fd40-bde2-4b29-a9cd-de69093296ca"),
                            ArticleId = new Guid("1f16a542-b836-4152-893c-a0884baf210c")
                        },
                        new
                        {
                            TagId = new Guid("975f1f23-971f-45f0-bcf8-8a354e4e1cf9"),
                            ArticleId = new Guid("1f16a542-b836-4152-893c-a0884baf210c")
                        });
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0e18c37c-2a15-44fc-ace9-73e15d2a5d03"),
                            Name = "Politics"
                        },
                        new
                        {
                            Id = new Guid("02a95519-a82b-4b57-8c51-05d261e27c05"),
                            Name = "Physics"
                        },
                        new
                        {
                            Id = new Guid("098d3a1e-f70d-445a-8487-72ca58fcc596"),
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("3c723d99-f1a2-4ce8-965b-7b037c87f83e"),
                            Name = "Well-Being"
                        },
                        new
                        {
                            Id = new Guid("d90aab27-c51d-46d6-8471-130e7390024a"),
                            Name = "Psycology"
                        },
                        new
                        {
                            Id = new Guid("f473dafa-67a8-4f80-ba84-684a849965ba"),
                            Name = "Metaphyysics"
                        });
                });

            modelBuilder.Entity("Entities.Models.Paragraph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ParagraphId");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Paragraph");
                });

            modelBuilder.Entity("Entities.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TagId");

                    b.Property<string>("TagValue")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eee4a769-de0c-4e4d-9b4e-8f50406a5fac"),
                            TagValue = "left-politics"
                        },
                        new
                        {
                            Id = new Guid("0e617317-64c7-4e53-bf27-396d93c87c82"),
                            TagValue = "right-politics"
                        },
                        new
                        {
                            Id = new Guid("ce9f0204-8ded-4e5b-b044-328455f0c3f0"),
                            TagValue = "ecology"
                        },
                        new
                        {
                            Id = new Guid("0eea77a8-e163-4b52-b0dc-d67fd7eec682"),
                            TagValue = "Anxiety"
                        },
                        new
                        {
                            Id = new Guid("61191da9-4363-47ef-9745-996b9410dce4"),
                            TagValue = "phylosophy"
                        },
                        new
                        {
                            Id = new Guid("e7a6fd40-bde2-4b29-a9cd-de69093296ca"),
                            TagValue = "Boudism"
                        },
                        new
                        {
                            Id = new Guid("975f1f23-971f-45f0-bcf8-8a354e4e1cf9"),
                            TagValue = "Personal"
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "bc7bda4e-35e1-42a4-abee-2846cd098601",
                            ConcurrencyStamp = "4dcf9d1f-d86c-43e1-978a-8096e19aaee5",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        },
                        new
                        {
                            Id = "81edfecf-f9dc-4e36-bc8e-d6be270a7aa8",
                            ConcurrencyStamp = "417fc5c7-5c81-4db0-83bd-d1df36b0ccec",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "f8e145f6-4568-43d3-9756-384ba74d4b8f",
                            ConcurrencyStamp = "827549e3-0dbb-4695-922e-f358996b06d2",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Article", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Models.ArticleTag", b =>
                {
                    b.HasOne("Entities.Models.Article", "Acticle")
                        .WithMany("ArticleTags")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Tag", "Tag")
                        .WithMany("TagArticles")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acticle");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Entities.Models.Paragraph", b =>
                {
                    b.HasOne("Entities.Models.Article", "Article")
                        .WithMany("Paragraphs")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
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
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
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

                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Article", b =>
                {
                    b.Navigation("ArticleTags");

                    b.Navigation("Paragraphs");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Entities.Models.Tag", b =>
                {
                    b.Navigation("TagArticles");
                });
#pragma warning restore 612, 618
        }
    }
}
