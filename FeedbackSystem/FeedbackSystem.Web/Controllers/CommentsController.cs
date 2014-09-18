namespace FeedbackSystem.Web.Controllers
{
    using FeedbackSystem.Data;
    using FeedbackSystem.Models;
    using FeedbackSystem.Web.DataModels;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class CommentsController : BaseApiController
    {
        public CommentsController()
            : this(new FeedbackSystemData(new FeedbackSystemDbContext()))
        {
        }

        public CommentsController(FeedbackSystemData data)
            : base(data)
        {

        }

        [HttpGet]
        public IHttpActionResult All()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var comments = this.Data.Comments
                                    .All()
                                    .Select(CommentDataModel.FromDataToModel);

            return Ok(comments);
        }

        [HttpGet]
        public IHttpActionResult FeedbackComments(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var comments = this.Data.Comments
                                    .All()
                                    .Where(c => c.FeedbackId == id)
                                    .Select(CommentDataModel.FromDataToModel);

            return Ok(comments);
        }

        [HttpDelete]
        public IHttpActionResult DeletComment(int id)
        {
            var existingComment = this.Data.Comments
                                        .All()
                                        .FirstOrDefault(a => a.Id == id);

            if (existingComment == null)
            {
                return BadRequest("Comment does not exists!");
            }

            this.Data.Comments.Delete(existingComment);
            this.Data.SaveChanges();

            return Ok(existingComment);
        }

        [HttpPost]
        public IHttpActionResult CreateComment(int feedbackId, CommentDataModel comment)
        {
            var feedBack = this.Data.Feedbacks
                                    .All()
                                    .FirstOrDefault(f => f.Id == feedbackId);

            if (feedBack == null)
            {
                return BadRequest("Feedback does not exist!");
            }

            var userId = User.Identity.GetUserId();

            var newComment = new Comment
            {
                UserId = userId,
                FeedbackId = feedbackId,
                PostDate = comment.PostDate,
                Text = comment.Text
            };

            feedBack.Comments.Add(newComment);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}
