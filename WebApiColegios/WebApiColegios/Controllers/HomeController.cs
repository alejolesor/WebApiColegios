using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiColegios.Models;

namespace WebApiColegios.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult Sigin(Usuario User)
        {
            try
            {
                using (DrogadiccionEntities context = new DrogadiccionEntities())
                {
                    var user = context.Usuario.Where(x => x.email == User.email);

                    return Redirect("Home/Index");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
