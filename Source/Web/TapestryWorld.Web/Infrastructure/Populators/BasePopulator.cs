namespace TapestryWorld.Web.Infrastructure.Populators
{
    using TapestryWorld.Data;

    public class BasePopulator
    {
        private ITapestryWorldData data;
        private ICacheService cache;

        public BasePopulator(ITapestryWorldData data, ICacheService cache)
        {
            this.data = data;
            this.cache = cache;
        }
    }
}