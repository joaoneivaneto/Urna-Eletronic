using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urna.interfaces;
using Urna.Models;

namespace Urna.Controllers
{
    public class RegistroCandidatosController : Controller
    {
        private readonly IRegistroCandidatos _registroCandidatos;

        public RegistroCandidatosController(IRegistroCandidatos registroCandidatos)
        {
            _registroCandidatos = registroCandidatos;
        }


        // GET: RegistroCandidatosController
        public ActionResult Index()
        {
            return View(_registroCandidatos.List());
        }

        // GET: RegistroCandidatosController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_registroCandidatos.GetOne(id));
        }

        // GET: RegistroCandidatosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroCandidatosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegistroCandidatos collection)
        {
            try
            {
                _registroCandidatos.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroCandidatosController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_registroCandidatos.GetOne(id));
        }

        // POST: RegistroCandidatosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RegistroCandidatos collection)
        {
            try
            {
                _registroCandidatos.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroCandidatosController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_registroCandidatos.GetOne(id));
        }

        // POST: RegistroCandidatosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, RegistroCandidatos collection)
        {
            try
            {
                _registroCandidatos.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        


    }
}
