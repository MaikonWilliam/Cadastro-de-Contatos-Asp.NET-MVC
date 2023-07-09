using Microsoft.EntityFrameworkCore;
using MySiteMVC.Data;
using MySiteMVC.Models;
using System.Runtime.InteropServices;

namespace MySiteMVC.Repositório
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext ;
        public ContatoRepositorio(BancoContext context) 
        {
            _bancoContext = context;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public List<ContatoModel> BuscarTodos(string name)
        {
            return _bancoContext.Contatos.Where(o => o.Nome.Contains(name)).ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato) 
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
        public ContatoModel ListarporId(int id) 
        {
            return _bancoContext.Contatos.FirstOrDefault(o => o.Id == id);
        }
        public ContatoModel Alterar(ContatoModel contato)
        {
            var contatoDB = ListarporId(contato.Id);

            if (contatoDB == null) throw new Exception("Houve um erro na alteração do contato!");
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }
    }
}
