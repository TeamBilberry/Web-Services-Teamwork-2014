namespace FeedbackSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Data;
    using Data.Contracts;
    using DataModels;
    using FeedbackSystem.Models;
    using FeedbackSystem.Models.Enums;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class FeedbacksController : BaseApiController
    {
        public FeedbacksController()
           : this (new FeedbackSystemData())
        {
            
        }

        public FeedbacksController(IFeedbackSystemData data)
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

            var feedbacks = this.Data.Feedbacks.All().Select(FeedbackDataModel.FromDataToModel);

            return Ok(feedbacks);
        }


        [HttpPut]
        public IHttpActionResult SeedFakeData(string password)
        {
            if (password != "qwerty")
            {
                return BadRequest();
            }

            var userId = User.Identity.GetUserId();

            var feedback = new Feedback
            {
                UserId = userId,
                Type = FeedbackType.Complaint,
                AddressedTo = "John Smith",
                PostDate = DateTime.Now,
                Text = "I am just testing this"
            };

            this.Data.Feedbacks.Add(feedback);
            int count = this.Data.SaveChanges();

            return Ok(string.Format("{0} new record(s) added", count));
        }
    }
}