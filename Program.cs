
using rgr;
using System.Globalization;

internal class Program
{
    public static int Main()
    {

        Engine engine = new();

        Console.WriteLine("Введите шанс ответа выбора ведущего игрока(0.0-1.0): ");
        if (double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double k))
        {
            if (k > 1.0 || k < 0.0)
            {
                Console.WriteLine("Ошибка введите числа от 0.0 до 1.0");
            }

            Console.WriteLine("Введите количество прогонов: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (n <= 0)
                {
                    Console.WriteLine("Количество прогонов не может быть отрицательным.");
                }
                engine.Start(k,n);
            }
            else
            {

            }
        }
        else
        {
            Console.WriteLine("Вы ввели не число");
        }
        return 1;
    }
}