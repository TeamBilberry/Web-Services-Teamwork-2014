namespace FeedbackSystem.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IFeedbackSystemDbContext
    {
        IDbSet<Comment> Comments { get; set; }

        IDbSet<Feedback> Feedbacks { get; set; }

        IDbSet<UrgentProblem> UrgentProblems { get; set; }

//        IDbSet<User> Users { get; set; }

        int SaveChanges();
    }
}