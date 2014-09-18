namespace FeedbackSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;
    using Models.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<FeedbackSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FeedbackSystemDbContext context)
        {
           /* var user = new User
            {
                Email = "telerik@telerik.com",
                PasswordHash = "qwerty",
                UserName = "telerik@telerik.com"
            };

            var feedback = new Feedback
            {
                AddressedTo = "John Snow",
                PostDate = DateTime.Now,
                Text = "Good job!",
                Type = FeedbackType.Praise,
                User = user
            };

            context.Feedbacks.Add(feedback);
            context.SaveChanges();*/
        }
    }
}
