using Microsoft.AspNetCore.Mvc;

namespace APIpractice.Controllers {
    public class PaymentController: Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
