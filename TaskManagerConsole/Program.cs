

class Program
{
    public static List<TaskManagerConsole.Task> Tasks { get; set; } = [];

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберете команду:");
            //Ctrl+D для копирования целой строки
            Console.WriteLine("1 - Создание задачи");
            Console.WriteLine("2 - Получение задачи по Id");
            Console.WriteLine("3 - Получение списка задач");
            // Реализовать закрытие задачи
            // Реализовать взятие задачи в работу
            Console.WriteLine("4 - Выход из программы");

            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Введите заголовок задачи");
                    var title = Console.ReadLine();
                    Console.WriteLine("Введите описание задачи");
                    var description = Console.ReadLine();

                    var taskId = AddTask(title, description);
                    Console.WriteLine($"Создана задача с идентификатором {taskId}");
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine("Введите идентификатор задачи");
                    var id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(GetTaskById(id));
                    break;

                case ConsoleKey.D3:
                    GetTasks();
                    break;

                case ConsoleKey.D4:
                    return;
            }
        }
    }

    public static int AddTask(string title, string description)
    {
        var newTask = new TaskManagerConsole.Task
        {
            Id = Tasks.Count + 1,
            Title = title,
            Description = description,
            CreatedDate = DateTime.Now.ToString(),
            StartDate = "",
            ClosedDate = "",
            Status = TaskManagerConsole.TaskStatus.New,
        };

        Tasks.Add(newTask);

        return newTask.Id;
    }

    public static string GetTaskById(int id) 
    {
        var task = Tasks[id-1];

        return $"Задача {task.Id}: {task.Title}, {task.Description}, {task.Status}, {task.CreatedDate}, {task.StartDate}, {task.ClosedDate}";
    }

    public static void GetTasks()
    {
        foreach (var task in Tasks)
        {
            Console.WriteLine($"Задача {task.Id}: {task.Title}, {task.Description}, {task.Status}, {task.CreatedDate}, {task.StartDate}, {task.ClosedDate}");
        }
    }
}