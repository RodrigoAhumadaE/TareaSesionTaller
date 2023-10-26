using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TareaSesionTaller.Models;

namespace TareaSesionTaller.Controllers;

public class HomeController : Controller{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger){
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index(){
        return View("Index");
    }

    [HttpPost("procesa/usuario")]
    public IActionResult ProcesaUsuario(Usuario usuario){
        if(ModelState.IsValid){
            HttpContext.Session.SetString("Nombre", usuario.Nombre);
            HttpContext.Session.SetInt32("num",22);
            return View("Dashboard");
        }
        return View("Index");
    }

    [HttpPost("dashboard/accion/{id_accion}")]
    public IActionResult DashboardAccion(string id_accion){
        int num = (int)HttpContext.Session.GetInt32("num");       
        if(id_accion == "A"){
            num++;
            HttpContext.Session.SetInt32("num", num);
            return View("Dashboard");
        }else if(id_accion == "B"){
            num--;
            HttpContext.Session.SetInt32("num", num);
            return View("Dashboard");
        }else if(id_accion == "C"){
            num*=2;
            HttpContext.Session.SetInt32("num", num);
            return View("Dashboard");
        }
        Random rand = new Random();
        num+=rand.Next(1,11);
        HttpContext.Session.SetInt32("num", num);
        return View("Dashboard");
    }

    [HttpGet("procesaLogout")]
    public IActionResult ProcesaLogout(){
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
