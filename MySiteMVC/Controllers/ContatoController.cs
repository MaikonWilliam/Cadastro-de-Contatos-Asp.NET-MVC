using Microsoft.AspNetCore.Mvc;
using MySiteMVC.Data;
using MySiteMVC.Models;
using MySiteMVC.Repositório;

namespace MySiteMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            var list =  _contatoRepositorio.BuscarTodos();
            return View(list);
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            var list = _contatoRepositorio.BuscarTodos(name);
            return View(list);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return Redirect("Index");
        }

        public IActionResult Editar(int id)
        {
            var contato = _contatoRepositorio.ListarporId(id);
            return View(contato);
        }
        
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            _contatoRepositorio.Alterar(contato);
            return Redirect("Index");
        }

        public IActionResult ApagarConfirmacao()
        {
           
            return View();
        }
        public IActionResult ApagarConfirmação(int id) 
        {
            return View();
        }

       
    }
}
