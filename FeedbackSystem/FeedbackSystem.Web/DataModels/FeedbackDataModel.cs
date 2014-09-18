namespace FeedbackSystem.Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using FeedbackSystem.Models;
    using FeedbackSystem.Models.Enums;

    public class FeedbackDataModel
    {
        public static Expression<Func<Feedback, FeedbackDataModel>> FromDataToModel
        {
            get
            {
                return feedback => new FeedbackDataModel()
                {
                    Id = feedback.Id,
                    Type = feedback.Type,
                    PostDate = feedback.PostDate,
                    Text = feedback.Text,
                    UserId = feedback.UserId,
//                    Comments = feedback.Comments.AsQueryable().Select(CommentDataModel.FromDataToModel).ToArray()
                };
            }
        }


        public FeedbackDataModel()
        {
            this.Comments = new HashSet<CommentDataModel>();
        }

        public FeedbackDataModel(Feedback feedback)
        {
            this.Id = feedback.Id;
            this.Type = feedback.Type;
            this.PostDate = feedback.PostDate;
            this.Text = feedback.Text;
            this.UserId = feedback.UserId;
            this.Comments = feedback.Comments.AsQueryable().Select(c => new CommentDataModel(c));
        }

        public int Id { get; set; }

        [Required]
        public FeedbackType Type { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        [MinLength(10)]
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }

        public string AddressedTo { get; set; }

        public IEnumerable<CommentDataModel> Comments { get; set; }
    }
}