using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Избери задача:");
            Console.WriteLine("1. Преобразуване между бройни системи");
            Console.WriteLine("2. Средно, Мода, Медиана");
            Console.WriteLine("3. Детерминанта на матрица 3x3");
            Console.WriteLine("4. Корени на полином");
            Console.WriteLine("5. Най-къс 3D вектор");
            Console.WriteLine("6. Множества: Сечение, Обединение, Разлика, Допълнение");
            Console.WriteLine("7. Пермутации, Комбинации, Вариации");
            Console.WriteLine("8. Вероятност от 100 хвърляния на зар");
            Console.WriteLine("9. Изход");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Въведи число: ");
                    string number = Console.ReadLine();
                    Console.Write("От коя бройна система: ");
                    int fromBase = int.Parse(Console.ReadLine());
                    Console.Write("Към коя бройна система: ");
                    int toBase = int.Parse(Console.ReadLine());
                    string converted = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
                    Console.WriteLine(converted);
                    break;
                case "2":
                    var nums = Console.ReadLine().Split().Select(double.Parse).ToList();
                    var avg = nums.Average();
                    var mode = nums.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
                    var med = nums.OrderBy(x => x).ToList();
                    double median = med.Count % 2 == 0 ? (med[med.Count / 2 - 1] + med[med.Count / 2]) / 2.0 : med[med.Count / 2];
                    Console.WriteLine($"{avg:F2} / {mode} / {median}");
                    break;
                case "3":
                    var matrix = new double[3, 3];
                    for (int i = 0; i < 3; i++)
                    {
                        var row = Console.ReadLine().Split().Select(double.Parse).ToArray();
                        for (int j = 0; j < 3; j++)
                            matrix[i, j] = row[j];
                    }
                    double det = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                               - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                               + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
                    Console.WriteLine(det);
                    break;
                case "4":
                    var coeffs = Console.ReadLine().Split().Select(double.Parse).ToArray();
                    if (coeffs.Length == 3)
                    {
                        double a = coeffs[0], b = coeffs[1], c = coeffs[2];
                        double d = b * b - 4 * a * c;
                        if (d > 0)
                            Console.WriteLine($"{(-b + Math.Sqrt(d)) / (2 * a)} {(-b - Math.Sqrt(d)) / (2 * a)}");
                        else if (d == 0)
                            Console.WriteLine($"{-b / (2 * a)}");
                        else
                            Console.WriteLine("Няма реални корени");
                    }
                    break;
                case "5":
                    int n = int.Parse(Console.ReadLine());
                    double minLen = double.MaxValue;
                    for (int i = 0; i < n; i++)
                    {
                        var vec = Console.ReadLine().Split().Select(double.Parse).ToArray();
                        double len = Math.Sqrt(vec[0] * vec[0] + vec[1] * vec[1] + vec[2] * vec[2]);
                        if (len < minLen) minLen = len;
                    }
                    Console.WriteLine(minLen);
                    break;
                case "6":
                    var set1 = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
                    var set2 = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
                    var intersect = set1.Intersect(set2);
                    var union = set1.Union(set2);
                    var diff = set1.Except(set2);
                    var complement = set2.Except(set1);
                    Console.WriteLine("Сечение: " + string.Join(" ", intersect));
                    Console.WriteLine("Обединение: " + string.Join(" ", union));
                    Console.WriteLine("Разлика: " + string.Join(" ", diff));
                    Console.WriteLine("Допълнение: " + string.Join(" ", complement));
                    break;
                case "7":
                    int a1 = int.Parse(Console.ReadLine());
                    int a2 = int.Parse(Console.ReadLine());
                    BigInteger Factorial(int x)
                    {
                        BigInteger r = 1;
                        for (int i = 2; i <= x; i++) r *= i;
                        return r;
                    }
                    BigInteger P = Factorial(a1);
                    BigInteger C = Factorial(a1) / (Factorial(a2) * Factorial(a1 - a2));
                    BigInteger V = Factorial(a1) / Factorial(a1 - a2);
                    Console.WriteLine($"{P} {C} {V}");
                    break;
                case "8":
                    var rnd = new Random();
                    var counts = new int[6];
                    for (int i = 0; i < 100; i++)
                        counts[rnd.Next(6)]++;
                    for (int i = 0; i < 6; i++)
                        Console.WriteLine($"{i + 1}: {counts[i]}");
                    break;
                case "9":
                    return;
            }
        }
    }
}
