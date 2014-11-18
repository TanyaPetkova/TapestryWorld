namespace TapestryWorld.Web.Infrastructure.Populators
{
    using TapestryWorld.Data;

    public class CategoryPopulator : BasePopulator
    {
        public CategoryPopulator(ITapestryWorldData data, ICacheService cache)
            : base(data, cache)
        {
        }
    }
}