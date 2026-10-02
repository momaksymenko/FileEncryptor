namespace FileEncryptor.Models;

public class OperationResult
{
    public string FilePath { get; set; }

    public bool IsSuccess { get; set; }

    public string Message { get; set; }

    public OperationResult(string filePath, bool isSuccess, string message)
    {
        FilePath = filePath;
        IsSuccess = isSuccess;
        Message = message;
    }
}
