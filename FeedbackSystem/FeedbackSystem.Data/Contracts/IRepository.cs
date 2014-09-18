namespace FeedbackSystem.Data.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Search(Expression<Func<T, bool>> condition);

        T Find(int id);

        void Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        int SaveChanges();
    }
}