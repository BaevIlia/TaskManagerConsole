namespace TaskManagerConsole;

public class Task
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set;}

    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public string CreatedDate { get; set; }

    /// <summary>
    /// Дата взятия задачи в работу
    /// </summary>
    public string StartDate { get; set; }

    /// <summary>
    /// Дата закрытия задачи
    /// </summary>
    public string ClosedDate { get; set; }

    /// <summary>
    /// Статус задачи
    /// </summary>
    /// <remarks>
    /// New - Новая,
    /// InWork - В работе,
    /// Closed - Завершённая
    /// </remarks>
    public TaskStatus Status { get; set; }
}