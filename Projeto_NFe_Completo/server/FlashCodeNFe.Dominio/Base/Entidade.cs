using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Dominio.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class Entidade
    {
        public long Id { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Entidade entidade = obj as Entidade;
            if (entidade == null)
                return false;
            else
                return Id.Equals(entidade.Id);
        }
    }
}
