using Collections_List;

List<IGo> list = new List<IGo>() {
new Car("Ford", 2010, 70), new Car(), new Car("Запорожец", 1950, 50), new Car("WV", 1990, 75),
new Plane("Boeing", 2000, 900, 40), new Plane(), new Plane("Ил-2", 1943, 300, 40),new Plane("Boeing", 2000, 900, 40), new Plane("Airbus", 2015, 990, 60)
};


string[] menu = new[]
{
"1 – просмотр коллекции\n",
"2 – добавление элемента (данные вводим с клавиатуры)\n",
"3 – добавление элемента по указанному индексу (индекс и данные вводим с клавиатуры)\n",
"4 – нахождение элемента с начала коллекции (переопределить метод Equals или оператор == для вашего класса – сравнение только по полю name) (данные для поиска по полю name вводим с клавиатуры, вы должны иметь минимум 2 объекта в коллекции с одинаковыми именами)\n",
"5 – нахождение элемента с конца коллекции (данные для поиска по полю name вводим с клавиатуры, вы должны иметь минимум 2 объекта в коллекции с одинаковыми именами)\n",
"6 – удаление элемента по индексу (индекс вводим с клавиатуры)\n",
"7 – удаление элемента по значению (данные для поиска по полю name вводим с клавиатуры)\n",
"8 – реверс коллекции\n",
"9 – сортировка\n",
"10 – выполнение методов всех объектов, поддерживающих Interface2\n",
"0 – выход\n"
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
                ViewList(list);
                break;
            case 2:
                AddToList(list);
                break;
            case 3:
                AddToListByIndex(list);
                break;
            case 4:
                SearchFromStrat(list);
                break;
            case 5:
                SearchFromEnd(list);
                break;
            case 6:
                RemoveElement(list);
                break;
            case 7:
                RemoveByValue(list);
                break;
            case 8:
                list.Reverse();
                ViewList(list);
                break;
            case 9:
                list.Sort(delegate (IGo x, IGo y)
                {
                    if (x.GetName() == null && y.GetName() == null) return 0;
                    else if (x.GetName() == null) return -1;
                    else if (y.GetName() == null) return 1;
                    else return x.GetName().CompareTo(y.GetName());
                }
                        );
                Console.WriteLine("Лист отсортирован");
                break;
            case 10:
                foreach (var obj in list)
                {
                    (obj as IFly)?.Fly();
                }
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Некорректное значение");
                break;
        }
    }
}

static void ViewList(List<IGo> list)
{
    foreach (var i in list)
    {
        Console.WriteLine(i);
    }
}

static void AddToList(List<IGo> list)
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
                        list.Add(new Plane(name, year, speedFly, speedGo));
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
                        list.Add(new Car(name, year, speedGo));
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

static void AddToListByIndex(List<IGo> list)
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
                        Console.WriteLine("Введите индекс");
                        int index = Convert.ToInt32(Console.ReadLine());
                        list.Insert(index, new Plane(name, year, speedFly, speedGo));
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
                        Console.WriteLine("Введите индекс");
                        int index = Convert.ToInt32(Console.ReadLine());
                        list.Insert(index, new Car(name, year, speedGo));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Невозможно создать объект: {ex}");
                    }
                    break;
            }
        }
        Console.WriteLine("Желаете продолжить: да - y, нет - n ");
        string? choise1 = Console.ReadLine();
        if ((!(char.TryParse(choise1, out ch)))) Console.WriteLine("Некорректное значение");
    } while (ch == 'y');
}

static void SearchFromStrat(List<IGo> list)
{
    Console.Write("Имя: ");
    string? name = Console.ReadLine();
    Car car = new(name, 0, 0);
    Plane plane = new(name, 0, 0, 0);
    foreach (var i in list)
    {
        if (i is Car)
        {
            if ((Car)i == car)
            {
                Console.WriteLine($"{list.IndexOf(i)}. {i}");
                break;
            }
        }
        if (i is Plane)
        {
            if ((Plane)i == plane)
            {
                Console.WriteLine($"{list.IndexOf(i)}. {i}");
                break;
            }
        }
    }
}

static void SearchFromEnd(List<IGo> list)
{
    Console.Write("Имя: ");
    string? name = Console.ReadLine();
    Car car = new(name, 0, 0);
    Plane plane = new(name, 0, 0, 0);
    for (int i = list.Count - 1; i >= 0; i--)
    {
        if (list[i] is Car)
        {
            if ((Car)list[i] == car)
            {
                Console.WriteLine($"{list.LastIndexOf(list[i])}. {list[i]}");
                break;
            }
        }
        if (list[i] is Plane)
        {
            if ((Plane)list[i] == plane)
            {
                Console.WriteLine($"{list.LastIndexOf(list[i])}. {list[i]}");
                break;
            }
        }
    }
}

static void RemoveElement(List<IGo> list)
{
    int index;
    Console.WriteLine("Введите номер удаляемого элемента");
    string? n = Console.ReadLine();
    if (!(int.TryParse(n, out index)) || index >= list.Count || index < 0) Console.WriteLine("Удаление невозможно");
    else list.RemoveAt(index);
}

static void RemoveByValue(List<IGo> list)
{
    Console.Write("Имя: ");
    string? name = Console.ReadLine();
    Car car = new(name, 0, 0);
    Plane plane = new(name, 0, 0, 0);
    for (int i = list.Count - 1; i >= 0; i--)
    {
        if (list[i] is Car)
        {
            if ((Car)list[i] == car)
            {
                list.Remove(list[i]);
            }
        }
        if (list[i] is Plane)
        {
            if ((Plane)list[i] == plane)
            {
                list.Remove(list[i]);
            }
        }
    }
}
