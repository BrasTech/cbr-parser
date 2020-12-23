using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SystemGlobalServices.Models;

namespace SystemGlobalServices.Controllers
{
    public class CurrencyController : Controller
    {
        private IndexViewModel IndexViewModel = IndexViewModel.getInstance();

        [Route("currency")]
        public ActionResult Index(string id)
        {
            IndexViewModel.FilterDataById(id);
            return View(IndexViewModel);
        }
    }
}
