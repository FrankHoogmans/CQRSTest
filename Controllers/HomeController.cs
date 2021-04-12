using System.Diagnostics;
using System.Threading.Tasks;
using CQRSTest.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CQRSTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IModelWithMappingFactory _factory;

        public HomeController(ILogger<HomeController> logger, IModelWithMappingFactory factory)
        {
            this._logger = logger;
            this._factory = factory;
        }

        public async Task<IActionResult> Index([FromServices] IMediator mediator)
        {
            var viewModel = await this._factory.Load(new DeviceGetByIdRequest<SimpleDeviceViewModel>(1));

            //var viewModel = await SimpleDeviceViewModel.Load(mediator, 1);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
