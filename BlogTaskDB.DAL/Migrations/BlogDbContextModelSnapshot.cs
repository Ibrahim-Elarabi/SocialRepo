//// <auto-generated />
//using System;
//using BlogTask.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

//namespace BlogTask.Migrations
//{
//    [DbContext(typeof(BlogDbContext))]
//    partial class BlogDbContextModelSnapshot : ModelSnapshot
//    {
//        protected override void BuildModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder
//                .HasAnnotation("Relational:MaxIdentifierLength", 128)
//                .HasAnnotation("ProductVersion", "5.0.12")
//                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//            modelBuilder.Entity("BlogTask.Areas.Identity.Data.ApplicationUser", b =>
//                {
//                    b.Property<string>("Id")
//                        .HasColumnType("nvarchar(450)");

//                    b.Property<int>("AccessFailedCount")
//                        .HasColumnType("int");

//                    b.Property<string>("ConcurrencyStamp")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Email")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("EmailConfirmed")
//                        .HasColumnType("bit");

//                    b.Property<bool>("LockoutEnabled")
//                        .HasColumnType("bit");

//                    b.Property<DateTimeOffset?>("LockoutEnd")
//                        .HasColumnType("datetimeoffset");

//                    b.Property<string>("NormalizedEmail")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("NormalizedUserName")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("PasswordHash")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("PhoneNumber")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("PhoneNumberConfirmed")
//                        .HasColumnType("bit");

//                    b.Property<string>("SecurityStamp")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("TwoFactorEnabled")
//                        .HasColumnType("bit");

//                    b.Property<string>("UserName")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("ApplicationUser");
//                });

//            modelBuilder.Entity("BlogTask.Models.Blog", b =>
//                {
//                    b.Property<int>("BlogId")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("Description")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasMaxLength(20)
//                        .HasColumnType("nvarchar(20)");

//                    b.HasKey("BlogId");

//                    b.ToTable("Blogs");
//                });

//            modelBuilder.Entity("BlogTask.Models.Group", b =>
//                {
//                    b.Property<int>("GroupID")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("Description")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Title")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("GroupID");

//                    b.ToTable("Groups");
//                });

//            modelBuilder.Entity("BlogTask.Models.GroupUser", b =>
//                {
//                    b.Property<int>("ID")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<int>("GroupID")
//                        .HasColumnType("int");

//                    b.Property<bool>("IsRequest")
//                        .HasColumnType("bit");

//                    b.Property<string>("UserId")
//                        .HasColumnType("nvarchar(450)");

//                    b.HasKey("ID");

//                    b.HasIndex("GroupID");

//                    b.HasIndex("UserId");

//                    b.ToTable("GroupUsers");
//                });

//            modelBuilder.Entity("BlogTask.Models.Post", b =>
//                {
//                    b.Property<int>("PostID")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("ApplicationUserId")
//                        .HasColumnType("nvarchar(450)");

//                    b.Property<int>("BlogID")
//                        .HasColumnType("int");

//                    b.Property<DateTime>("Date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("Description")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Title")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("PostID");

//                    b.HasIndex("ApplicationUserId");

//                    b.HasIndex("BlogID");

//                    b.ToTable("Posts");
//                });

//            modelBuilder.Entity("BlogTask.Models.GroupUser", b =>
//                {
//                    b.HasOne("BlogTask.Models.Group", "Group")
//                        .WithMany("GroupUsers")
//                        .HasForeignKey("GroupID")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.HasOne("BlogTask.Areas.Identity.Data.ApplicationUser", "ApplicationUser")
//                        .WithMany("GroupUsers")
//                        .HasForeignKey("UserId");

//                    b.Navigation("ApplicationUser");

//                    b.Navigation("Group");
//                });

//            modelBuilder.Entity("BlogTask.Models.Post", b =>
//                {
//                    b.HasOne("BlogTask.Areas.Identity.Data.ApplicationUser", "ApplicationUser")
//                        .WithMany("Posts")
//                        .HasForeignKey("ApplicationUserId");

//                    b.HasOne("BlogTask.Models.Blog", "Blog")
//                        .WithMany("Posts")
//                        .HasForeignKey("BlogID")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.Navigation("ApplicationUser");

//                    b.Navigation("Blog");
//                });

//            modelBuilder.Entity("BlogTask.Areas.Identity.Data.ApplicationUser", b =>
//                {
//                    b.Navigation("GroupUsers");

//                    b.Navigation("Posts");
//                });

//            modelBuilder.Entity("BlogTask.Models.Blog", b =>
//                {
//                    b.Navigation("Posts");
//                });

//            modelBuilder.Entity("BlogTask.Models.Group", b =>
//                {
//                    b.Navigation("GroupUsers");
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}
