namespace TapestryWorld.Web.Infrastructure.Services.Base
{
    using TapestryWorld.Data;

    public abstract class BaseService
    {
        protected ITapestryWorldData Data { get; private set; }

        public BaseService(ITapestryWorldData data)
        {
            this.Data = data;
        }
    }
}
