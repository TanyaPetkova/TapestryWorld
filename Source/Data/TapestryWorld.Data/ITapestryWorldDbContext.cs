namespace TapestryWorld.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using TapestryWorld.Data.Models;

    public interface ITapestryWorldDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Dimension> Dimensions { get; set; }

        IDbSet<StitchedTapestry> StitchedTapestries { get; set; }

        IDbSet<Tapestry> Tapestries { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Vote> Votes { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntyty> Entry<TEntyty>(TEntyty entyty) where TEntyty : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
