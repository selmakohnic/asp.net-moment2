using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moment2.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace moment2.Controllers
{
    public class HomeController : Controller
    {
        //Startsidan
        public IActionResult Index()
        {
            //Skickar data från controllern till vyn med ViewData och ViewBag
            ViewData["Title"] = "Välkommen till min reselogg!";
            ViewBag.subheading = "På den här webbplatsen lägger jag till alla mina resor.";
            
            //Sessionsvariabel från Index till About
            string messageSession = "Efter regn kommer solsken ☀";
            HttpContext.Session.SetString("messagesession", messageSession);

            return View();
        }

        //Ny resa-sidan
        [HttpGet]
        [Route("/nyresa")]    //Ny route
        public IActionResult NewTravel()
        {
            return View();
        }

        //Ny resa tillagd-sidan
        [HttpPost]
        [Route("/nyresatillagd")]   //Ny route
        public IActionResult TravelDone(Travel model, IFormCollection col)
        {
            //Kontrollerar om inmatningsfälten är korrekt ifyllda
            if (ModelState.IsValid)
            {
                //Hämtar data från inmatningsfälten
                Travel t = new Travel();
                t.Country = col["Country"];
                t.City = col["City"];
                t.Description = col["Description"];
                t.Date = Convert.ToDateTime(col["Date"]);
                t.CostOfFlight = Convert.ToDouble(col["CostOfFlight"]);
                t.CostOfHotel = Convert.ToDouble(col["CostOfHotel"]);

                //Om checkboxen inte är checkad får TravelAlone false, annars true
                if (col["TravelAlone"] == "false")
                {
                    t.TravelAlone = false;
                }
                else
                {
                    t.TravelAlone = true;
                }

                t.CalcCost();   //Anropar metoden för att räkna ut den totala kostnaden

                //Sessionsvariabel
                string travelSession = JsonConvert.SerializeObject(t);
                HttpContext.Session.SetString("travelsession", travelSession);

                return View(t);
            }
            return View("NewTravel");
        }

        //Om-sidan
        [Route("/om")]  //Ny route
        public IActionResult About()
        {
            //Sessionsvariabel från Index till About
            string messageSession = HttpContext.Session.GetString("messagesession");
            ViewBag.text = messageSession;

            //Skapar lista med reseattributen
            List<TravelAttributes> travellist = new List<TravelAttributes>
            {               
                new TravelAttributes(1, "Land"),
                new TravelAttributes(2, "Stad"),
                new TravelAttributes(3, "Resedatum"),
                new TravelAttributes(4, "Kostnad flyg"),
                new TravelAttributes(5, "Kostnad hotell"),
                new TravelAttributes(6, "Total kostnad"),
                new TravelAttributes(7, "Enskild resa")
            };

            ViewModeln vm = new ViewModeln
            {
                TravelAttributesList = travellist
            };

            //Returnerar direkt i anropet till vyn
            return View(vm);
        }
    }
}