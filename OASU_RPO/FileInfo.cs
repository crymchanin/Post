using System;


/// <summary>
/// Представляет информацию о файле ОАСУ РПО
/// </summary>
public class FileInfo {

    /// <summary>
    /// Инициализирует новый объект класса FileInfo
    /// </summary>
    public FileInfo() { }

    /// <summary>
    /// Инициализирует новый объект класса FileInfo определяет его имя и дату создания
    /// </summary>
    public FileInfo(string fileName, DateTime timeEnd) {
        FileName = fileName;
        TimeEnd = timeEnd;
    }

    /// <summary>
    /// Инициализирует новый объект класса FileInfo определяет ИД операции, его имя и дату создания
    /// </summary>
    public FileInfo(int operationId, string fileName, DateTime timeEnd) {
        OperationId = operationId;
        FileName = fileName;
        TimeEnd = timeEnd;
    }

    /// <summary>
    /// ИД операции
    /// </summary>
    public int OperationId { get; set; }

    /// <summary>
    /// Имя файла
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Дату создания файла
    /// </summary>
    public DateTime TimeEnd { get; set; }
}