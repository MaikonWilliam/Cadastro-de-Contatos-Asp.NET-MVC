using MySiteMVC.Data;
using MySiteMVC.Models;

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

        public ContatoModel Adicionar(ContatoModel contato) 
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

       
    }
}
