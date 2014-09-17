namespace FeedbackSystem.Web.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using FeedbackSystem.Models;

    public class CommentDataModel // : IDataModel<Comment, CommentDataModel>
    {
        public static Func<Comment, CommentDataModel> FromDataToModel
        {
            get
            {
                return c => new CommentDataModel
                {
                    Id = c.Id,
                    PostDate = c.PostDate,
                    Text = c.Text,
                    UserId = c.UserId
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
                    UserId = c.UserId
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
        }

        public int Id { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string Text { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}