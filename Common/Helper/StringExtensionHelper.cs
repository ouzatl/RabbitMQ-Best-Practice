using System.Text;

namespace Common.Helper
{
    public static class StringExtensionHelper
    {
        public static byte[] GetBytes(this string value)
        {
            return System.Text.Encoding.ASCII.GetBytes(value);
        }

        public static string GetString(this byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }
    }
}