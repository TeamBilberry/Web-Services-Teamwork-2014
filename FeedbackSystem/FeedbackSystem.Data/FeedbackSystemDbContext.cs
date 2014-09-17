namespace FeedbackSystem.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class FeedbackSystemDbContext : IdentityDbContext<User>, IFeedbackSystemDbContext
    {
        public FeedbackSystemDbContext()
            : base("FeedbackSystem", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FeedbackSystemDbContext, Configuration>());
        }

        public static FeedbackSystemDbContext Create()
        {
            return new FeedbackSystemDbContext();
        }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Feedback> Feedbacks { get; set; }

        public IDbSet<UrgentProblem> UrgentProblems { get; set; }


        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}