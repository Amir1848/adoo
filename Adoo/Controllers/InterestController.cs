using Adoo.Base;
using Adoo.Models;
using Adoo.Services;
using Adoo.ViewModels;

namespace Adoo.Controllers
{
    public class InterestController : BaseController<Interest, InterestViewModel, InterestService>
    {
        public InterestController(InterestService service): base(service)
        {

        }
    }
}
