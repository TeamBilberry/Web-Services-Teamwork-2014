namespace FeedbackSystem.Web.Controllers
{
    using Data;
    using Data.Contracts;

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
    }
}