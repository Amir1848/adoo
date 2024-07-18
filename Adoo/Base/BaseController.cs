using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adoo.Base
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController<TEntity, TViewModel, TService> : ControllerBase
        where TEntity : Entity
        where TViewModel : class, new()
        where TService : BusinessBase<TEntity, TViewModel>
    {
        protected readonly TService _service;
        public BaseController(TService service) : base()
        {
            _service = service;
        }

        [HttpPost]
        public virtual IActionResult Save([FromBody] TEntity entity)
        {
            var res = _service.Create(entity);
            return Ok(res);
        }

        [HttpGet]
        public virtual TViewModel Get(long id)
        {
            return _service.FetchViewModelByID(id);
        }

        [HttpPut]
        public virtual IActionResult Update([FromBody] TEntity entity)
        {
            _service.Update(entity);
            return Ok();
        }

        [HttpDelete]
        public virtual IActionResult Delete(long id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
