using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace SoiticTest.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SoiticTestControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}