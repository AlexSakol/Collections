int[] mas = new int[30];
Random rand = new Random();
for (int i = 0; i < 30; i++)
{
    mas[i] = rand.Next(-100, 100);
}

foreach (int i in mas)
{
    Console.Write($"{i}\t");
}
Console.WriteLine();
Console.WriteLine();
int sum = (from i in mas where (i < 0) select i).Sum();
Console.WriteLine($"sum = {sum}");
Console.WriteLine();
