namespace FeedbackSystem.Web.Controllers
{
    using System.Web.Http;
    using Data.Contracts;

//    [Authorize]
    public abstract class BaseApiController : ApiController
    {
        protected IFeedbackSystemData Data;

        protected BaseApiController(IFeedbackSystemData data)
        {
            this.Data = data;
        }
    }
}