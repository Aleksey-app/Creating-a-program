using System;
class Program
{
    // Функция меню
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите задание для расчёта:");
            Console.WriteLine("1. Класс A схемы Эйткена");
            Console.WriteLine("2. Класс B интерполяционная формула Ньютона вперед, назад");
            Console.WriteLine("3. Класс C решить систему алгебраических уровнений методом простых итераций");
            Console.WriteLine("4. Класс D решение однородного уравнения гиперболтческого типа Setka&Progonka");
            Console.WriteLine("5. Выйти");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ошибка: введите число от 1 до 5");
                continue;
            }

            if (choice == 5)
            {
                Console.WriteLine("Программа завершена.");
                break;
            }

            switch (choice)
            {
                case 1:
                    RunClassA();
                    break;
                case 2:
                    RunClassB();
                    break;
                case 3:
                    RunClassC();
                    break;
                case 4:
                    RunClassD();
                    break;
                default:
                    Console.WriteLine("Ошибка: введите число от 1 до 5");
                    break;
            }
        }
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
    // Функция для вычисления приближенного значения функции по интерполяционной формуле Ньютона (интерполяция вперёд)
    static double NewtonForwardInterpolation(double[] x, double[] y, double xT)
    {
        double result = 0;

        // Разделенные разности
        double[] deltaY = new double[y.Length - 1];
        for (int i = 0; i < deltaY.Length; i++)
        {
            deltaY[i] = y[i + 1] - y[i];
        }

        // Сумма для интерполяции вперёд
        double sum = deltaY[0];
        double term = 1;
        for (int i = 1; i < y.Length - 1; i++)
        {
            term *= (xT - x[i - 1]) / (i);
            sum += term * deltaY[i];
        }

        result = y[0] + sum;

        return result;
    }
    // Функция для вычисления приближенного значения функции по интерполяционной формуле Ньютона (интерполяция назад)
    static double NewtonBackwardInterpolation(double[] x, double[] y, double xT)
    {
        double result = 0;

        // Разделенные разности
        double[] deltaY = new double[y.Length - 1];
        for (int i = 0; i < deltaY.Length; i++)
        {
            deltaY[i] = y[i + 1] - y[i];
        }

        // Сумма для интерполяции назад
        double sum = deltaY[y.Length - 2];
        double term = 1;
        for (int i = 1; i < y.Length - 1; i++)
        {
            term *= (xT - x[x.Length - i]) / (i);
            sum += term * deltaY[y.Length - i - 1];
        }

        result = y[y.Length - 1] + sum;

        return result;
    }
    // Функция для решения системы линейных уравнений методом простых итераций
    static double[] SimpleIterationMethod(double[,] A, double[] b, double[] x0, double e)
    {
        int n = b.Length;
        double[] x = new double[n];
        double[] xNew = new double[n];
        double[,] T = new double[n, n];
        double[] c = new double[n];
        double error = e + 1;  // начальное значение ошибки, чтобы войти в цикл

        while (error > e)
        {
            // Вычисление матрицы T и вектора c
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        T[i, j] = -A[i, j] / A[i, i];
                    }
                    sum += T[i, j] * x0[j];
                }
                c[i] = b[i] / A[i, i];
                xNew[i] = sum + c[i];
            }

            // Проверка на сходимость
            error = 0;
            for (int i = 0; i < n; i++)
            {
                error += Math.Abs(xNew[i] - x0[i]);
            }

            // Обновление значений x0
            Array.Copy(xNew, x0, n);
        }

        return x0;
    }
    // функция метод прогонки для решения системы линейных алгебрарических уровнений
    static void ProgonkaMethod(double[,] grid, double[,] ut, double h, int Nx, int Nt)
    {
        double[] alpha = new double[Nx];
        double[] beta = new double[Nx];
        double[] gamma = new double[Nx];

        // Применяем метод прогонки для каждого временного слоя
        for (int j = 1; j < Nt; j++)
        {
            // Вычисляем коэффициенты для метода прогонки
            for (int i = 1; i < Nx - 1; i++)
            {
                double a = -1 / h / h;
                double b = 2 / h / h;
                double c = -1 / h / h;
                double d = ut[i, j - 1];

                alpha[i] = b - a * gamma[i - 1];
                beta[i] = c / alpha[i];
                gamma[i] = -a / alpha[i];
                grid[i, j] = (d - a * grid[i - 1, j - 1]) / alpha[i];
            }

            // Обратный ход метода прогонки
            for (int i = Nx - 2; i > 0; i--)
            {
                grid[i, j] = grid[i, j] - beta[i] * grid[i + 1, j];
            }
        }
    }
    static void RunClassA()
    {
            // Заданные значения
            double[] x = { 9.95, 10.25 };  // x_i
            double[] y = { 15.2368, 18.1109 };  // y_i
            double xT = 10.777;  // xT
        try
        {
            // Вычисление приближенного значения функции с помощью схемы Эйткена
            double result = AitkenInterpolation(x, y, xT);
            Console.WriteLine("Приближенное значение функции f(xT) при xT = {0}: {1}", xT, result);

            // Вывод описания
            Console.WriteLine("Это значение было вычислено с использованием схемы Эйткена и представляет собой оценку функции в заданной точке, основанную на известных значениях функции в ближайших точках.");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
    static void RunClassB()
    {
        // Заданные значения
        double[] x = { 1.25, 1.26, 1.27 };  // x_i
        double[] y = { 13.4776, 13.8759, 14.2367 };  // y_i
        double xT = 1.237;  // xT

        try
        {
            // Вычисление приближенного значения функции с помощью интерполяции вперёд
            double forwardResult = NewtonForwardInterpolation(x, y, xT);
            Console.WriteLine("Приближенное значение функции f(xT) при xT = {0} (интерполяция вперёд): {1}", xT, forwardResult);

            // Вычисление приближенного значения функции с помощью интерполяции назад
            double backwardResult = NewtonBackwardInterpolation(x, y, xT);
            Console.WriteLine("Приближенное значение функции f(xT) при xT = {0} (интерполяция назад): {1}", xT, backwardResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
    static void RunClassC()
    {
        // Заданные значения
        double[,] A = {
            { 0.77, 0.14, -0.06, 0.12 },
            { -0.12, 1.00, -0.32, 0.18 },
            { -0.08, 0.12, 0.77, -0.32 },
            { -0.25, -0.22, -0.14, 1.00 }
        };
        double[] b = { 1.2100, -0.7200, -0.5800, 1.00 };
        double[] x0 = new double[b.Length];
        double e = 1e-7;
        try
        {
            // Решение системы уравнений методом простых итераций
            double[] solution = SimpleIterationMethod(A, b, x0, e);

            // Вывод результата
            Console.WriteLine("Решение системы уравнений методом простых итераций:");
            for (int i = 0; i < solution.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {solution[i]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
    static void RunClassD()
    {
        double h = 0.1;
        int Nx = (int)(1 / h) + 1; // Количество узлов по x
        int Nt = (int)(1 / h) + 1; // Количество узлов по t

        // Создаем массивы для сетки и значений функций
        double[,] grid = new double[Nx, Nt];
        double[,] ut = new double[Nx, Nt]; // Значения производной по времени
        double[] x_values = new double[Nx]; // Значения x
        double[] t_values = new double[Nt]; // Значения t

        // Заполняем значения x и t
        for (int i = 0; i < Nx; i++)
        {
            x_values[i] = i * h;
        }
        for (int j = 0; j < Nt; j++)
        {
            t_values[j] = j * h;
        }
        try
        {
            // Вычисляем начальное условие f0(x) и производную по времени ut(x,0)
            for (int i = 0; i < Nx; i++)
            {
                double x = x_values[i];
                double f0 = 0.5 * Math.Pow(x + 1, 2);
                double ut0 = (x + 0.5) * Math.Cos(Math.PI * x);
                grid[i, 0] = f0;
                ut[i, 0] = ut0;
            }

            // Заполняем граничные условия w1(t) и w2(t)
            for (int j = 0; j < Nt; j++)
            {
                double t = t_values[j];
                double w1 = 0.5;
                double w2 = 2 - 3 * t;
                grid[0, j] = w1;
                grid[Nx - 1, j] = w2;
            }

            // Выводим значения сетки и начальных условий в табличной форме
            Console.WriteLine("Табличная форма сетки и начальных условий:");
            Console.WriteLine("x\t|\tt\t|\tu(x, t)\t|\tut(x, t)");
            Console.WriteLine("---------------------------------------------");
            for (int j = 0; j < Nt; j++)
            {
                for (int i = 0; i < Nx; i++)
                {
                    Console.Write($"{x_values[i]:F3}\t|\t{t_values[j]:F3}\t|\t{grid[i, j]:F5}\t|\t{ut[i, j]:F5}\n");
                }
            }

            // Применяем метод прогонки для решения системы
            ProgonkaMethod(grid, ut, h, Nx, Nt);

            // Выводим результаты решения
            Console.WriteLine("\nРезультаты решения:");
            Console.WriteLine("x\t|\tt\t|\tu(x, t)");
            Console.WriteLine("---------------------------------------------");
            for (int j = 0; j < Nt; j++)
            {
                for (int i = 0; i < Nx; i++)
                {
                    Console.Write($"{x_values[i]:F3}\t|\t{t_values[j]:F3}\t|\t{grid[i, j]:F5}\n");
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}