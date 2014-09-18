namespace FeedbackSystem.Web.Controllers
{
    using FeedbackSystem.Data;
    using FeedbackSystem.Web.DataModels;
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
    }
}
