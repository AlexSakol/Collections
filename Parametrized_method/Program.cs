using Collections_List;
static int method<T>(T[] m)
{

    int count = 0;
    foreach (var item in m)
        if (item != null)
            count++;
    return count;
}

static void Main(string[] args)
{
    Car[] m = new Car[] { new Car(), new Car(), new Car(), null, null };
    Console.WriteLine(method<Car>(m));

    object[] m1 = new object[] { new Car(), 7, null, 9, null };
    Console.WriteLine(method(m1));

    int?[] m2 = new int?[] { 4, 6, null, 8, 6, null };
    Console.WriteLine(method(m2));
}

