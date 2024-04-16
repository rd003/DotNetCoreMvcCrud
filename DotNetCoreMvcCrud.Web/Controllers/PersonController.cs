using DotNetCoreMvcCrud.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreMvcCrud.Web.Controllers
{
    public class PersonController(IPersonRepository _personRepo) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var people = await _personRepo.GetPeople();
            return View(people);
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
           if(!ModelState.IsValid)
                return View(person);
           try
           {
                await _personRepo.AddPerson(person);
                TempData["successMessage"] = "Saved successfully.";
                return RedirectToAction(nameof(AddPerson));
           }
           catch (Exception ex)
           {
                TempData["errorMessage"] = "Something went wrong.";
                return View();
           }
        }

        public async Task<IActionResult> UpdatePerson(int id)
        {
            var person = await _personRepo.FindPersonById(id);
            if (person == null)
            {
                TempData["errorMessage"] = "Record does not found";
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            try
            {
                await _personRepo.UpdatePerson(person);
                TempData["successMessage"] = "Updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Something went wrong";
                return View();
            }
        }

        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                var person = await _personRepo.FindPersonById(id);
                if (person == null)
                {
                    TempData["errorMessage"] = "Record does not found";
                    return RedirectToAction(nameof(Index));
                }
                await _personRepo.DeletePerson(person);
                TempData["successMessage"] = "Deleted successfully";
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Something went wrong";
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
