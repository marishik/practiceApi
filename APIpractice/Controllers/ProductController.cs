using Microsoft.AspNetCore.Mvc;

namespace APIpractice.Controllers {
    public class ProductController: Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
