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
            }
        };
        public IActionResult Index()
        {
            return View(instituicoes);
        }
    }
}
