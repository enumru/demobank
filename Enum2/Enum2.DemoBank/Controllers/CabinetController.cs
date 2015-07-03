using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using Enum2.DemoBank.Helpers;
using Enum2.DemoBank.Models;

namespace Enum2.DemoBank.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.User = CurrentUser();
            return View();
        }

        private BankClientViewModel CurrentUser()
        {
            var claims = ClaimsPrincipal.Current.Claims.ToList();
            var emailClaim = claims.First(x => x.Type == "email");
            var phoneClaim = claims.First(x => x.Type == "phone");

            var user = new BankClientViewModel()
            {
                Email = emailClaim != null ? emailClaim.Value : null,
                Phone = phoneClaim != null ? phoneClaim.Value.FormatPhone() : null,
            };

            return user;
        }
    }
}