using CaptchaMvc.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsoDeCaptcha.Models;

namespace UsoDeCaptcha.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult EjemploCaptcha() {
            Cuenta cuenta = new Cuenta();
            return View("EjemploCaptcha", cuenta);
        }
        [HttpPost]
        public ActionResult Registro(Cuenta cu) {
            
            if (!this.IsCaptchaValid(""))   //Primero verificamos si el captcha es correcto
            {
                ViewBag.error = "Captcha invalido";
                return View("EjemploCaptcha", cu);//retornamos el objeto Cuenta (cu) para mostrar el formulario con todos los datos
            }
            if (!ModelState.IsValid)    //Luego verificamos si el modelo es correcto
                return View("EjemploCaptcha", cu);
            ViewBag.cuenta = cu;
            return View("Success");     //Si todo es correcto retornamos la vista successs

        }
    }
}