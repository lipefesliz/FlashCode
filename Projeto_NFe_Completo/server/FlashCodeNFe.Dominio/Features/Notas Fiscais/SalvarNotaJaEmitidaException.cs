using FlashCodeNFe.Dominio.Exceptions;

namespace FlashCodeNFe.Dominio.Features.Notas_Fiscais
{
    public class SalvarNotaJaEmitidaException : BusinessException
    {
        public SalvarNotaJaEmitidaException(ErrorCodes errorCode) : base(errorCode, "Não é possivel salvar uma nota já emitida")
        {
        }
    }
}
