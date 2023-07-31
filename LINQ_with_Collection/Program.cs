Company google = new Company { name = "Google", year = 1977 };
Company lg = new Company { name = "Lg", year = 1979 };
Company sony = new Company { name = "Sony", year = 1905 };
Company apple = new Company { name = "Apple", year = 1972 };
List<Company> companies = new List<Company> { google, lg, sony, apple };

List<Person> list = new List<Person>()
            {
                new Person { name = "Ivan", year = 1970, post = "дворник", salary = 100, company = google },
                new Person { name = "Petr", year = 1987, post = "слесарь", salary = 230, company = lg },
                new Person { name = "Serge", year = 1963, post = "сторож", salary = 200, company = sony },
                new Person { name = "Ben", year = 1966, post = "вахтер", salary = 150, company = apple },
                new Person { name = "Steve", year = 1987, post = "дворник", salary = 120, company = google },
            };


Console.WriteLine("Список дворников с их окладом.");
Console.WriteLine();
var select1 = from person in list
              where person.post == "дворник" && person.company == google
              select new
              {
                  Name = person.company.name,
                  Post = person.post,
                  Salary = person.salary
              };

foreach (var v in select1)
{

    Console.WriteLine($"{v.Name} {v.Post} {v.Salary}");
    Console.WriteLine();
}

internal class Person
{
    public string name;
    public int year;
    public string post;
    public double salary;
    public Company company;
}



internal class Company
{
    public string name;
    public int year;
}
