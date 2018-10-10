using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Enderecos;
using FlashCodeNFe.Infra.ORM.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FlashCodeNFe.Infra.ORM.Features.Orders
{
    /// <summary>
    /// Repositório de orders
    /// </summary>
    public class EnderecoRepository : IEnderecoRepositorio
    {
        private FlashCodeNFeDbContext _context;

        public EnderecoRepository(FlashCodeNFeDbContext context)
        {
            _context = context;
        }

        #region ADD

        /// <summary>
        /// Adiciona um novo endereco na base de dados
        /// </summary>
        // <param name="endereco">É o endereco que será adicionado da base de dados</param>
        /// <returns>Retorna o novo endereco com os atributos atualizados (como id)</returns>
        public Endereco Add(Endereco endereco)
        {
            // Indexamos o produto no context do EF
            // Isso evita que o EF adicione um novo produto caso o endereco.Product tenha id inválido
            // Estamos considerando que o produto deve ser pré-cadastrado.
            _context.Enderecos.Attach(endereco);
            // Adiciona a nova endereco
            var newEndereco = _context.Enderecos.Add(endereco);
            // Salva no banco
            _context.SaveChanges();
            // Retorna a nova endereco com id atualizado
            return newEndereco;
        }

        #endregion

        #region GET

        public IQueryable<Endereco> PegarTodos(int? tamanho = null)
        {
            if (tamanho != null)
                return _context.Enderecos.Take((int)tamanho);
            else
                return _context.Enderecos;
        }

        public Endereco PegarPorId(long enderecoId)
        {
            return _context.Enderecos.FirstOrDefault(e => e.Id == enderecoId);
        }

        #endregion

        #region REMOVE

        public bool Remover(long[] enderecosId)
        {
            var enderecos = new List<Endereco>();
            foreach (var endereco in enderecosId)
            {
                enderecos.Add(_context.Enderecos.Where(p => p.Id == endereco).FirstOrDefault());
            }
            if (enderecos.Count < 1)
                throw new NotFoundException();

            _context.Enderecos.RemoveRange(enderecos);

            return _context.SaveChanges() > 0;
        }

        #endregion

        #region UPDATE
        public bool Atualizar(Endereco endereco)
        {
            // Altera o estado
            _context.Entry(endereco).State = EntityState.Modified;
            // Salva mudanças
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}
