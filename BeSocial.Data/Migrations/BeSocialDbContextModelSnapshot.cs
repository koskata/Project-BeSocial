﻿// <auto-generated />
using System;
using BeSocial.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeSocial.Data.Migrations
{
    [DbContext(typeof(BeSocialDbContext))]
    partial class BeSocialDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeSocial.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("User's first name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("User's last name");

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

                    b.HasData(
                        new
                        {
                            Id = new Guid("b744c1d2-71a0-42a9-af63-836846a0fa40"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a584dda1-9f08-45dc-872c-a029c7e41016",
                            Email = "georgiivanov@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Georgi",
                            LastName = "Ivanov",
                            LockoutEnabled = false,
                            NormalizedEmail = "GEORGIIVANOV@GMAIL.COM",
                            NormalizedUserName = "GEORGIIVANOV@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKOs3aSlhJm7H9XJQM1AQZdvFiEi07HNlE7ZjarhOByiOt3VskuHV2a601aZxuLWIg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f8ee2c19-8d3d-4702-9151-7b4fafc42e0d",
                            TwoFactorEnabled = false,
                            UserName = "georgiivanov@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "79ee72a3-591d-4d47-ad21-f52fcef61787",
                            Email = "dimitarpavlov@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Dimitar",
                            LastName = "Pavlov",
                            LockoutEnabled = false,
                            NormalizedEmail = "DIMITARPAVLOV@GMAIL.COM",
                            NormalizedUserName = "DIMITARPAVLOV@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEM6gKCaFFqf/lZ/boIeU9srkEmBIvkWKBnhya8zZjNWNDNNw7ZMupFn3Mg4cyTnutg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "eec078a7-56ee-44b3-8d93-dc54befa1ebf",
                            TwoFactorEnabled = false,
                            UserName = "dimitarpavlov@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("42409a8e-62ad-41ce-82be-533c18943886"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4944a82e-6045-4a65-a395-af2cd01ff603",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Adminov",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEBt0f52C/4JoiifNwBkqnhww5LnGprfmHbpaPXCs4wFAlv4PASz1p9Z8XzApH4Q4yw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "848c8f05-6777-4b9a-ad2c-4e340b04c580",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("BeSocial.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category identifier for group");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Category name for group");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Funny"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lifestyle"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Music"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("BeSocial.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Comment identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Comment description");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Post identifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User identifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("BeSocial.Data.Models.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Group identifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int")
                        .HasComment("Premium user identifier who is creator of group");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Group name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Groups", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e4d30dd1-31f7-4a05-9f45-9b40f8bad5eb"),
                            CategoryId = 3,
                            CreatorId = 1,
                            Name = "Champions League Matches"
                        });
                });

            modelBuilder.Entity("BeSocial.Data.Models.GroupParticipant", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Group identifier");

                    b.Property<Guid>("ParticipantId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Participant identifier");

                    b.HasKey("GroupId", "ParticipantId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("GroupParticipants", (string)null);

                    b.HasData(
                        new
                        {
                            GroupId = new Guid("e4d30dd1-31f7-4a05-9f45-9b40f8bad5eb"),
                            ParticipantId = new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20")
                        });
                });

            modelBuilder.Entity("BeSocial.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Post identifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Post date of creation");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Creator identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Post description");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Group identifier");

                    b.Property<int>("Likes")
                        .HasColumnType("int")
                        .HasComment("Post likes counter");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Post title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("GroupId");

                    b.ToTable("Posts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0a48ee8-f260-4d8e-9f47-bd1d553b23f7"),
                            CategoryId = 1,
                            CreatedOn = new DateTime(2024, 3, 23, 16, 25, 56, 0, DateTimeKind.Unspecified),
                            CreatorId = new Guid("b744c1d2-71a0-42a9-af63-836846a0fa40"),
                            Description = "Why did the tomato turn red? Because it saw the salad dressing!",
                            Likes = 0,
                            Title = "Joke that I heard from my friend"
                        },
                        new
                        {
                            Id = new Guid("b32c53b2-bed3-49cb-a43f-189de2dcc6c6"),
                            CategoryId = 3,
                            CreatedOn = new DateTime(2024, 4, 7, 12, 37, 12, 0, DateTimeKind.Unspecified),
                            CreatorId = new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                            Description = "The semi-final in champions league will be: Real Madrid vs Manchester City. The match is going to be very interesting!",
                            Likes = 0,
                            Title = "Semi-Final Champions League"
                        },
                        new
                        {
                            Id = new Guid("7b38ce67-125a-44b7-b13a-666e3167b20a"),
                            CategoryId = 2,
                            CreatedOn = new DateTime(2024, 4, 3, 10, 16, 34, 0, DateTimeKind.Unspecified),
                            CreatorId = new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                            Description = "Today I woke up and went to the gym. Then I went home and worked from home a bit. At the end of the day, we sat down to dinner with my family.",
                            Likes = 0,
                            Title = "One day in my life"
                        });
                });

            modelBuilder.Entity("BeSocial.Data.Models.PostLiker", b =>
                {
                    b.Property<Guid>("LikerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Post liker identifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Post identifier");

                    b.HasKey("LikerId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostLikers", (string)null);
                });

            modelBuilder.Entity("BeSocial.Data.Models.PremiumUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Premium user identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Normal user identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Premium user description");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Premium user first name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Premium user last name");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("PremiumUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                            Description = "Hello, my name is Dimitar. I am 25 years old from Sofia. I would love it if you follow me for more content from me.",
                            FirstName = "Dimitar",
                            LastName = "Pavlov"
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = new Guid("42409a8e-62ad-41ce-82be-533c18943886"),
                            Description = "The best admin. You can't touch me!",
                            FirstName = "Admin",
                            LastName = "Adminov"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BeSocial.Data.Models.Comment", b =>
                {
                    b.HasOne("BeSocial.Data.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BeSocial.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeSocial.Data.Models.Group", b =>
                {
                    b.HasOne("BeSocial.Data.Models.Category", "Category")
                        .WithMany("Groups")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeSocial.Data.Models.PremiumUser", "Creator")
                        .WithMany("CreatedGroups")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("BeSocial.Data.Models.GroupParticipant", b =>
                {
                    b.HasOne("BeSocial.Data.Models.Group", "Group")
                        .WithMany("GroupParticipants")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BeSocial.Data.Models.ApplicationUser", "Participant")
                        .WithMany("GroupParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("BeSocial.Data.Models.Post", b =>
                {
                    b.HasOne("BeSocial.Data.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeSocial.Data.Models.ApplicationUser", "Creator")
                        .WithMany("Posts")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeSocial.Data.Models.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId");

                    b.Navigation("Category");

                    b.Navigation("Creator");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("BeSocial.Data.Models.PostLiker", b =>
                {
                    b.HasOne("BeSocial.Data.Models.ApplicationUser", "Liker")
                        .WithMany()
                        .HasForeignKey("LikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeSocial.Data.Models.Post", "Post")
                        .WithMany("PostLikers")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Liker");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BeSocial.Data.Models.PremiumUser", b =>
                {
                    b.HasOne("BeSocial.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("BeSocial.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("BeSocial.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeSocial.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("BeSocial.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeSocial.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("GroupParticipants");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BeSocial.Data.Models.Category", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BeSocial.Data.Models.Group", b =>
                {
                    b.Navigation("GroupParticipants");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BeSocial.Data.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostLikers");
                });

            modelBuilder.Entity("BeSocial.Data.Models.PremiumUser", b =>
                {
                    b.Navigation("CreatedGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
