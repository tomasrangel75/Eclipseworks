using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.API.Controllers
{
    public class TarefaHistoricoController : Controller
    {
        // GET: TarefaHistoricoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TarefaHistoricoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TarefaHistoricoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarefaHistoricoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarefaHistoricoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TarefaHistoricoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarefaHistoricoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TarefaHistoricoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
