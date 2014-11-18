namespace TapestryWorld.Data
{
    using System;
    using System.Collections.Generic;

    using TapestryWorld.Data.Common.Models;
    using TapestryWorld.Data.Common.Repository;
    using TapestryWorld.Data.Models;
    using TapestryWorld.Data.Repositories.Base;

    public class TapestryWorldData : ITapestryWorldData
    {
        private readonly ITapestryWorldDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public TapestryWorldData(ITapestryWorldDbContext context)
        {
            this.context = context;
        }

        public ITapestryWorldDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public IRepository<User> Users 
        {
            get 
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public IRepository<Tapestry> Tapestries
        {
            get
            {
                return this.GetRepository<Tapestry>();
            }
        }

        public IRepository<Dimension> Dimensions
        {
            get
            {
                return this.GetRepository<Dimension>();
            }
        }

        public IRepository<StitchedTapestry> StitchedTapestries
        {
            get
            {
                return this.GetRepository<StitchedTapestry>();
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
