
namespace Collections_List
{
    public class Car : IGo
    {
        private double speed;
        private string? name;

        public Car() : this("Car", 2000, 60)
        {
        }

        public Car(string? name, int year, double speed)
        {
            Name = name;
            Year = year;
            Speed = speed;
        }

        public string? Name
        {
            get => name;
            set
            {
                if (value == null) name = "Car";
                else name = value;
            }
        }
        public int Year { get; set; }

        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value < 0) speed = 0;
                else speed = value;
            }
        }

        private static bool Comparer(Car a, Car b)
        {
            if (a.Name == b.Name) return true;
            else return false;
        }
        public static bool operator ==(Car a, Car b)
        {
            if (Comparer(a, b) == true) return true;
            else return false;
        }

        public static bool operator !=(Car a, Car b)
        {
            if (Comparer(a, b) == false) return true;
            else return false;
        }

        public void Go() => Console.WriteLine($"Скорость {this.speed}");


        public void Print() => Console.WriteLine($"{this.Name} едет по шоссе");

        public override string? ToString() => $"{Name} скорость {speed} год выпуска {Year}";

        public string? GetName() => this.Name;
    }

}
