

class Program
{
    public static List<TaskManagerConsole.Task> Tasks { get; set; } = new()
    {
        new TaskManagerConsole.Task()
        {
            Id= 1,
            Title = "Чебуреки",
            Description = "Вкусный рецепт чебуреков от Нурик",
            CreatedDate = DateTime.Now.ToString(),
            StartDate = "",
            ClosedDate = "",
            Status = TaskManagerConsole.TaskStatus.New

        }
    };
    public static int TaskId { get; set; }

  

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберете команду:");
            //Ctrl+D для копирования целой строки
            Console.WriteLine("1 - Создание задачи");
            Console.WriteLine("2 - Получение задачи по Id");
            Console.WriteLine("3 - Получение списка задач");
            Console.WriteLine("4 - Взятие задачи в работу");
            Console.WriteLine("5 - Закрытие задачи");
            Console.WriteLine("6 - Выход из программы");
            
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
                    TaskId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(GetTaskById(TaskId));
                    TaskId = 0;
                    break;
                case ConsoleKey.D3:
                    GetTasks();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("Введите идентификатор задачи");
                    TaskId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(InWorkStatus(TaskId));
                    TaskId = 0;
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("Введите идентификатор задачи");
                    TaskId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(ClosedStatus(TaskId));
                    TaskId = 0;
                    break;
                case ConsoleKey.D6:
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
    public static string InWorkStatus(int id)
    {
        var task = Tasks[id - 1];
        task.Status = TaskManagerConsole.TaskStatus.InWork;
        task.StartDate = DateTime.Now.ToString();

        return $"Задача {id} взята в работу";
    }
    public static string ClosedStatus(int id)
    {
        var task = Tasks[id - 1];
        task.Status = TaskManagerConsole.TaskStatus.Closed;
        task.ClosedDate = DateTime.Now.ToString();

        return $"Задача {id} завершена";
    }
}