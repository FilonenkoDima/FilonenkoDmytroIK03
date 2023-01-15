using AutoMapper;
using Lab3.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Configurations;
using Microsoft.IdentityModel.Tokens;

namespace Lab.Swagger.Controllers
{
    public class PerformanceController : Controller
    {
        public IActionResult Index()
        {
            return View(GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        
        public IActionResult Find()
        {
            return View();
        }

        [HttpGet("GetAllPerformance")]
        public IEnumerable<PerformanceModel> GetAll()
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDTO, PerformanceModel>()));
            return Mapper.Map<IEnumerable<PerformanceDTO>, List<PerformanceModel>>(Configurations.Config.performanceBLL.GetAllPerformance());
        }


        public IActionResult GetPerformanceById(PerformanceModel model)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDTO, PerformanceModel>()));

            if (model.Id != 0)
            {
                var performance = Config.performanceBLL.GetPerformanceById(model.Id);
                if (performance == null)
                    return NotFound();
                return View(new List<PerformanceModel> { Mapper.Map<PerformanceDTO, PerformanceModel>(performance) });
            }
            else if (!string.IsNullOrEmpty(model.Author))
            {
                var performance = Config.performanceBLL.GetPerformanceByAuthor(model.Author);
                if (performance.IsNullOrEmpty())
                    return NotFound();
                return View(Mapper.Map<IEnumerable<PerformanceDTO>, List<PerformanceModel>>(performance));
            }
            else if (!string.IsNullOrEmpty(model.Name))
            {
                var performance = Config.performanceBLL.GetPerformanceByName(model.Name);
                if (performance.IsNullOrEmpty())
                    return NotFound();
                return View(Mapper.Map<IEnumerable<PerformanceDTO>, List<PerformanceModel>>(performance));
            }
            else if (!string.IsNullOrEmpty(model.Genre))
            {
                var performance = Config.performanceBLL.GetPerformanceByGenre(model.Genre);
                if (performance.IsNullOrEmpty())
                    return NotFound();
                return View(Mapper.Map<IEnumerable<PerformanceDTO>, List<PerformanceModel>>(performance));
            }
            else if(model.Date != null)
            {
                var performance = Config.performanceBLL.GetPerformanceByDate(model.Date);
                if (performance.IsNullOrEmpty())
                    return NotFound();
                return Ok(Mapper.Map<IEnumerable<PerformanceDTO>, List<PerformanceModel>>(performance));
            }
            return View();
          
        }

        [HttpGet("GetPerformanceByAuthor")]
        public IActionResult GetPerformanceByAuthor(string author)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDTO, PerformanceModel>()));
            var performance = Config.performanceBLL.GetPerformanceByAuthor(author);
            if (performance.IsNullOrEmpty())
                return NotFound();
            return Ok(Mapper.Map<IEnumerable<PerformanceDTO>, List<PerformanceModel>>(performance));
        }

        [HttpGet("GetPerformanceByName")]
        public IActionResult GetPerformanceByName(string name)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDTO, PerformanceModel>()));
            var performance = Config.performanceBLL.GetPerformanceByName(name);
            if (performance.IsNullOrEmpty())
                return NotFound();
            return Ok(Mapper.Map<IEnumerable<PerformanceDTO>, List<PerformanceModel>>(performance));
        }

        [HttpGet("GetPerformanceByGenre")]
        public IActionResult GetPerformanceByGenre(string genre)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDTO, PerformanceModel>()));
            var performance = Config.performanceBLL.GetPerformanceByGenre(genre);
            if (performance.IsNullOrEmpty())
                return NotFound();
            return Ok(Mapper.Map<IEnumerable<PerformanceDTO>, List<PerformanceModel>>(performance));
        }

        [HttpGet("GetPerformanceByDate")]
        public IActionResult GetPerformanceByDate(DateTime date)
        {
            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDTO, PerformanceModel>()));
            var performance = Config.performanceBLL.GetPerformanceByDate(date);
            if (performance.IsNullOrEmpty())
                return NotFound();
            return Ok(Mapper.Map<IEnumerable<PerformanceDTO>, List<PerformanceModel>>(performance));
        }

        [HttpPost("Performance/DeletePerformance")]
        public IActionResult DeleteMethod(int id) 
        {
            Config.performanceBLL.DeletePerformance(id);
            return RedirectToAction("Index", "Performance");
        }


        [HttpPost("Performance/AddPerformance")]
        public IActionResult AddPerformance(PerformanceModel performance)
        {

            var Mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PerformanceModel, PerformanceDTO>()));
            Config.performanceBLL.AddNewPerformance(Mapper.Map<PerformanceModel, PerformanceDTO>(performance));
            return RedirectToAction("Index", "Performance");
        }

        [HttpPut]
        public IActionResult Put(PerformanceModel performance)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var storedPerformance = Config.performanceBLL.GetPerformanceById(performance.Id);
            if(storedPerformance == null)
                return NotFound();
            storedPerformance.Author = performance.Author;
            storedPerformance.Name = performance.Name;
            storedPerformance.Genre = performance.Genre;
            storedPerformance.Date = performance.Date;
            return Ok(storedPerformance);
        }
    }
}
