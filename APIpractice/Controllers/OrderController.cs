using Microsoft.AspNetCore.Mvc;

namespace APIpractice.Controllers {
    public class OrderController: Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
