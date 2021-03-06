//// <auto-generated />
//using System;
//using BlogTask.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

//namespace BlogTask.Migrations
//{
//    [DbContext(typeof(BlogDbContext))]
//    [Migration("20211215090831_create DB")]
//    partial class createDB
//    {
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder
//                .HasAnnotation("Relational:MaxIdentifierLength", 128)
//                .HasAnnotation("ProductVersion", "5.0.13")
//                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//            modelBuilder.Entity("BlogTask.Models.Blog", b =>
//                {
//                    b.Property<int>("BlogId")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("Description")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Name")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("BlogId");

//                    b.ToTable("Blogs");
//                });

//            modelBuilder.Entity("BlogTask.Models.Post", b =>
//                {
//                    b.Property<int>("PostID")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<int>("BlogID")
//                        .HasColumnType("int");

//                    b.Property<DateTime>("Date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("Description")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Title")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("PostID");

//                    b.HasIndex("BlogID");

//                    b.ToTable("Posts");
//                });

//            modelBuilder.Entity("BlogTask.Models.Post", b =>
//                {
//                    b.HasOne("BlogTask.Models.Blog", "Blog")
//                        .WithMany("Posts")
//                        .HasForeignKey("BlogID")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.Navigation("Blog");
//                });

//            modelBuilder.Entity("BlogTask.Models.Blog", b =>
//                {
//                    b.Navigation("Posts");
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}
