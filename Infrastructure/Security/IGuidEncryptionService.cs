namespace Infrastructure.Security;

public interface IGuidEncryptionService
{
    string EncryptGuid(Guid guid);
    Guid DecryptGuid(string encryptedGuid);
}