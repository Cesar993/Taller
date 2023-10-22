using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Taller.Models;

namespace Taller.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("procesa/inicio")]
    public IActionResult IniciarSesion(string nombreUsuario)
    {
        HttpContext.Session.SetString("Nombre", nombreUsuario);
       
        HttpContext.Session.SetInt32("NumeroDash", 22);       
        return RedirectToAction("Dashboard");
    }
    [HttpPost]
    [Route("procesa/salida")]
    public IActionResult IniciarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost]
    [Route("sumarUno")]
    public IActionResult SumarUno()
    {
        int? numeroSumar = HttpContext.Session.GetInt32("NumeroDash");
        
        numeroSumar +=1;
        HttpContext.Session.SetInt32("NumeroDash", numeroSumar.Value);
        Console.WriteLine(numeroSumar);
        return RedirectToAction("Dashboard");
    }
    [HttpPost]
    [Route("restarUno")]
    public IActionResult RestarUno()
    {
        int? numeroResta = HttpContext.Session.GetInt32("NumeroDash");
        
        numeroResta -=1;
        HttpContext.Session.SetInt32("NumeroDash", numeroResta.Value);

        return RedirectToAction("Dashboard");
    }
    [HttpPost]
    [Route("multi")]
    public IActionResult Multi()
    {
        int? numero = HttpContext.Session.GetInt32("NumeroDash");
        
        numero = numero*2;
        HttpContext.Session.SetInt32("NumeroDash", numero.Value);

        return RedirectToAction("Dashboard");
    }
    [HttpPost]
    [Route("random")]
    public IActionResult Random()
    {
        int? numero = HttpContext.Session.GetInt32("NumeroDash");
        Random ran = new Random();

        int numerAlAzar = ran.Next(1,11);
        numero = numero+numerAlAzar;
        HttpContext.Session.SetInt32("NumeroDash", numero.Value);

        return RedirectToAction("Dashboard");
    }

    public IActionResult Privacy()
    {   
        return View("Privacy");
        
    }


    public IActionResult Dashboard()
    {   

   
        return View("Dashboard");
    
   
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
