using System.Security.Cryptography;
using System.Text;

namespace Maltat.Infrastructure.RedSms.Helpers;

/// <summary>
/// Вспомогательный класс для криптографических операций.
/// </summary>
public static class CryptoHelper
{
    /// <summary>
    /// Вычисляет MD5-хеш для входной строки.
    /// </summary>
    /// <param name="input">Входная строка для хеширования.</param>
    /// <returns>MD5-хеш в виде шестнадцатеричной строки или null, если входная строка пуста.</returns>
    public static string? GetMd5Hash(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashBytes = MD5.HashData(inputBytes);

        StringBuilder sb = new();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("x2"));
        }

        return sb.ToString();
    }
}