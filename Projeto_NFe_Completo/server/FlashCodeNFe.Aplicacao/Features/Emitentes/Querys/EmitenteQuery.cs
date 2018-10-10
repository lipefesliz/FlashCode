using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Emitentes.Querys
{
    public class EmitenteQuery
    {
        public virtual int Size { get; set; }

        public EmitenteQuery(int _size)
        {
            Size = _size;
        }
    }
}
