namespace FeedbackSystem.Web.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using FeedbackSystem.Models;

    public class CommentDataModel
    {
        public static Expression<Func<Comment, CommentDataModel>> FromDataToModel
        {
            get
            {
                return c => new CommentDataModel
                {
                    Id = c.Id,
                    PostDate = c.PostDate,
                    Text = c.Text,
                    UserId = c.UserId,
                    FeedbackId = c.FeedbackId,
                    UserName = c.User.UserName
                };
            }
        }

        public static Func<CommentDataModel, Comment> FromModelToData
        {
            get
            {
                return c => new Comment
                {
                    Id = c.Id,
                    PostDate = c.PostDate,
                    Text = c.Text,
                    UserId = c.UserId,
                };
            }
        }

        public CommentDataModel()
        {

        }
        
        public CommentDataModel(Comment comment)
        {
            this.Id = comment.Id;
            this.PostDate = comment.PostDate;
            this.Text = comment.Text;
            this.UserId = comment.UserId;
//            this.UserName = comment.User.UserName;
            this.FeedbackId = comment.FeedbackId;
        }

        public int Id { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }

        public string UserName { get; set; }
		
		[Required]
		public int FeedbackId { get; set; }
    }
}