using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universidade.Data;
using Universidade.Models;

namespace Universidade.Controllers
{
    public class InstituicaoController : Controller
    {
        //Comentando a lista que usamos para um teste inicial no começo. Não iremos mais precisar dela.
        //private static IList<Instituicao> instituicoes = new List<Instituicao>()
        //{
        //    new Instituicao()
        //    {
        //        InstituicaoID = 1,
        //        Nome = "Unimar",
        //        Endereco = "Marília"
        //    },
        //    new Instituicao()
        //    {
        //        InstituicaoID = 2,
        //        Nome = "Univem",
        //        Endereco = "Marília"
        //    },
        //    new Instituicao()
        //    {
        //        InstituicaoID = 3,
        //        Nome = "Católica",
        //        Endereco = "Marília"
        //    },
        //    new Instituicao()
        //    {
        //        InstituicaoID = 4,
        //        Nome = "Univesp",
        //        Endereco = "São Paulo"
        //    }
        //};
        private readonly IESContext context; // antigamente usavam o underline antes do nome para dizer que era uma variável privada, isso já não é mais boa prática.

        public InstituicaoController(IESContext context)
        {
            this.context = context;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            return View(await context.Instituicoes.OrderBy(i => i.Nome).ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Nome, Endereco")] Instituicao instituicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Add(instituicao);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocorreu um erro ao tentar criar uma instituição.");
            }
            return View(instituicao);
        }

        // GET: Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Instituicao instituicao = await context.Instituicoes
                .FirstOrDefaultAsync(m => m.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("InstituicaoID, Nome, Endereco")] Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(instituicao);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (!InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw new Exception(ex.Message);
                    }                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }
        private bool InstituicaoExists(int? id)
        {
            return context.Instituicoes.Any(m => m.InstituicaoID == id);
        }

        // GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instituicao instituicao = await context.Instituicoes
                .SingleOrDefaultAsync(m => m.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }

        // GET: Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instituicao instituicao = await context.Instituicoes
                .SingleOrDefaultAsync(i => i.InstituicaoID == id);

            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Instituicao instituicao = await context.Instituicoes
                .SingleOrDefaultAsync(i => i.InstituicaoID == id);

            context.Instituicoes.Remove(instituicao);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
