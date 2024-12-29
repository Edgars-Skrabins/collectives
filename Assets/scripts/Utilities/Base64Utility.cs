using System;
using System.Text;

namespace Collectives.Utilities
{
    public static class Base64Utility
    {
        public static string GetBase64EncodedString(string _text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(_text);
            return Convert.ToBase64String(textBytes);
        }

        public static string GetBase64DecodedString(string _base64String)
        {
            byte[] textBytes = Convert.FromBase64String(_base64String);
            return Encoding.UTF8.GetString(textBytes);
        }
    }
}
