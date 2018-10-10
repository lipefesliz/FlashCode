using System.Linq;

namespace FlashCodeNFe.Dominio.Base
{
    public interface IRepositorio<T> where T : Entidade
    {
        IQueryable<T> PegarTodos(int? tamanho = null);
        T Add(T entidade);
        bool Atualizar(T entidade);
        T PegarPorId(long entidadeId);
        bool Remover(long[] entidadesId);
    }
}
