namespace FeedbackSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
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

        //[Authorize(Roles = "User")]
        [HttpGet]
        public IHttpActionResult All()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = User.Identity.GetUserId();

            var feedbacks = this.Data.Feedbacks.All()
                                            .Where(f=>f.UserId == userId)
                                            .Select(FeedbackDataModel.FromDataToModel);

            return Ok(feedbacks);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IHttpActionResult All(string password)
        {
            if (password != "qwerty")
            {
                return BadRequest("Wrong password");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var feedbacks = this.Data.Feedbacks.All().Select(FeedbackDataModel.FromDataToModel).ToArray();

            return Ok(feedbacks);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var feedback = this.Data.Feedbacks.Find(id);

            if (feedback == null)
            {
                return NotFound();
            }

            var model = new FeedbackDataModel(feedback);

            return Ok(feedback);
        }

        [HttpPost]
        public IHttpActionResult Create(FeedbackDataModel model)
        {
            model.UserId = User.Identity.GetUserId();

            var feedback = new Feedback
            {
                AddressedTo = model.AddressedTo,
                Comments = model.Comments.AsQueryable().Select(CommentDataModel.FromModelToData).ToList(),
                PostDate = model.PostDate,
                Text = model.Text,
                UserId = User.Identity.GetUserId(),
                Type = model.Type
            };

            this.Data.Feedbacks.Add(feedback);
            this.Data.SaveChanges();

            var addedModel = new FeedbackDataModel(feedback);
            return Ok(addedModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, FeedbackDataModel model)
        {

            var feedback = this.Data.Feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }

            feedback.PostDate = model.PostDate;
            feedback.Text = model.Text;
            feedback.Type = model.Type;
            feedback.AddressedTo = model.AddressedTo;

            this.Data.SaveChanges();

            model.Id = feedback.Id;
            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var feedback = this.Data.Feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }

            this.Data.Feedbacks.Delete(feedback);
            this.Data.SaveChanges();

            return Ok();
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
                Text = "I am just testing this",
            };

            this.Data.Feedbacks.Add(feedback);
            int count = this.Data.SaveChanges();

            return Ok(string.Format("{0} new record(s) added", count));
        }
    }
}