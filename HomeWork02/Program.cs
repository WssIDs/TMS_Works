namespace HomeWork02
{
    public static class Program
    {
        public static void Main()
        {
            // Пока не нажали Q или q просим ввод
            while (true)
            {
                Console.WriteLine("Введите размерность матрицы (Выход q или Q)");

                if (!InputValue(out var m, "m = "))
                {
                    // Выход
                    break;
                }

                if (!InputValue(out var n, "n = "))
                {
                    // Выход
                    break;
                }

                if (m <= 0 || n <= 0)
                {
                    Console.WriteLine("Размерность матрицы должна быть больше 0");
                    continue;
                }

                var matrix = new int[m, n];

                matrix.Init();
                matrix.Print();

                var bFunctionMenu = false;

                // Пока не выбрано меню назад
                while (!bFunctionMenu)
                {
                    Console.WriteLine("--- Меню ---");
                    Console.WriteLine("1 \tНайти количество положительных/отрицательных чисел в матрице");
                    Console.WriteLine("2 \tСортировка элементов матрицы построчно (по возрастанию)");
                    Console.WriteLine("3 \tСортировка элементов матрицы построчно (по убыванию)");
                    Console.WriteLine("4 \tИнверсия элементов матрицы построчно");
                    Console.WriteLine("<0 \tНазад");

                    int.TryParse(Console.ReadLine(), out var menuPosition);

                    switch (menuPosition)
                    {
                        case 1:
                        {
                            matrix.PrintCountPositiveAndNegative(out var countPositive, out var countNegative);
                            Console.WriteLine($"В матрице количество положительных чисел = {countPositive} , отрицательных = {countNegative}");
                            break;
                        }
                        case 2:
                        {
                            matrix.SortRows();
                            matrix.Print();
                            break;
                        }
                        case 3:
                        {
                            matrix.SortRows(false);
                            matrix.Print();
                            break;
                        }
                        case 4:
                        {
                            matrix.InverseRows();
                            matrix.Print();
                            break;
                        }
                        case < 0:
                        {
                            bFunctionMenu = true;
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Выберите корректный пункт меню или число меньше 0 для выхода");
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ввод числа
        /// </summary>
        /// <param name="m">Введенное число</param>
        /// <param name="message">Сообщение при вводе</param>
        /// <returns>false - введен Q или q</returns>
        private static bool InputValue(out int m, string message)
        {
            Console.Write(message);

            var inputStr = Console.ReadLine();

            int.TryParse(inputStr, out m);

            var result = inputStr is not ("Q" or "q");

            return result;
        }

        /// <summary>
        /// Заполнение элементов матрицы
        /// </summary>
        /// <param name="matrix"></param>
        private static void Init(this int[,] matrix)
        {
            for (var i = 0;
                 i < matrix.GetLength(0);
                 i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Введите a[{i},{j}] = ");
                    int.TryParse(Console.ReadLine(), out var number);

                    matrix[i, j] = number;
                }
            }
        }

        /// <summary>
        /// Вывод элементов матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        private static void Print(this int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("|".PadRight(3, ' '));

                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],-5}");
                }

                Console.WriteLine("|");
            }
        }

        /// <summary>
        /// вывод в консоль количество положительных и отрицательных элементов матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="countPositive"></param>
        /// <param name="countNegative"></param>
        private static void PrintCountPositiveAndNegative(this int[,] matrix, out int countPositive, out int countNegative)
        {
            countPositive = 0;
            countNegative = 0;

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    switch (matrix[i, j])
                    {
                        case > 0:
                            countPositive++;
                            break;
                        case < 0:
                            countNegative++;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Сортировка элементов матрицы построчно
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="ascending">true - по возрастанию, false - по убыванию</param>
        private static void SortRows(this int[,] matrix, bool ascending = true)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                var n = matrix.GetLength(1);

                for (var k = 0; k < n; k++)
                {
                    for (var j = 0; j < n-1; j++)
                    {
                        var bNeedReplace = ascending ? matrix[i, j] > matrix[i, j + 1] : matrix[i, j] < matrix[i, j + 1];

                        if (bNeedReplace)
                        {
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Инверсия элементов матрицы построчно
        /// </summary>
        /// <param name="matrix">Матрица</param>
        private static void InverseRows(this int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                var n = matrix.GetLength(1);
                var lastStep = n / 2;

                for (var j = 0; j < lastStep; j++)
                {
                    // Получение позиции противоположного элемента
                    var opposite = n - 1 - j;
                    (matrix[i, j], matrix[i, opposite]) = (matrix[i, opposite], matrix[i, j]);
                }
            }
        }
    }
}