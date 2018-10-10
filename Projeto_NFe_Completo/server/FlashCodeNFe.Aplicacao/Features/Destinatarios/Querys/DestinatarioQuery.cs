using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Destinatarios.Querys
{
    public class DestinatarioQuery
    {

        public virtual int Size { get; set; }

        public DestinatarioQuery(int _size)
        {
            Size = _size;
        }
    }
}
