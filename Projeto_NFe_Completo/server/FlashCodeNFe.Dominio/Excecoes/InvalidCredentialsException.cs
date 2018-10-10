namespace FlashCodeNFe.Dominio.Exceptions
{
    /// <summary>
    /// Representa uma exceção de negócio: durante a validação das credencias, no login, 
    /// as credenciais (email e senha)
    /// 
    /// </summary>
    public class InvalidCredentialsException : BusinessException
    {
        public InvalidCredentialsException() : base(ErrorCodes.Unauthorized, "Nome de usuário ou senha incorreto") { }
    }
}
