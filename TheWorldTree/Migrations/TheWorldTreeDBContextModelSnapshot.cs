﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheWorldTree.Data;

namespace TheWorldTree.Migrations
{
    [DbContext(typeof(TheWorldTreeDBContext))]
    partial class TheWorldTreeDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheWorldTree.Models.TreeAlbumFolder", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Classify")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creater")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Describe")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("FlName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UpdateOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("TreeAlbumFolder");
                });

            modelBuilder.Entity("TheWorldTree.Models.TreeCatalos", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creater")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Enable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iconic")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("IsLast")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int?>("Sort")
                        .HasColumnType("int");

                    b.Property<string>("UpdateOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("TreeCatalos");
                });

            modelBuilder.Entity("TheWorldTree.Models.TreeDic", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creater")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DicCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node1Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node2Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node3Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node4Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node5Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node6Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node7Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node8Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NodeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("TreeDic");
                });

            modelBuilder.Entity("TheWorldTree.Models.TreeFileInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ContentID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Content_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creater")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Expanded_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FileFullName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("FileLength")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileRelPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FileSize")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Thum_file")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("TreeFileInfo");
                });

            modelBuilder.Entity("TheWorldTree.Models.TreeFileSuffixType", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Content_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creater")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Expanded_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UpdateOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("TreeFileSuffixType");
                });

            modelBuilder.Entity("TheWorldTree.Models.TreeIPInfo", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("IPAccessTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAdd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TreeIPInfo");
                });

            modelBuilder.Entity("TheWorldTree.Models.TreeMsgBoard", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creater")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MsgContent")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("UpdateOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserIP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TreeMsgBoard");
                });

            modelBuilder.Entity("TheWorldTree.Models.TreePress", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creater")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Issue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UpdateOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("TreePress");
                });
#pragma warning restore 612, 618
        }
    }
}
