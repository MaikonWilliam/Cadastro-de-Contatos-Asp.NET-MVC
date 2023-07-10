using MySiteMVC.Data;
using MySiteMVC.Models;

namespace MySiteMVC.Repositório
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        List<ContatoModel> BuscarTodos(string name);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel ListarporId(int id);
        ContatoModel Alterar(ContatoModel contato);
        bool Apagar(int id);

    }
}
