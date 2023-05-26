using Microsoft.AspNetCore.Mvc;
using movielisting.Models;

namespace movielisting.Controllers
{
    public class FilmController : Controller
    {
        private FilmContext ctx;
        public FilmController(FilmContext fctx)
        {
            ctx = fctx;
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Rem(int id)
        {
            var del = ctx.Film.Where(b => b.No == id).FirstOrDefault();
            ctx.Remove(del);
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Modify(Film flm)
        {
            if (ModelState.IsValid)
            {
                ctx.Update(flm);
                await ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return View(flm);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(Film flm)
        {
            if (ModelState.IsValid)
            {
                ctx.Add(flm);
                await ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }
        public IActionResult Modify(int id)
        {
            var del = ctx.Film.Where(b => b.No == id).FirstOrDefault();
            return View(del);
        }
        public IActionResult Index()
        {
            var flm = ctx.Film.ToList();
            return View(flm);
        }
    }
}

