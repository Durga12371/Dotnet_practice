using Microsoft.AspNetCore.Mvc;
using WebApplication4.Services;
using WebApplication4.Models;
using System.Diagnostics;

namespace WebApplication4.Controllers
{
    public class TrainController : Controller
    {
       // private readonly IConfiguration _configuration;
        private readonly ITrainService _trainService;
        public TrainController(ITrainService trainService)
        {
           // _configuration = configuration;
            _trainService = trainService;
        }

        public IActionResult FindTrains(Input input)
        {
            TrainVM model=new TrainVM();
            model.FindTrains=_trainService.display(input).ToList();
            return View(model);
        }
        public IActionResult Find(Input input)
        {
            TrainVM model = new TrainVM();
            model.Find = _trainService.display(input).ToList();
            return View(model);
        }
        public IActionResult TrainsDetails()
        {
            TrainVM model = new TrainVM();
            model.TrainsDetails = _trainService.Follow().ToList();
            return View(model);
        }

           
       
       public IActionResult Create(Train train)
        {
            TrainVM model= new TrainVM();
            model.TrainsDetails = _trainService.CreateTrains(train).ToList();
            return View(model);
        }
    }
}
