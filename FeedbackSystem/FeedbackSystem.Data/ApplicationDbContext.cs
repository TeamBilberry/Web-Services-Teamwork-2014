namespace FeedbackSystem.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class ApplicationDbContext : IdentityDbContext<User>, IFeedbackSystemDbContext
    {
        public ApplicationDbContext()
            : base("AppHarborConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
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