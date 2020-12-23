using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SystemGlobalServices.Model;
using SystemGlobalServices.Models;

namespace SystemGlobalServices.Controllers
{
    public class СurrenciesController : Controller
    {
        private IndexViewModel IndexViewModel = IndexViewModel.getInstance();
        [Route("currencies")]
        public IActionResult Index(int? page = 1)
        {
            IndexViewModel.FilterData((int)page);
            return View(IndexViewModel);
        }
    }
}
