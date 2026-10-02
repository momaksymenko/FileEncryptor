using System.Security.Cryptography;

namespace FileEncryptor.Services;

public class KeyStorageService
{
    private const int KeyLength = 32;
    private readonly string keyFolderPath;
    private readonly string keyFilePath;

    public KeyStorageService()
    {
        keyFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FileEncryptor");
        keyFilePath = Path.Combine(keyFolderPath, "encryption.key");
    }

    public byte[] GetOrCreateKey()
    {
        if (File.Exists(keyFilePath))
        {
            byte[] protectedKey = File.ReadAllBytes(keyFilePath);
            byte[] key = ProtectedData.Unprotect(protectedKey, null, DataProtectionScope.CurrentUser);

            if (key.Length != KeyLength)
                throw new CryptographicException("Збережений ключ має неправильний розмір.");

            return key;
        }

        byte[] newKey = RandomNumberGenerator.GetBytes(KeyLength);
        byte[] protectedNewKey = ProtectedData.Protect(newKey, null, DataProtectionScope.CurrentUser);
        Directory.CreateDirectory(keyFolderPath);
        File.WriteAllBytes(keyFilePath, protectedNewKey);
        return newKey;
    }
}
