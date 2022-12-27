namespace InterFin
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Calculator calculator = new Calculator();
            Console.WriteLine("Результат сложения: "+((ICalculator)calculator).Addition());
            Console.ReadKey();
        }
    }
    public interface ICalculator
    {
        long Addition();
    }
    public class Calculator : ICalculator
    {
        ILogger Logger { get; set; }
        long ICalculator.Addition()
        {
            Logger = new Logger();
            bool check = true;
            long a = 0, b = 0;
            do
            {
                try
                {
                    Console.WriteLine("Введите 2 целочисленных значения");
                    Console.Write("Введите первое число: ");
                    string tempA = Console.ReadLine();
                    Console.Write("Введите второе число: ");
                    string tempB = Console.ReadLine();
                    bool parsecheck1 = long.TryParse(tempA, out a);
                    bool parsecheck2 = long.TryParse(tempB, out b);
                    if ((parsecheck1 == false) | (parsecheck2 == false)) throw new FormatException("Вы ввели неверное значение!");
                    check = false;
                }
                catch (Exception ex)
                {
                    Logger.Error("Программа выдала ошибку");
                    Console.WriteLine(ex.Message);
                }
            }
            while (check);
            Logger.Event("Начался процесс сложения");
            long rez = a + b;
            Logger.Event("Закончился процесс сложения");
            return rez;
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mess);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Event(string mess)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(mess);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}