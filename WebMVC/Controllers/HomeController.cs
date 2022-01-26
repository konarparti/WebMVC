using Microsoft.AspNetCore.Mvc;
using WebMVC.Domain;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;
        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
        }

        public IActionResult Contacts()
        {
            return View(_dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }
    }
}
