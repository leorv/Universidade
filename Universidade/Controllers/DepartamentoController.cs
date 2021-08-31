using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universidade.Data;

namespace Universidade.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IESContext _context;

        public DepartamentoController(IESContext context)
        {
            _context = context;
        }

         public async Task<IActionResult> Index()
        {
            return View(await _context.Departamentos.OrderBy(d => d.Nome).ToListAsync());
        }
    }
}
