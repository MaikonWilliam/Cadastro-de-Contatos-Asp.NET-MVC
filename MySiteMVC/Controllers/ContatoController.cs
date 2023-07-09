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

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            
            _contatoRepositorio.Adicionar(contato);
           
           
            return Redirect("Index");
        }
    }
}
