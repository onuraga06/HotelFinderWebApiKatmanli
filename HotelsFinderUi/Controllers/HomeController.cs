using HotelsFinderUi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelsFinderUi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Hostel> hList = new List<Hostel>();
            using (var client = new HttpClient())
            {
                var responseTalk = client.GetAsync("https://localhost:44358/api/Hotels");
                responseTalk.Wait();
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)//Http200 Dondurudyse
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var hostelOkunan = readTask.Result;
                    hList = JsonConvert.DeserializeObject<List<Hostel>>(hostelOkunan);

                }

            }
            return View(hList);
        }
        public IActionResult Details(int id)
        {
            Hostel hostel = new Hostel();
            using (var client = new HttpClient())
            {
                var responseTalk = client.GetAsync("https://localhost:44358/api/Hotels" + "/" + id);
                responseTalk.Wait();
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var hostelOkunan = readTask.Result;
                    hostel = JsonConvert.DeserializeObject<Hostel>(hostelOkunan);
                    return View(hostel);
                }

            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44358/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = client.DeleteAsync("Hotels" + "/" + id).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hostel ent)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44358/api/");
            var stringContent = new StringContent(JsonConvert.SerializeObject(ent), Encoding.UTF8, "application/json");
            var result = client.PostAsync("Hotels", stringContent);
            result.Wait();
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Edit(int id)
        {
            Hostel hostel = new Hostel();
            using (var client = new HttpClient())
            {
                var responseTalk = client.GetAsync("https://localhost:44358/api/Hotels" + "/" + id);
                responseTalk.Wait();
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var hostelOkunan = readTask.Result;
                    hostel = JsonConvert.DeserializeObject<Hostel>(hostelOkunan);
                    return View(hostel);
                }

            }
            return View();

        }
        [HttpPost]
        public IActionResult Edit(Hostel ent)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44358/api/");
            var stringContent = new StringContent(JsonConvert.SerializeObject(ent), Encoding.UTF8, "application/json");
            var result = client.PutAsync("Hotels", stringContent);
            result.Wait();
            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
