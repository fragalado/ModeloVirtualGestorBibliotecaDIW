﻿using DAL;
using Microsoft.AspNetCore.Mvc;
using ModeloVirtualDIW.Models;
using System.Diagnostics;

namespace ModeloVirtualDIW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto contexto;

        public HomeController(Contexto contexto)
        {
            Usuario usu = new Usuario();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}