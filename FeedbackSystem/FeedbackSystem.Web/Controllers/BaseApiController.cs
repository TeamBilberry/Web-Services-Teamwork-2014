namespace FeedbackSystem.Web.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.Contracts;

//    [Authorize]
    public abstract class BaseApiController : ApiController
    {
        protected IFeedbackSystemData Data;

        protected BaseApiController(FeedbackSystemData data)
        {
            this.Data = data;
        }
    }
}