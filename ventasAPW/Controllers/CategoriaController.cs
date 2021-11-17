using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ventasAPW.Models;

namespace ventasAPW.Controllers
{
    public class CategoriaController : Controller
    {
        private apventasEntities db = new apventasEntities();
        // GET: Categoria
        public ActionResult Index()
        {
            var listaCategorias = db.Categoria.ToList();
            return View(listaCategorias);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categoria cat)
        {            
            db.Categoria.Add(cat);
            db.SaveChanges();

            return View();
        }
        //int? significa que puede ser null
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var categorias = db.Categoria.Find(id);
                if (categorias != null)
                {
                    return View(categorias);
                }
            }
            //redirige hacia otra vista (Action Index)
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Categoria cat)
        {
            //modifica los registros
            db.Entry(cat).State = EntityState.Modified;
            //se guarda en la base de daatos
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                var categoria = db.Categoria.Find(id);
                if(categoria != null)
                {
                    return View(categoria);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(Categoria cat)
        {
            //buscar o comprabar que exista en la base de datos
            var categoria = db.Categoria.Find(cat.id_categoria);
            //permite quitar el registro
            db.Categoria.Remove(categoria);
            //guardar en la base de datos
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}