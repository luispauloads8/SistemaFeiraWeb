﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
