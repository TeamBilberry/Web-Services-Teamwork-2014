namespace FeedbackSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;
    using Microsoft.AspNet.Identity;

//    [Authorize]
    public class UrgentProblemsController : BaseApiController
    {
        public UrgentProblemsController()
            : this(new FeedbackSystemData())
        {   
        }

        public UrgentProblemsController(IFeedbackSystemData data)
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

            var userId = User.Identity.GetUserId();

            var problems = this.Data.UrgentProblems.All().Select(UrgentProblemDataModel.FromDataToModel);

            return Ok(problems);
        }
    }
}