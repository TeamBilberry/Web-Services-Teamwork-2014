namespace FeedbackSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;
    using FeedbackSystem.Models;
    using Microsoft.AspNet.Identity;


    [Authorize]
    
    public class CommentsController : BaseApiController
    {
        public CommentsController()
            : this(new FeedbackSystemData())
        {
        }

        public CommentsController(IFeedbackSystemData data)
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

        [HttpPost]
        public IHttpActionResult Add(int feedbackId, CommentDataModel commentModel)
        {
            var feedback = this.Data.Feedbacks.Find(feedbackId);

            if (feedback == null)
            {
                return NotFound();
            }

            var comment = new Comment
            {
                PostDate = commentModel.PostDate,
                Text = commentModel.Text,
                FeedbackId = feedbackId,
                UserId = User.Identity.GetUserId()
            };

            feedback.Comments.Add(comment);
            this.Data.SaveChanges();

            commentModel.Id = comment.Id;
            commentModel.FeedbackId = comment.FeedbackId;
            commentModel.UserId = comment.UserId;

            return Ok(commentModel);
        }

        [HttpDelete]
        public IHttpActionResult Deletе(int id)
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
        public IHttpActionResult Create(int feedbackId, CommentDataModel comment)
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
