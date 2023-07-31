using Collections_List;

Queue<IGo> q = new Queue<IGo>();
q.Enqueue(new Car("Ford", 2010, 70));
q.Enqueue(new Car());
q.Enqueue(new Car("Запорожец", 1950, 50));
q.Enqueue(new Plane("Boeing", 2000, 900, 40));
q.Enqueue(new Plane());
q.Enqueue(new Plane("Boeing", 2000, 900, 40));

string[] menu = new[]
{
"1. Просмотр очереди\n",
"2. Добавление элемента в очередь\n",
"3. Удаление элемента из очереди\n",
"4. Поиск элемента в очереди\n",
"5. Очистить очередь\n",
"6. Выход\n"
};

for (; ; )
{
    foreach (string menuItem in menu)
    {
        Console.Write(menuItem);
    }
    int i;
    string? choise = Console.ReadLine();
    if (!(int.TryParse(choise, out i))) Console.WriteLine("Некорректное значение");
    else
    {
        switch (i)
        {
            case 1:
                ViewQueue(q);
                break;
            case 2:
                AddToQueue(q);
                break;
            case 3:
                q.Dequeue();
                break;
            case 4:
                QueueSearchElement(q);
                break;
            case 5:
                q.Clear();
                break;
            case 6:
                return;
            default:
                Console.WriteLine("Некорректное значение");
                break;
        }
    }
}

static void ViewQueue(Queue<IGo> q)
{
    foreach (var i in q)
    {
        Console.WriteLine(i);
    }
}

static void AddToQueue(Queue<IGo> q)
{
    char ch;
    do
    {
        Console.WriteLine("1. Добавить новый самолет");
        Console.WriteLine("2. Добавить новый автомобиль");
        int i;
        string? choise = Console.ReadLine();
        if (!(int.TryParse(choise, out i))) Console.WriteLine("Некорректное значение");
        else
        {
            switch (i)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Введите наименование самолета");
                        string? name = Console.ReadLine();
                        Console.WriteLine("Введите год выпуска самолета");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите скорость полета");
                        double speedFly = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите скорость на полосе");
                        double speedGo = Convert.ToDouble(Console.ReadLine());
                        q.Enqueue(new Plane(name, year, speedFly, speedGo));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Невозможно создать объект: {ex}");
                    }
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Введите наименование автомобиля");
                        string? name = Console.ReadLine();
                        Console.WriteLine("Введите год выпуска автомобиля");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите скорость автомобиля");
                        double speedGo = Convert.ToDouble(Console.ReadLine());
                        q.Enqueue(new Car(name, year, speedGo));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Невозможно создать объект: {ex}");
                    }
                    break;
            }
        }
        Console.WriteLine("Желаете продолжить: да - y, нет - n");
        string? choise1 = Console.ReadLine();
        if ((!(char.TryParse(choise1, out ch)))) Console.WriteLine("Некорректное значение");
    } while (ch == 'y');
}

static void QueueSearchElement(Queue<IGo> q)
{
    Console.Write("Имя: ");
    string? name = Console.ReadLine();
    Car car = new(name, 0, 0);
    Plane plane = new(name, 0, 0, 0);
    foreach (var i in q)
    {
        if (i is Car)
        {
            if ((Car)i == car)
            {
                Console.WriteLine(i);
                break;
            }
        }
        if (i is Plane)
        {
            if ((Plane)i == plane)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}
