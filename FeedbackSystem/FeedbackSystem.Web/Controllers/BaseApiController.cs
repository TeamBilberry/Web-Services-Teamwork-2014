namespace FeedbackSystem.Web.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Data.Contracts;

//    [Authorize]
    [EnableCors("*", "*", "*")]
    public abstract class BaseApiController : ApiController
    {
        protected IFeedbackSystemData Data;

        protected BaseApiController(IFeedbackSystemData data)
        {
            this.Data = data;
        }
    }
}