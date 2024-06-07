using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Security;

public class GuidEncryptionService(IOptions<GuidEncryptionOptions> options) : IGuidEncryptionService
{
    public string EncryptGuid(Guid guid)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(options.Value.SecretKey);
            aes.IV = Encoding.UTF8.GetBytes(options.Value.SecretPhrase);
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (var ms = new System.IO.MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new System.IO.StreamWriter(cs))
                {
                    sw.Write(guid.ToString());
                }

                var encryptedBytes = ms.ToArray();
                var base64String = Convert.ToBase64String(encryptedBytes);
                var base64UrlString = base64String.Replace('+', '-').Replace('/', '_').Replace("=", string.Empty);
                return base64UrlString;
            }
        }
    }

    public Guid DecryptGuid(string encryptedGuid)
    {
        encryptedGuid = encryptedGuid.Replace('-', '+').Replace('_', '/');
        switch (encryptedGuid.Length % 4)
        {
            case 2: encryptedGuid += "=="; break;
            case 3: encryptedGuid += "="; break;
        }

        var buffer = Convert.FromBase64String(encryptedGuid);

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(options.Value.SecretKey);
            aes.IV = Encoding.UTF8.GetBytes(options.Value.SecretPhrase);
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var sr = new System.IO.StreamReader(cs))
            {
                var decryptedString = sr.ReadToEnd();
                return Guid.Parse(decryptedString);
            }
        }
    }
}