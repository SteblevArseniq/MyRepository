using Microsoft.AspNetCore.Mvc;
using NewtonLibrary;

namespace NewtonWeb.Controllers
{
    public class NewtonController : Controller
    {
        public IActionResult Index()
        {
            return View(getResult());
        }

        private Point getResult()
        {
            Equation systemEquation1 = new Equation(-2.6e-15, -0.76, -1.6e-15, 1.6, 16, 2.76e+19, 3.26e-8, -1.6e-23, 6, 17.6);
            Equation systemEquation2 = new Equation(-9.6e-16, -0.6, -4.6e-17, 0.96, 1.6, 2.6e+20, 4.6e-9, -3.6e-23, 1, 1.05);
            return new Point(NewtonMethod.SolvingSystem(systemEquation1, systemEquation2));
        }
    }
}
