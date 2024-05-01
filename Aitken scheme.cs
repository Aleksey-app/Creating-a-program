using System;

class Program
{
    static void Main(string[] args)
    {
        // Заданные значения
        double[] x = { 9.95, 10.25 };  // x_i
        double[] y = { 15.2368, 18.1109 };  // y_i
        double xT = 10.777;  // xT

        // Вычисление приближенного значения функции с помощью схемы Эйткена
        double result = AitkenInterpolation(x, y, xT);
        Console.WriteLine("Приближенное значение функции f(xT) при xT = {0}: {1}", xT, result);

        // Вывод описания
        Console.WriteLine("Это значение было вычислено с использованием схемы Эйткена и представляет собой оценку функции в заданной точке, основанную на известных значениях функции в ближайших точках.");
    }

    // Функция для вычисления приближенного значения функции с помощью схемы Эйткена
    static double AitkenInterpolation(double[] x, double[] y, double xT)
    {
        double result = 0;

        // Разделенные разности первого порядка
        double[] deltaY1 = new double[y.Length - 1];
        for (int i = 0; i < deltaY1.Length; i++)
        {
            deltaY1[i] = y[i + 1] - y[i];
        }

        // Разность между xT и точками x
        double deltaXT = xT - x[0];

        // Вычисление приближенного значения функции
        result = y[0] + deltaXT / (x[1] - x[0]) * deltaY1[0];

        return result;
    }
}
