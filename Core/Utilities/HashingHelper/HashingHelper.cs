using System.Text;

namespace Core.Utilities.HashingHelper
{
    public class HashingHelper
    {
        public static void CreatePassword(string password , out byte[] passwordHash , out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPassowrd(string password , byte[] passwordHash , byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if (computedHash.Length != passwordHash.Length)
                    return false;

                for(int i = 0; i<computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;

            }
        }
    }
}
