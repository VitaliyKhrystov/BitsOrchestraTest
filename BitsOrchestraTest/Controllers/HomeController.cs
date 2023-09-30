using AutoMapper;
using BitsOrchestraTest.Domain.Entities;
using BitsOrchestraTest.Domain.Repositories.Abstract;
using BitsOrchestraTest.Models;
using BitsOrchestraTest.ViewModel;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BitsOrchestraTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, IPersonRepository personRepository, IMapper mapper)
        {
            this.logger = logger;
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string message)
        {
            ViewBag.Message = null;
            if (message != null)
                ViewBag.Message = message;

            var people = await personRepository.GetAll();
            return View(people.Select(p => mapper.Map<PersonViewModel>(p)).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Upload([Required]IFormFile fileInfo) 
        {
            if (fileInfo == null || fileInfo.ContentType != "text/csv")
            {
                return RedirectToAction("Index", "Home", new { message = new string("Content type must be text/csv") });
            }
            else
            {
                try
                {
                    var result = new List<Person>();
                    using (StreamReader stream = new StreamReader(fileInfo.OpenReadStream()))
                    {
                        using (var cvsReader = new CsvReader(stream, CultureInfo.CurrentCulture))
                        {
                            result = cvsReader.GetRecords<PersonModelCrvReader>().Select(d => mapper.Map<Person>(d)).ToList();
                        }
                    }
                    if (result.Count != 0)
                        await personRepository.AddRange(result);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
                return Redirect("Index");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id != 0)
            {
                try
                {
                    var person = await personRepository.GetById(id);
                    if (person != null)
                        return View(mapper.Map<PersonModel>(person));
                    else
                        return Redirect("Index");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }

            }
            return Redirect("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await personRepository.Update(mapper.Map<Person>(model));
                    return Redirect("Index");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                try
                {
                    var person = await personRepository.GetById(id);
                    if (person != null)
                        await personRepository.Delete(person);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }

            }
            return RedirectToAction("Index", "Home");
        }
    }
}