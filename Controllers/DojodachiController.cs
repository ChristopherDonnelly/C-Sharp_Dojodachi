using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dojodachi_Project.Models;

namespace Dojodachi_Project.Controllers
{
    public class DojodachiController : Controller
    {

        Dojodachi myDojodachi = new Dojodachi();

	    [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("feed")]
        public JsonResult Feed([FromBody] Dojodachi tempDojodachi)
        {
            int fullness = tempDojodachi.feed();
            string msg = $"You fed your Lil' Devil (Fullness: +{fullness}, Meals: -1)";
            if(fullness <= 0){
                msg = "Your Lil' Devil didn't like the meal that you provided (Meals: -1)";
            }

            var data = new {
                dojodachi = tempDojodachi,
                message = msg
            };

            return Json(data);
        }

        [HttpPost]
        [Route("play")]
        public JsonResult Play([FromBody] Dojodachi tempDojodachi)
        {
            int happiness = tempDojodachi.play();
            string msg = $"Your Lil' Devil enjoyed play time (Happiness: +{happiness}, Energy: -5)";
            if(happiness <= 0){
                msg = "Your Lil' Devil didn't enjoy play time (Energy: -5)";
            }

            var data = new {
                dojodachi = tempDojodachi,
                message = msg
            };

            return Json(data);
        }

        [HttpPost]
        [Route("work")]
        public JsonResult Work([FromBody] Dojodachi tempDojodachi)
        {
            int meals = tempDojodachi.work();
            string msg = $"Your Lil' Devil worked all day (Meals: +{meals}, Energy: -5)";

            var data = new {
                dojodachi = tempDojodachi,
                message = msg
            };

            return Json(data);
        }

        [HttpPost]
        [Route("sleep")]
        public JsonResult Sleep([FromBody] Dojodachi tempDojodachi)
        {
            tempDojodachi.sleep();
            string msg = $"Your Lil' Devil slept all night (Energy: +15, Fullness: -5, Happiness: -5)";

            var data = new {
                dojodachi = tempDojodachi,
                message = msg
            };

            return Json(data);
        }
   }
}