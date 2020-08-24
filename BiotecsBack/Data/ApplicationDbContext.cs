using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BiotecsBack.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductPhoto> ProductPhotos { get; set; }

        public DbSet<Group> Categories { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticlePhoto> ArticlePhotos { get; set; }

        public DbSet<ActiveSubstance> ActiveSubstances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Group>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Article>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<ActiveSubstance>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Seed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified || e.State == EntityState.Deleted));


            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        ((AuditableEntity)entityEntry.Entity).IsDeleted = true;
                        ((AuditableEntity)entityEntry.Entity).DeletedAt = DateTime.UtcNow;
                        entityEntry.State = EntityState.Modified;
                        break;
                    default:
                        ((AuditableEntity)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
                        break;
                }
            }


            return await base.SaveChangesAsync(cancellationToken);
        }
    }

    public static class DatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, GroupName = "GNameGeo1", GroupNameEng = "GNameEng1", GroupNameRu = "GNameRu1" },
                new Group { Id = 2, GroupName = "GNameGeo2", GroupNameEng = "GNameEng2", GroupNameRu = "GNameRu2" },
                new Group { Id = 3, GroupName = "GNameGeo3", GroupNameEng = "GNameEng3", GroupNameRu = "GNameRu3" },
                new Group { Id = 4, GroupName = "GNameGeo4", GroupNameEng = "GNameEng4", GroupNameRu = "GNameRu4" },
                new Group { Id = 5, GroupName = "GNameGeo5", GroupNameEng = "GNameEng5", GroupNameRu = "GNameRu5" }
            );

            modelBuilder.Entity<ActiveSubstance>().HasData(
                new ActiveSubstance { Id = 1, SubstanceName = "SubstanceNameGeo1", SubstanceNameEng = "SubstanceNameEng1", SubstanceNameRu = "SubstanceNameRu1" },
                new ActiveSubstance { Id = 2, SubstanceName = "SubstanceNameGeo2 ", SubstanceNameEng = "SubstanceNameEng2 ", SubstanceNameRu = "SubstanceNameRu2 " },
                new ActiveSubstance { Id = 3, SubstanceName = "SubstanceNameGeo3 ", SubstanceNameEng = "SubstanceNameEng3 ", SubstanceNameRu = "SubstanceNameRu3 " },
                new ActiveSubstance { Id = 4, SubstanceName = "SubstanceNameGeo4 ", SubstanceNameEng = "SubstanceNameEng4 ", SubstanceNameRu = "SubstanceNameRu4 " },
                new ActiveSubstance { Id = 5, SubstanceName = "SubstanceNameGeo5 ", SubstanceNameEng = "SubstanceNameEng5 ", SubstanceNameRu = "SubstanceNameRu5 " },
                new ActiveSubstance { Id = 6, SubstanceName = "SubstanceNameGeo6 ", SubstanceNameEng = "SubstanceNameEng6 ", SubstanceNameRu = "SubstanceNameRu6 " },
                new ActiveSubstance { Id = 7, SubstanceName = "SubstanceNameGeo7 ", SubstanceNameEng = "SubstanceNameEng7 ", SubstanceNameRu = "SubstanceNameRu7 " },
                new ActiveSubstance { Id = 8, SubstanceName = "SubstanceNameGeo8 ", SubstanceNameEng = "SubstanceNameEng8 ", SubstanceNameRu = "SubstanceNameRu8 " },
                new ActiveSubstance { Id = 9, SubstanceName = "SubstanceNameGeo9 ", SubstanceNameEng = "SubstanceNameEng9 ", SubstanceNameRu = "SubstanceNameRu9 " },
                new ActiveSubstance { Id = 10, SubstanceName = "SubstanceNameGeo10 ", SubstanceNameEng = "SubstanceNameEng10 ", SubstanceNameRu = "SubstanceNameRu10 " }


            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ProductName = "ProductNameGeo1", ProductNameEng = "ProductNameEng1", ProductNameRu = "ProductNameRu1", GroupId = 1, ActiveSubstanceId = 1, Description = "DescriptionGeo1", DescriptionEng = "DescriptionEng1", DescriptionRu = "DescriptionRu1" },
                new Product { Id = 2, ProductName = "ProductNameGeo2", ProductNameEng = "ProductNameEng2", ProductNameRu = "ProductNameRu2", GroupId = 2, ActiveSubstanceId = 1, Description = "DescriptionGeo2", DescriptionEng = "DescriptionEng2", DescriptionRu = "DescriptionRu2" },
                new Product { Id = 3, ProductName = "ProductNameGeo3", ProductNameEng = "ProductNameEng3", ProductNameRu = "ProductNameRu3", GroupId = 5, ActiveSubstanceId = 2, Description = "DescriptionGeo3", DescriptionEng = "DescriptionEng3", DescriptionRu = "DescriptionRu3" },
                new Product { Id = 4, ProductName = "ProductNameGeo4", ProductNameEng = "ProductNameEng4", ProductNameRu = "ProductNameRu4", GroupId = 5, ActiveSubstanceId = 4, Description = "DescriptionGeo4", DescriptionEng = "DescriptionEng4", DescriptionRu = "DescriptionRu4" },
                new Product { Id = 5, ProductName = "ProductNameGeo5", ProductNameEng = "ProductNameEng5", ProductNameRu = "ProductNameRu5", GroupId = 2, ActiveSubstanceId = 2, Description = "DescriptionGeo5", DescriptionEng = "DescriptionEng5", DescriptionRu = "DescriptionRu5" },
                new Product { Id = 6, ProductName = "ProductNameGeo6", ProductNameEng = "ProductNameEng6", ProductNameRu = "ProductNameRu6", GroupId = 1, ActiveSubstanceId = 10, Description = "DescriptionGeo6", DescriptionEng = "DescriptionEng6", DescriptionRu = "DescriptionRu6" },
                new Product { Id = 7, ProductName = "ProductNameGeo7", ProductNameEng = "ProductNameEng7", ProductNameRu = "ProductNameRu7", GroupId = 2, ActiveSubstanceId = 3, Description = "DescriptionGeo7", DescriptionEng = "DescriptionEng7", DescriptionRu = "DescriptionRu7" },
                new Product { Id = 8, ProductName = "ProductNameGeo8", ProductNameEng = "ProductNameEng8", ProductNameRu = "ProductNameRu8", GroupId = 2, ActiveSubstanceId = 3, Description = "DescriptionGeo8", DescriptionEng = "DescriptionEng8", DescriptionRu = "DescriptionRu8" },
                new Product { Id = 9, ProductName = "ProductNameGeo9", ProductNameEng = "ProductNameEng9", ProductNameRu = "ProductNameRu9", GroupId = 3, ActiveSubstanceId = 4, Description = "DescriptionGeo9", DescriptionEng = "DescriptionEng9", DescriptionRu = "DescriptionRu9" },
                new Product { Id = 10, ProductName = "ProductNameGeo10", ProductNameEng = "ProductNameEng10", ProductNameRu = "ProductNameRu10", GroupId = 1, ActiveSubstanceId = 1, Description = "DescriptionGeo10", DescriptionEng = "DescriptionEng10", DescriptionRu = "DescriptionRu10" },
                new Product { Id = 11, ProductName = "ProductNameGeo11", ProductNameEng = "ProductNameEng11", ProductNameRu = "ProductNameRu11", GroupId = 2, ActiveSubstanceId = 7, Description = "DescriptionGeo11", DescriptionEng = "DescriptionEng11", DescriptionRu = "DescriptionRu11" },
                new Product { Id = 12, ProductName = "ProductNameGeo12", ProductNameEng = "ProductNameEng12", ProductNameRu = "ProductNameRu12", GroupId = 2, ActiveSubstanceId = 2, Description = "DescriptionGeo12", DescriptionEng = "DescriptionEng12", DescriptionRu = "DescriptionRu12" },
                new Product { Id = 13, ProductName = "ProductNameGeo13", ProductNameEng = "ProductNameEng13", ProductNameRu = "ProductNameRu13", GroupId = 3, ActiveSubstanceId = 4, Description = "DescriptionGeo13", DescriptionEng = "DescriptionEng13", DescriptionRu = "DescriptionRu13" },
                new Product { Id = 14, ProductName = "ProductNameGeo14", ProductNameEng = "ProductNameEng14", ProductNameRu = "ProductNameRu14", GroupId = 1, ActiveSubstanceId = 6, Description = "DescriptionGeo14", DescriptionEng = "DescriptionEng14", DescriptionRu = "DescriptionRu14" },
                new Product { Id = 15, ProductName = "ProductNameGeo15", ProductNameEng = "ProductNameEng15", ProductNameRu = "ProductNameRu15", GroupId = 1, ActiveSubstanceId = 3, Description = "DescriptionGeo15", DescriptionEng = "DescriptionEng15", DescriptionRu = "DescriptionRu15" },
                new Product { Id = 16, ProductName = "ProductNameGeo16", ProductNameEng = "ProductNameEng16", ProductNameRu = "ProductNameRu16", GroupId = 4, ActiveSubstanceId = 9, Description = "DescriptionGeo16", DescriptionEng = "DescriptionEng16", DescriptionRu = "DescriptionRu16" },
                new Product { Id = 17, ProductName = "ProductNameGeo17", ProductNameEng = "ProductNameEng17", ProductNameRu = "ProductNameRu17", GroupId = 5, ActiveSubstanceId = 7, Description = "DescriptionGeo17", DescriptionEng = "DescriptionEng17", DescriptionRu = "DescriptionRu17" },
                new Product { Id = 18, ProductName = "ProductNameGeo18", ProductNameEng = "ProductNameEng18", ProductNameRu = "ProductNameRu18", GroupId = 5, ActiveSubstanceId = 4, Description = "DescriptionGeo18", DescriptionEng = "DescriptionEng18", DescriptionRu = "DescriptionRu18" },
                new Product { Id = 19, ProductName = "ProductNameGeo19", ProductNameEng = "ProductNameEng19", ProductNameRu = "ProductNameRu19", GroupId = 2, ActiveSubstanceId = 6, Description = "DescriptionGeo19", DescriptionEng = "DescriptionEng19", DescriptionRu = "DescriptionRu19" },
                new Product { Id = 20, ProductName = "ProductNameGeo20", ProductNameEng = "ProductNameEng20", ProductNameRu = "ProductNameRu20", GroupId = 3, ActiveSubstanceId = 4, Description = "DescriptionGeo20", DescriptionEng = "DescriptionEng20", DescriptionRu = "DescriptionRu20" },
                new Product { Id = 21, ProductName = "ProductNameGeo21", ProductNameEng = "ProductNameEng21", ProductNameRu = "ProductNameRu21", GroupId = 4, ActiveSubstanceId = 10, Description = "DescriptionGeo21", DescriptionEng = "DescriptionEng21", DescriptionRu = "DescriptionRu21" },
                new Product { Id = 22, ProductName = "ProductNameGeo22", ProductNameEng = "ProductNameEng22", ProductNameRu = "ProductNameRu22", GroupId = 5, ActiveSubstanceId = 7, Description = "DescriptionGeo22", DescriptionEng = "DescriptionEng22", DescriptionRu = "DescriptionRu22" },
                new Product { Id = 23, ProductName = "ProductNameGeo23", ProductNameEng = "ProductNameEng23", ProductNameRu = "ProductNameRu23", GroupId = 4, ActiveSubstanceId = 5, Description = "DescriptionGeo23", DescriptionEng = "DescriptionEng23", DescriptionRu = "DescriptionRu23" },
                new Product { Id = 24, ProductName = "ProductNameGeo24", ProductNameEng = "ProductNameEng24", ProductNameRu = "ProductNameRu24", GroupId = 5, ActiveSubstanceId = 2, Description = "DescriptionGeo24", DescriptionEng = "DescriptionEng24", DescriptionRu = "DescriptionRu24" },
                new Product { Id = 25, ProductName = "ProductNameGeo25", ProductNameEng = "ProductNameEng25", ProductNameRu = "ProductNameRu25", GroupId = 1, ActiveSubstanceId = 5, Description = "DescriptionGeo25", DescriptionEng = "DescriptionEng25", DescriptionRu = "DescriptionRu25" },
                new Product { Id = 26, ProductName = "ProductNameGeo26", ProductNameEng = "ProductNameEng26", ProductNameRu = "ProductNameRu26", GroupId = 2, ActiveSubstanceId = 2, Description = "DescriptionGeo26", DescriptionEng = "DescriptionEng26", DescriptionRu = "DescriptionRu26" },
                new Product { Id = 27, ProductName = "ProductNameGeo27", ProductNameEng = "ProductNameEng27", ProductNameRu = "ProductNameRu27", GroupId = 3, ActiveSubstanceId = 1, Description = "DescriptionGeo27", DescriptionEng = "DescriptionEng27", DescriptionRu = "DescriptionRu27" },
                new Product { Id = 28, ProductName = "ProductNameGeo28", ProductNameEng = "ProductNameEng28", ProductNameRu = "ProductNameRu28", GroupId = 4, ActiveSubstanceId = 9, Description = "DescriptionGeo28", DescriptionEng = "DescriptionEng28", DescriptionRu = "DescriptionRu28" },
                new Product { Id = 29, ProductName = "ProductNameGeo29", ProductNameEng = "ProductNameEng29", ProductNameRu = "ProductNameRu29", GroupId = 4, ActiveSubstanceId = 3, Description = "DescriptionGeo29", DescriptionEng = "DescriptionEng29", DescriptionRu = "DescriptionRu29" },
                new Product { Id = 30, ProductName = "ProductNameGeo30", ProductNameEng = "ProductNameEng30", ProductNameRu = "ProductNameRu30", GroupId = 4, ActiveSubstanceId = 5, Description = "DescriptionGeo30", DescriptionEng = "DescriptionEng30", DescriptionRu = "DescriptionRu30" }
             );
        }
    }
}
