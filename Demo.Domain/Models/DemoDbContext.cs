﻿using Microsoft.EntityFrameworkCore;

namespace Demo.Domain.Models
{
    public partial class DemoDbContext : DbContext
    {
        public const string DEV_CONN_STRING = "Data Source=mobyus-c0110129.database.windows.net;Initial Catalog=Demo;User ID=c0110129;Password=3435tXm7QSnx;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string _connString = null;

        public DemoDbContext()
        {
        }

        public DemoDbContext(string connString)
        {
            _connString = connString;
        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Parent> ParentSet { get; set; }
        public virtual DbSet<Child> ChildSet { get; set; }
        public virtual DbSet<AutoGeneratedKey> AutoGeneratedKeySet { get; set; }
        public virtual DbSet<NoAutoGeneratedKey> NoAutoGeneratedKeySet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (string.IsNullOrWhiteSpace(_connString))
                {
                    _connString = DEV_CONN_STRING;
                }
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent", "Relations");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.ToTable("Child", "Relations");

                entity.HasOne(d => d.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(d => d.ParentID)
                .HasConstraintName("FK_B_A");
            });

            modelBuilder.Entity<AutoGeneratedKey>(entity =>
            {
                entity.ToTable("AutoGeneratedKey", "Keys");
                // 'By convention' zal een key column van het type int of Guid als 'Identity' column aanzien worden.
                // Er zullen dus automatisch nummers worden toegekend.
            });
            modelBuilder.Entity<NoAutoGeneratedKey>(entity =>
            {
                entity.ToTable("NoAutoGeneratedKey", "Keys");
                // Dit zorgt ervoor dat de database geen nummer toekent.
                // Hier breken we dus met de 'conventie'.
                entity.Property(e => e.Id)
                    .ValueGeneratedNever(); 
            });
        }
    }
}