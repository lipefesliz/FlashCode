using FlashCodeNFe.Dominio.Exceptions;
using FlashCodeNFe.Dominio.Features.Destinatarios;
using FlashCodeNFe.Infra.ORM.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FlashCodeNFe.Infra.ORM.Features.Destinatarios
{
    /// <summary>
    /// Repositório de orders
    /// </summary>
    public class DestinatarioRepository : IDestinatarioRepositorio
    {
        private FlashCodeNFeDbContext _context;

        public DestinatarioRepository(FlashCodeNFeDbContext context)
        {
            _context = context;
        }

        #region ADD

        /// <summary>
        /// Adiciona um novo destinatario na base de dados
        /// </summary>
        // <param name="destinatario">É o destinatario que será adicionado da base de dados</param>
        /// <returns>Retorna o novo destinatario com os atributos atualizados (como id)</returns>
        public Destinatario Add(Destinatario destinatario)
        {
            var newDestinatario = _context.Destinatarios.Add(destinatario);
            // Salva no banco
            _context.SaveChanges();
            return newDestinatario;
        }

        #endregion

        #region GET

        public IQueryable<Destinatario> PegarTodos(int? tamanho = null)
        {
            if (tamanho != null)
                return _context.Destinatarios.Include(d => d.Endereco).Take((int)tamanho);
            else
                return _context.Destinatarios.Include(d => d.Endereco);
        }

        public Destinatario PegarPorId(long destinatarioId)
        {
            return _context.Destinatarios
                            .Include(d => d.Endereco)
                            .Where(c => c.Id == destinatarioId)
                            .FirstOrDefault();
        }

        #endregion

        #region REMOVE

        public bool Remover(long[] destinatariosId)
        {
            var destinatarios = new List<Destinatario>();
            foreach (var destinatario in destinatariosId)
            {
                destinatarios.Add(_context.Destinatarios.Where(p => p.Id == destinatario).FirstOrDefault());
            }
            if (destinatarios.Count < 1)
                throw new NotFoundException();

            foreach (var item in destinatarios)
            {
                _context.Enderecos.Remove(item.Endereco);
                _context.Destinatarios.Remove(item);
            }

            return _context.SaveChanges() > 0;
        }

        #endregion

        #region UPDATE
        public bool Atualizar(Destinatario destinatario)
        {
            // Altera o estado
            _context.Entry(destinatario).State = EntityState.Modified;
            // Salva mudanças
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}
