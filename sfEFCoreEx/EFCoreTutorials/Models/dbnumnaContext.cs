using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCoreTutorials.Models
{
    public partial class dbnumnaContext : DbContext
    {
        public dbnumnaContext()
        {
        }

        public dbnumnaContext(DbContextOptions<dbnumnaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DartCorpcode> DartCorpcodes { get; set; }
        public virtual DbSet<DartCorpcode2> DartCorpcode2s { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }
        public virtual DbSet<HashTag> HashTags { get; set; }
        public virtual DbSet<Iposchedule> Iposchedules { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<RawDatum> RawData { get; set; }
        public virtual DbSet<TodoItem> TodoItems { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<TourCrawlingDatum> TourCrawlingData { get; set; }
        public virtual DbSet<TourKeyword> TourKeywords { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WiseSaying> WiseSayings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=db.fseason.info;Database=dbnumna;user=numna;password=0811lee0811lee");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("author");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedAt1).HasColumnName("createdAt");

                entity.Property(e => e.ImagePath).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt1).HasColumnName("updatedAt");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CateDesc)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CateName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            });

            modelBuilder.Entity<DartCorpcode>(entity =>
            {
                entity.HasKey(e => e.CorpCode)
                    .HasName("PRIMARY");

                entity.ToTable("dart_corpcode");

                entity.Property(e => e.CorpCode)
                    .HasMaxLength(10)
                    .HasColumnName("corp_code");

                entity.Property(e => e.CorpName)
                    .HasMaxLength(150)
                    .HasColumnName("corp_name");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("date")
                    .HasColumnName("modify_date");

                entity.Property(e => e.StockCode)
                    .HasMaxLength(10)
                    .HasColumnName("stock_code");
            });

            modelBuilder.Entity<DartCorpcode2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dart_corpcode2");

                entity.Property(e => e.CorpCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("corp_code");

                entity.Property(e => e.CorpName)
                    .HasMaxLength(150)
                    .HasColumnName("corp_name");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("date")
                    .HasColumnName("modify_date");

                entity.Property(e => e.StockCode)
                    .HasMaxLength(10)
                    .HasColumnName("stock_code");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<HashTag>(entity =>
            {
                entity.HasKey(e => new { e.Htname, e.TodoId })
                    .HasName("PRIMARY");

                entity.Property(e => e.Htname)
                    .HasMaxLength(150)
                    .HasColumnName("HTName");

                entity.Property(e => e.TodoId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            });

            modelBuilder.Entity<Iposchedule>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("IPOSchedule");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.LowPrice)
                    .HasColumnType("decimal(10,0)")
                    .HasColumnName("lowPrice");

                entity.Property(e => e.Price).HasColumnType("decimal(10,0)");

                entity.Property(e => e.RegDate).HasColumnType("date");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("projects");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("client");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Service)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("service");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<RawDatum>(entity =>
            {
                entity.HasKey(e => e.RawId)
                    .HasName("PRIMARY");

                entity.Property(e => e.RawId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("createdAt");

                entity.Property(e => e.Req)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Result).IsRequired();
            });

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.HasKey(e => e.TodoId)
                    .HasName("PRIMARY");

                entity.ToTable("TodoItem");

                entity.Property(e => e.TodoId).HasColumnType("int(11)");

                entity.Property(e => e.Completed).HasColumnType("int(1)");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.TodoDesc)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.TodoTitle)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.TopicId).HasColumnType("int(11)");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CateId).HasColumnType("int(11)");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            });

            modelBuilder.Entity<TourCrawlingDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tour_crawlingData");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("area");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("contents");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Keyword)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("keyword");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10,0)")
                    .HasColumnName("price");

                entity.Property(e => e.Title)
                    .HasColumnType("int(11)")
                    .HasColumnName("title");
            });

            modelBuilder.Entity<TourKeyword>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tour_keyword");

                entity.HasIndex(e => e.Searchword, "searchword");

                entity.Property(e => e.Searchword)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("searchword");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Sns)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("sns");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("token");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            });

            modelBuilder.Entity<WiseSaying>(entity =>
            {
                entity.HasKey(e => e.Wsid)
                    .HasName("PRIMARY");

                entity.ToTable("WiseSaying");

                entity.Property(e => e.Wsid)
                    .HasColumnType("int(11)")
                    .HasColumnName("WSId");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.UpdateTime).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.Wscontent)
                    .IsRequired()
                    .HasColumnName("WSContent");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
