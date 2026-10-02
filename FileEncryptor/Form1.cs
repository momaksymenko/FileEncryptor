using FileEncryptor.Models;
using FileEncryptor.Services;

namespace FileEncryptor;

public partial class Form1 : Form
{
    private readonly FileEncryptionService fileEncryptionService = new FileEncryptionService();
    private readonly KeyStorageService keyStorageService = new KeyStorageService();

    public Form1()
    {
        InitializeComponent();
    }

    private void buttonChooseFolder_Click(object? sender, EventArgs e)
    {
        using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = "Оберіть папку з файлами для обробки";
            folderBrowserDialog.UseDescriptionForTitle = true;

            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;

            textBoxFolderPath.Text = folderBrowserDialog.SelectedPath;
            AddLog($"Обрано папку: {folderBrowserDialog.SelectedPath}");
            RefreshFileList();
        }
    }

    private void buttonRefresh_Click(object? sender, EventArgs e)
    {
        if (!EnsureFolderSelected())
            return;

        RefreshFileList();
        AddLog($"Список оновлено. Знайдено файлів: {listViewFiles.Items.Count}.");
    }

    private void buttonEncrypt_Click(object? sender, EventArgs e)
    {
        ProcessFiles(encrypt: true);
    }

    private void buttonDecrypt_Click(object? sender, EventArgs e)
    {
        ProcessFiles(encrypt: false);
    }

    private void buttonProcessSelectedFile_Click(object? sender, EventArgs e)
    {
        if (!EnsureFolderSelected())
            return;

        if (listViewFiles.SelectedItems.Count != 1)
        {
            MessageBox.Show("Виберіть один файл зі списку.", "Файл не обрано", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string filePath = Path.Combine(textBoxFolderPath.Text, listViewFiles.SelectedItems[0].Text);
        if (!File.Exists(filePath))
        {
            AddLog("Вибраний файл більше не існує. Оновіть список.");
            RefreshFileList();
            return;
        }

        bool encrypt = !Path.GetExtension(filePath).Equals(".enc", StringComparison.OrdinalIgnoreCase);

        try
        {
            byte[] key = keyStorageService.GetOrCreateKey();
            OperationResult result = ProcessFile(filePath, key, encrypt);
            RefreshFileList();
        }
        catch (Exception exception)
        {
            AddLog($"Помилка: {exception.Message}");
        }
    }

    private void ProcessFiles(bool encrypt)
    {
        if (!EnsureFolderSelected())
            return;

        try
        {
            byte[] key = keyStorageService.GetOrCreateKey();
            List<string> files = fileEncryptionService.GetFilesForOperation(textBoxFolderPath.Text, encrypt).ToList();

            if (files.Count == 0)
            {
                string operation = encrypt ? "шифрування" : "дешифрування";
                AddLog($"Немає файлів для {operation}.");
                return;
            }

            int successfulOperations = 0;
            foreach (string filePath in files)
            {
                OperationResult result = ProcessFile(filePath, key, encrypt);

                if (result.IsSuccess)
                    successfulOperations++;
            }

            string operationName = encrypt ? "Шифрування" : "Дешифрування";
            AddLog($"{operationName} завершено ({successfulOperations} з {files.Count}).");
            RefreshFileList();
        }
        catch (Exception exception)
        {
            AddLog($"Помилка: {exception.Message}");
        }
    }

    private OperationResult ProcessFile(string filePath, byte[] key, bool encrypt)
    {
        OperationResult result = encrypt
            ? fileEncryptionService.EncryptFile(filePath, key)
            : fileEncryptionService.DecryptFile(filePath, key);

        AddLog(result.Message);

        if (result.IsSuccess && checkBoxDeleteSourceFile.Checked)
            TryDeleteSourceFile(filePath);

        return result;
    }

    private void TryDeleteSourceFile(string filePath)
    {
        try
        {
            File.Delete(filePath);
            AddLog($"Видалено вихідний файл: {Path.GetFileName(filePath)}");
        }
        catch (IOException exception)
        {
            AddLog($"Результат створено, але не вдалося видалити {Path.GetFileName(filePath)}: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            AddLog($"Результат створено, але не вдалося видалити {Path.GetFileName(filePath)}: {exception.Message}");
        }
    }

    private bool EnsureFolderSelected()
    {
        if (!Directory.Exists(textBoxFolderPath.Text))
        {
            MessageBox.Show("Спочатку оберіть наявну папку для обробки.", "Папку не обрано", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        return true;
    }

    private void RefreshFileList()
    {
        listViewFiles.BeginUpdate();
        listViewFiles.Items.Clear();

        try
        {
            foreach (string filePath in fileEncryptionService.GetAllFiles(textBoxFolderPath.Text))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                string state = fileInfo.Extension.Equals(".enc", StringComparison.OrdinalIgnoreCase) ? "Зашифровано" : "Звичайний файл";
                ListViewItem listViewItem = new ListViewItem(fileInfo.Name);
                listViewItem.SubItems.Add(FormatFileSize(fileInfo.Length));
                listViewItem.SubItems.Add(state);
                listViewFiles.Items.Add(listViewItem);
            }

        }
        catch (Exception exception)
        {
            AddLog($"Не вдалося оновити список: {exception.Message}");
        }
        finally
        {
            listViewFiles.EndUpdate();
        }
    }

    private void AddLog(string message)
    {
        listBoxLog.Items.Add($"{DateTime.Now:HH:mm:ss} — {message}");
        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
    }

    private static string FormatFileSize(long bytes)
    {
        return bytes < 1024 ? $"{bytes} Б" : $"{bytes / 1024.0:F1} КБ";
    }
}
