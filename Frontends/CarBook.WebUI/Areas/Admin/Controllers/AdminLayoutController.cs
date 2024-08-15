using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminSidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminRemovePartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminCreateOrUpdatePartial()
        {
            return PartialView();
        }

    }
}
