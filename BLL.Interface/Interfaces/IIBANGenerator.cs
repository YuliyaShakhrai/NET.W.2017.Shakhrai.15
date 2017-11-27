namespace BLL.Interface.Interfaces
{
    public interface IIBANGenerator
    {
        /// <summary>
        /// Generates an account's IBAN
        /// </summary>
        /// <returns>Account's IBAN</returns>
        string GenerateAccountNumber();
    }
}
