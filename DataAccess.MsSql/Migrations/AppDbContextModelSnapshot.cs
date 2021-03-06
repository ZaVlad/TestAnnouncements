// <auto-generated />
using System;
using DataAccess.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.MsSql.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Announcement");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAdded = new DateTime(2021, 11, 14, 16, 42, 23, 799, DateTimeKind.Local).AddTicks(806),
                            Description = "Some announcement 1",
                            Title = "Best Announcement in the World"
                        },
                        new
                        {
                            Id = 2,
                            DateAdded = new DateTime(2021, 11, 14, 16, 42, 23, 800, DateTimeKind.Local).AddTicks(8022),
                            Description = "Some announcement 2",
                            Title = "Best Announcement in the Universe"
                        },
                        new
                        {
                            Id = 3,
                            DateAdded = new DateTime(2021, 11, 14, 16, 42, 23, 800, DateTimeKind.Local).AddTicks(8045),
                            Description = "Some announcement 3",
                            Title = "Buy new cheap goods!"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
