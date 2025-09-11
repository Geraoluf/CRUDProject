using CRUDProject.Data;
using CRUDProject.Models;
using CRUDProject.Models.Domain;
using CRUDProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUDProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCDbContext dbContext;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(MVCDbContext DbContext, ILogger<EmployeeController> logger)
        {
            dbContext = DbContext;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Employee = await dbContext.Employees.ToListAsync();

            return View(Employee);
           
        }



        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployee addEmployee)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Navn = addEmployee.Navn,
                Email = addEmployee.Email,
                Løn = addEmployee.Løn,
                Afdeling = addEmployee.Afdeling,
                PersonNummer = addEmployee.PersonNummer
            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("AddEmployee");

        }



        




        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(m => m.Id == id);

            if (employee != null)
            {

                var viewModel = new DetailsViewModel()
                {

                    Id = employee.Id,
                    Navn = employee.Navn,
                    Email = employee.Email,
                    Løn = employee.Løn,
                    Afdeling = employee.Afdeling,
                    PersonNummer = employee.PersonNummer

                };
                return View("Edit", viewModel);



            }

            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> Edit(UpdateViewModel Model)
        {
            var employee = await dbContext.Employees.FindAsync(Model.Id);

            if (employee != null)
            {
                employee.Navn = Model.Navn;
                employee.Email = Model.Email;
                employee.Løn = Model.Løn;
                employee.PersonNummer = Model.PersonNummer;
                employee.Afdeling = Model.Afdeling;
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Edit"); 
        }





        [HttpPost]
        public async Task<IActionResult> Delete(UpdateViewModel model)
        {
            var employee = await dbContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit");

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    
}
