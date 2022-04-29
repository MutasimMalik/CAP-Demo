using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace CapDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ICapPublisher _capPublisher;
        private readonly AppDbContext _appDbContext;

        public DemoController(ICapPublisher capPublisher, AppDbContext appDbContext)
        {
            _capPublisher = capPublisher;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using (var trans = _appDbContext.Database.BeginTransaction(_capPublisher, autoCommit: true))
            {
                await _capPublisher.PublishAsync("DemoMessage", DateTime.Now);
                await trans.CommitAsync();
            }
            return Ok();
        }
    }
}
