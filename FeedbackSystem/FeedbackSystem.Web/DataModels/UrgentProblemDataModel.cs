namespace FeedbackSystem.Web.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using FeedbackSystem.Models;
    using FeedbackSystem.Models.Enums;

    public class UrgentProblemDataModel
    {

        public static Expression<Func<UrgentProblem, UrgentProblemDataModel>> FromDataToModel
        {
            get
            {
                return problem => new UrgentProblemDataModel
                {
                    Id = problem.Id,
                    PostDate = problem.PostDate,
                    EndDate = problem.EndDate,
                    Status = problem.Status,
                    Text = problem.Text,
                    UserId = problem.UserId,
                };
            }
        }

        public UrgentProblemDataModel()
        {

        }

        public UrgentProblemDataModel(UrgentProblem problem)
        {
            this.Id = problem.Id;
            this.PostDate = problem.PostDate;
            this.EndDate = problem.EndDate;
            this.Status = problem.Status;
            this.Text = problem.Text;
            this.UserId = problem.UserId;
        }

        public int Id { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public ProblemStatusType Status { get; set; }

        [Required]
        [MinLength(10)]
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}