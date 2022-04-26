namespace Operational.Service.Security
{
    public interface ITokenService
    {
        bool IsTokenValid(string key, string issuer, string token);
        string GetTokenUserName(string token);
    }
}
