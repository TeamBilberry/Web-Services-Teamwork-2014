namespace FeedbackSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Contracts;

    public class EfRepository<T> : IRepository<T> where T : class
    {
        private FeedbackSystemDbContext context;
        private IDbSet<T> set;

        public EfRepository()
            : this(new FeedbackSystemDbContext())
        {
        }

        public EfRepository(FeedbackSystemDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> condition)
        {
            return this.All().Where(condition);
        }

        public T Find(int id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(int id)
        {
            var entity = this.Find(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public T Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
            return entity;
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}