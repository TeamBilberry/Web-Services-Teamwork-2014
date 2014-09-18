namespace FeedbackSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Contracts;
    using Models;

    public class FeedbackSystemData : IFeedbackSystemData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public FeedbackSystemData()
            : this(new FeedbackSystemDbContext())
        {
        }

        public FeedbackSystemData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Feedback> Feedbacks
        {
            get { return this.GetRepository<Feedback>(); }
        }

        public IRepository<UrgentProblem> UrgentProblems
        {
            get { return this.GetRepository<UrgentProblem>(); }
        }

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
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(IRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}