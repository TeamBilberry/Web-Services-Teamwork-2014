namespace FeedbackSystem.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IFeedbackSystemDbContext : IDbContext
    {
        IDbSet<Comment> Comments { get; set; }

        IDbSet<Feedback> Feedbacks { get; set; }

        IDbSet<UrgentProblem> UrgentProblems { get; set; }

//        IDbSet<User> Users { get; set; }
    }
}