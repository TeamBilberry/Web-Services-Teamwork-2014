namespace FeedbackSystem.Data.Contracts
{
    using System;
    using Models;

    public interface IFeedbackSystemData : IDisposable
    {
        IRepository<Comment> Comments { get; }

        IRepository<Feedback> Feedbacks { get; }

        IRepository<UrgentProblem> UrgentProblems { get; }

//        IRepository<User> Users { get; }

        int SaveChanges();
    }
}