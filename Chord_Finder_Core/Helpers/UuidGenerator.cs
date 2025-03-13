using System.Security.Cryptography;
using System.Text;

namespace Chord_Finder_Core.Helpers
{
    public static class UuidGenerator
    {
        public static Guid GenerateUuid(string prefix, int index)
        {
            string input = $"{prefix}-{index}";

            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                return new Guid(hashBytes);
            }
        }
    }
}
