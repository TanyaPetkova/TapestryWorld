namespace TapestryWorld.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using TapestryWorld.Data.Common.Models;
    using TapestryWorld.Data.Migrations;
    using TapestryWorld.Data.Models;

    public class TapestryWorldDbContext : IdentityDbContext<User>, ITapestryWorldDbContext
    {
        public TapestryWorldDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TapestryWorldDbContext, Configuration>());
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Tapestry> Tapestries { get; set; }

        public virtual IDbSet<StitchedTapestry> StitchedTapestries { get; set; }

        public virtual IDbSet<Dimension> Dimensions { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public static TapestryWorldDbContext Create()
        {
            return new TapestryWorldDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
