﻿namespace FlashCodeNFe.Dominio.Exceptions
{
    /// <summary>
    /// Representa uma exceção de negócio: durante o cadastro, 
    /// a entidade já foi cadastrada com os dados informados
    /// 
    /// </summary>
    public class AlreadyExistsException : BusinessException
    {
        public AlreadyExistsException() : base(ErrorCodes.AlreadyExists, "Este registro já existe") { }
    }
}
