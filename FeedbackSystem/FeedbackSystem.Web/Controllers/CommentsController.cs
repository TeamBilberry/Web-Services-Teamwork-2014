﻿namespace FeedbackSystem.Web.Controllers
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

    }
}
