using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevIO.UI.Site.Models;
using DevIO.UI.Site.Data;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevIO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDBContext _contexto;
        public TesteCrudController(MeuDBContext contexto)
        {
            _contexto = contexto;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Eduardo",
                DataNascimento = "25/10/1983",
                Email = "eduardo@eduardopires.net.br"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "eduardo@eduardopires.net.br");
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Eduardo");
            aluno.Nome = "Joao";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            return View("_Layout");
        }
    }
}

