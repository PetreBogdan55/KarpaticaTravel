namespace KarpaticaTravelAPI.Infrastructure
{
    public interface ITokenManager
    {
        string GenerateJwtToken(string email, string name);
    }
}