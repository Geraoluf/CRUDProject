using CRUDProject.Data;
using CRUDProject.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDProject.Controllers
{
    public class MedarbejderController : Controller
    {

        private readonly MVCDbContext dbContext;

        public MedarbejderController(MVCDbContext DbContext)
        {
            dbContext = DbContext;
        }


        [HttpGet]
        public async Task<IActionResult> VisData()
        {
            var medarbejder = await dbContext.Medarbejder.ToListAsync();

            return View(medarbejder);
           
        }



        [HttpGet]
        public IActionResult TilføjMedarbejder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TilføjMedarbejder(TilføjMedarbejder tilføjMedarbejder)
        {
            var medarbejder = new Medarbejder()
            {
                Id = Guid.NewGuid(),
                Navn = tilføjMedarbejder.Navn,
                Email = tilføjMedarbejder.Email,
                Løn = tilføjMedarbejder.Løn,
                Afdeling = tilføjMedarbejder.Afdeling,
                PersonNummer = tilføjMedarbejder.PersonNummer
            };

            await dbContext.Medarbejder.AddAsync(medarbejder);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("TilføjMedarbejder");

        }



        




        [HttpGet]
        public async Task<IActionResult> Detaljer(Guid id)
        {
            var medarbejder = await dbContext.Medarbejder.FirstOrDefaultAsync(m => m.Id == id);

            if (medarbejder != null)
            {

                var ViewModel = new SeDetaljerViewModel()
                {

                    Id = medarbejder.Id,
                    Navn = medarbejder.Navn,
                    Email = medarbejder.Email,
                    Løn = medarbejder.Løn,
                    Afdeling = medarbejder.Afdeling,
                    PersonNummer = medarbejder.PersonNummer

                };
                return View("visDetaljer", ViewModel);



            }

            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> Detaljer(UpdateViewModel Model)
        {
            var medarbejder = await dbContext.Medarbejder.FindAsync(Model.Id);

            if (medarbejder != null)
            {
                medarbejder.Navn = Model.Navn;
                medarbejder.Email = Model.Email;
                medarbejder.Løn = Model.Løn;
                medarbejder.PersonNummer = Model.PersonNummer;
                medarbejder.Afdeling = Model.Afdeling;
                await dbContext.SaveChangesAsync();
                return RedirectToAction("VisData");

            }
            return RedirectToAction("VisData"); 
        }





        [HttpPost]
        public async Task<IActionResult> Slet(UpdateViewModel model)
        {
            var medarbejder = await dbContext.Medarbejder.FindAsync(model.Id);

            if (medarbejder != null)
            {
                dbContext.Medarbejder.Remove(medarbejder);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("VisData");
            }

            return RedirectToAction("VisData");

        }
    }
    
}
