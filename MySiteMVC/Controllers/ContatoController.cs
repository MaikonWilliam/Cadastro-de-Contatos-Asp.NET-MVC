using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);                
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = "Ops! Não conseguimos cadastrar seu contato,tente novamente, detalhes do " +
                $"erro: {error.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Editar(int id)
        {
            var contato = _contatoRepositorio.ListarporId(id);
            return View(contato);
        }
        
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Alterar(contato);
                    TempData["MensagemSucesso"] = "Contato Alterado com sucesso!";
                    return RedirectToAction("Index");
                  
                }

                return View("Editar", contato);
            }
            catch ( Exception error) 
            {
                 TempData["MensagemErro"] = "Ops! Não conseguimos alterar seu contato,tente novamente, detalhes do " + 
                 $"erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var contato = _contatoRepositorio.ListarporId(id);
            
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _contatoRepositorio.Apagar(id);
                TempData["MensagemErro"] = "O contato foi excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Ops! Não foi possivel excluir o contato, detalhes: {ex.Message}";
                return RedirectToAction("Index");
            }

            _contatoRepositorio.Apagar(id);
           return RedirectToAction("Index");
        }
        

       
    }
}
