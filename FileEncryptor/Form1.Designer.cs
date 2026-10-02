namespace FileEncryptor
{
partial class Form1
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        groupBoxFolder = new GroupBox();
        labelFolderPath = new Label();
        textBoxFolderPath = new TextBox();
        buttonChooseFolder = new Button();
        groupBoxOperations = new GroupBox();
        buttonEncrypt = new Button();
        buttonDecrypt = new Button();
        buttonProcessSelectedFile = new Button();
        buttonRefresh = new Button();
        checkBoxDeleteSourceFile = new CheckBox();
        groupBoxFiles = new GroupBox();
        listViewFiles = new ListView();
        columnHeaderFileName = new ColumnHeader();
        columnHeaderFileSize = new ColumnHeader();
        columnHeaderFileState = new ColumnHeader();
        groupBoxLog = new GroupBox();
        listBoxLog = new ListBox();
        groupBoxFolder.SuspendLayout();
        groupBoxOperations.SuspendLayout();
        groupBoxFiles.SuspendLayout();
        groupBoxLog.SuspendLayout();
        SuspendLayout();
        // 
        // groupBoxFolder
        // 
        groupBoxFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxFolder.Controls.Add(labelFolderPath);
        groupBoxFolder.Controls.Add(textBoxFolderPath);
        groupBoxFolder.Controls.Add(buttonChooseFolder);
        groupBoxFolder.Location = new Point(14, 16);
        groupBoxFolder.Margin = new Padding(3, 4, 3, 4);
        groupBoxFolder.Name = "groupBoxFolder";
        groupBoxFolder.Padding = new Padding(3, 4, 3, 4);
        groupBoxFolder.Size = new Size(926, 109);
        groupBoxFolder.TabIndex = 3;
        groupBoxFolder.TabStop = false;
        groupBoxFolder.Text = "Папка для обробки";
        // 
        // labelFolderPath
        // 
        labelFolderPath.AutoSize = true;
        labelFolderPath.Location = new Point(17, 47);
        labelFolderPath.Name = "labelFolderPath";
        labelFolderPath.Size = new Size(148, 20);
        labelFolderPath.TabIndex = 0;
        labelFolderPath.Text = "Папка для обробки:";
        // 
        // textBoxFolderPath
        // 
        textBoxFolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxFolderPath.Location = new Point(181, 43);
        textBoxFolderPath.Margin = new Padding(3, 4, 3, 4);
        textBoxFolderPath.Name = "textBoxFolderPath";
        textBoxFolderPath.ReadOnly = true;
        textBoxFolderPath.Size = new Size(548, 27);
        textBoxFolderPath.TabIndex = 1;
        // 
        // buttonChooseFolder
        // 
        buttonChooseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonChooseFolder.Location = new Point(742, 41);
        buttonChooseFolder.Margin = new Padding(3, 4, 3, 4);
        buttonChooseFolder.Name = "buttonChooseFolder";
        buttonChooseFolder.Size = new Size(166, 33);
        buttonChooseFolder.TabIndex = 2;
        buttonChooseFolder.Text = "Обрати папку";
        buttonChooseFolder.UseVisualStyleBackColor = true;
        buttonChooseFolder.Click += buttonChooseFolder_Click;
        // 
        // groupBoxOperations
        // 
        groupBoxOperations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxOperations.Controls.Add(buttonEncrypt);
        groupBoxOperations.Controls.Add(buttonDecrypt);
        groupBoxOperations.Controls.Add(buttonProcessSelectedFile);
        groupBoxOperations.Controls.Add(buttonRefresh);
        groupBoxOperations.Controls.Add(checkBoxDeleteSourceFile);
        groupBoxOperations.Location = new Point(14, 139);
        groupBoxOperations.Margin = new Padding(3, 4, 3, 4);
        groupBoxOperations.Name = "groupBoxOperations";
        groupBoxOperations.Padding = new Padding(3, 4, 3, 4);
        groupBoxOperations.Size = new Size(926, 134);
        groupBoxOperations.TabIndex = 2;
        groupBoxOperations.TabStop = false;
        groupBoxOperations.Text = "Операції";
        // 
        // buttonEncrypt
        // 
        buttonEncrypt.Location = new Point(17, 41);
        buttonEncrypt.Margin = new Padding(3, 4, 3, 4);
        buttonEncrypt.Name = "buttonEncrypt";
        buttonEncrypt.Size = new Size(171, 37);
        buttonEncrypt.TabIndex = 0;
        buttonEncrypt.Text = "Шифрувати файли";
        buttonEncrypt.UseVisualStyleBackColor = true;
        buttonEncrypt.Click += buttonEncrypt_Click;
        // 
        // buttonDecrypt
        // 
        buttonDecrypt.Location = new Point(199, 41);
        buttonDecrypt.Margin = new Padding(3, 4, 3, 4);
        buttonDecrypt.Name = "buttonDecrypt";
        buttonDecrypt.Size = new Size(183, 37);
        buttonDecrypt.TabIndex = 1;
        buttonDecrypt.Text = "Дешифрувати файли";
        buttonDecrypt.UseVisualStyleBackColor = true;
        buttonDecrypt.Click += buttonDecrypt_Click;
        // 
        // buttonProcessSelectedFile
        // 
        buttonProcessSelectedFile.Location = new Point(392, 41);
        buttonProcessSelectedFile.Margin = new Padding(3, 4, 3, 4);
        buttonProcessSelectedFile.Name = "buttonProcessSelectedFile";
        buttonProcessSelectedFile.Size = new Size(217, 37);
        buttonProcessSelectedFile.TabIndex = 2;
        buttonProcessSelectedFile.Text = "Обробити вибраний файл";
        buttonProcessSelectedFile.UseVisualStyleBackColor = true;
        buttonProcessSelectedFile.Click += buttonProcessSelectedFile_Click;
        // 
        // buttonRefresh
        // 
        buttonRefresh.Location = new Point(619, 41);
        buttonRefresh.Margin = new Padding(3, 4, 3, 4);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new Size(149, 37);
        buttonRefresh.TabIndex = 3;
        buttonRefresh.Text = "Оновити список";
        buttonRefresh.UseVisualStyleBackColor = true;
        buttonRefresh.Click += buttonRefresh_Click;
        // 
        // checkBoxDeleteSourceFile
        // 
        checkBoxDeleteSourceFile.AutoSize = true;
        checkBoxDeleteSourceFile.Location = new Point(17, 90);
        checkBoxDeleteSourceFile.Margin = new Padding(3, 4, 3, 4);
        checkBoxDeleteSourceFile.Name = "checkBoxDeleteSourceFile";
        checkBoxDeleteSourceFile.Size = new Size(371, 24);
        checkBoxDeleteSourceFile.TabIndex = 4;
        checkBoxDeleteSourceFile.Text = "Видаляти вихідний файл після успішної операції";
        checkBoxDeleteSourceFile.UseVisualStyleBackColor = true;
        // 
        // groupBoxFiles
        // 
        groupBoxFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxFiles.Controls.Add(listViewFiles);
        groupBoxFiles.Location = new Point(14, 287);
        groupBoxFiles.Margin = new Padding(3, 4, 3, 4);
        groupBoxFiles.Name = "groupBoxFiles";
        groupBoxFiles.Padding = new Padding(3, 4, 3, 4);
        groupBoxFiles.Size = new Size(926, 226);
        groupBoxFiles.TabIndex = 1;
        groupBoxFiles.TabStop = false;
        groupBoxFiles.Text = "Файли у папці";
        // 
        // listViewFiles
        // 
        listViewFiles.Columns.AddRange(new ColumnHeader[] { columnHeaderFileName, columnHeaderFileSize, columnHeaderFileState });
        listViewFiles.Dock = DockStyle.Fill;
        listViewFiles.FullRowSelect = true;
        listViewFiles.GridLines = true;
        listViewFiles.Location = new Point(3, 24);
        listViewFiles.Margin = new Padding(3, 4, 3, 4);
        listViewFiles.Name = "listViewFiles";
        listViewFiles.Size = new Size(920, 198);
        listViewFiles.TabIndex = 0;
        listViewFiles.UseCompatibleStateImageBehavior = false;
        listViewFiles.View = View.Details;
        // 
        // columnHeaderFileName
        // 
        columnHeaderFileName.Text = "Назва файла";
        columnHeaderFileName.Width = 440;
        // 
        // columnHeaderFileSize
        // 
        columnHeaderFileSize.Text = "Розмір";
        columnHeaderFileSize.Width = 130;
        // 
        // columnHeaderFileState
        // 
        columnHeaderFileState.Text = "Стан";
        columnHeaderFileState.Width = 200;
        // 
        // groupBoxLog
        // 
        groupBoxLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxLog.Controls.Add(listBoxLog);
        groupBoxLog.Location = new Point(14, 527);
        groupBoxLog.Margin = new Padding(3, 4, 3, 4);
        groupBoxLog.Name = "groupBoxLog";
        groupBoxLog.Padding = new Padding(3, 4, 3, 4);
        groupBoxLog.Size = new Size(926, 205);
        groupBoxLog.TabIndex = 0;
        groupBoxLog.TabStop = false;
        groupBoxLog.Text = "Журнал подій";
        // 
        // listBoxLog
        // 
        listBoxLog.Dock = DockStyle.Fill;
        listBoxLog.HorizontalScrollbar = true;
        listBoxLog.IntegralHeight = false;
        listBoxLog.Location = new Point(3, 24);
        listBoxLog.Margin = new Padding(3, 4, 3, 4);
        listBoxLog.Name = "listBoxLog";
        listBoxLog.Size = new Size(920, 177);
        listBoxLog.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(953, 748);
        Controls.Add(groupBoxLog);
        Controls.Add(groupBoxFiles);
        Controls.Add(groupBoxOperations);
        Controls.Add(groupBoxFolder);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(969, 784);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Шифрувальник файлів";
        groupBoxFolder.ResumeLayout(false);
        groupBoxFolder.PerformLayout();
        groupBoxOperations.ResumeLayout(false);
        groupBoxOperations.PerformLayout();
        groupBoxFiles.ResumeLayout(false);
        groupBoxLog.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.GroupBox groupBoxFolder;
    private System.Windows.Forms.Label labelFolderPath;
    private System.Windows.Forms.TextBox textBoxFolderPath;
    private System.Windows.Forms.Button buttonChooseFolder;
    private System.Windows.Forms.GroupBox groupBoxOperations;
    private System.Windows.Forms.Button buttonEncrypt;
    private System.Windows.Forms.Button buttonDecrypt;
    private System.Windows.Forms.Button buttonProcessSelectedFile;
    private System.Windows.Forms.Button buttonRefresh;
    private System.Windows.Forms.CheckBox checkBoxDeleteSourceFile;
    private System.Windows.Forms.GroupBox groupBoxFiles;
    private System.Windows.Forms.ListView listViewFiles;
    private System.Windows.Forms.ColumnHeader columnHeaderFileName;
    private System.Windows.Forms.ColumnHeader columnHeaderFileSize;
    private System.Windows.Forms.ColumnHeader columnHeaderFileState;
    private System.Windows.Forms.GroupBox groupBoxLog;
    private System.Windows.Forms.ListBox listBoxLog;
}
}
