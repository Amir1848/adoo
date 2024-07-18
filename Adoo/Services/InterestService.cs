using Adoo.Base;
using Adoo.Context;
using Adoo.Models;
using Adoo.ViewModels;

namespace Adoo.Services
{
    public class InterestService : BusinessBase<Interest, InterestViewModel>
    {
        public InterestService(ApplicationDBContext context) : base(context)
        {

        }
        public override InterestViewModel FetchByID(long id)
        {
            var dbModel = FetchEntityByID(id);

            return new InterestViewModel
            {
                Description = dbModel.Description,
                ID = id,
                Link = dbModel.Link,
                Title = dbModel.Title,
            };
        }
    }
}
