namespace InterFin
{
    public class Program
    {
        ILogger Logger { get; }
        static void Main(string[] args)
        {
            bool check=true;
            do
            {
                try
                {
                    Console.WriteLine("Введите 2 целочисленных значения");
                    Console.Write("Введите первое число: ");
                    string tempA = Console.ReadLine();
                    Console.Write("Введите второе число: ");
                    string tempB = Console.ReadLine();
                    bool parsecheck1 = long.TryParse(tempA, out long a);
                    bool parsecheck2 = long.TryParse(tempB, out long b);
                    if ((parsecheck1 == false) | (parsecheck2 == false)) throw new FormatException("Вы ввели неверное значение!");
                    check = false;
                    Calculator calculator = new Calculator();
                    Console.WriteLine( ((ICalculator) calculator).Addition(a,b));
                }
                catch (Exception ex)
                {
                    Logger.Error("Программа выдала ошибку");
                    Console.WriteLine(ex.Message);
                }
            }
            while (check);
        }
    }
    public interface ICalculator
    {
        long Addition(long a, long b);
    }
    public class Calculator : ICalculator
    {
        ILogger Logger { get; }
        long ICalculator.Addition(long a, long b)
        {
            Logger.Event("Начался процесс сложения");
            long rez = a + b;
            return rez;
            Logger.Event("Закончился процесс сложения");
        }
    }
    public interface ILogger
    {
        void Error(string mess);
        void Event(string mess);
    }
    public class Logger : ILogger
    {
        public void Error(string mess)
        {
            Console.WriteLine(mess);
        }

        public void Event(string mess)
        {
            Console.WriteLine(mess);
        }
    }
}