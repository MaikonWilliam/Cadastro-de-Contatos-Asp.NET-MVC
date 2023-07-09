using MySiteMVC.Data;
using MySiteMVC.Models;

namespace MySiteMVC.Repositório
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato); 
    }
}
