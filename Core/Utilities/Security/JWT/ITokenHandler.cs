namespace Core.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        Token CreateToken(Guid userId, string email, string roleId);
    }
}
