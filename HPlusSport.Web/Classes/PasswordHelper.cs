using System;
using System.Security.Cryptography;

namespace HPlusSport.Web.Classes
{
    public static class PasswordHelper
    {
        private const int numberOfIterations = 10000;

        public static HashInformation HashPassword(string password)
        {
            var rfc2898DeriveBytes =
                new Rfc2898DeriveBytes(password, 32, numberOfIterations);
            var hash = rfc2898DeriveBytes.GetBytes(20);
            var salt = rfc2898DeriveBytes.Salt;

            return new HashInformation
            {
                Hash = Convert.ToBase64String(hash),
                Salt = Convert.ToBase64String(rfc2898DeriveBytes.Salt)
            };
        }

        public static bool VerifyPassword(string password, HashInformation hashInformation)
        {
            var salt = Convert.FromBase64String(hashInformation.Salt);
            var rfc2898DeriveBytes =
                new Rfc2898DeriveBytes(password, salt, numberOfIterations);
            var hash = rfc2898DeriveBytes.GetBytes(20);

            return Convert.ToBase64String(hash) == hashInformation.Hash;
        }
    }

    public class HashInformation
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}