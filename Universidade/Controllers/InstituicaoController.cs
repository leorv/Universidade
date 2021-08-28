using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universidade.Models;

namespace Universidade.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao()
            {
                InstituicaoID = 1,
                Nome = "Unimar",
                Endereco = "Marília"
            },
            new Instituicao()
            {
                InstituicaoID = 2,
                Nome = "Univem",
                Endereco = "Marília"
            },
            new Instituicao()
            {
                InstituicaoID = 3,
                Nome = "Católica",
                Endereco = "Marília"
            },
            new Instituicao()
            {
                InstituicaoID = 4,
                Nome = "Univesp",
                Endereco = "São Paulo"
            }
        };
        public IActionResult Index()
        {
            return View(instituicoes);
        }
        // GET: Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao instituicao)
        {
            instituicoes.Add(instituicao);
            instituicao.InstituicaoID = instituicoes.Select(x => x.InstituicaoID).Max() + 1;
            return RedirectToAction("Index");
        }

        // GET: Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }

        // GET: Datails
        public IActionResult Details(int id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        // GET: Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            return RedirectToAction("Index");
        }
    }
}
