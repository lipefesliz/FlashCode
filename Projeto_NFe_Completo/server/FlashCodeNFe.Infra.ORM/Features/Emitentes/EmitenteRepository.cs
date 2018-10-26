using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Emitentes;
using FlashCodeNFe.Infra.ORM.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FlashCodeNFe.Infra.ORM.Features.Emitentes
{
    public class EmitenteRepository : IEmitenteRepositorio
    {
        private FlashCodeNFeDbContext _context;

        public EmitenteRepository(FlashCodeNFeDbContext context)
        {
            _context = context;
        }

        #region ADD

        /// <summary>
        /// Adiciona um novo emitente na base de dados
        /// </summary>
        // <param name="emitente">É o emitente que será adicionado da base de dados</param>
        /// <returns>Retorna o novo emitente com os atributos atualizados (como id)</returns>
        public Emitente Add(Emitente emitente)
        {
            var newEmitente = _context.Emitentes.Add(emitente);
            // Salva no banco
            _context.SaveChanges();
            // Retorna a nova emitente com id atualizado
            return newEmitente;
        }

        #endregion

        #region GET

        public IQueryable<Emitente> PegarTodos(int? tamanho = null)
        {
            if (tamanho != null)
            {
                return _context.Emitentes.Include(d => d.Endereco).Take((int)tamanho);
            }
            else
            {
                var teste = _context.Emitentes.Include(d => d.Endereco);
                return teste;
            }
        }

        public Emitente PegarPorId(long emitenteId)
        {
            return _context.Emitentes.Include(x => x.Endereco).FirstOrDefault(e => e.Id == emitenteId);
        }

        #endregion

        #region REMOVE

        public bool Remover(long[] emitentesId)
        {
            List<Emitente> emitentes = new List<Emitente>();
            foreach (long emitente in emitentesId)
            {
                emitentes.Add(_context.Emitentes.Where(p => p.Id == emitente).FirstOrDefault());
            }
            if (emitentes.Count < 1)
            {
                throw new NotFoundException();
            }
            foreach (var item in emitentes)
            {
                _context.Enderecos.Remove(item.Endereco);
                _context.Emitentes.Remove(item);
            }

            return _context.SaveChanges() > 0;
        }

        #endregion

        #region UPDATE
        public bool Atualizar(Emitente emitente)
        {
            // Altera o estado
            _context.Entry(emitente).State = EntityState.Modified;
            // Salva mudanças
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}
