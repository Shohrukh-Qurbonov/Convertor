using Convertor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Convertor.Controllers
{
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetValcurs(string date)
        {
            var Valcurs = await getValcurs(date);
            return Json(Valcurs);
        }

        private async Task<ValCurs> getValcurs(string date)
        {
            using var client = new HttpClient();

            var result = await client.GetAsync($"https://nbt.tj/tj/kurs/export_xml.php?date={date}&export=xmlout");

            XmlSerializer formatter = new XmlSerializer(typeof(ValCurs));
            ValCurs valcurs = (ValCurs)formatter.Deserialize(new StringReader(await result.Content.ReadAsStringAsync()));

            return await Task.Run(() => valcurs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
