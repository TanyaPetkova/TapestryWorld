namespace TapestryWorld.Data
{
    using TapestryWorld.Data.Common.Repository;
    using TapestryWorld.Data.Models;

    public interface ITapestryWorldData
    {
        ITapestryWorldDbContext Context { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Dimension> Dimensions { get; }

        IRepository<StitchedTapestry> StitchedTapestries { get; }

        IRepository<Tapestry> Tapestries { get; }

        IRepository<Vote> Votes { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
