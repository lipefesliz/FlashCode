using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Transportadores;
using FlashCodeNFe.Infra.ORM.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FlashCodeNFe.Infra.ORM.Features.Orders
{
    /// <summary>
    /// Repositório de orders
    /// </summary>
    public class TransportadorRepository : ITransportadorRepositorio
    {
        private FlashCodeNFeDbContext _context;

        public TransportadorRepository(FlashCodeNFeDbContext context)
        {
            _context = context;
        }

        #region ADD

        /// <summary>
        /// Adiciona um novo transportador na base de dados
        /// </summary>
        // <param name="transportador">É o transportador que será adicionado da base de dados</param>
        /// <returns>Retorna o novo transportador com os atributos atualizados (como id)</returns>
        public Transportador Add(Transportador transportador)
        {
            var newTransportador = _context.Transportadores.Add(transportador);
            _context.SaveChanges();
            return newTransportador;
        }

        #endregion

        #region GET
        public IQueryable<Transportador> PegarTodos(int? tamanho = null)
        {
            if (tamanho != null)
                return _context.Transportadores.Include(p => p.Endereco).Take((int)tamanho);
            else
                return _context.Transportadores.Include(p => p.Endereco);
        }

        public Transportador PegarPorId(long transportadorId)
        {
            return _context.Transportadores.Include(e => e.Endereco).FirstOrDefault(e => e.Id == transportadorId);
        }

        #endregion

        #region REMOVE

        public bool Remover(long[] transportadorsId)
        {
            var transportadores = new List<Transportador>();
            foreach (var transportador in transportadorsId)
            {
                transportadores.Add(_context.Transportadores.Where(p => p.Id == transportador).FirstOrDefault());
            }
            if (transportadores.Count < 1)
                throw new NotFoundException();


            foreach (var item in transportadores)
            {
                _context.Enderecos.Remove(item.Endereco);
                _context.Transportadores.Remove(item);
            }

            return _context.SaveChanges() > 0;
        }

        #endregion

        #region UPDATE
        public bool Atualizar(Transportador transportador)
        {
            // Altera o estado
            _context.Entry(transportador).State = EntityState.Modified;
            // Salva mudanças
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}
