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
    public class UrgentProblemsController : BaseApiController
    {
        public UrgentProblemsController(IFeedbackSystemData data)
            : base(data)
        {
        }

        [HttpGet]
//        [Authorize(Roles = "User")]
        public IHttpActionResult AllByUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = User.Identity.GetUserId();

            var problems = this.Data.UrgentProblems.All()
                                .Where(p => p.UserId == userId)
                                .Select(UrgentProblemDataModel.FromDataToModel);

            return Ok(problems);
        }

        [HttpGet]
//        [Authorize(Roles = "Admin")]
        public IHttpActionResult All()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var problems = this.Data.UrgentProblems.All()
                                .Select(UrgentProblemDataModel.FromDataToModel);

            return Ok(problems);
        }


        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var problem = this.Data.UrgentProblems.All()
                    .Where(p=>p.Id == id)
                    .Select(UrgentProblemDataModel.FromDataToModel);

            if (!problem.Any())
            {
                return NotFound();
            }

            return Ok(problem);
        }

        [HttpPost]
        public IHttpActionResult Create(UrgentProblemDataModel model)
        {
            model.UserId = User.Identity.GetUserId();
            model.UserName = User.Identity.GetUserName();

            var problem = new UrgentProblem
            {
                Text = model.Text,
                PostDate = model.PostDate,
                EndDate = model.EndDate,
                UserId = model.UserId,
                Status = model.Status,
            };

            this.Data.UrgentProblems.Add(problem);
            this.Data.SaveChanges();

            model.Id = problem.Id;

            return Ok(model);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, UrgentProblemDataModel model)
        {
            var problem = this.Data.UrgentProblems.Find(id);

            if (problem == null)
            {
                return NotFound();
            }

            problem.Text = model.Text;
            problem.Status = model.Status;
            problem.PostDate = model.PostDate;
            problem.EndDate = model.EndDate;

            this.Data.SaveChanges();
            model.Id = problem.Id;

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var problem = this.Data.UrgentProblems.Find(id);

            if (problem == null)
            {
                return NotFound();
            }

            var model = new UrgentProblemDataModel(problem);

            this.Data.UrgentProblems.Delete(problem);
            this.Data.SaveChanges();

            return Ok(model);
        }
    }
}