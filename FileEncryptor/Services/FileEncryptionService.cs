using System.Security.Cryptography;
using System.Text;
using FileEncryptor.Models;

namespace FileEncryptor.Services;

public class FileEncryptionService
{
    private const string EncryptedExtension = ".enc";
    private static readonly byte[] FormatMarker = Encoding.ASCII.GetBytes("FE1");
    private const int NonceLength = 12;
    private const int TagLength = 16;

    public IEnumerable<string> GetAllFiles(string folderPath)
    {
        return Directory.EnumerateFiles(folderPath, "*", SearchOption.TopDirectoryOnly)
            .Where(filePath => !Path.GetFileName(filePath).Equals("encryption.key", StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<string> GetFilesForOperation(string folderPath, bool encrypt)
    {
        return GetAllFiles(folderPath).Where(filePath =>
            encrypt
                ? !Path.GetExtension(filePath).Equals(EncryptedExtension, StringComparison.OrdinalIgnoreCase)
                : Path.GetExtension(filePath).Equals(EncryptedExtension, StringComparison.OrdinalIgnoreCase));
    }

    public OperationResult EncryptFile(string filePath, byte[] key)
    {
        string fileName = Path.GetFileName(filePath);
        string encryptedFilePath = filePath + ".enc";

        if (File.Exists(encryptedFilePath))
            return Failure(filePath, $"Пропущено: {fileName}, файл результату вже існує.");

        try
        {
            byte[] sourceData = File.ReadAllBytes(filePath);
            byte[] nonce = RandomNumberGenerator.GetBytes(NonceLength);
            byte[] tag = new byte[TagLength];
            byte[] encryptedData = new byte[sourceData.Length];

            using (AesGcm aesGcm = new AesGcm(key, TagLength))
            {
                aesGcm.Encrypt(nonce, sourceData, encryptedData, tag);
            }

            using (FileStream output = new FileStream(encryptedFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                output.Write(FormatMarker);
                output.Write(nonce);
                output.Write(tag);
                output.Write(encryptedData);
            }
            return Success(filePath, $"Зашифровано: {fileName}");
        }
        catch (UnauthorizedAccessException)
        {
            return Failure(filePath, $"Помилка шифрування {fileName}: немає доступу до файла.");
        }
        catch (IOException)
        {
            return Failure(filePath, $"Помилка шифрування {fileName}: файл зайнятий іншою програмою або недоступний.");
        }
        catch (CryptographicException)
        {
            return Failure(filePath, $"Помилка шифрування {fileName}: не вдалося виконати шифрування.");
        }
        catch (Exception exception)
        {
            return Failure(filePath, $"Помилка шифрування {fileName}: {exception.Message}");
        }
    }

    public OperationResult DecryptFile(string encryptedFilePath, byte[] key)
    {
        string encryptedFileName = Path.GetFileName(encryptedFilePath);
        string decryptedFilePath = encryptedFilePath.Substring(0, encryptedFilePath.Length - EncryptedExtension.Length);

        if (File.Exists(decryptedFilePath))
            return Failure(encryptedFilePath, $"Пропущено: {encryptedFileName}, файл результату вже існує.");

        try
        {
            byte[] fileData = File.ReadAllBytes(encryptedFilePath);
            if (fileData.Length < FormatMarker.Length + NonceLength + TagLength)
                return Failure(encryptedFilePath, $"Помилка дешифрування {encryptedFileName}: файл має неправильний формат.");

            string fileMarker = Encoding.ASCII.GetString(fileData, 0, FormatMarker.Length);
            if (fileMarker != "FE1")
                return Failure(encryptedFilePath, $"Помилка дешифрування {encryptedFileName}: файл має неправильний формат.");

            byte[] nonce = new byte[NonceLength];
            Array.Copy(fileData, FormatMarker.Length, nonce, 0, NonceLength);

            byte[] tag = new byte[TagLength];
            Array.Copy(fileData, FormatMarker.Length + NonceLength, tag, 0, TagLength);

            int encryptedDataStartIndex = FormatMarker.Length + NonceLength + TagLength;
            int encryptedDataLength = fileData.Length - encryptedDataStartIndex;
            byte[] encryptedData = new byte[encryptedDataLength];
            Array.Copy(fileData, encryptedDataStartIndex, encryptedData, 0, encryptedDataLength);
            byte[] decryptedData = new byte[encryptedData.Length];

            using (AesGcm aesGcm = new AesGcm(key, TagLength))
            {
                aesGcm.Decrypt(nonce, encryptedData, tag, decryptedData);
            }

            File.WriteAllBytes(decryptedFilePath, decryptedData);
            return Success(encryptedFilePath, $"Дешифровано: {encryptedFileName}");
        }
        catch (UnauthorizedAccessException)
        {
            return Failure(encryptedFilePath, $"Помилка дешифрування {encryptedFileName}: немає доступу до файла.");
        }
        catch (IOException)
        {
            return Failure(encryptedFilePath, $"Помилка дешифрування {encryptedFileName}: файл зайнятий іншою програмою або недоступний.");
        }
        catch (CryptographicException)
        {
            return Failure(encryptedFilePath, $"Помилка дешифрування {encryptedFileName}: файл пошкоджений або ключ не підходить.");
        }
        catch (Exception exception)
        {
            return Failure(encryptedFilePath, $"Помилка дешифрування {encryptedFileName}: {exception.Message}");
        }
    }

    private static OperationResult Success(string filePath, string message)
    {
        return new OperationResult(filePath, true, message);
    }

    private static OperationResult Failure(string filePath, string message)
    {
        return new OperationResult(filePath, false, message);
    }
}
